using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;
using BDInfoSummary;

Console.WriteLine("Hello, Browser!");

public partial class MyClass
{
    [JSExport]
    internal static string Greeting()
    {
        var text = $"Hello, World! Greetings from {GetHRef()}";
        Console.WriteLine(text);
        return text;
    }

    [JSImport("window.location.href", "main.js")]
    internal static partial string GetHRef();
    
    [JSImport("getTestValue", "main.js")]
    internal static partial string GetTestValue();

    [JSImport("readFile", "main.js")]
    [return: JSMarshalAs<JSType.Promise<JSType.Any>>()]
    internal static partial Task<object> ReadFile(int fileID, double offset, double length);

    [JSExport]
    [return: JSMarshalAs<JSType.Promise<JSType.String>>()]
    internal static async Task<string> SetFiles([JSMarshalAs<JSType.String>] string fileTreeJson) {
        Console.WriteLine("SetFiles called from JS, result: " + fileTreeJson);
        var fileTree = JsonSerializer.Deserialize(fileTreeJson, typeof(WebFile[]), SourceGenerationContext.Default) as WebFile[];

        // await ReadLargeFile(fileTree);
        var dir = new WebDirectoryInfo(fileTree, fileTree[0]);
        var summary = new Summary(dir);
        await summary.InitBDRom();
        Console.WriteLine(summary.DiscSummary);
        await summary.StartScan();
        Console.WriteLine(summary.Report.ReportText);

        var jsonString = JsonSerializer.Serialize(fileTree, typeof(WebFile[]), SourceGenerationContext.Default);
        await Task.Delay(100);
        return jsonString;
    }

    static IEnumerable<WebFile> Flatten(WebFile root)
    {
        yield return root;

        if (root.children != null)
        {
            foreach (var child in root.children)
            {
                foreach (var descendant in Flatten(child))
                {
                    yield return descendant;
                }
            }
        }
    }

    static async Task ReadLargeFile(WebFile[] fs) {
        // get the file with the largest size
        var largestFile = Flatten(fs[0]).OrderByDescending(f => f.size).FirstOrDefault();
        Console.WriteLine($"Largest file: {largestFile.name} ({largestFile.size} bytes)");

        // Read all bytes from the file in chunks of 10 megabytes, until reaching the end of the file size.
        double readBytes = 0;
        double megabytes = 150;
        double chunkSize = 1024 * 1024 * megabytes;
        double offset = 0;
        var startTime = DateTime.Now;
        double iters = 0;
        while (readBytes < largestFile.size) {
            iters++;
            var readResp = await ReadFile(largestFile.fileID, offset, chunkSize);
            var respBytes = (byte[])readResp;
            readBytes += respBytes.Length;
            offset += respBytes.Length;
            // Log progress
            var timeElapsed = DateTime.Now - startTime;
            var percent = readBytes / largestFile.size * 100;
            var itersRemaining = (largestFile.size - readBytes) / chunkSize;
            var timeEstimated = timeElapsed / iters * itersRemaining;
            Console.WriteLine($"Read {readBytes}/{largestFile.size},\t{percent:0.00}%\tElapsed: {timeElapsed:mm\\:ss\\.ff},\tRemaining: {timeEstimated:mm\\:ss\\.ff}");
        }
        
    }
}

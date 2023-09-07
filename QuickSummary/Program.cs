// See https://aka.ms/new-console-template for more information

using System;
using BDInfoIO = BDInfoLib.BDROM.IO;

namespace QuickSummary;

class Program
{
    public static void Main(string[] args)
    {
        var folder = args[0];
        Console.Error.WriteLine($"Opening {folder}");
        
        var fileInfo = BDInfoIO.FileInfo.FromFullName(folder);
        var dir = BDInfoIO.DirectoryInfo.FromDirectoryName(fileInfo.FullName);
        
        var summary = new Summary(dir);
        summary.InitBDRom();
        Console.Error.WriteLine(summary.DiscSummary);
        summary.StartScan();
        Console.WriteLine(summary.Report.ReportText);
    }
}

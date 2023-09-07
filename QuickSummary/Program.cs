// See https://aka.ms/new-console-template for more information

using System;

namespace QuickSummary;

class Program
{
    public static void Main(string[] args)
    {
        var folder = args[0];
        Console.WriteLine($"Opening {folder}");
        var summary = new Summary(folder);
        summary.Rescan();
        summary.StartScan();
        Console.WriteLine(summary.Report.ReportText);
    }
}

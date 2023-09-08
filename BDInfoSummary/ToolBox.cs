using System;
using BDInfoLib.BDROM;

namespace BDInfoSummary;

public class ToolBox
{
    public static string FormatFileSize(double fSize, bool formatHR = false)
    {
        if (fSize <= 0) return "0";
        var units = new[] { "B", "KB", "MB", "GB", "TB", "PB", "EB" };

        var digitGroups = 0;
        if (formatHR)
            digitGroups = (int)(Math.Log10(fSize) / Math.Log10(1024));

        return $"{fSize / Math.Pow(1024, digitGroups):N2} {units[digitGroups]}";
    }
    
    public static int ComparePlaylistFiles(TSPlaylistFile x, TSPlaylistFile y)
    {
        if (x == null && y == null)
        {
            return 0;
        }

        if (x == null && y != null)
        {
            return 1;
        }

        if (x != null && y == null)
        {
            return -1;
        }

        if (x!.TotalLength > y!.TotalLength)
        {
            return -1;
        }

        if (y.TotalLength > x.TotalLength)
        {
            return 1;
        }

        return string.CompareOrdinal(x.Name, y.Name);
    }
    
    public static string GetApplicationVersion()
    {
        // var version = Assembly.GetExecutingAssembly().GetName().Version;
        var version = "0.8.0.1";

        if (version != null)
#if DEBUG || BETA
            return $"{version}b";
#else
            return $"{version}";
#endif

        return string.Empty;
    }
}
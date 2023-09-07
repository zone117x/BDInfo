using System;
using System.Collections.Generic;
using BDInfoLib.BDROM;

namespace QuickSummary;

public class BDInfoFileBase
{
    public TimeSpan Length { get; set; } = TimeSpan.Zero;
    public ulong EstimatedSize { get; set; } = 0;
    public ulong TotalSize { get; set; } = 0;
}

public class PlayListFileItem : BDInfoFileBase
{
    public string PlayListName { get; set; } = string.Empty;

    public int Chapters { get; set; }

    public int Group { get; set; } = 0;

    public bool IsChecked { get; set; } = false;
}

public class StreamClipItem : BDInfoFileBase
{
    public string ClipName { get; set; } = string.Empty;
    public int Index { get; set; } = 0;
    public int Angle { get; set; } = 0;
}

public class StreamFileItem
{
    public string Codec { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public long BitRate { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public int PID { get; set; } = 0;
}

public class ScanBDROMState
{    
    public event Action OnUpdate;
    public void RaiseOnUpdate() => OnUpdate?.Invoke();
    
    private long _totalBytes;
    public long TotalBytes
    {
        get => _totalBytes;
        set
        {
            _totalBytes = value;
            RaiseOnUpdate();
        }
    }

    private long _finishedBytes;
    public long FinishedBytes
    {
        get => _finishedBytes;
        set
        {
            _finishedBytes = value;
            RaiseOnUpdate();
        }
    }
    
    public DateTime TimeStarted = DateTime.Now;
    public TSStreamFile StreamFile;
    public Dictionary<string, List<TSPlaylistFile>> PlaylistMap = new();
    public Exception Exception;
}

public class ScanBDROMResult
{
    public Exception ScanException = new("Scan has not been run.");
    public Dictionary<string, Exception> FileExceptions = new();
}
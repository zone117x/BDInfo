using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BDInfoLib;
using BDInfoLib.BDROM;

namespace QuickSummary;

public class Summary
{
    string Folder;
    bool IsImage;
    bool IsPopupVisible;
    List<PlayListFileItem> PlaylistFiles = new();
    List<StreamClipItem> StreamFiles = new();
    List<StreamFileItem> Streams = new();
    BDROM _bdRom;
    string DiscSummary = string.Empty;
    int SelectedPlaylistIndex;
    double ScanProgress = 0;
    ScanBDROMResult _scanResult = new();
    TSStreamFile _streamFile;
    PlayListFileItem SelectedPlaylist = new();
    string ProcessedFile = string.Empty;
    TimeSpan ElapsedTime = TimeSpan.Zero;
    TimeSpan RemainingTime = TimeSpan.Zero;
    
    public Report Report { get; set; }
    
    public Summary(string folder)
    {
        this.Folder = folder;
    }
    
    public void Rescan()
    {
        if (string.IsNullOrEmpty(Folder))
        {
            throw new Exception("Folder not specified");
        }

        var attr = File.GetAttributes(Folder);
        IsImage = attr.HasFlag(FileAttributes.Normal) || attr.HasFlag(FileAttributes.Archive);

        SetPath(Folder);
    }

    void SetPath(string path)
    {
        if (IsImage)
            Folder = path;

        InitBDRom(path);
    }

    void InitBDRom(string path)
    {
        IsPopupVisible = true;

        PlaylistFiles.Clear();
        StreamFiles.Clear();
        Streams.Clear();

        InitBDROMWork(path);
        InitBDROMCompleted();
    }

    void InitBDROMWork(string path)
    {
        try
        {
            _bdRom = new BDROM(path);
            _bdRom.PlaylistFileScanError += (file, exception) =>
            {
                Console.Error.WriteLine($"PlaylistFileScanError: {exception}");
                return true;
            };
            _bdRom.StreamFileScanError += (file, exception) =>
            {
                Console.Error.WriteLine($"StreamFileScanError: {exception}");
                return true;
            };
            _bdRom.StreamClipFileScanError += (file, exception) =>
            {
                Console.Error.WriteLine($"StreamClipFileScanError: {exception}");
                return true;
            };
            _bdRom.Scan();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"BDROM scan error: {ex}");
        }
    }
    
    void InitBDROMCompleted()
    {
        IsPopupVisible = false;

        DiscSummary = string.Empty;

        if (!string.IsNullOrEmpty(_bdRom.DiscTitle))
        {
            DiscSummary += $"Disc Title: {_bdRom.DiscTitle}\r\n";
        }

        if (!IsImage)
            Folder = _bdRom.DirectoryRoot?.FullName;

        if (_bdRom.DirectoryBDMV != null)
        {
            DiscSummary += $"Detected BDMV Folder: {_bdRom.DirectoryBDMV.FullName} (Disc Label: {_bdRom.VolumeLabel})\r\n";
            if (IsImage)
                DiscSummary += $"ISO Image: {Folder}\r\n";
        }

        var features = new List<string>();
        if (_bdRom.IsUHD)
        {
            features.Add("Ultra HD");
        }
        if (_bdRom.Is50Hz)
        {
            features.Add("50Hz Content");
        }
        if (_bdRom.IsBDPlus)
        {
            features.Add("BD+ Copy Protection");
        }
        if (_bdRom.IsBDJava)
        {
            features.Add("BD-Java");
        }
        if (_bdRom.Is3D)
        {
            features.Add("Blu-ray 3D");
        }
        if (_bdRom.IsDBOX)
        {
            features.Add("D-BOX Motion Code");
        }
        if (_bdRom.IsPSP)
        {
            features.Add("PSP Digital Copy");
        }
        if (features.Count > 0)
        {
            DiscSummary += $"Detected Features: {string.Join(", ", features.ToArray())}\r\n";
        }

        DiscSummary += $"Disc Size: {_bdRom.Size:N0} bytes ({ToolBox.FormatFileSize(_bdRom.Size, true)})\r\n";

        LoadPlaylists();
    }
    
    void LoadPlaylists()
    {
        if (_bdRom == null) return;

        var hasHiddenTracks = false;

        var groups = new List<List<TSPlaylistFile>>();

        var sortedPlaylistFiles = new TSPlaylistFile[_bdRom.PlaylistFiles.Count];
        _bdRom.PlaylistFiles.Values.CopyTo(sortedPlaylistFiles, 0);
        Array.Sort(sortedPlaylistFiles, ToolBox.ComparePlaylistFiles);

        foreach (var playlist in sortedPlaylistFiles)
        {
            if (!playlist.IsValid) continue;

            var matchingGroupIndex = 0;
            for (var groupIndex = 0; groupIndex < groups.Count; groupIndex++)
            {
                var group = groups[groupIndex];
                foreach (var playlist2 in group.Where(playlist2 => playlist2.IsValid))
                {
                    foreach (var clip1 in playlist.StreamClips)
                    {
                        if (playlist2.StreamClips.Any(clip2 => clip1?.Name == clip2?.Name))
                        {
                            matchingGroupIndex = groupIndex + 1;
                        }

                        if (matchingGroupIndex > 0) break;
                    }
                    if (matchingGroupIndex > 0) break;
                }
                if (matchingGroupIndex > 0) break;
            }
            if (matchingGroupIndex > 0)
            {
                groups[matchingGroupIndex - 1].Add(playlist);
            }
            else
            {
                groups.Add(new List<TSPlaylistFile> { playlist });
            }
        }

        for (var groupIndex = 0; groupIndex < groups.Count; groupIndex++)
        {
            var group = groups[groupIndex];
            group.Sort(ToolBox.ComparePlaylistFiles);

            foreach (var playlist in group.Where(playlist => playlist.IsValid))
            {
                if (playlist.HasHiddenTracks)
                {
                    hasHiddenTracks = true;
                }
                var playListFile = new PlayListFileItem
                {
                    Group = groupIndex + 1,
                    PlayListName = playlist.Name,
                    Length = new TimeSpan((long)(playlist.TotalLength * 10000000)),
                    Chapters = playlist.Chapters is { Count: > 1 } ? playlist.Chapters.Count : 0,
                    EstimatedSize = BDInfoLibSettings.EnableSSIF && playlist.InterleavedFileSize > 0
                        ? playlist.InterleavedFileSize
                        : playlist.FileSize,
                    TotalSize = playlist.TotalAngleSize
                };

                PlaylistFiles.Add(playListFile);
            }
        }

        if (hasHiddenTracks)
        {
            DiscSummary += "(*) Some playlists on this disc have hidden tracks. These tracks are marked with an asterisk.";
        }

        if (PlaylistFiles.Count > 0)
        {
            SelectedPlaylistIndex = 0;
        }
    }
    
    public void StartScan()
    {
        if (_bdRom == null) throw new Exception("bdrom is null");
        
        ScanProgress = 0;

        var streamFiles = new List<TSStreamFile>();
        if (!PlaylistFiles.Any(item => item.IsChecked))
        {
            streamFiles.AddRange(_bdRom.StreamFiles.Values.Where(streamFile => streamFile != null));
        }
        else
        {
            foreach (var playListFile in PlaylistFiles.Where(item => item.IsChecked))
            {
                var playListName = playListFile.PlayListName;
                if (playListName == null || !_bdRom.PlaylistFiles.ContainsKey(playListName)) continue;

                var playList = _bdRom.PlaylistFiles[playListName];
                foreach (var clip in playList.StreamClips.Where(clip => clip is { StreamFile: { } }
                                                                        && !streamFiles.Contains(clip.StreamFile)))
                {
                    streamFiles.Add(clip.StreamFile);
                }
            }
        }

        ScanBDROMWork(streamFiles);
        ScanBDROMCompleted();
    }

    void ScanBDROMWork(List<TSStreamFile> streamFiles)
    {
        var scanState = new ScanBDROMState();
        var lastProgressOutput = DateTime.Now;
        scanState.OnUpdate += () =>
        {
            if (DateTime.Now - lastProgressOutput >= TimeSpan.FromMilliseconds(500))
            {
                lastProgressOutput = DateTime.Now;
                ScanBDROMProgress(scanState);
            }
        };
        
        foreach (var streamFile in streamFiles!)
        {
            var streamFileName = streamFile.Name;
            if (streamFileName == null) continue;

            if (BDInfoLibSettings.EnableSSIF && streamFile.InterleavedFile is { FileInfo: { } })
            {
                scanState.TotalBytes += streamFile.InterleavedFile.FileInfo.Length;
            }
            else
            {
                if (streamFile.FileInfo != null) 
                    scanState.TotalBytes += streamFile.FileInfo.Length;
            }

            if (!scanState.PlaylistMap.ContainsKey(streamFileName))
            {
                scanState.PlaylistMap[streamFileName] = new List<TSPlaylistFile>();
            }

            if (_bdRom is not { PlaylistFiles.Values: { } }) continue;

            foreach (var playlist in _bdRom.PlaylistFiles.Values)
            {
                playlist.ClearBitrates();

                foreach (var clip in playlist.StreamClips.Where(clip => clip.Name == streamFileName)
                             .Where(_ => !scanState.PlaylistMap[streamFileName].Contains(playlist)))
                {
                    scanState.PlaylistMap[streamFileName].Add(playlist);
                }
            }
        }

        foreach (var streamFile in streamFiles)
        {
            scanState.StreamFile = streamFile;

            ScanBDROMThread(scanState);

            if (streamFile.FileInfo != null)
                scanState.FinishedBytes += streamFile.FileInfo.Length;
            if (scanState.Exception != null)
            {
                _scanResult.FileExceptions[streamFile.Name] = scanState.Exception;
            }
        }
        _scanResult.ScanException = null;
        ScanBDROMProgress(scanState);
    }
    
    void ScanBDROMProgress(ScanBDROMState scanState)
    {
        try
        {
            var finishedBytes = scanState.FinishedBytes;
            if (scanState.StreamFile != null)
            {
                finishedBytes += scanState.StreamFile.Size;
            }

            var progress = ((double)finishedBytes / scanState.TotalBytes);
            if (progress < 0) progress = 0;
            if (progress > 1) progress = 1;
            ScanProgress = progress * 100;

            ElapsedTime = DateTime.Now.Subtract(scanState.TimeStarted);
            RemainingTime = progress is > 0 and < 100 
                ? new TimeSpan((long)(ElapsedTime.Ticks / progress) - ElapsedTime.Ticks) 
                : new TimeSpan(0);
            
            Console.Error.WriteLine($"Scan progress: {ScanProgress:0.00}%\tElapsed: {ElapsedTime:mm\\:ss\\.ff}\tRemaining: {RemainingTime:mm\\:ss\\.ff}");
        }
        catch (Exception ex)
        {
            // ignore ??
            Console.Error.WriteLine($"Error handling ScanBDROMProgress: {ex}");
        }
    }
    
    void ScanBDROMThread(ScanBDROMState scanState)
    {
        try
        {
            _streamFile = scanState.StreamFile;
            _streamFile.AbortScan = false;
            var playlists = scanState.PlaylistMap[_streamFile.Name];
            _streamFile.Scan(playlists, true, scanState.RaiseOnUpdate);
        }
        catch (Exception ex)
        {
            scanState.Exception = ex;
        }
        finally
        {
            _streamFile = null;
        }
    }
    
    void ScanBDROMCompleted()
    {
        UpdateSubtitleChapterCount();
        UpdatePlaylistBitrates();

        ScanProgress = 100;
        ProcessedFile = "Scan complete";

        ElapsedTime = TimeSpan.Zero;
        RemainingTime = TimeSpan.Zero;

        if (_scanResult.ScanException != null)
        {
            throw _scanResult.ScanException;
        }

        GenerateReport();
    }

    void UpdateSubtitleChapterCount()
    {
        if (_bdRom == null) return;

        foreach (var item in PlaylistFiles)
        {
            var playlistName = item.PlayListName;
            if (playlistName == null || !_bdRom.PlaylistFiles.ContainsKey(playlistName)) continue;

            var playlist = _bdRom.PlaylistFiles[playlistName];

            foreach (var stream in playlist.Streams.Values.Where(stream => stream is { IsGraphicsStream: true }))
            {
                ((TSGraphicsStream)stream).ForcedCaptions = 0;
                ((TSGraphicsStream)stream).Captions = 0;
            }

            foreach (var clip in playlist.StreamClips)
            {
                if (clip?.StreamFile?.Streams.Values == null) continue;

                foreach (var stream in clip.StreamFile.Streams.Values.Where(stream => stream is { IsGraphicsStream: true }))
                {
                    if (!playlist.Streams.ContainsKey(stream.PID)) continue;

                    var plStream = (TSGraphicsStream)playlist.Streams[stream.PID];
                    var clipStream = (TSGraphicsStream)stream;

                    plStream.ForcedCaptions += clipStream.ForcedCaptions;
                    plStream.Captions += clipStream.Captions;

                    if (plStream.Width == 0 && clipStream.Width > 0)
                        plStream.Width = clipStream.Width;
                    if (plStream.Height == 0 && clipStream.Height > 0)
                        plStream.Height = clipStream.Height;
                }
            }
        }
    }

    void UpdatePlaylistBitrates()
    {
        if (_bdRom == null) return;

        foreach (var item in PlaylistFiles)
        {
            var playlistName = item.PlayListName;
            if (playlistName == null || !_bdRom.PlaylistFiles.ContainsKey(playlistName)) continue;

            var playlist = _bdRom.PlaylistFiles[playlistName];
            item.TotalSize = playlist.TotalAngleSize;
        }

        if (SelectedPlaylist == null)
        {
            return;
        }

        var selectedPlaylistName = SelectedPlaylist.PlayListName;
        TSPlaylistFile selectedPlaylistFile = null;
        if (selectedPlaylistName != null && _bdRom.PlaylistFiles.ContainsKey(selectedPlaylistName))
        {
            selectedPlaylistFile = _bdRom.PlaylistFiles[selectedPlaylistName];
        }
        if (selectedPlaylistFile == null)
        {
            return;
        }

        for (var i = 0; i < StreamFiles.Count; i++)
        {
            var file = StreamFiles[i];

            if (selectedPlaylistFile.StreamClips.Count <= i ||
                selectedPlaylistFile.StreamClips[i]?.Name != file.ClipName) continue;
            file.TotalSize = selectedPlaylistFile.StreamClips[i].PacketSize;
        }

        for (var i = 0; i < Streams.Count; i++)
        {
            var streamItem = Streams[i];
            if (i >= selectedPlaylistFile.SortedStreams.Count ||
                selectedPlaylistFile.SortedStreams[i].PID != streamItem.PID) continue;

            var stream = selectedPlaylistFile.SortedStreams[i];

            streamItem.BitRate = stream switch
            {
                { AngleIndex: > 0 } => (int)Math.Round((double)stream.ActiveBitRate / 1000),
                { AngleIndex: <= 0 } => (int)Math.Round((double)stream.BitRate / 1000),
                _ => 0
            };
            streamItem.Description = stream?.Description;
        }
    }

    private void GenerateReport()
    {
        List<TSPlaylistFile> playlists = new();

        var source = PlaylistFiles.Any(item => item.IsChecked)
            ? PlaylistFiles.Where(item => item.IsChecked)
            : PlaylistFiles;

        foreach (var item in source)
        {
            if (_bdRom.PlaylistFiles.TryGetValue(item.PlayListName, out var value))
                playlists.Add(value);
        }

        Report = new Report(_bdRom, playlists, _scanResult);
    }
}

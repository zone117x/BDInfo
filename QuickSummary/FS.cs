using System;
using System.Threading.Tasks;
using SearchOption = System.IO.SearchOption;
using IDirectoryInfo = BDInfoLib.BDROM.IO.IDirectoryInfo;
using IFileInfo = BDInfoLib.BDROM.IO.IFileInfo;
using IStream = BDInfoLib.BDROM.IO.IStream;

namespace QuickSummary;

public class NativeFS
{
    public class DirectoryInfo : IDirectoryInfo
    {
        private readonly System.IO.DirectoryInfo _impl;
        public string Name => _impl.Name;

        public string FullName => _impl.FullName;

        public IDirectoryInfo Parent => _impl.Parent != null ? new DirectoryInfo(_impl.Parent) : null;

        public DirectoryInfo(string path) => _impl = new System.IO.DirectoryInfo(path);

        public DirectoryInfo(System.IO.DirectoryInfo impl) => _impl = impl;

        public IDirectoryInfo[] GetDirectories()
        {
            return Array.ConvertAll(_impl.GetDirectories(), x => new DirectoryInfo(x));
        }

        public IFileInfo[] GetFiles()
        {
            return Array.ConvertAll(_impl.GetFiles(), x => new FileInfo(x));
        }

        public IFileInfo[] GetFiles(string searchPattern)
        {
            return Array.ConvertAll(_impl.GetFiles(searchPattern), x => new FileInfo(x));
        }

        public IFileInfo[] GetFiles(string searchPattern, SearchOption searchOption)
        {
            return Array.ConvertAll(_impl.GetFiles(searchPattern, searchOption), x => new FileInfo(x));
        }

        public string GetVolumeLabel()
        {
            try
            {
                var driveInfo = new System.IO.DriveInfo(_impl.FullName);
                return _impl.Root.FullName == _impl.FullName ? driveInfo.VolumeLabel : Name;
            }
            catch (Exception)
            {
                return Name;
            }
        }
        
        public static IDirectoryInfo FromDirectoryName(string path)
        {
            return new DirectoryInfo(path);
        }
    }

    public class FileInfo : IFileInfo
    {
        private readonly System.IO.FileInfo _impl;
        
        public FileInfo(System.IO.FileInfo impl) => _impl = impl;
        
        public string Name => _impl.Name;

        public string FullName => _impl.FullName;

        public string Extension => _impl.Extension;

        public long Length => _impl.Length;

        public bool IsDir => _impl.Attributes.HasFlag(System.IO.FileAttributes.Directory);
        
        public IStream OpenRead() => new Stream(_impl.OpenRead());

        public async Task<string> ReadAllText()
        {
            using var streamReader = _impl.OpenText();
            return await streamReader.ReadToEndAsync();
        }
    }
    
    public class Stream : IStream
    {
        private readonly System.IO.Stream _impl;
        
        public Stream(System.IO.Stream impl) => _impl = impl;
        public long Length => _impl.Length;

        public Task<int> Read(byte[] buffer, int offset, int count) => _impl.ReadAsync(buffer, offset, count);

        public void Close() => _impl.Close();
        public void Dispose() => _impl.Dispose();
    }
}

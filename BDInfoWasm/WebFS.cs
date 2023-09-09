using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BDInfoLib.BDROM.IO;

public class WebDirectoryInfo : IDirectoryInfo
{
    private readonly WebFile[] _fileTree;

    private readonly WebFile _node;

    public string Name => _node.name;

    public string FullName => _node.path;

    public IDirectoryInfo Parent {
        get
        {
            // Use a stack-based approach to scan _fileTree iteratively for a node that contains this node
            var stack = new Stack<WebFile>(_fileTree);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                if (node.children != null)
                {
                    foreach (var child in node.children)
                    {
                        if (child == _node)
                        {
                            return new WebDirectoryInfo(_fileTree, node);
                        }
                        stack.Push(child);
                    }
                }
            }
            return null;
        }
    }

    public WebDirectoryInfo(WebFile[] fileTree, WebFile node)
    {
        _fileTree = fileTree;
        _node = node;
    }

    public IDirectoryInfo[] GetDirectories()
    {
        List<IDirectoryInfo> dirs = new();
        foreach (var child in _node.children)
        {
            if (child.type == "dir")
            {
                dirs.Add(new WebDirectoryInfo(_fileTree, child));
            }
        }
        return dirs.ToArray();
    }

    public IFileInfo[] GetFiles()
    {
        List<IFileInfo> files = new();
        foreach (var child in _node.children)
        {
            if (child.type == "file")
            {
                files.Add(new WebFileInfo(child));
            }
        }
        return files.ToArray();
    }

    /// <param name="searchPattern">
    /// Match against the names of children files. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.
    /// </param>
    public IFileInfo[] GetFiles(string searchPattern)
    {
        List<IFileInfo> files = new();
        foreach (var child in _node.children)
        {
            if (child.type == "file")
            {
                if (Util.IsWildcardMatch(searchPattern, child.name))
                {
                    files.Add(new WebFileInfo(child));
                }
            }
        }
        return files.ToArray();
    }

    public IFileInfo[] GetFiles(string searchPattern, System.IO.SearchOption searchOption)
    {
        List<IFileInfo> files = new();
        if (searchOption == System.IO.SearchOption.AllDirectories)
        {
            var stack = new Stack<WebFile>(_fileTree);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                if (node.type == "file" && Util.IsWildcardMatch(searchPattern, node.name))
                {
                    files.Add(new WebFileInfo(node));
                }
                if (node.children != null)
                {
                    foreach (var child in node.children)
                    {
                        stack.Push(child);
                    }
                }
            }
        }
        else
        {
        foreach (var child in _node.children)
        {
            if (child.type == "file")
            {
                if (Util.IsWildcardMatch(searchPattern, child.name))
                {
                    files.Add(new WebFileInfo(child));
                }
            }
        }
        }
        return files.ToArray();
    }

    public string GetVolumeLabel()
    {
        return Name;
    }
}

public class WebFileInfo : IFileInfo
{
    private readonly WebFile _impl;
    
    public WebFileInfo(WebFile impl) => _impl = impl;
    
    public string Name => _impl.name;

    public string FullName => _impl.path;

    public string Extension => _impl.name.Substring(_impl.name.LastIndexOf('.'));

    public long Length => (long)_impl.size;

    public bool IsDir => _impl.type == "dir";
    
    public IStream OpenRead() => new WebStream(_impl);

    async Task<string> IFileInfo.ReadAllText()
    {
        var readResult = await MyClass.ReadFile(_impl.fileID, 0, _impl.size);
        var bytes = (byte[])readResult;
        var text = System.Text.Encoding.UTF8.GetString(bytes);
        return text;
    }
}

public class WebStream : IStream
{
    private readonly WebFile _impl;
    private long _position;
    
    public WebStream(WebFile impl) => _impl = impl;

    public long Length => (long)_impl.size;


    public void Close() {}

    public void Dispose() {}

    public async Task<int> Read(byte[] buffer, int offset, int count)
    {
        var readResult = await MyClass.ReadFile(_impl.fileID, _position, count);
        var bytes = (byte[])readResult;
        _position += bytes.Length;
        Array.Copy(bytes, 0, buffer, offset, bytes.Length);
        return bytes.Length;
    }
}

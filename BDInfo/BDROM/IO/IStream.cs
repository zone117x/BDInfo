using System;
using System.Threading.Tasks;

namespace BDInfoLib.BDROM.IO;

public interface IStream : IDisposable
{
    long Length { get; }
    Task<int> Read(byte[] buffer, int offset, int count);
    void Close();
}

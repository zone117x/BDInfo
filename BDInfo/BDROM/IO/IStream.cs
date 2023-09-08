using System;

namespace BDInfoLib.BDROM.IO;

public interface IStream : IDisposable
{
    long Length { get; }
    int Read(byte[] buffer, int offset, int count);
    void Close();
    IBinaryReader GetBinaryReader();
}

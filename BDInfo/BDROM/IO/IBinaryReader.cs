namespace BDInfoLib.BDROM.IO;

public interface IBinaryReader
{
    int Read(byte[] buffer, int index, int count);
    void Close();
}

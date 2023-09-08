namespace BDInfoLib.BDROM.IO;

public interface IStreamReader
{
    string ReadToEnd();
    void Close();
}

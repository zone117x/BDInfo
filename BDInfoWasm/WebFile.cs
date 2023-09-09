
using System.Text.Json.Serialization;

public class WebFile
{
    public string name { get; set; }
    public string type { get; set; }
    public double size { get; set; }
    public string path { get; set; }
    public int fileID { get; set; }
    public WebFile[] children { get; set; }
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(WebFile))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}

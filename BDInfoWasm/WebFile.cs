public class WebFile
{
    public string name { get; set; }
    public string type { get; set; }
    public double size { get; set; }
    public string path { get; set; }
    public int fileID { get; set; }
    public WebFile[] children { get; set; }
}

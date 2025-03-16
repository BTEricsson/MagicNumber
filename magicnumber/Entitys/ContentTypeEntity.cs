namespace MagicNumber.Entitys
{

    public class ContentType
    {
        public ContentType() { HeadBytes = ""; Contenttype = ""; }

        public ContentType(string contenttype, string headBytes, List<string> ext, string endBytes = "", string description = "" )
        {
            HeadBytes = headBytes;
            EndBytes = endBytes;
            Contenttype = contenttype;
            Description = description;
            Ext = ext;
        }

        public string HeadBytes { get; private set; }
        public string? EndBytes { get; private set; }
        public string Contenttype { get; private set; }
        public string? Description { get; private set; }
        public List<string> Ext { get; private set; }
    }
}
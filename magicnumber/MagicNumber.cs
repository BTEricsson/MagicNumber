
using MagicNumber.Entitys;

namespace MagicNumber
{
    public static class MagicContent
    {
        public static ContentType getContenttype(this Stream checkStream)
        {
            BinaryReader chkBinary = new BinaryReader(checkStream);

            Byte[] chkbytes = chkBinary.ReadBytes(0x20);
            string data_as_hex = BitConverter.ToString(chkbytes);
            string magicCheck_C = data_as_hex.Substring(0, 50);


            //chkBinary.BaseStream.Position = checkStream.Length -2;            
            //    Byte[] chkEndbytes = chkBinary.ReadBytes(0x2);
            //string end_data_as_hex = BitConverter.ToString(chkEndbytes);
            //string magicCheck_End = end_data_as_hex.Substring(0, 5);

         return magicCheck_C.gettype();
        }


        internal static ContentType gettype(this string magic)
        {
            var contenttype = new ContentType();

            contenttype = contenttype.checkType(magic, contentTypes.JPG_JFIF);
            contenttype = contenttype.checkType(magic, contentTypes.JPG_EXIF);
            contenttype = contenttype.checkType(magic, contentTypes.JPG);
            
            contenttype = contenttype.checkType(magic, contentTypes.TIF_II);
            contenttype = contenttype.checkType(magic, contentTypes.TIF_MM);

            contenttype = contenttype.checkType(magic, contentTypes.GIF_87);
            contenttype = contenttype.checkType(magic, contentTypes.GIF_89);
            contenttype = contenttype.checkType(magic, contentTypes.GIF_8);

            contenttype = contenttype.checkType(magic, contentTypes.PDF);
            contenttype = contenttype.checkType(magic, contentTypes.WORD);

            contenttype = contenttype.checkType(magic, contentTypes.EXE);

            contenttype = contenttype.checkType(magic, contentTypes.ZIP);

            return contenttype;
        }

        internal static ContentType checkType(this ContentType content, string value, ContentType contentType)
        {
            if (!string.IsNullOrEmpty(content.Contenttype))
                return content;

            var startValue = contentType.HeadBytes;

            if (value.Substring(0, startValue.Length) != startValue)
                return content;

            return contentType;
        }
    }


    internal static class contentTypes
    {
        public static ContentType JPG_JFIF = new ContentType(contenttype: "image/jpg", headBytes: "FF-D8-FF-E0", endBytes: "FF-D9", ext: new List<string> { "jpg","jpeg" }, description: "JPEG File Interchange Format JFIF");
        public static ContentType JPG_EXIF = new ContentType(contenttype: "image/jpg", headBytes: "FF-D8-FF-E1", endBytes: "FF-D9", ext: new List<string> { "jpg", "jpeg" }, description: "JPEG File Interchange Format Exif");
        public static ContentType JPG = new ContentType(contenttype: "image/jpg", headBytes: "FF-D8", endBytes: "FF-D9", ext: new List<string> { "jpg", "jpeg" }, description: "JPEG File Interchange Format");


        public static ContentType TIF_II = new ContentType(contenttype: "image/tif", headBytes: "49-49-2A-00", ext: new List<string>{"tif,tiff"}, description: "TIFF format (Intel - little endian)");
        public static ContentType TIF_MM = new ContentType(contenttype : "image/tif" , headBytes: "49-49-00-2A", ext: new List<string> {"tif,tiff"}, description: "TIFF format (Motorola - big endian)");
        
        
        public static ContentType GIF_89 = new ContentType(contenttype : "image/gif" , headBytes: "47-49-46-38-39-61", ext: new List<string> { "gif" }, description: "GIF89");
        public static ContentType GIF_87 = new ContentType (contenttype : "image/gif" , headBytes: "47-49-46-38-37-61", ext: new List<string> { "gif" }, description: "GIF87");
        public static ContentType GIF_8 = new ContentType(contenttype: "image/gif", headBytes: "47-49-46-38", ext: new List<string> { "gif" }, description: "GIF8");

        public static ContentType PDF = new ContentType(contenttype: "text/pdf", headBytes: "25-50-44-46", ext: new List<string> { "pdf" }, description: "pdf");
        public static ContentType WORD = new ContentType(contenttype: "text/word", headBytes: "50-4B-03-04", ext: new List<string> { "docx" }, description: "Docx");


        public static ContentType EXE = new ContentType(contenttype: "Excecutable", headBytes: "4D-5A", ext: new List<string> { "exe" }, description: "Excecutable files, MS-DOS, OS/2 or MS Windows");
        public static ContentType ZIP = new ContentType(contenttype: "ZIP", headBytes: "50-4B-03-04", ext: new List<string> { "zip" }, description: "pkzip format");

    }
}
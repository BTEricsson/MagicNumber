using MagicNumber.Entitys;
using System.Text;

namespace MagicNumber
{
   
    public partial class Form1 : Form
    {
        Color BaseColor = Color.Black;
        Color HiColor = Color.Red;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_selectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;
                    using (Stream str = openFileDialog1.OpenFile())
                    {
                        var contenttype = str.getContenttype();

                        //UpdateTypeLabel(contenttype);
                        UddateLabel(lbl_FileType, "File Type", contenttype.Contenttype);
                        //UpdateSubTypeLabel(contenttype);
                        UddateLabel(lbl_SubType, "Discription", contenttype.Description);
                        //UpdateHeadHexLabel(contenttype);
                        UddateLabel(lbl_HeadHex, "Head Hex", contenttype.HeadBytes);
                        //UpdateEndHexLabel(contenttype);
                        UddateLabel(lbl_EndHex, "End Hex", contenttype.EndBytes);
                        updateTextBox(str, contenttype);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void UddateLabel(Label label, string labelName,  string? text)
        {
            if (string.IsNullOrEmpty(text))
            {
                label.Text = $"{labelName}: ";
                return;
            }

            label.Text = $"{labelName}: {text}";
        }

        ref struct PartToCheck
        {
            public bool StartSet;
            public bool EndSet;
        }

        private void updateTextBox(Stream str, ContentType contentType)
        {
            str.Position = 0;
            int CHUNK_SIZE = 1008;
            RTB_Char.Clear();
            var partToCheck = new PartToCheck();

            using (BinaryReader br = new BinaryReader(str, new ASCIIEncoding()))
            {
                byte[] chunk;

                chunk = br.ReadBytes(CHUNK_SIZE);
                while (chunk.Length > 0)
                {          
                    DisplayBytes(chunk, chunk.Length, contentType, ref partToCheck);
                    chunk = br.ReadBytes(CHUNK_SIZE);
                }
            }

        }

        private void DisplayBytes(byte[] bdata, int len, ContentType contentType, ref PartToCheck partToCheck)
        {
            int i;
            int j = 0;
            char dchar;
            // 3 * 16 chars for hex display, 16 chars for text and 8 chars
            // for the 'gutter' int the middle.
            StringBuilder dumptext = new StringBuilder("        ", 16 * 4 + 8);
            for (i = 0; i < len; i++)
            {
                dumptext.Insert(j * 3, String.Format("{0:X2} ", (int)bdata[i]));
                dchar = (char)bdata[i];
                //' replace 'non-printable' chars with a '.'.
                if (Char.IsWhiteSpace(dchar) || Char.IsControl(dchar))
                {
                    dchar = '.';
                }
                dumptext.Append(dchar);
                j++;
                
                
                if (j == 16)
                {
                    updateText(dumptext.ToString(), contentType, ref partToCheck);
                    dumptext.Length = 0;
                    dumptext.Append("        ");
                    j = 0;
                }
            }


            // display the remaining line
            if (j > 0)
            {
                for (i = j; i < 16; i++)
                {
                    dumptext.Insert(j * 3, "   ");
                }

                updateText(dumptext.ToString(), contentType, ref partToCheck);
            }
        }

        private void updateText(string text, ContentType contentType, ref  PartToCheck isContentType)
        {
            if (contentType is null)
                return;

            string textCodeStart = string.Empty;
            string textCodeEnd = string.Empty;

            bool isHeadUpdated;
            bool isEndUpdated;

            int indexOfSpace = text.LastIndexOf(" ")+1;
            var hexText = text.Substring(0, indexOfSpace);
            var charText = text.Substring(indexOfSpace, text.Length - indexOfSpace);
            

            int nextIndex = 0;

            (isHeadUpdated, textCodeStart) = setTextBlock(hexText, contentType.HeadBytes, ref nextIndex, isContentType.StartSet);
            (isEndUpdated, textCodeEnd) =  setTextBlock(hexText, contentType?.EndBytes, ref nextIndex, isContentType.EndSet);

            if (nextIndex < hexText.Length)
                RTB_Char.AppendText(hexText.Substring(nextIndex, hexText.Length - nextIndex), BaseColor);


            nextIndex = 0;
            // display chars
            setCharBlock(isHeadUpdated, textCodeStart, charText, ref nextIndex);
            setCharBlock(isEndUpdated, textCodeEnd, charText, ref nextIndex);

            // display last chars if any left
            if (nextIndex < charText.Length)
                RTB_Char.AppendText(charText.Substring(nextIndex, charText.Length - nextIndex), BaseColor);


            RTB_Char.AppendText(Environment.NewLine, BaseColor);


            if (isHeadUpdated)
                isContentType.StartSet = true;

            if (isEndUpdated)
                isContentType.EndSet = true;
        
        }

        private void setCharBlock(bool startPos, string textCode, string charText, ref int nextCharStart )
        {
            if (!startPos)
                return;

            var codeArray = textCode.Replace(" ", ",").Split(",");
            var codeString = ConvertHexStringToString(codeArray);
            var codeIndex = charText.IndexOf(codeString);

            if (codeIndex > 0)
                RTB_Char.AppendText(charText.Substring(0, codeIndex), BaseColor);

            RTB_Char.AppendText(charText.Substring(codeIndex, codeString.Length), HiColor);

            nextCharStart = codeIndex + codeString.Length;
        }

        private (bool startPos,string textCode) setTextBlock(string hexText,string? bytes, ref int nextStart, bool isSet)
        {
            if ((string.IsNullOrEmpty(bytes) || isSet))
                return (false, string.Empty);
            
            string textCode = bytes.Replace("-", " ");
            int startPos = hexText.IndexOf(textCode);

            if (startPos == -1)
                return (false,textCode);

            if (startPos > nextStart)
                RTB_Char.AppendText(hexText.Substring(nextStart, startPos), BaseColor);

            nextStart = startPos;
            RTB_Char.AppendText(hexText.Substring(nextStart, textCode.Length), HiColor);

            nextStart = startPos + textCode.Length;

            return (true, textCode);
        }
     
        private string ConvertHexStringToString(string [] stringArray)
        {
            Char newChar(string S)  { return (Char)Int16.Parse(S, System.Globalization.NumberStyles.AllowHexSpecifier); }
            return new string(Array.ConvertAll(stringArray, c => (Char.IsWhiteSpace(newChar(c)) || Char.IsControl(newChar(c))) ? '.' : newChar(c)));
        }

    }
}

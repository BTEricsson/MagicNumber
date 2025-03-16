namespace MagicNumber
{
    public static class RichTextExt
    {
        public static void AppendText(this RichTextBox textBox, string Text, Color color)
        {
            textBox.SelectionStart = textBox.TextLength;
            textBox.SelectionLength = 0;

            textBox.SelectionColor = color;
            textBox.AppendText(Text);
            textBox.SelectionColor = textBox.ForeColor;
        }
    }
}

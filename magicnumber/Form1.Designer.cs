namespace MagicNumber
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openFileDialog1 = new OpenFileDialog();
            btn_selectFile = new Button();
            lbl_FileType = new Label();
            RTB_Char = new RichTextBox();
            lbl_HeadHex = new Label();
            lbl_EndHex = new Label();
            lbl_SubType = new Label();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_selectFile
            // 
            btn_selectFile.Location = new Point(741, 476);
            btn_selectFile.Name = "btn_selectFile";
            btn_selectFile.Size = new Size(75, 23);
            btn_selectFile.TabIndex = 1;
            btn_selectFile.Text = "File";
            btn_selectFile.UseVisualStyleBackColor = true;
            btn_selectFile.Click += btn_selectFile_Click;
            // 
            // lbl_FileType
            // 
            lbl_FileType.AutoSize = true;
            lbl_FileType.Location = new Point(12, 25);
            lbl_FileType.Name = "lbl_FileType";
            lbl_FileType.Size = new Size(49, 15);
            lbl_FileType.TabIndex = 2;
            lbl_FileType.Text = "FileType";
            // 
            // RTB_Char
            // 
            RTB_Char.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RTB_Char.Location = new Point(265, 12);
            RTB_Char.Name = "RTB_Char";
            RTB_Char.Size = new Size(551, 454);
            RTB_Char.TabIndex = 4;
            RTB_Char.Text = "";
            // 
            // lbl_HeadHex
            // 
            lbl_HeadHex.AutoSize = true;
            lbl_HeadHex.Location = new Point(12, 83);
            lbl_HeadHex.Name = "lbl_HeadHex";
            lbl_HeadHex.Size = new Size(56, 15);
            lbl_HeadHex.TabIndex = 5;
            lbl_HeadHex.Text = "HeadHex";
            // 
            // lbl_EndHex
            // 
            lbl_EndHex.AutoSize = true;
            lbl_EndHex.Location = new Point(12, 114);
            lbl_EndHex.Name = "lbl_EndHex";
            lbl_EndHex.Size = new Size(48, 15);
            lbl_EndHex.TabIndex = 6;
            lbl_EndHex.Text = "EndHex";
            // 
            // lbl_SubType
            // 
            lbl_SubType.AutoSize = true;
            lbl_SubType.Location = new Point(12, 51);
            lbl_SubType.Name = "lbl_SubType";
            lbl_SubType.Size = new Size(51, 15);
            lbl_SubType.TabIndex = 7;
            lbl_SubType.Text = "SubType";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(828, 502);
            Controls.Add(lbl_SubType);
            Controls.Add(lbl_EndHex);
            Controls.Add(lbl_HeadHex);
            Controls.Add(RTB_Char);
            Controls.Add(lbl_FileType);
            Controls.Add(btn_selectFile);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private Button btn_selectFile;
        private Label lbl_FileType;
        private RichTextBox RTB_Char;
        private Label lbl_HeadHex;
        private Label lbl_EndHex;
        private Label lbl_SubType;
    }
}

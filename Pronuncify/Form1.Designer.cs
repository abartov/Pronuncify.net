namespace Pronuncify
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textLog = new System.Windows.Forms.TextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.fontButton = new System.Windows.Forms.Button();
            this.labelWord = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelOnAir = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textLang = new System.Windows.Forms.TextBox();
            this.comboWasapiDevices = new System.Windows.Forms.ComboBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.textWordFile = new System.Windows.Forms.TextBox();
            this.btnLoadWords = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listWords = new System.Windows.Forms.ListBox();
            this.btnOutputFolder = new System.Windows.Forms.Button();
            this.textOutputFolder = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveWords = new System.Windows.Forms.Button();
            this.btnFindSox = new System.Windows.Forms.Button();
            this.textSox = new System.Windows.Forms.TextBox();
            this.linkHomepage = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(25, 19);
            this.progressBar1.Maximum = 5;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(169, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 0;
            // 
            // textLog
            // 
            this.textLog.Location = new System.Drawing.Point(22, 231);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.Size = new System.Drawing.Size(483, 182);
            this.textLog.TabIndex = 2;
            // 
            // fontButton
            // 
            this.fontButton.Location = new System.Drawing.Point(25, 48);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(75, 23);
            this.fontButton.TabIndex = 3;
            this.fontButton.Text = "Font";
            this.fontButton.UseVisualStyleBackColor = true;
            this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
            // 
            // labelWord
            // 
            this.labelWord.AutoSize = true;
            this.labelWord.Location = new System.Drawing.Point(22, 83);
            this.labelWord.Name = "labelWord";
            this.labelWord.Size = new System.Drawing.Size(48, 13);
            this.labelWord.TabIndex = 4;
            this.labelWord.Text = "the word";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textLang);
            this.groupBox1.Controls.Add(this.comboWasapiDevices);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.labelWord);
            this.groupBox1.Controls.Add(this.fontButton);
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 204);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recorder";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.labelOnAir);
            this.panel1.Location = new System.Drawing.Point(378, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(99, 100);
            this.panel1.TabIndex = 16;
            // 
            // labelOnAir
            // 
            this.labelOnAir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelOnAir.AutoSize = true;
            this.labelOnAir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOnAir.Location = new System.Drawing.Point(14, 37);
            this.labelOnAir.Name = "labelOnAir";
            this.labelOnAir.Size = new System.Drawing.Size(61, 24);
            this.labelOnAir.TabIndex = 0;
            this.labelOnAir.Text = "off air";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "language";
            // 
            // textLang
            // 
            this.textLang.Location = new System.Drawing.Point(305, 48);
            this.textLang.Name = "textLang";
            this.textLang.Size = new System.Drawing.Size(32, 20);
            this.textLang.TabIndex = 14;
            this.textLang.TextChanged += new System.EventHandler(this.textLang_TextChanged);
            // 
            // comboWasapiDevices
            // 
            this.comboWasapiDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWasapiDevices.FormattingEnabled = true;
            this.comboWasapiDevices.Location = new System.Drawing.Point(251, 21);
            this.comboWasapiDevices.Name = "comboWasapiDevices";
            this.comboWasapiDevices.Size = new System.Drawing.Size(121, 21);
            this.comboWasapiDevices.TabIndex = 13;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(378, 77);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "NEXT";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(378, 48);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(378, 19);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textWordFile
            // 
            this.textWordFile.Location = new System.Drawing.Point(15, 49);
            this.textWordFile.Name = "textWordFile";
            this.textWordFile.Size = new System.Drawing.Size(216, 20);
            this.textWordFile.TabIndex = 7;
            // 
            // btnLoadWords
            // 
            this.btnLoadWords.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLoadWords.Location = new System.Drawing.Point(15, 20);
            this.btnLoadWords.Name = "btnLoadWords";
            this.btnLoadWords.Size = new System.Drawing.Size(96, 23);
            this.btnLoadWords.TabIndex = 8;
            this.btnLoadWords.Text = "Load words...";
            this.btnLoadWords.UseVisualStyleBackColor = true;
            this.btnLoadWords.Click += new System.EventHandler(this.btnLoadWords_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // listWords
            // 
            this.listWords.FormattingEnabled = true;
            this.listWords.Location = new System.Drawing.Point(15, 74);
            this.listWords.Name = "listWords";
            this.listWords.Size = new System.Drawing.Size(218, 186);
            this.listWords.TabIndex = 9;
            // 
            // btnOutputFolder
            // 
            this.btnOutputFolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOutputFolder.Location = new System.Drawing.Point(667, 31);
            this.btnOutputFolder.Name = "btnOutputFolder";
            this.btnOutputFolder.Size = new System.Drawing.Size(84, 23);
            this.btnOutputFolder.TabIndex = 11;
            this.btnOutputFolder.Text = "Record To...";
            this.btnOutputFolder.UseVisualStyleBackColor = true;
            this.btnOutputFolder.Click += new System.EventHandler(this.btnOutputFolder_Click);
            // 
            // textOutputFolder
            // 
            this.textOutputFolder.Location = new System.Drawing.Point(511, 31);
            this.textOutputFolder.Name = "textOutputFolder";
            this.textOutputFolder.Size = new System.Drawing.Size(150, 20);
            this.textOutputFolder.TabIndex = 10;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyDocuments;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveWords);
            this.groupBox2.Controls.Add(this.textWordFile);
            this.groupBox2.Controls.Add(this.btnLoadWords);
            this.groupBox2.Controls.Add(this.listWords);
            this.groupBox2.Location = new System.Drawing.Point(511, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 280);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // btnSaveWords
            // 
            this.btnSaveWords.Location = new System.Drawing.Point(125, 20);
            this.btnSaveWords.Name = "btnSaveWords";
            this.btnSaveWords.Size = new System.Drawing.Size(107, 22);
            this.btnSaveWords.TabIndex = 10;
            this.btnSaveWords.Text = "Save words...";
            this.btnSaveWords.UseVisualStyleBackColor = true;
            // 
            // btnFindSox
            // 
            this.btnFindSox.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnFindSox.Location = new System.Drawing.Point(667, 63);
            this.btnFindSox.Name = "btnFindSox";
            this.btnFindSox.Size = new System.Drawing.Size(84, 23);
            this.btnFindSox.TabIndex = 14;
            this.btnFindSox.Text = "sox.exe";
            this.btnFindSox.UseVisualStyleBackColor = true;
            // 
            // textSox
            // 
            this.textSox.Location = new System.Drawing.Point(511, 63);
            this.textSox.Name = "textSox";
            this.textSox.Size = new System.Drawing.Size(150, 20);
            this.textSox.TabIndex = 13;
            // 
            // linkHomepage
            // 
            this.linkHomepage.AutoSize = true;
            this.linkHomepage.Location = new System.Drawing.Point(571, 400);
            this.linkHomepage.Name = "linkHomepage";
            this.linkHomepage.Size = new System.Drawing.Size(128, 13);
            this.linkHomepage.TabIndex = 15;
            this.linkHomepage.TabStop = true;
            this.linkHomepage.Text = "Pronuncify.net homepage";
            this.linkHomepage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHomepage_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 421);
            this.Controls.Add(this.linkHomepage);
            this.Controls.Add(this.btnFindSox);
            this.Controls.Add(this.textSox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOutputFolder);
            this.Controls.Add(this.textOutputFolder);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textLog);
            this.Name = "Form1";
            this.Text = "Pronuncify";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button fontButton;
        private System.Windows.Forms.Label labelWord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textWordFile;
        private System.Windows.Forms.Button btnLoadWords;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox listWords;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ComboBox comboWasapiDevices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textLang;
        private System.Windows.Forms.Button btnOutputFolder;
        private System.Windows.Forms.TextBox textOutputFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelOnAir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveWords;
        private System.Windows.Forms.Button btnFindSox;
        private System.Windows.Forms.TextBox textSox;
        private System.Windows.Forms.LinkLabel linkHomepage;
    }
}


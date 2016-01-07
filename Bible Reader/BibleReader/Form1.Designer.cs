namespace BibleReader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.booksOfBibleListBox = new System.Windows.Forms.ListBox();
            this.chapterNumbersListBox = new System.Windows.Forms.ListBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchResultsPanel = new System.Windows.Forms.Panel();
            this.bibleListComboBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(213, 41);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(1058, 860);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
            this.richTextBox1.Click += new System.EventHandler(this.richTextBox1_Click);
            // 
            // booksOfBibleListBox
            // 
            this.booksOfBibleListBox.Font = new System.Drawing.Font("Calibri", 10.5F);
            this.booksOfBibleListBox.FormattingEnabled = true;
            this.booksOfBibleListBox.ItemHeight = 17;
            this.booksOfBibleListBox.Items.AddRange(new object[] {
            "Genesis",
            "Exodus",
            "Leviticus",
            "Numbers",
            "Deuteronomy",
            "Joshua ",
            "Judges",
            "Ruth",
            "1 Samuel",
            "2 Samuel",
            "1 Kings",
            "2 Kings",
            "1 Chronicles",
            "2 Chronicles",
            "Ezra",
            "Nehemiah",
            "Esther",
            "Job",
            "Psalms",
            "Proverbs",
            "Ecclesiastes",
            "Song of Solomon",
            "Isaiah",
            "Jeremiah",
            "Lamentations",
            "Ezekiel",
            "Daniel",
            "Hosea",
            "Joel",
            "Amos",
            "Obadiah",
            "Jonah",
            "Micah",
            "Nahum",
            "Habakkuk",
            "Zephaniah",
            "Haggai",
            "Zechariah",
            "Malachi",
            "Matthew",
            "Mark",
            "Luke",
            "John",
            "Acts",
            "Romans",
            "1 Corinthians",
            "2 Corinthians",
            "Galatians",
            "Ephesians",
            "Philippians",
            "Colossians",
            "1 Thessalonians",
            "2 Thessalonians",
            "1 Timothy",
            "2 Timothy",
            "Titus",
            "Philemon",
            "Hebrews",
            "James",
            "1 Peter",
            "2 Peter",
            "1 John",
            "2 John",
            "3 John",
            "Jude",
            "Revelation"});
            this.booksOfBibleListBox.Location = new System.Drawing.Point(12, 13);
            this.booksOfBibleListBox.Name = "booksOfBibleListBox";
            this.booksOfBibleListBox.Size = new System.Drawing.Size(121, 888);
            this.booksOfBibleListBox.TabIndex = 1;
            this.booksOfBibleListBox.Click += new System.EventHandler(this.Form1_Click);
            this.booksOfBibleListBox.SelectedIndexChanged += new System.EventHandler(this.booksOfBibleListBox_SelectedIndexChanged);
            // 
            // chapterNumbersListBox
            // 
            this.chapterNumbersListBox.Font = new System.Drawing.Font("Calibri", 10.5F);
            this.chapterNumbersListBox.FormattingEnabled = true;
            this.chapterNumbersListBox.ItemHeight = 17;
            this.chapterNumbersListBox.Location = new System.Drawing.Point(139, 13);
            this.chapterNumbersListBox.Name = "chapterNumbersListBox";
            this.chapterNumbersListBox.Size = new System.Drawing.Size(68, 888);
            this.chapterNumbersListBox.TabIndex = 2;
            this.chapterNumbersListBox.Click += new System.EventHandler(this.Form1_Click);
            this.chapterNumbersListBox.SelectedIndexChanged += new System.EventHandler(this.chapterNumbersListBox_SelectedIndexChanged);
            // 
            // searchTextBox
            // 
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.searchTextBox.ForeColor = System.Drawing.Color.Black;
            this.searchTextBox.Location = new System.Drawing.Point(6, 3);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(238, 18);
            this.searchTextBox.TabIndex = 3;
            this.searchTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.searchTextBox_MouseClick);
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            this.searchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchTextBox_KeyPress);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1181, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 26);
            this.button1.TabIndex = 4;
            this.button1.Text = "SEARCH";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.searchTextBox);
            this.panel1.Location = new System.Drawing.Point(885, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 26);
            this.panel1.TabIndex = 5;
            // 
            // searchResultsPanel
            // 
            this.searchResultsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchResultsPanel.AutoScroll = true;
            this.searchResultsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchResultsPanel.Location = new System.Drawing.Point(885, 35);
            this.searchResultsPanel.Name = "searchResultsPanel";
            this.searchResultsPanel.Size = new System.Drawing.Size(354, 489);
            this.searchResultsPanel.TabIndex = 6;
            this.searchResultsPanel.Visible = false;
            // 
            // bibleListComboBox
            // 
            this.bibleListComboBox.FormattingEnabled = true;
            this.bibleListComboBox.Items.AddRange(new object[] {
            "King James Version (KJV)",
            "King James Version (KJV) - With Strongs\' numbers"});
            this.bibleListComboBox.Location = new System.Drawing.Point(213, 13);
            this.bibleListComboBox.Name = "bibleListComboBox";
            this.bibleListComboBox.Size = new System.Drawing.Size(279, 22);
            this.bibleListComboBox.TabIndex = 7;
            this.bibleListComboBox.Text = "King James Version (KJV)";
            this.bibleListComboBox.SelectedIndexChanged += new System.EventHandler(this.bibleListComboBox_SelectedIndexChanged);
            this.bibleListComboBox.Click += new System.EventHandler(this.Form1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1283, 911);
            this.Controls.Add(this.bibleListComboBox);
            this.Controls.Add(this.searchResultsPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chapterNumbersListBox);
            this.Controls.Add(this.booksOfBibleListBox);
            this.Controls.Add(this.richTextBox1);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Bible Reader";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListBox booksOfBibleListBox;
        private System.Windows.Forms.ListBox chapterNumbersListBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel searchResultsPanel;
        private System.Windows.Forms.ComboBox bibleListComboBox;
    }
}


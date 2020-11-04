namespace Your_Vocabulary
{
    partial class SelectList
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
            this.Cancel = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonNewList = new System.Windows.Forms.Button();
            this.labelLanguageCount = new System.Windows.Forms.Label();
            this.textBoxLanguages = new System.Windows.Forms.TextBox();
            this.labelWordCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxLists = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Cancel.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.ForeColor = System.Drawing.Color.Black;
            this.Cancel.Location = new System.Drawing.Point(505, 276);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 15;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSelect.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.buttonSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelect.ForeColor = System.Drawing.Color.Black;
            this.buttonSelect.Location = new System.Drawing.Point(597, 276);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect.TabIndex = 14;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = false;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonNewList
            // 
            this.buttonNewList.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonNewList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonNewList.ForeColor = System.Drawing.Color.Black;
            this.buttonNewList.Location = new System.Drawing.Point(34, 277);
            this.buttonNewList.Name = "buttonNewList";
            this.buttonNewList.Size = new System.Drawing.Size(75, 23);
            this.buttonNewList.TabIndex = 13;
            this.buttonNewList.Text = "New list";
            this.buttonNewList.UseVisualStyleBackColor = false;
            this.buttonNewList.Click += new System.EventHandler(this.buttonNewList_Click);
            // 
            // labelLanguageCount
            // 
            this.labelLanguageCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelLanguageCount.AutoSize = true;
            this.labelLanguageCount.Location = new System.Drawing.Point(374, 47);
            this.labelLanguageCount.Name = "labelLanguageCount";
            this.labelLanguageCount.Size = new System.Drawing.Size(63, 13);
            this.labelLanguageCount.TabIndex = 12;
            this.labelLanguageCount.Text = "Languages:";
            this.labelLanguageCount.Click += new System.EventHandler(this.labelLanguageCount_Click);
            // 
            // textBoxLanguages
            // 
            this.textBoxLanguages.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxLanguages.Location = new System.Drawing.Point(374, 67);
            this.textBoxLanguages.Multiline = true;
            this.textBoxLanguages.Name = "textBoxLanguages";
            this.textBoxLanguages.Size = new System.Drawing.Size(299, 186);
            this.textBoxLanguages.TabIndex = 11;
            this.textBoxLanguages.TextChanged += new System.EventHandler(this.textBoxLanguages_TextChanged);
            // 
            // labelWordCount
            // 
            this.labelWordCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelWordCount.AutoSize = true;
            this.labelWordCount.Location = new System.Drawing.Point(267, 48);
            this.labelWordCount.Name = "labelWordCount";
            this.labelWordCount.Size = new System.Drawing.Size(66, 13);
            this.labelWordCount.TabIndex = 10;
            this.labelWordCount.Text = "Word count:";
            this.labelWordCount.Click += new System.EventHandler(this.labelWordCount_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Word lists:";
            // 
            // listBoxLists
            // 
            this.listBoxLists.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.listBoxLists.FormattingEnabled = true;
            this.listBoxLists.Location = new System.Drawing.Point(34, 67);
            this.listBoxLists.Name = "listBoxLists";
            this.listBoxLists.Size = new System.Drawing.Size(299, 186);
            this.listBoxLists.TabIndex = 8;
            this.listBoxLists.SelectedIndexChanged += new System.EventHandler(this.listBoxLists_SelectedIndexChanged);
            // 
            // SelectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(707, 368);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.buttonNewList);
            this.Controls.Add(this.labelLanguageCount);
            this.Controls.Add(this.textBoxLanguages);
            this.Controls.Add(this.labelWordCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxLists);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectList";
            this.Activated += new System.EventHandler(this.SelectList_Activated);
            this.Load += new System.EventHandler(this.SelectList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonNewList;
        private System.Windows.Forms.Label labelLanguageCount;
        private System.Windows.Forms.TextBox textBoxLanguages;
        private System.Windows.Forms.Label labelWordCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxLists;
    }
}
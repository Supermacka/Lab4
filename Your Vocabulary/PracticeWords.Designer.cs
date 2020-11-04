namespace Your_Vocabulary
{
    partial class PracticeWords
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
            this.labelQuestion = new System.Windows.Forms.Label();
            this.textBoxGuess = new System.Windows.Forms.TextBox();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.buttonEndPractice = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelQuestion
            // 
            this.labelQuestion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 34F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestion.Location = new System.Drawing.Point(423, 94);
            this.labelQuestion.MaximumSize = new System.Drawing.Size(550, 0);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(532, 106);
            this.labelQuestion.TabIndex = 0;
            this.labelQuestion.Text = "Translate the [] word [] to [] ";
            this.labelQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelQuestion.Click += new System.EventHandler(this.labelQuestion_Click);
            // 
            // textBoxGuess
            // 
            this.textBoxGuess.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxGuess.Location = new System.Drawing.Point(472, 239);
            this.textBoxGuess.Name = "textBoxGuess";
            this.textBoxGuess.Size = new System.Drawing.Size(432, 20);
            this.textBoxGuess.TabIndex = 1;
            this.textBoxGuess.TextChanged += new System.EventHandler(this.textBoxGuess_TextChanged);
            this.textBoxGuess.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxGuess_KeyDown);
            // 
            // buttonRestart
            // 
            this.buttonRestart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonRestart.BackColor = System.Drawing.Color.Red;
            this.buttonRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRestart.ForeColor = System.Drawing.Color.Black;
            this.buttonRestart.Location = new System.Drawing.Point(503, 481);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(356, 107);
            this.buttonRestart.TabIndex = 6;
            this.buttonRestart.Text = "Restart";
            this.buttonRestart.UseVisualStyleBackColor = false;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // buttonEndPractice
            // 
            this.buttonEndPractice.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonEndPractice.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.buttonEndPractice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEndPractice.ForeColor = System.Drawing.Color.Black;
            this.buttonEndPractice.Location = new System.Drawing.Point(551, 609);
            this.buttonEndPractice.Name = "buttonEndPractice";
            this.buttonEndPractice.Size = new System.Drawing.Size(254, 74);
            this.buttonEndPractice.TabIndex = 7;
            this.buttonEndPractice.Text = "End practice";
            this.buttonEndPractice.UseVisualStyleBackColor = false;
            this.buttonEndPractice.Click += new System.EventHandler(this.buttonEndPractice_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(606, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Current session";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(604, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(409, 37);
            this.label2.TabIndex = 9;
            this.label2.Text = "0 out of 0 words are correct";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PracticeWords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1345, 873);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonEndPractice);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.textBoxGuess);
            this.Controls.Add(this.labelQuestion);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PracticeWords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PracticeWords";
            this.Load += new System.EventHandler(this.PracticeWords_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.TextBox textBoxGuess;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Button buttonEndPractice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
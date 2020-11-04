using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Labb4_Library;

namespace Your_Vocabulary
{
    public partial class NewList : Form
    {
        public NewList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectList selectList = new SelectList();
            selectList.IsActive = false;
            Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            SelectList selectList = new SelectList();
            string[] textBoxLanguages = textBox2.Lines;

            if (textBox1.Text != "" && textBoxLanguages.Length > 1 && !WordList.GetLists().Contains(textBox1.Text))
            {
                WordList newList = new WordList(textBox1.Text, textBoxLanguages);
                newList.Save();
                selectList.IsActive = false;
                Close();
            }
            else if (textBox1.Text.Length == 0)
            {
                string message = "Specify a title-name for your vocabulary";
                string title = "Title not specified";
                MessageBox.Show(message, title);
            }
            else if (WordList.GetLists().Contains(textBox1.Text))
            {
                string message = "There is already a list with the same name";
                string title = "Name already exists";
                MessageBox.Show(message, title);
            }
            else
            {
                string message = "Specify atleast 2 languages";
                string title = "To few languages";
                MessageBox.Show(message, title);
            }
        }
    }
}

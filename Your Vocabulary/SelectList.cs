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
    public partial class SelectList : Form
    {
        public bool IsActive { get; set; }

        public string listName { get; set; }

        public SelectList()
        {
            InitializeComponent();
        }

        private void listBoxLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            WordList loadList = WordList.LoadList(listBoxLists.SelectedItem.ToString());
            labelWordCount.Text = "Word count: " + loadList.Count();
            labelLanguageCount.Text = "Language count: " + loadList.Languages.Length;

            textBoxLanguages.Clear();
            foreach (string language in loadList.Languages)
            {
                textBoxLanguages.AppendText(language);
                textBoxLanguages.AppendText(Environment.NewLine);
            }
        }

        public void buttonNewList_Click(object sender, EventArgs e)
        {
            NewList newList = new NewList();
            newList.ShowDialog();
            IsActive = true;
        }

        private void labelWordCount_Click(object sender, EventArgs e)
        {

        }

        private void labelLanguageCount_Click(object sender, EventArgs e)
        {
        }

        private void textBoxLanguages_TextChanged(object sender, EventArgs e)
        {

        }

        private void SelectList_Load(object sender, EventArgs e)
        {
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            this.listName = this.listBoxLists.SelectedItem.ToString();
            Close();
        }

        private void SelectList_Activated(object sender, EventArgs e)
        {
            listBoxLists.Items.Clear();
            for (int i = 0; i < WordList.GetLists().Length; i++)
            {
                listBoxLists.Items.Add(WordList.GetLists()[i]);
            }
            if (this.listBoxLists.Items.Count > 0)
            {
                this.listBoxLists.SelectedIndex = 0;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

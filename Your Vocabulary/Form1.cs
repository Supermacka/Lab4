using Labb4_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Your_Vocabulary
{
    public partial class Form1 : Form
    {
        public static string ListName { get; set; }

        public static DataGridView DGV { get; set; }

        public static Button ButtonPractice { get; set; }



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void buttonAddWord_Click(object sender, EventArgs e)
        {
            using (AddWord addWord = new AddWord())
            {
                addWord.ShowDialog();
            }
        }

        private void buttonRemoveWord_Click(object sender, EventArgs e)
        {
            WordList loadList = WordList.LoadList(ListName);
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string getCellValue = Convert.ToString(selectedRow.Cells[0].Value);

                loadList.Remove(0, getCellValue);

                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(item.Index);
                }
            }
            if (dataGridView1.Rows != null && dataGridView1.Rows.Count <= 0)
            {
                buttonPractice.Enabled = false;
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Form1.DGV = this.dataGridView1;
            Form1.ButtonPractice = this.buttonPractice;
            SelectList selectList = new SelectList();
            AddWord addWord = new AddWord();

            if (selectList.ShowDialog() == DialogResult.OK)
            {
                OpenSelectedList(selectList);
            }
            else
            {
                MessageBox.Show("You did not select a vocabulary");
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_AllowUserToAddRowsChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void setActiveWordlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddWord addWord = new AddWord();
            SelectList selectList = new SelectList();

            if (selectList.ShowDialog() == DialogResult.OK)
            {
                OpenSelectedList(selectList);
            }
        }

        private void OpenSelectedList(SelectList selectList)
        {
            dataGridView1.Rows.Clear();
            Form1.ListName = selectList.listName;

            WordList loadList;
            loadList = WordList.LoadList(selectList.listName);

            dataGridView1.ColumnCount = loadList.Languages.Length;
            for (int i = 0; i < loadList.Languages.Length; i++)
            {
                dataGridView1.Columns[i].HeaderText = loadList.Languages[i];
            }

            loadList.List(Array.IndexOf(loadList.Languages, loadList.Languages[0]), (x =>
            {
                dataGridView1.ColumnCount = loadList.Languages.Length;
                for (int i = 0; i < loadList.Languages.Length; i++)
                {
                    dataGridView1.Columns[i].Name = loadList.Languages[i];
                }
                string[] row = new string[loadList.Languages.Length];

                for (int i = 0; i < loadList.Languages.Length; i++)
                {
                    row[i] = x[i];
                }
                dataGridView1.Rows.Add(row);
            }));
            this.dataGridView1.AllowUserToAddRows = false;

            if (loadList.Count() > 0)
            {
                buttonPractice.Enabled = true;
            }
            else
            {
                buttonPractice.Enabled = false;
            }
        }

        private void buttonPractice_Click(object sender, EventArgs e)
        {
            PracticeWords practiceWords = new PracticeWords();
            practiceWords.ShowDialog();
        }
    }
}

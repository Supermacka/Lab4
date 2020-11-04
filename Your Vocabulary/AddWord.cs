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
    public partial class AddWord : Form
    {

        public AddWord()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void AddWord_Shown(object sender, EventArgs e)
        {
            // Add languages to column1...
            WordList loadList = WordList.LoadList(Form1.ListName);

            dataGridView1.ColumnCount = 2;
            for (int i = 0; i < loadList.Languages.Length; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = loadList.Languages[i];
                dataGridView1.Rows.Add(row);
            }
            this.dataGridView1.AllowUserToAddRows = false;

        }

        private void AddWord_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value == null)
                    {
                        string message = "Please translate all the languages of the word";
                        string Title = "All forms not filled!";
                        MessageBox.Show(message, Title);
                        return;
                    }
                }
            }

            WordList loadList = WordList.LoadList(Form1.ListName);
            string[] translations = new string[loadList.Languages.Length];
            string[] row = new string[loadList.Languages.Length];
            for (int i = 0; i < loadList.Languages.Length; i++)
            {
                translations[i] = dataGridView1.Rows[i].Cells[1].Value.ToString();

                row[i] = dataGridView1.Rows[i].Cells[1].Value.ToString();
            }
            Form1.DGV.Rows.Add(row);
            loadList.Add(translations);
            loadList.Save();
            
            Form1.ButtonPractice.Enabled = true;

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

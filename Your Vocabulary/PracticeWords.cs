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
    public partial class PracticeWords : Form
    {
        public string fromLang { get; set; }
        public string fromWord { get; set; }
        public string toLang { get; set; }
        public string toWord { get; set; }
        public int correctAnswers { get; set; } = 0;
        public int count { get; set; } = 0;

        public PracticeWords()
        {
            InitializeComponent();
        }

        private void labelQuestion_Click(object sender, EventArgs e)
        {

        }

        private void PracticeWords_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Question();
        }

        private void textBoxGuess_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxGuess_KeyDown(object sender, KeyEventArgs e)
        {
            WordList loadList = WordList.LoadList(Form1.ListName);

            if (e.KeyData == Keys.Enter && textBoxGuess.Text != "")
            {
                if (textBoxGuess.Text == toWord)
                {
                    correctAnswers++;
                    count++;
                }
                else
                {
                    string message = $"That's not quite right \n The correct answer is \'{toWord}\'";
                    string title = "Incorrect translation";
                    MessageBox.Show(message, title);
                    count++;
                }
                textBoxGuess.Clear();
                label2.Text = $"{count} out of {correctAnswers} words are correct";
                Question();
            }
        }

        private void Question()
        {
            WordList loadList = WordList.LoadList(Form1.ListName);

            fromLang = loadList.Languages[loadList.GetWordToPractice().FromLanguage];
            fromWord = loadList.GetWordToPractice().Translations[0];
            toLang = loadList.Languages[loadList.GetWordToPractice().ToLanguage];
            toWord = loadList.GetWordToPractice().Translations[1].ToString();
            labelQuestion.Text = $"Translate the {fromLang} word \'{fromWord}\', to {toLang}: ";
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void buttonEndPractice_Click(object sender, EventArgs e)
        {
            if (count > 0)
            {
                float result = (((float)correctAnswers / count) * 100);
                string message = $"{((int)result)}% of your translations were correct!";
                string title = "YOUR RESULT";
                MessageBox.Show(message, title);
            }
            Close();
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            correctAnswers = 0;
            count = 0;
            Question();
            label2.Text = $"{count} out of {correctAnswers} words are correct";
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Labb4_Library
{
    public class WordList
    {
        private List<Word> listOfWords = new List<Word>();
        public string Name { get; }
        public string[] Languages { get; }

        public WordList(string name, params string[] languages)
        {
            this.Name = name;

            var MyArrayUpper = languages.Select(s => s.ToUpperInvariant()).ToArray();
            this.Languages = MyArrayUpper;
        }

        public static string[] GetLists()
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Labb4";
            string[] files = Directory.GetFiles(folderPath).Select(file => Path.GetFileName(file.Replace(".dat", ""))).ToArray();
            return files;
        }

        public static WordList LoadList(string name)
        {
            string folderName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Labb4";
            string fileName = name + ".dat";
            folderName = System.IO.Path.Combine(folderName, fileName);

            try
            {
                WordList thisWordList;
                using (StreamReader sr = new StreamReader(folderName))
                {
                    string line = sr.ReadLine();
                    string[] languages = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    thisWordList = new WordList(name, languages);

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] translations = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        thisWordList.Add(translations);
                    }
                }
                return thisWordList;
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }

        public void Save()
        {
            string folderName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Labb4";
            System.IO.Directory.CreateDirectory(folderName);
            
            string fileName = this.Name + ".dat";
            folderName = System.IO.Path.Combine(folderName, fileName);
            Console.WriteLine("Path to my file: {0}\n", folderName);

            if (!System.IO.File.Exists(folderName))
            {
                System.IO.FileStream fs = System.IO.File.Create(folderName);
                fs.Close();
                using (StreamWriter writeToFile = new StreamWriter(folderName))
                {
                    foreach (string item in this.Languages)
                    {
                        writeToFile.Write(item.ToUpper() + ";");
                    }
                    writeToFile.WriteLine();
                }
            }
            if (listOfWords.Count > 0)
            {
                using (StreamWriter writeToFile = new StreamWriter(folderName, true))
                {
                    for (int j = 0; j < this.Languages.Length; j++)
                    {
                        writeToFile.Write(listOfWords[listOfWords.Count - 1].Translations[j].ToLower() + ";");
                    }
                    writeToFile.WriteLine();
                }
            }
        }
        
        public void Add(params string[] translations)
        {
            listOfWords.Add(new Word(translations));
        }

        public bool Remove(int translation, string word)
        {
            int removeLength = 0;
            foreach (Word thatWord in listOfWords)
            {
                if (!Array.Equals(thatWord.Translations[translation], word))
                {
                    removeLength++;
                }
                if (removeLength >= listOfWords.Count)
                {
                    return false;
                }
            }

            for (int i = 0; i < listOfWords.Count - 1; i++)
            {
                if (listOfWords[i].Translations[translation] == word)
                {
                    listOfWords.RemoveAt(i);
                }
            }

            string folderName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Labb4";
            string fileName = this.Name + ".dat";
            folderName = System.IO.Path.Combine(folderName, fileName);

            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader(folderName))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.Contains(word))
                    {
                        sw.WriteLine(line);
                    }
                }
            }

            File.Delete(folderName);
            File.Move(tempFile, folderName);

            return true;
        }

        public int Count()
        {
            return listOfWords.Count();
        }

        public Word GetWordToPractice()
        {
            Random rndm = new Random();

            int randomWord = rndm.Next(0, listOfWords.Count - 1);
            int fromLang;
            int toLang;

            do
            {
                fromLang = rndm.Next(0, Languages.Length);
                toLang = rndm.Next(0, Languages.Length);

            } while (fromLang == toLang);

            string translateFrom = (listOfWords[randomWord].Translations[fromLang].ToString());
            string translateTo = (listOfWords[randomWord].Translations[toLang].ToString());
            return new Word(fromLang, toLang, translateFrom, translateTo);
        }

        public void List(int sortByTranslation, Action<string[]> showTranslations)
        {
            var sortedList = listOfWords.OrderBy(s => s.Translations[sortByTranslation]).ToArray();
            foreach (Word word in sortedList)
            {
                showTranslations(word.Translations);
            }
        }
    }
}
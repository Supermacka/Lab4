using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using Labb4_Library;
using Microsoft.SqlServer.Server;

namespace Labb4_ConsoleApp
{

    class Program
    {

        static void Main(string[] args)
        {
            WordList loadList;

            if (args.Length == 0)
            {
                DefaultOutput();
            }
            else
            {
                switch (args[0].ToLower())
                {
                    case "-lists":
                        ListsFunction();
                        break;

                    case "-new":
                        try
                        {
                            NewFunction(args[1], args.Skip(2).ToArray());
                            break;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("You did not specify <listName> or <languages> for the list!");
                            Console.WriteLine();
                            break;
                        }

                    case "-add":
                        try
                        {
                            loadList = WordList.LoadList(args[1]);
                            AddFunction(loadList, args[1]);
                            break;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("You did not specify a <listName>!");
                            Console.WriteLine();
                            break;
                        }

                    case "-remove":
                        try
                        {
                            loadList = WordList.LoadList(args[1]);
                            RemoveFunction(loadList, args[2], args.Skip(3).ToArray(), args[1]);
                            break;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("You did not specify a <listName> or <words>!");
                            Console.WriteLine();
                            break;
                        }

                    case "-words":
                        try
                        {
                            if (args.Length < 3)
                            {
                                loadList = WordList.LoadList(args[1]);
                                WordsFunction(loadList, args[1]);
                                break;
                            }
                            else
                            {
                                loadList = WordList.LoadList(args[1]);
                                WordsFunctionByLanguage(loadList, args[2], args[1]);
                                break;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("You did not specify <listName> or <sortByLanguage>!");
                            Console.WriteLine();
                            break;
                        }

                    case "-count":
                        try
                        {
                            loadList = WordList.LoadList(args[1]);
                            CountFunction(loadList, args[1]);
                            break;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("You did not specify a <list name>!");
                            Console.WriteLine();
                            break;
                        }

                    case "-practice":
                        try
                        {
                            loadList = WordList.LoadList(args[1]);
                            PracticeFunction(loadList, args[1]);
                            break;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("You did not specify a <list name>!");
                            Console.WriteLine();
                            break;
                        }

                    default:
                        Console.WriteLine($"There is no argumnet named \"{args[0]}\"");
                        Console.WriteLine();
                        DefaultOutput();
                        break;
                }
            }
        }

        public static void DefaultOutput()
        {
            Console.WriteLine("What would you like to do? ");
            Console.WriteLine("-lists");
            Console.WriteLine("-new <list name> <language 1> <language 2> .. <language n>");
            Console.WriteLine("-add <list name>");
            Console.WriteLine("-remove <list name> <language> <word 1> <word 2> .. <word n>");
            Console.WriteLine("-words <listname> <sortByLanguage>");
            Console.WriteLine("-count <listname>");
            Console.WriteLine("-practice <listname>");
            Console.WriteLine();
        }

        public static void ListsFunction()
        {
            int listCount = WordList.GetLists().Length;
            Console.WriteLine($"There are [{listCount}]lists:");
            for (int i = 0; i < WordList.GetLists().Length; i++)
            {
                Console.WriteLine($"{i+1}:  {WordList.GetLists()[i]}");
            }
            Console.WriteLine();
        }

        public static void NewFunction(string listName, string[] languages)
        {
            if (Array.Exists(WordList.GetLists(), s => s == listName))
            {
                Console.WriteLine($"A list with the name [{listName}] already exists!");
                Console.WriteLine("You can use the command '-add' to add new words to that list.");
                Console.WriteLine();
                return;
            }

            if (languages.Length < 2)
            {
                Console.WriteLine("Specify at least two languages for the list!");
                Console.WriteLine();
                return;
            }

            WordList newWordList = new WordList(listName, languages);
            newWordList.Save();
            AddFunction(newWordList, listName);
        }

        public static void RemoveFunction(WordList loadList, string language, string[] words, string listName)
        {
            if (loadList == null)
            {
                Console.WriteLine($"There is no list with the name [{listName}]!");
                Console.WriteLine("Make sure you spelled everything corectly.");
                Console.WriteLine("Use command \"-lists\" to see the names of all the lists");
                Console.WriteLine();
                return;
            }
            if (!Array.Exists(loadList.Languages, element => element == language.ToUpper()))
            {
                Console.WriteLine($"There is no language [{language}] in list [{listName}]!");
                Console.WriteLine();
                return;
            }
            if (words.Length == 0)
            {
                Console.WriteLine($"You did not specify a word to remove!");
                Console.WriteLine();
                return;
            }

            int translation = 0;
            foreach (string listLanguage in loadList.Languages)
            {
                int index = 0;
                if (Array.Equals(listLanguage, language))
                {
                    translation = index;
                }
                else
                {
                    index++;
                }
            }

            int removeCount = 0;
            List<string> removedWords = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                if (loadList.Remove(translation, words[i]) == true)
                {
                    removeCount++;
                    removedWords.Add(words[i]);
                }
                else
                {
                    Console.WriteLine($"There is no word [{words[i]}], in [{loadList.Name}]");
                }
            }
            Console.WriteLine($"[{removeCount}] words were removed from [{loadList.Name}]:");
            if (removedWords.Count != 0)
            {
                removedWords.ForEach(s => Console.WriteLine($"-{s}"));
            }
        }

        public static void CountFunction(WordList loadList, string listName)
        {
            if (loadList == null)
            {
                Console.WriteLine($"There is no list with the name [{listName}]!");
                Console.WriteLine("Make sure you spelled everything corectly.");
                Console.WriteLine("Use command \"-lists\" to see the names of all the lists");
                return;
            }
            Console.WriteLine($"There are [{loadList.Count()}]words in list [{listName}]");
            Console.WriteLine();
        }

        public static void AddFunction(WordList loadList, string listName)
        {
            if (loadList == null)
            {
                Console.WriteLine($"There is no list with the name [{listName}]!");
                Console.WriteLine("Make sure you spelled everything corectly.");
                Console.WriteLine("Use command \"-lists\" to see the names of all the lists");
                Console.WriteLine();
                return;
            }

            string userInput;
            bool isEmpty = false;
            int countTranslation = 0;
            string[] translationsContainer = new string[loadList.Languages.Length];
            do
            {
                Console.Write($"1. Add a new word [{loadList.Languages[0]}]: ");
                userInput = Console.ReadLine();
                if (userInput == "")
                {
                    Console.WriteLine($"[{countTranslation}] NEW word/s were added to list [{loadList.Name}]");
                    Console.WriteLine();
                    return;
                }
                translationsContainer[0] = userInput;

                for (int i = 1; i < loadList.Languages.Length; i++)
                {
                    Console.Write($"2. Translate the word to [{loadList.Languages[i]}]: ");
                    userInput = Console.ReadLine();
                    if (userInput == "")
                    {
                        isEmpty = true;
                        break;
                    }
                    translationsContainer[i] = userInput;
                }
                if (isEmpty == true)
                {
                    Console.WriteLine($"[{countTranslation}] NEW word/s were added to list [{loadList.Name}]");
                    Console.WriteLine();
                    return;
                }

                loadList.Add(translationsContainer);
                loadList.Save();
                countTranslation++;

            } while (userInput != "");
        }

        public static void WordsFunction(WordList loadList, string listName)
        {
            if (loadList == null)
            {
                Console.WriteLine($"There is no list with the name [{listName}]!");
                Console.WriteLine("Make sure you spelled everything corectly.");
                Console.WriteLine("Use command \"-lists\" to see the names of all the lists");
                Console.WriteLine();
                return;
            }

            string sortByLanguage = loadList.Languages[0];
            foreach (string language in loadList.Languages)
            {
                if (string.Equals(sortByLanguage.ToUpper(), language))
                {
                    for (int i = 0; i < 1; i++)
                    {
                        for (int j = 0; j < loadList.Languages.Length; j++)
                        {
                            Console.Write($"{loadList.Languages[j], -20}");
                        }
                        Console.WriteLine();
                    }
                    loadList.List(Array.IndexOf(loadList.Languages, language), (x =>
                    {
                        for (int i = 0; i < loadList.Languages.Length; i++)
                        {
                            Console.Write($"{ x[i], -20}");
                        }
                        Console.WriteLine();
                    }));
                    return;
                }
            }
        }

        public static void WordsFunctionByLanguage(WordList loadList, string sortByLanguage, string listName)
        {
            if (loadList == null)
            {
                Console.WriteLine($"There is no list with the name [{listName}]!");
                Console.WriteLine("Make sure you spelled everything corectly.");
                Console.WriteLine("Use command \"-lists\" to see the names of all the lists");
                Console.WriteLine();
                return;
            }

            foreach (string language in loadList.Languages)
            {
                if (string.Equals(sortByLanguage.ToUpper(), language))
                {
                    for (int i = 0; i < 1; i++)
                    {
                        for (int j = 0; j < loadList.Languages.Length; j++)
                        {
                            Console.Write($"{loadList.Languages[j],-20}");
                        }
                        Console.WriteLine();
                    }
                    loadList.List(Array.IndexOf(loadList.Languages, language), (x =>
                    {
                        for (int i = 0; i < loadList.Languages.Length; i++)
                        {
                            Console.Write($"{ x[i],-20}");
                        }
                        Console.WriteLine();
                    }));
                    return;
                }
            }
            Console.WriteLine($"Could not find language [{sortByLanguage.ToUpper()}] in list [{loadList.Name}]");
            Console.WriteLine("Make sure the language is spelled correctly.");
            Console.WriteLine();
        }

        public static void PracticeFunction(WordList loadList, string listName)
        {
            if (loadList == null)
            {
                Console.WriteLine($"There is no list with the name [{listName}]!");
                Console.WriteLine("Make sure you spelled everything corectly.");
                Console.WriteLine("Use command \"-lists\" to see the names of all the lists");
                Console.WriteLine();
                return;
            }
            if (loadList.Count() <= 0)
            {
                Console.WriteLine($"There are [0] words in this list!");
                Console.WriteLine();
                return;
            }

            Console.WriteLine($"- Word Practice -");
            int count = 0;
            int correctAnswers = 0;
            for (int i = 0; i < loadList.Count(); i++)
            {
                Console.WriteLine($"-Practiced {count}/{loadList.Count()}words");

                string fromLang = loadList.Languages[loadList.GetWordToPractice().FromLanguage];
                string fromWord = loadList.GetWordToPractice().Translations[0];
                string toLang = loadList.Languages[loadList.GetWordToPractice().ToLanguage];
                string toWord = loadList.GetWordToPractice().Translations[1];
                Console.Write($"Translate the {fromLang} word \'{fromWord}\', to {toLang}: ");
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "")
                {
                    break;
                }

                if (userInput == toWord)
                {
                    Console.WriteLine("That's correct!");
                    correctAnswers++;
                }
                else
                {
                    Console.WriteLine("That's not quite right.");
                    Console.WriteLine($"The correct answer is \'{toWord}\'");
                }
                count++;
            }
            float result = ((float)correctAnswers / count) * 100;
            Console.WriteLine();
            Console.WriteLine($"You practiced {count}/{loadList.Count()}words");
            Console.WriteLine($"Score: {(int)result}%");
        }
    }
}

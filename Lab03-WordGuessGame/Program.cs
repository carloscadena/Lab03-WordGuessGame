using System;
using System.IO;

namespace Lab03_WordGuessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../wordlist.txt";
            Console.WriteLine("Hello World!");
            CreateWordList(path);
            ReadWordsFromFile(path);
            AddNewWord(path, "blahblahblah");
            AddNewWord(path, "something new");
            DeleteWordFromFile(path, "something new");
        }
        //static void UserMenu()
        //{
        //    Console.WriteLine("Welcome to my Word Guess Game!");
        //    Console.WriteLine("Please select an option:");
        //    Console.WriteLine("1) Start a game");
        //    Console.WriteLine("2) Admin");
        //    Console.WriteLine("3) Exit");
        //}
        static void CreateWordList(string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    try
                    {
                        sw.Write("Hi hello how are you");
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        sw.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // Close the file
            }
        }
        static string[] ReadWordsFromFile(string path)
        {
            try
            {
                string[] myWords = File.ReadAllLines(path);
                for (int i = 0; i < myWords.Length; i++)
                {
                    Console.WriteLine(myWords[i]);
                }
                return myWords;
            }
            catch (Exception)
            {
                throw;
            }
        }
        static void AddNewWord(string path, string newWord)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(newWord);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        static void DeleteWordFromFile(string path, string lineToRemove)
        {
            // needs some error handling
            string[] currentWords = ReadWordsFromFile(path);
            string[] newWords = new string[currentWords.Length - 1];
            for (int i = 0; i < currentWords.Length; i++)
            {
                if (lineToRemove != currentWords[i])
                {
                    newWords[i] = currentWords[i]; 
                }
            }
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    for (int i = 0; i < newWords.Length; i++)
                    {
                        sw.WriteLine(newWords[i]);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

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
            CreateFile(path);
            ReadFile(path);
        }
        //static void UserMenu()
        //{
        //    Console.WriteLine("Welcome to my Word Guess Game!");
        //    Console.WriteLine("Please select an option:");
        //    Console.WriteLine("1) Start a game");
        //    Console.WriteLine("2) Admin");
        //    Console.WriteLine("3) Exit");
        //}
        static void CreateFile(string path)
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
        static string[] ReadFile(string path)
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
    }
}

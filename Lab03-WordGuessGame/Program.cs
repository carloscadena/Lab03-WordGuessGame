using System;
using System.IO;

namespace Lab03_WordGuessGame
{
    public class Program
    {
        public static string path = "../../../wordlist.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CreateWordList(path);
            
            AddNewWord(path, "chocolate");
            AddNewWord(path, "seattle");
            AddNewWord(path, "codefellows");
            AddNewWord(path, "city");
            UserMenu();
        }
        static void UserMenu()
        {
            Console.WriteLine("Welcome to my Word Guess Game!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1) Start a game");
            Console.WriteLine("2) Admin");
            Console.WriteLine("3) Exit");
            HandleUserChoice();
        }
        static void HandleUserChoice()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    RunGame();
                    break;
                case "2":
                    RunAdmin();
                    break;
                case "3":
                    Console.WriteLine("Thanks for playing!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    UserMenu();
                    break;
            }
        }
        static void RunGame()
        {
            int guessesLeft = 10;
            string[] wordList = ReadWordsFromFile(path);
            int index = RandomNumber(1, wordList.Length - 1);
            string word = wordList[index];
            string incorrectGuesses = "";
            string correctGuesses = "";
            string displayWord = "_";
            foreach (char letter in word)
            {
                Console.Write("_ ");
            }
            
            while(guessesLeft > 0)
            {
                displayWord = "";
                Console.WriteLine($"You can guess incorrectly {guessesLeft} more times");
                Console.WriteLine($"Letters you've guessed: {incorrectGuesses}");
                char input = Convert.ToChar(Console.ReadLine());
                if (word.Contains(input))
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (input == word[i])
                        {
                            correctGuesses += input;
                            displayWord += input.ToString();
                            Console.Write(input + " ");
                        }
                        else if (correctGuesses.Contains(word[i]))
                        {
                            displayWord += word[i];
                            Console.Write(word[i] + " ");
                        }
                        else
                        {
                            displayWord += "_";
                            Console.Write("_ ");
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (correctGuesses.Contains(word[i]))
                        {
                            displayWord += word[i];
                            Console.Write(word[i] + " ");
                        }
                        else
                        {
                            Console.Write("_ ");
                        }
                    }
                    displayWord += "_";
                    incorrectGuesses += input;
                    guessesLeft--;
                }
                if (!displayWord.Contains("_"))
                {
                    break;
                }
            }
            if (displayWord.Contains("_"))
            {
                Console.WriteLine("\n\nBetter luck next time!\n\n");
                UserMenu();
            }
            else
            {
                Console.WriteLine("\n\nGreat job! You've won the game!\n\n");
                UserMenu();
            }
        }
        
        // Generate a random number between two numbers
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        static void RunAdmin()
        {
            Console.WriteLine("What would you like to do");
            Console.WriteLine("1) View all words");
            Console.WriteLine("2) Add a word");
            Console.WriteLine("3) Delete a word");
            Console.WriteLine("4) Back to main menu");
            HandleAdminChoice();
        }

        static void HandleAdminChoice()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    string[] words = ReadWordsFromFile(path);
                    foreach (string word in words)
                    {
                        Console.WriteLine(word);
                    }
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    RunAdmin();
                    break;
                case "2":
                    Console.WriteLine("Which word would you like to add?");
                    input = Console.ReadLine();
                    AddNewWord(path, input);
                    Console.WriteLine("Word successfully added.");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    RunAdmin();
                    break;
                case "3":
                    Console.WriteLine("Which word would you like to delete?");
                    input = Console.ReadLine();
                    DeleteWordFromFile(path, input);
                    Console.WriteLine("Word successfully deleted.");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    RunAdmin();
                    break;
                case "4":
                    UserMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    RunAdmin();
                    break;
            }
        }

        public static void CreateWordList(string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    try
                    {
                        sw.Write("software\n");
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
        public static string[] ReadWordsFromFile(string path)
        {
            try
            {
                string[] myWords = File.ReadAllLines(path);
                return myWords;
            }
            catch (Exception)
            {
                throw;
            }
        }
        static void WriteWordsListToConsole(string[] words)
        {
            for (int i = 0; i< words.Length; i++)
                {
                    Console.WriteLine(words[i]);
                }
}
        public static void AddNewWord(string path, string newWord)
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
            string[] currentWords = ReadWordsFromFile(path);
            string[] newWords = new string[currentWords.Length - 1];
            int count = 0;
            for (int i = 0; i < currentWords.Length; i++)
            {
                if (lineToRemove != currentWords[i])
                {
                    newWords[count] = currentWords[i];
                    count++;
                }
            }
            try
            {
                File.WriteAllText(path, "");
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

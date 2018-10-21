using System;
using System.IO;
using Xunit;
using static Lab03_WordGuessGame.Program;

namespace WordGuessGame_Test
{
    public class UnitTest1
    {
        [Fact]
        public void CreateNewFileTest()
        {
            CreateWordList(path);
            Assert.True(File.Exists(path) == true);
        }

        [Fact]
        public void UpdateFileTest()
        {
            AddNewWord(path, "blahblah");
            string[] test = ReadWordsFromFile(path);
            Assert.True(test[test.Length - 1] == "blahblah");
        }

        [Fact]
        public void FileCanBeDeletedTest()
        {
            File.Delete(path);
            Assert.False(File.Exists(path) == true);
        }

        [Fact]
        public void NewWordCanBeAddedTest()
        {
            AddNewWord(path, "anewword");
            string[] test = ReadWordsFromFile(path);
            Assert.True(test[test.Length - 1] == "anewword");
        }

        [Fact]
        public void ReadAllWordsFromFileTest()
        {
            AddNewWord(path, "blah");
            string[] test = ReadWordsFromFile(path);
            Assert.True(test.Length == 2);
        }

        [Fact]
        public void WordRetrievedContainsCertainLetterTest()
        {
            AddNewWord(path, "apples");
            string[] test = ReadWordsFromFile(path);
            string word = test[test.Length - 1];
            Assert.Contains("a", word);
        }

    }
}

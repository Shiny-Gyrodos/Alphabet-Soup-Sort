﻿using System;

namespace MyApp
{
    class WordsAndValues
    {
        public int value;
        public string word;

        public WordsAndValues(int value, string word)
        {
            this.value = value;
            this.word = word;
        }
    }

    //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    internal class Program
    {
        static List<WordsAndValues> wordsAndValues = new List<WordsAndValues>();
        static List<int> valueList = new List<int>();
        static List<string> wordList = new List<string>();
        static char[] charStorage = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
                                   //0^   1^   2^   3^   4^   5^   6^   7^   8^   9^  10^  11^  12^  13^  14^  15^  16^  17^  18^  19^  20^  21^  22^  23^  24^  25^
        static void Main(string[] args)
        {
            int amountOfWords = GetWordCount();
            string[] wordCollection = GetWords(amountOfWords);
            int[] valueCollection = GetWordValue(wordCollection, amountOfWords);
            SortWords(wordCollection, valueCollection);

            Console.Clear();
            Console.WriteLine("Here are the words sorted.\n");

            foreach(string word in wordList)
            {
                Console.Write(word + " "); // Bug will sometimes print a word twice.
            }

            Console.ReadKey();
        }

        //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

        static void SortWords(string[] wordCollection, int[] valueCollection) // Sorts the words
        {
            for (int i = 0; i < wordCollection.Length; i++)
            {
                wordsAndValues.Add(new WordsAndValues(valueCollection[i], wordCollection[i]));
                valueList.Add(wordsAndValues[i].value);
            }

            valueList.Sort();

            for (int i = 0; i < valueList.Count; i++)
            {
                for (int j = 0; j < wordsAndValues.Count; j++)
                {
                    if (wordsAndValues[j].value == valueList[i])
                    {
                        wordList.Add(wordsAndValues[j].word);
                        valueList.Remove(i); // Shortens search.
                        wordsAndValues[j].value = -1; // Makes sure the same word won't be added twice.
                        j = wordsAndValues.Count; // Shortens search.
                    }
                }
            }
        }

        //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

        static int[] GetWordValue(string[] wordCollection, int amountOfWords) //  Returns the word's values
        {
            int[] valueCollection = new int[amountOfWords];

            for (int i = 0; i < wordCollection.Length; i++)
            {
                int charCount = 0;

                foreach(char character in wordCollection[i])
                {
                    int charLocation = Array.IndexOf(charStorage, character);
                    valueCollection[i] += charLocation;
                    charCount++;
                }

                valueCollection[i] /= charCount;
            }

            return valueCollection;
        }

        //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

        static string[] GetWords(int amountOfWords) // Retruns the words that are to be sorted.
        {
            string[] wordCollection = new string[amountOfWords];

            Console.WriteLine("Input your desired words one-by-one.");

            for (int i = 0; i < amountOfWords; i++)
            {
                int validCharCount = 0;

                try
                {
                    string wordTyped = Console.ReadLine().ToLower();

                    foreach(char character in wordTyped)
                    {
                        if(Char.IsLetter(character))
                        for(int j = 0; j < charStorage.Length; j++)
                        {
                            if (character == charStorage[j])
                            {
                                validCharCount++;
                                j = charStorage.Length;
                            }
                        }
                    }

                    if (validCharCount != wordTyped.Length)
                    {
                        throw new NotImplementedException();
                    }

                    wordCollection[i] = wordTyped;
                }
                catch  // Catch block for if you enter Ctrl-Z or an invalid character.
                {
                    Console.WriteLine("Make sure your words are composed soley of valid characters.");
                    i--;
                }
            }

            return wordCollection;
        }

        //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

        static int GetWordCount() // Returns the amount of words that will be sorted.
        {
            bool validChoiceMade = false;
            int amountOfWords = 0;

            Console.WriteLine("Enter in the amount of words you want to sort.");

            do
            {
                try
                {
                    amountOfWords = int.Parse(Console.ReadLine());
                    validChoiceMade = true;
                }
                catch
                {
                    Console.WriteLine("Numbers only.");
                }      
            } while (!validChoiceMade);

            return amountOfWords;
        }
    }
}
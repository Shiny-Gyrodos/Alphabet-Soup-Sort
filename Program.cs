using System;

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
    internal class Program
    {
        static List<WordsAndValues> wordsAndValues = new List<WordsAndValues>();
        static List<int> valueList = new List<int>();
        static List<string> wordList = new List<string>();
        static char[] CharStorage = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
                                   //0^   1^   2^   3^   4^   5^   6^   7^   8^   9^  10^  11^  12^  13^  14^  15^  16^  17^  18^  19^  20^  21^  22^  23^  24^  25^
        static void Main(string[] args)
        {
            int amountOfWords = GetWordCount();
            string[] wordCollection = GetWords(amountOfWords);
            int[] valueCollection = GetWordValue(wordCollection, amountOfWords);
            SortWords(wordCollection, valueCollection);

            foreach(string word in wordList)
            {
                Console.Write(word + " ");
            }

            Console.ReadKey();
        }



        static void SortWords(string[] wordCollection, int[] valueCollection)
        {
            for (int i = 0; i < wordCollection.Length; i++)
            {
                wordsAndValues.Add(new WordsAndValues(valueCollection[i], wordCollection[i]));
                valueList.Add(wordsAndValues[i].value);
            }

            valueList.Sort();

            foreach(int value in valueList)
            {
                for (int i = 0; i < wordsAndValues.Count(); i++)
                {
                    if (wordsAndValues[i].value == valueList[value]) // Throws argument out of range exception.
                    {
                        wordList.Add(wordsAndValues[i].word);
                    }
                }
            }
        }



        static int[] GetWordValue(string[] wordCollection, int amountOfWords)
        {
            int[] valueCollection = new int[amountOfWords];

            for (int i = 0; i < wordCollection.Length; i++)
            {
                foreach(char character in wordCollection[i])
                {
                    int charLocation = Array.IndexOf(CharStorage, character);
                    valueCollection[i] += charLocation;
                }
            }

            foreach (int value in valueCollection)
            {
                Console.Write(value + " ");
            }

            return valueCollection;
        }



        static string[] GetWords(int amountOfWords)
        {
            string[] wordCollection = new string[amountOfWords];

            Console.WriteLine("Input your desired words one-by-one.");

            for (int i = 0; i < amountOfWords; i++)
            {
                try
                {
                    string wordTyped = Console.ReadLine().ToLower();
                    wordCollection[i] = wordTyped;
                }
                catch
                {
                    Console.WriteLine("Make sure your words are composed soley of valid characters.");
                }
            }

            return wordCollection;
        }



        static int GetWordCount()
        {
            bool validChoiceMade = false;
            int amountOfWords = 0;

            Console.WriteLine("Enter in the amount of words you want to sort.");

            do
            {
                try
                {
                    amountOfWords = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Numbers only.");
                }

                validChoiceMade = true;       

            } while (!validChoiceMade);

            return amountOfWords;
        }
    }
}
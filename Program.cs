using System;

namespace MyApp
{
    internal class Program
    {
        static char[] CharStorage = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        static void Main(string[] args)
        {
            int amountOfWords = GetWordCount();
            string[] wordCollection = GetWords(amountOfWords);
            int[] wordValue = GetWordValue(wordCollection, amountOfWords);
            Console.ReadKey();
        }



        static int[] GetWordValue(string[] wordCollection, int amountOfWords)
        {
            int[] wordValue = new int[amountOfWords];

            for (int i = 0; i < wordCollection.Length; i++)
            {
                foreach(char character in wordCollection[i])
                {
                    int charLocation = Array.IndexOf(CharStorage, character);
                    wordValue[i] += charLocation;
                }
            }

            return wordValue;
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
                    amountOfWords = int.Parse(Console.ReadLine().ToString());
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
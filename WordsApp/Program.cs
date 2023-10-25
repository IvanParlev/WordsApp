namespace WordsApp
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter your text:");
            string input = Console.ReadLine();

            int wordCount = CountWords(input);
            Console.WriteLine($"The count of all words is {wordCount}");

            string shortestWord = ShortestWord(input);
            Console.WriteLine($"The shortest word in the text is: {shortestWord}");

            string longestWord = LongestWord(input);
            Console.WriteLine($"The longest word in the text is: {longestWord}");

            if (wordCount >= 1)
            {
                int averageWordLength = AverageWordLength(input) / wordCount;
                Console.WriteLine($"The average word length in the text is: {averageWordLength}");
            }
            else
            {
                Console.WriteLine($"The average word length in the text is: There are no words");
            }

            Dictionary<string, int> wordFrequencies = GetWordFrequencies(input);
            List<string> mostCommonWords = GetMostCommonWords(wordFrequencies, 5);

            Console.WriteLine("Five most common words in the text are:");
            foreach (string word in mostCommonWords)
            {
                Console.WriteLine($"{word}: {wordFrequencies[word]} times");
            }

            List<string> leastCommonWords = GetLeastCommonWords(wordFrequencies, 5);

            Console.WriteLine("Five least common words in the text are:");
            foreach (string word in leastCommonWords)
            {
                Console.WriteLine($"{word}: {wordFrequencies[word]} times");
            }
        }

        static int CountWords(string text)
        {
            string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r', '.' }, StringSplitOptions.RemoveEmptyEntries);
            int wordsCount = 0;

            if (string.IsNullOrWhiteSpace(text))
            {
                return 0;
            }

            foreach (string word in words)
            {
                if (word.Length >= 3)
                {
                    wordsCount++;
                }
            }

            return wordsCount;
        }

        static string ShortestWord(string text)
        {
            string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r', '.', '"', '-', '_' }, StringSplitOptions.RemoveEmptyEntries);
            string shortestWord = string.Empty;

            if (string.IsNullOrWhiteSpace(text))
            {
                return "There are no words";
            }

            foreach (string word in words)
            {
                if (word.Length >= 3)
                {
                    if (shortestWord == string.Empty)
                    {
                        shortestWord = word;
                    }
                    if (word.Length < shortestWord.Length)
                    {
                        shortestWord = word;
                    }
                }
            }
            if (shortestWord == string.Empty)
            {
                return "There are no words.";
            }

            return shortestWord;
        }

        static string LongestWord(string text)
        {
            string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r', '.', '"', '-', '_' }, StringSplitOptions.RemoveEmptyEntries);
            string longestWord = string.Empty;

            if (string.IsNullOrWhiteSpace(text))
            {
                return "There are no words";
            }

            foreach (string word in words)
            {
                if (word.Length >= 3)
                {
                    if (longestWord == string.Empty)
                    {
                        longestWord = word;
                    }
                    if (word.Length > longestWord.Length)
                    {
                        longestWord = word;
                    }
                }
            }
            if (longestWord == string.Empty)
            {
                return "There are no words.";
            }
            return longestWord;
        }

        static int AverageWordLength(string text)
        {
            string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', '"', '-', '_' }, StringSplitOptions.RemoveEmptyEntries);
            int average = 0;

            if (string.IsNullOrWhiteSpace(text))
            {
                return 0;
            }

            foreach (string word in words)
            {
                if (word.Length >= 3)
                {
                    average += word.Length;
                }
            }

            return average;
        }

        static Dictionary<string, int> GetWordFrequencies(string text)
        {
            string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', '"', '-', '_' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> wordFrequencies = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (word.Length >= 3)
                {
                    if (wordFrequencies.ContainsKey(word))
                    {
                        wordFrequencies[word]++;
                    }
                    else
                    {
                        wordFrequencies[word] = 1;
                    }
                }
            }

            return wordFrequencies;
        }

        static List<string> GetMostCommonWords(Dictionary<string, int> wordFrequencies, int count)
        {
            List<string> mostCommonWords = new List<string>();
            foreach (var pair in wordFrequencies)
            {
                if (mostCommonWords.Count < count)
                {
                    mostCommonWords.Add(pair.Key);
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (wordFrequencies[mostCommonWords[i]] < pair.Value)
                        {
                            mostCommonWords.Insert(i, pair.Key);
                            mostCommonWords.RemoveAt(count);
                            break;
                        }
                    }
                }
            }
            return mostCommonWords;
        }

        static List<string> GetLeastCommonWords(Dictionary<string, int> wordFrequencies, int count)
        {
            List<string> leastCommonWords = new List<string>();
            foreach (var pair in wordFrequencies)
            {
                if (leastCommonWords.Count < count)
                {
                    leastCommonWords.Add(pair.Key);
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (wordFrequencies[leastCommonWords[i]] > pair.Value)
                        {
                            leastCommonWords.Insert(i, pair.Key);
                            leastCommonWords.RemoveAt(count);
                            break;
                        }
                    }
                }
            }
            return leastCommonWords;
        }
    }
}
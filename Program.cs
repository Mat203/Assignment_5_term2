static void Main()
{
    string[] wordList = File.ReadAllLines("words.txt");
    
    List<string> WordsWithTypos()
    {
        Console.Write("Write a sentence: ");
        string input = Console.ReadLine();
        for (int i = 0; i < input.Length; i++)
        {
            char s = input[i];
            if (s == '.' || s == ',' || s == ';' || s == ':' || s == '-' || s == '!' || s == '?')
            {
                input = input.Remove(i, 1);
                i--;
            }
        }

        string[] words = input.Split(" ");
        
        List<string> typosMistakes = new List<string>();

        foreach (string word in words)
        {
            if (!wordList.Contains(word.ToLower()) & !wordList.Contains(word))
            {
                typosMistakes.Add(word);
            }
        }

        if (typosMistakes.Count > 0)
        {
            Console.Write("Looks like you have typos in next words: ");
            Console.WriteLine(string.Join(", ", typosMistakes));
        }

        return typosMistakes;

    }
    

    int LevenshteinMatvii(string original, string candidate)
    {
        int n = original.Length;
        int m = candidate.Length;
        int[,] matrix = new int[n + 1, m + 1];

        if (n == 0)
            return m;
        if (m == 0)
            return n;

        for (int i = 0; i <= n; i++)
        {
            matrix[i, 0] = i;
        }

        for (int j = 0; j <= m; j++)
        {
            matrix[0, j] = j;
        }

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                int cost;
                if (candidate[j - 1] == original[i - 1])
                {
                    cost = 0;
                }
                else
                {
                    cost = 1;
                }

                matrix[i, j] = Math.Min(
                    Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                    matrix[i - 1, j - 1] + cost);
            }
        }

        return matrix[n, m];
    }

    void FindBestMatchesMatvii(string input, string[] dictionary)
    {
        PriorityQueue<string, int> candidates = new PriorityQueue<string, int>();
        foreach (string word in dictionary)
        {
            int distance = LevenshteinMatvii(input, word);
            candidates.Enqueue(word, distance);
        }

        Queue<string> bestMatches = new Queue<string>();
        while (candidates.Count > 0)
        {
            bestMatches.Enqueue(candidates.Dequeue());
        }

        bestMatches.Reverse();

        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine(bestMatches.Dequeue());
        }
    }
    
    foreach (var word in WordsWithTypos())
    {
        Console.WriteLine($"Maybe instead of '{word}' you meant: ");
        FindBestMatchesMatvii(word, wordList);
    }
    



    int LevensteinDistanceVaria(string original, string candidate)
    {
        // preparation stage
        var array = new int[candidate.Length + 1, original.Length + 1];
        for (int i = 0; i <= candidate.Length; i++)
        {
            array[i, 0] = i;
        }

        for (int j = 0; j <= original.Length; j++)
        {
            array[0, j] = j;
        }

        for (int i = 1; i <= candidate.Length; i++)
        {
            for (int j = 1; j <= original.Length; j++)
            {
                array[i, j] = Math.Min(Math.Min(array[i - 1, j] + 1, // deletion
                        array[i, j - 1] + 1), // insertion
                    array[i - 1, j - 1] + IsDifferent(candidate[i - 1], original[j - 1])); //substitution
            }
        }

        return array[candidate.Length, original.Length];

    }

    int IsDifferent(char first, char second)
    {
        return first == second ? 0 : 1;
    }
    
    int LenghtOfTheLongestCommonSubstring(string original, string candidate)
    {
        var array = new int[candidate.Length + 1, original.Length + 1];

        for (int j1 = 0; j1 <= original.Length; j1++)
        {
            array[0, j1] = 0;
        }

        for (int i1 = 0; i1 <= candidate.Length; i1++)
        {
            array[i1, 0] = 0;
        }

        for (int i = 1; i <= candidate.Length; i++)
        {
            for (int j = 1; j <= original.Length; j++)
            {
                char letterCandidate = candidate[i - 1];
                char letterOriginal = original[j - 1];
                // if letters match
                if (letterOriginal == letterCandidate)
                {
                    array[i, j] = array[i - 1, j - 1] + 1;
                }
                else
                {
                    array[i, j] = 0;
                }
            }
        }

        return MaximumNumberInArray(array);
    }

    int MaximumNumberInArray(int[,] array)
    {
        int max = array[0, 0];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                int cur = array[i, j];
                if (cur > max)
                {
                    max = cur;
                }
            }
        }

        return max;
    }
}


Main();


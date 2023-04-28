static void Main()
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

    string[] wordList = File.ReadAllLines("words.txt");
    List<string> typosMistakes = new List<string>();
    
    foreach (string word in words)
    {
            if (!wordList.Contains(word.ToLower()) & !wordList.Contains(word))
            {
                typosMistakes.Add(word);
            }
    }

    if ( typosMistakes.Count > 0)
    {
        Console.Write("Looks like you have typos in next words: ");
        Console.WriteLine(string.Join(", ", typosMistakes));
    }
    
    
    int LenghtOfTheLongestCommonSubstring(string original, string candidate)
    {
        var array = new int[candidate.Length+1, original.Length+1];

        // fill in zeros
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
                char letterCandidate = candidate[i-1];
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

    Console.WriteLine(LenghtOfTheLongestCommonSubstring("varia", "varivaria"));
}


Main();


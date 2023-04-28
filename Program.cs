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
    
}

Main();


// just some comment to check if everything is alright

int LenghtOfTheLongestCommonSubstring(string original, string candidate)
{
    var array = new int[original.Length, candidate.Length];

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
        for (int j = 0; j <= original.Length; j++)
        {
            char letterCandidate = candidate[i-1];
            // if letters match
        }
    }

    return 1;
}
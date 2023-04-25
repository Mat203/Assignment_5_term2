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
            if (!wordList.Contains(word.ToLower()))
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

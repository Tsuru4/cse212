public static class UniqueLettersSolution
{
    public static void Run()
    {
        var test1 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True because all letters unique
        Console.WriteLine(AreUniqueLetters(test1));
        Console.WriteLine(AreUniqueLettersAlternate(test1));

        var test2 = "abcdefghjiklanopqrstuvwxyz"; // Expect False because 'a' is repeated
        Console.WriteLine(AreUniqueLetters(test2));
        Console.WriteLine(AreUniqueLettersAlternate(test2));

        var test3 = "";
        Console.WriteLine(AreUniqueLetters(test3)); // Expect True because its an empty string
        Console.WriteLine(AreUniqueLettersAlternate(test3));
    }

    /**
     * <summary>Determine if there are any duplicate letters in the text provided</summary>
     * <param name="text">Text to check for duplicate letters</param>
     * <returns>true if all letters are unique, otherwise false</returns>
     */
    private static bool AreUniqueLetters(string text)
    {
        var found = new HashSet<char>();
        foreach (var letter in text)
        {
            // Look in set to see if letter was seen before
            if (found.Contains(letter))
                return false;
            // Otherwise we will add it to the set and move on
            found.Add(letter);
        }

        return true;
    }

    /**
     * <summary>Determine if there are any duplicate letters in the text provided</summary>
     * <param name="text">Text to check for duplicate letters</param>
     * <returns>true if all letters are unique, otherwise false</returns>
     */
    private static bool AreUniqueLettersAlternate(string text)
    {
        var unique = new HashSet<char>(text);
        return unique.Count == text.Length;
    }
}
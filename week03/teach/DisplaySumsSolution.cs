public static class DisplaySumsSolution
{
    public static void Run()
    {
        DisplaySumPairs([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);  
        // Should show something like (order does not matter):
        // 6 4
        // 7 3
        // 8 2
        // 9 1 

        Console.WriteLine("------------");
        DisplaySumPairs([-20, -15, -10, -5, 0, 5, 10, 15, 20]);  
        // Should show something like (order does not matter):
        // 10 0
        // 15 -5
        // 20 -10

        Console.WriteLine("------------");
        DisplaySumPairs([5, 11, 2, -4, 6, 8, -1]);
        // Should show something like (order does not matter):
        // 8 2
        // -1 11
    }

    /**
     * <summary>
     * Display pairs of numbers (no duplicates should be displayed) that sum to 
     * 10 using a set in O(n) time.  We are assuming that there are no duplicates 
     * in the list.
     * </summary>
     * <param name="numbers">array of integers</param>
     */
    private static void DisplaySumPairs(int[] numbers)
    {
        var valuesSeen = new HashSet<int>();
        foreach (var n in numbers)
        {
            // If 10-n is in the values_seen set then I know that
            // I have previously seen a number that will sum with n 
            // to equal 10. Print out that pair
            if (valuesSeen.Contains(10 - n))
                Console.WriteLine($"{n} {10-n}");
            // Add this number to the values_seen set
            valuesSeen.Add(n);
        }
    }
}
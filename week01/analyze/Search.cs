using System.Diagnostics;

public static class Search {
    public static void Run() {
        Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15}", "n", "sort1-count", "sort2-count", "sort1-time",
            "sort2-time");
        Console.WriteLine("{0,15}{0,15}{0,15}{0,15}{0,15}", "----------");

        for (int n = 0; n <= 25000; n += 1000) {
            var testData = Enumerable.Range(0, n).ToArray();
            int count1 = SearchSorted1(testData, n);
            int count2 = SearchSorted2(testData, n, 0, testData.Length - 1);
            double time1 = Time(() => SearchSorted1(testData, n), 100);
            double time2 = Time(() => SearchSorted2(testData, n, 0, testData.Length - 1), 100);
            Console.WriteLine("{0,15}{1,15}{2,15}{3,15:0.00000}{4,15:0.00000}", n, count1, count2, time1, time2);
        }
    }

    private static double Time(Action executeAlgorithm, int times) {
        var sw = Stopwatch.StartNew();
        for (var i = 0; i < times; ++i) {
            executeAlgorithm();
        }

        sw.Stop();
        return sw.Elapsed.TotalMilliseconds / times;
    }

    /// <summary>
    /// Search for 'target' in the list 'data'. When its found (or not found) the variable count which represents
    /// the work done in the function is returned.
    /// </summary>
    /// <param name="data">The array of numbers</param>
    /// <param name="target">The number we're looking for</param>
    private static int SearchSorted1(int[] data, int target) {
        var count = 0;
        foreach (var item in data) {
            count += 1;
            if (item == target)
                return count; // Found it
        }

        return count; // Didn't find it
    }

    /// <summary>
    /// Search for 'target' in the list 'data'. When its found (or not found) the variable count which represents
    /// the work done in the function is returned.
    /// </summary>
    /// <param name="data">The array of numbers</param>
    /// <param name="target">The number we're looking for</param>
    /// <param name="start">The index of the starting section of the data to look in</param>
    /// <param name="end">The index of the ending section of the data to look in</param>
    private static int SearchSorted2(int[] data, int target, int start, int end) {
        if (end < start)
            return 1; // All done
        var middle = (end + start) / 2;
        if (data[middle] == target)
            return 1; // Found it
        if (data[middle] < target) // Search in the upper half after index middle
            return 1 + SearchSorted2(data, target, middle + 1, end);
        // Search in the lower half before index middle
        return 1 + SearchSorted2(data, target, start, middle - 1);
    }
}
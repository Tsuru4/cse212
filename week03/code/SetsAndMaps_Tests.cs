using Microsoft.VisualStudio.TestTools.UnitTesting;

// DO NOT MODIFY THIS FILE

[TestClass]
public class FindPairsTests
{
    [TestMethod]
    public void FindPairs_TwoPairs()
    {
        var actual = SetsAndMaps.FindPairs(["am", "at", "ma", "if", "fi"]);
        var expected = new[] { "ma & am", "fi & if" };

        Assert.AreEqual(expected.Length, actual.Length);
        Assert.AreEqual(Canonicalize(expected), Canonicalize(actual));
    }

    [TestMethod]
    public void FindPairs_OnePair()
    {
        var actual = SetsAndMaps.FindPairs(["ab", "bc", "cd", "de", "ba"]);
        var expected = new[] { "ba & ab" };

        Assert.AreEqual(expected.Length, actual.Length);
        Assert.AreEqual(Canonicalize(expected), Canonicalize(actual));
    }

    [TestMethod]
    public void FindPairs_SameChar()
    {
        var actual = SetsAndMaps.FindPairs(["ab", "aa", "ba"]);
        var expected = new[] { "ba & ab" };

        Assert.AreEqual(expected.Length, actual.Length);
        Assert.AreEqual(Canonicalize(expected), Canonicalize(actual));
    }

    [TestMethod]
    public void FindPairs_ThreePairs()
    {
        var actual = SetsAndMaps.FindPairs(["ab", "ba", "ac", "ad", "da", "ca"]);
        var expected = new[] { "ba & ab", "da & ad", "ca & ac" };

        Assert.AreEqual(expected.Length, actual.Length);
        Assert.AreEqual(Canonicalize(expected), Canonicalize(actual));
    }

    [TestMethod]
    public void FindPairs_ThreePairsNumbers()
    {
        var actual = SetsAndMaps.FindPairs(["23", "84", "49", "13", "32", "46", "91", "99", "94", "31", "57", "14"]);
        var expected = new[] { "32 & 23", "94 & 49", "31 & 13" };

        Assert.AreEqual(expected.Length, actual.Length);
        Assert.AreEqual(Canonicalize(expected), Canonicalize(actual));
    }

    [TestMethod]
    public void FindPairs_NoPairs()
    {
        var actual = SetsAndMaps.FindPairs(["ab", "ac"]);
        var expected = new string[0];

        Assert.AreEqual(expected.Length, actual.Length);
        Assert.AreEqual(Canonicalize(expected), Canonicalize(actual));
    }

    // If this test takes longer than 5 seconds to run, your code is too inefficient.
    //  On my machine, this executes in ~200 ms with an efficient implementation.
    [TestMethod, Timeout(5000)]
    public void FindPairs_NoPairs_Efficiency()
    {
        var count = 1_000_000;
        bool done = false;
        var input = new List<string>(count);
        for (char a = (char)0x0; a <= 0xffff; ++a)
        {
            for (char b = (char)0x0; b <= 0xffff; ++b)
            {
                char[] chars = ['a', 'b'];
                string s = new(chars);
                input.Add(s);

                done = input.Count >= count;
                if (done)
                {
                    break;
                }
            }

            if (done)
            {
                break;
            }
        }

        var actual = SetsAndMaps.FindPairs(input.ToArray());
        Assert.AreEqual(0, actual.Length);
    }

    private string Canonicalize(string[] array)
    {
        if (array.Length == 0)
        {
            return "";
        }

        var canonicalString = array.Select(item =>
        {
            var parts = item.Split('&');
            return parts
                .Select(part => part.Trim())
                .OrderBy(x => x)
                .Aggregate((current, next) => current + "&" + next);
        })
        .OrderBy(x => x)
        .Aggregate((current, next) => current + "," + next);

        return canonicalString;
    }
}

[TestClass]
public class SummarizeDegreesTests
{
    [TestMethod]
    public void SummarizeCensusDegrees()
    {
        var result = SetsAndMaps.SummarizeDegrees("../../../census.txt");
        var expected = new Dictionary<string, int> {
            {"Bachelors", 5355},
            {"HS-grad", 10501},
            {"11th", 1175},
            {"Masters", 1723},
            {"9th", 514},
            {"Some-college", 7291},
            {"Assoc-acdm", 1067},
            {"Assoc-voc", 1382},
            {"7th-8th", 646},
            {"Doctorate", 413},
            {"Prof-school", 576},
            {"5th-6th", 333},
            {"10th", 933},
            {"1st-4th", 168},
            {"Preschool", 51},
            {"12th", 433},
        };

        CollectionAssert.AreEqual(expected, result);
    }
}

[TestClass]
public class IsAnagramTests
{
    [TestMethod]
    public void IsAnagram_BasicCases()
    {
        Assert.IsTrue(SetsAndMaps.IsAnagram("CAT", "ACT"));
        Assert.IsFalse(SetsAndMaps.IsAnagram("DOG", "GOOD"));
        Assert.IsFalse(SetsAndMaps.IsAnagram("AABBCCDD", "ABCD"));
        Assert.IsFalse(SetsAndMaps.IsAnagram("ABCCD", "ABBCD"));
        Assert.IsFalse(SetsAndMaps.IsAnagram("BC", "AD"));
    }

    [TestMethod]
    public void IsAnagram_IgnoresCases()
    {
        Assert.IsTrue(SetsAndMaps.IsAnagram("Ab", "Ba"));
    }

    [TestMethod]
    public void IsAnagram_IgnoresSpaces()
    {
        Assert.IsTrue(SetsAndMaps.IsAnagram("tom marvolo riddle", "i am lord voldemort"));
    }

    [TestMethod]
    public void IsAnagram_IgnoresSpacesAndCases()
    {
        Assert.IsTrue(SetsAndMaps.IsAnagram("A Decimal Point", "Im a Dot in Place"));
        Assert.IsTrue(SetsAndMaps.IsAnagram("Eleven plus Two", "Twelve Plus One"));
        Assert.IsFalse(SetsAndMaps.IsAnagram("Eleven plus One", "Twelve Plus One"));
    }

    // If this test takes longer than 5 seconds to run, your code is too inefficient.
    //  On my machine, this executes in ~1 second with an efficient implementation.
    [TestMethod, Timeout(5000)]
    public void IsAnagram_Efficiency()
    {
        var rand = new Random();
        var length = 30_000_000;
        var a_array = new char[length];
        var b_array = new char[length];

        for (int i = 0; i < length; ++i)
        {
            a_array[i] = (char)rand.Next(256);
            b_array[i] = (char)rand.Next(256);
        }

        Assert.IsFalse(SetsAndMaps.IsAnagram(new string(a_array), new string(b_array)));
    }
}

[TestClass]
public class MazeTests
{
    [TestMethod]
    public void Maze_Basic()
    {
        Dictionary<ValueTuple<int, int>, bool[]> map = SetupMazeMap();
        var maze = new Maze(map);
        Assert.AreEqual("Current location (x=1, y=1)", maze.GetStatus());
        AssertThrowsInvalidOperationException(maze.MoveUp);
        AssertThrowsInvalidOperationException(maze.MoveLeft);
        maze.MoveRight();
        AssertThrowsInvalidOperationException(maze.MoveRight);
        maze.MoveDown();
        maze.MoveDown();
        maze.MoveDown();
        maze.MoveRight();
        maze.MoveRight();
        maze.MoveUp();
        maze.MoveRight();
        maze.MoveDown();
        maze.MoveLeft();
        AssertThrowsInvalidOperationException(maze.MoveDown);
        maze.MoveRight();
        maze.MoveDown();
        maze.MoveDown();
        maze.MoveRight();
        Assert.AreEqual("Current location (x=6, y=6)", maze.GetStatus());
    }

    private void AssertThrowsInvalidOperationException(Action action)
    {
        try
        {
            action();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("Can't go that way!", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    private static Dictionary<ValueTuple<int, int>, bool[]> SetupMazeMap()
    {
        Dictionary<ValueTuple<int, int>, bool[]> map = new() {
            { (1, 1), new[] { false, true, false, true } },
            { (1, 2), new[] { false, true, true, false } },
            { (1, 3), new[] { false, false, false, false } },
            { (1, 4), new[] { false, true, false, true } },
            { (1, 5), new[] { false, false, true, true } },
            { (1, 6), new[] { false, false, true, false } },
            { (2, 1), new[] { true, false, false, true } },
            { (2, 2), new[] { true, false, true, true } },
            { (2, 3), new[] { false, false, true, true } },
            { (2, 4), new[] { true, true, true, false } },
            { (2, 5), new[] { false, false, false, false } },
            { (2, 6), new[] { false, false, false, false } },
            { (3, 1), new[] { false, false, false, false } },
            { (3, 2), new[] { false, false, false, false } },
            { (3, 3), new[] { false, false, false, false } },
            { (3, 4), new[] { true, true, false, true } },
            { (3, 5), new[] { false, false, true, true } },
            { (3, 6), new[] { false, false, true, false } },
            { (4, 1), new[] { false, true, false, false } },
            { (4, 2), new[] { false, false, false, false } },
            { (4, 3), new[] { false, true, false, true } },
            { (4, 4), new[] { true, true, true, false } },
            { (4, 5), new[] { false, false, false, false } },
            { (4, 6), new[] { false, false, false, false } },
            { (5, 1), new[] { true, true, false, true } },
            { (5, 2), new[] { false, false, true, true } },
            { (5, 3), new[] { true, true, true, true } },
            { (5, 4), new[] { true, false, true, true } },
            { (5, 5), new[] { false, false, true, true } },
            { (5, 6), new[] { false, true, true, false } },
            { (6, 1), new[] { true, false, false, false } },
            { (6, 2), new[] { false, false, false, false } },
            { (6, 3), new[] { true, false, false, false } },
            { (6, 4), new[] { false, false, false, false } },
            { (6, 5), new[] { false, false, false, false } },
            { (6, 6), new[] { true, false, false, false } }
        };
        return map;
    }
}

[TestClass]
public class EarthquakeDailySummaryTests
{
    [TestMethod]
    public void EarthquakeDailySummary_Basic()
    {
        var result = SetsAndMaps.EarthquakeDailySummary();
        Assert.IsTrue(result.Length > 5, "Too few earthquakes");

        foreach (string s in result)
        {
            Assert.IsTrue(s.Contains(" - Mag "), "String must contain a magnitude");
        }
    }
}
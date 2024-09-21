using Microsoft.VisualStudio.TestTools.UnitTesting;

// DO NOT MODIFY THIS FILE

[TestClass]
public class SumSquaresRecursiveTests
{
    [TestMethod]
    public void SumSquaresRecursive_Small()
    {
        var result = Recursion.SumSquaresRecursive(10);
        Assert.AreEqual(385, result);
    }

    [TestMethod]
    public void SumSquaresRecursive_Large()
    {
        var result = Recursion.SumSquaresRecursive(100);
        Assert.AreEqual(338350, result);
    }
}

[TestClass]
public class PermutationsChooseTests
{
    [TestMethod]
    public void PermutationsChoose_3()
    {
        var results = new List<string>();
        Recursion.PermutationsChoose(results, "ABCD", 3);

        results.Sort();
        var expected = new List<string> {
            "ABC",
            "ABD",
            "ACB",
            "ACD",
            "ADB",
            "ADC",
            "BAC",
            "BAD",
            "BCA",
            "BCD",
            "BDA",
            "BDC",
            "CAB",
            "CAD",
            "CBA",
            "CBD",
            "CDA",
            "CDB",
            "DAB",
            "DAC",
            "DBA",
            "DBC",
            "DCA",
            "DCB"
        };
        CollectionAssert.AreEqual(expected, results);
    }

    [TestMethod]
    public void PermutationsChoose_2()
    {
        var results = new List<string>();
        Recursion.PermutationsChoose(results, "ABCD", 2);

        results.Sort();
        var expected = new List<string> {
            "AB",
            "AC",
            "AD",
            "BA",
            "BC",
            "BD",
            "CA",
            "CB",
            "CD",
            "DA",
            "DB",
            "DC"
        };
        CollectionAssert.AreEqual(expected, results);
    }

    [TestMethod]
    public void PermutationsChoose_1()
    {
        var results = new List<string>();
        Recursion.PermutationsChoose(results, "ABCD", 1);

        results.Sort();
        var expected = new List<string> {
            "A",
            "B",
            "C",
            "D"
        };
        CollectionAssert.AreEqual(expected, results);
    }
}

[TestClass]
public class CountWaysToClimbTests
{
    [TestMethod]
    public void CountWaysToClimb_Small()
    {
        var result = Recursion.CountWaysToClimb(5);
        Assert.AreEqual(13, result);
    }

    [TestMethod]
    public void CountWaysToClimb_Medium()
    {
        var result = Recursion.CountWaysToClimb(20);
        Assert.AreEqual(121415, result);
    }

    [TestMethod, Timeout(5000)]
    public void CountWaysToClimb_Large()
    {
        var result = Recursion.CountWaysToClimb(100);
        Assert.AreEqual(180396380815100901214157639M, result);
    }
}

[TestClass]
public class WildcardBinaryTests
{
    [TestMethod]
    public void WildcardBinary_6_Long()
    {
        var results = new List<string>();
        Recursion.WildcardBinary("110*0*", results);

        results.Sort();
        var expected = new List<string> {
            "110000",
            "110001",
            "110100",
            "110101"
        };
        CollectionAssert.AreEqual(expected, results);
    }

    [TestMethod]
    public void WildcardBinary_EmptyString()
    {
        var results = new List<string>();
        Recursion.WildcardBinary("", results);

        var expected = new List<string> { "" };
        CollectionAssert.AreEqual(expected, results);
    }

    [TestMethod]
    public void WildcardBinary_NoWildcards()
    {
        var results = new List<string>();
        Recursion.WildcardBinary("101010101100", results);

        var expected = new List<string> { "101010101100" };
        CollectionAssert.AreEqual(expected, results);
    }

    [TestMethod]
    public void WildcardBinary_3_Long()
    {
        var results = new List<string>();
        Recursion.WildcardBinary("***", results);

        results.Sort();
        var expected = new List<string> {
            "000",
            "001",
            "010",
            "011",
            "100",
            "101",
            "110",
            "111"
        };
        CollectionAssert.AreEqual(expected, results);
    }
}

[TestClass]
public class SolveMazeTests
{
    [TestMethod]
    public void SolveMaze_Small()
    {
        var results = new List<string>();
        Maze smallMaze = new(3, 3, [1, 1, 1, 1, 0, 1, 1, 1, 2]);
        Recursion.SolveMaze(results, smallMaze);

        results.Sort();
        var expected = new List<string> {
            "<List>{(0, 0), (0, 1), (0, 2), (1, 2), (2, 2)}",
            "<List>{(0, 0), (1, 0), (2, 0), (2, 1), (2, 2)}"
        };
        CollectionAssert.AreEqual(expected, results);
    }

    [TestMethod]
    public void SolveMaze_Large()
    {
        var results = new List<string>();
        Maze bigMaze = new(20, 20,
            [
                1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1,
                1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1,
                0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0,
                0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1,
                1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1,
                0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1,
                0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1,
                1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1,
                0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1,
                0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1,
                0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1,
                0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1,
                1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0,
                0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0,
                0, 1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1,
                0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0,
                1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, 1, 2
            ]);

        Recursion.SolveMaze(results, bigMaze);

        results.Sort();
        var expected = new List<string> {
            "<List>{(0, 0), (0, 1), (0, 2), (0, 3), (1, 3), (2, 3), (3, 3), (3, 4), (3, 5), (3, 6), (2, 6), (1, 6), (1, 7), (1, 8), (1, 9), (1, 10), (2, 10), (3, 10), (4, 10), (5, 10), (5, 9), (5, 8), (5, 7), (5, 6), (5, 5), (5, 4), (5, 3), (5, 2), (5, 1), (5, 0), (6, 0), (7, 0), (8, 0), (9, 0), (10, 0), (10, 1), (10, 2), (10, 3), (10, 4), (10, 5), (10, 6), (9, 6), (8, 6), (8, 7), (8, 8), (7, 8), (7, 9), (7, 10), (7, 11), (7, 12), (7, 13), (6, 13), (5, 13), (5, 14), (5, 15), (5, 16), (5, 17), (5, 18), (5, 19), (6, 19), (7, 19), (8, 19), (9, 19), (10, 19), (11, 19), (12, 19), (12, 18), (12, 17), (12, 16), (12, 15), (12, 14), (12, 13), (12, 12), (12, 11), (12, 10), (12, 9), (13, 9), (14, 9), (15, 9), (15, 8), (15, 7), (15, 6), (15, 5), (14, 5), (13, 5), (12, 5), (12, 4), (12, 3), (12, 2), (12, 1), (13, 1), (14, 1), (15, 1), (16, 1), (17, 1), (17, 2), (17, 3), (17, 4), (17, 5), (18, 5), (19, 5), (19, 6), (19, 7), (19, 8), (19, 9), (19, 10), (19, 11), (19, 12), (18, 12), (17, 12), (16, 12), (16, 13), (16, 14), (16, 15), (17, 15), (18, 15), (18, 16), (18, 17), (18, 18), (18, 19), (19, 19)}"
        };
        CollectionAssert.AreEqual(expected, results);
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;

// DO NOT MODIFY THIS FILE

[TestClass]
public class MultiplesOfTests
{
    [TestMethod]
    public void TestMultiplesOf_Whole()
    {
        double[] multiples = Arrays.MultiplesOf(7, 5);
        CollectionAssert.AreEqual(new double[] { 7, 14, 21, 28, 35 }, multiples);
    }

    [TestMethod]
    public void TestMultiplesOf_Fractional()
    {
        double[] multiples = Arrays.MultiplesOf(1.5, 10);
        CollectionAssert.AreEqual(new double[] { 1.5, 3.0, 4.5, 6.0, 7.5, 9.0, 10.5, 12.0, 13.5, 15.0 }, multiples);
    }

    [TestMethod]
    public void TestMultiplesOf_Negative()
    {
        double[] multiples = Arrays.MultiplesOf(-2, 10);
        CollectionAssert.AreEqual(new double[] { -2, -4, -6, -8, -10, -12, -14, -16, -18, -20 }, multiples);
    }
}

[TestClass]
public class RotateListRightTests
{
    [TestMethod]
    public void TestRotateListRight_Rotate1()
    {
        List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Arrays.RotateListRight(numbers, 1);
        CollectionAssert.AreEqual(new List<int> { 9, 1, 2, 3, 4, 5, 6, 7, 8 }, numbers);
    }

    [TestMethod]
    public void TestRotateListRight_Rotate5()
    {
        List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Arrays.RotateListRight(numbers, 5);
        CollectionAssert.AreEqual(new List<int> { 5, 6, 7, 8, 9, 1, 2, 3, 4 }, numbers);
    }

    [TestMethod]
    public void TestRotateListRight_Rotate3()
    {
        List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Arrays.RotateListRight(numbers, 3);
        CollectionAssert.AreEqual(new List<int> { 7, 8, 9, 1, 2, 3, 4, 5, 6 }, numbers);
    }

    [TestMethod]
    public void TestRotateListRight_Rotate9()
    {
        List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Arrays.RotateListRight(numbers, 9);
        CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, numbers);
    }
}
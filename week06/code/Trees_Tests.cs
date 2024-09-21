using Microsoft.VisualStudio.TestTools.UnitTesting;

// DO NOT MODIFY THIS FILE

[TestClass]
public class TreeInsertTests
{
    [TestMethod]
    public void TreeInsert_Basic()
    {
        BinarySearchTree tree = new();
        tree.Insert(5);
        tree.Insert(3);
        tree.Insert(7);

        // After implementing 'no duplicates' rule,
        // this next insert will have no effect on the tree.
        tree.Insert(7);

        tree.Insert(4);
        tree.Insert(10);
        tree.Insert(1);
        tree.Insert(6);
        Assert.AreEqual("<Bst>{1, 3, 4, 5, 6, 7, 10}", tree.ToString());
    }
}

[TestClass]
public class TreeContainsTests
{
    [TestMethod]
    public void TreeContains_Basic()
    {
        BinarySearchTree tree = new();
        tree.Insert(5);
        tree.Insert(3);
        tree.Insert(7);
        tree.Insert(4);
        tree.Insert(10);
        tree.Insert(1);
        tree.Insert(6);

        Assert.IsTrue(tree.Contains(3));
        Assert.IsFalse(tree.Contains(2));
        Assert.IsTrue(tree.Contains(6));
        Assert.IsTrue(tree.Contains(7));
        Assert.IsFalse(tree.Contains(9));
    }
}

[TestClass]
public class TreeReverseTests
{
    [TestMethod]
    public void TreeReverse_Basic()
    {
        BinarySearchTree tree = new();
        tree.Insert(5);
        tree.Insert(3);
        tree.Insert(7);
        tree.Insert(4);
        tree.Insert(10);
        tree.Insert(1);
        tree.Insert(6);

        Assert.AreEqual("<IEnumerable>{10, 7, 6, 5, 4, 3, 1}", string.Join(", ", tree.Reverse().AsString()));
    }
}

[TestClass]
public class TreeGetHeightTests
{
    [TestMethod]
    public void TreeGetHeight_Basic()
    {
        BinarySearchTree tree = new();
        tree.Insert(5);
        tree.Insert(3);
        tree.Insert(7);
        tree.Insert(4);
        tree.Insert(10);
        tree.Insert(1);
        tree.Insert(6);
        Assert.AreEqual(3, tree.GetHeight());
        tree.Insert(6);
        Assert.AreEqual(3, tree.GetHeight());
        tree.Insert(12);
        Assert.AreEqual(4, tree.GetHeight());
    }
}

[TestClass]
public class CreateTreeFromSortedListTests
{
    [TestMethod]
    public void CreateTreeFromSortedList_CountBy10s()
    {
        var tree = Trees.CreateTreeFromSortedList([10, 20, 30, 40, 50, 60]);
        Assert.AreEqual("<Bst>{10, 20, 30, 40, 50, 60}", tree.ToString());
        Assert.AreEqual(3, tree.GetHeight());
    }

    [TestMethod]
    public void CreateTreeFromSortedList_127Nodes()
    {
        var tree = Trees.CreateTreeFromSortedList(Enumerable.Range(0, 127).ToArray()); // 2^7 - 1 nodes
        Assert.AreEqual("<Bst>{" + string.Join(", ", Enumerable.Range(0, 127)) + "}", tree.ToString());
        Assert.AreEqual(7, tree.GetHeight()); // Any higher and its not balanced.
    }

    [TestMethod]
    public void CreateTreeFromSortedList_128Nodes()
    {
        var tree = Trees.CreateTreeFromSortedList(Enumerable.Range(0, 128).ToArray()); // 2^7 nodes
        Assert.AreEqual("<Bst>{" + string.Join(", ", Enumerable.Range(0, 128)) + "}", tree.ToString());
        Assert.AreEqual(8, tree.GetHeight()); // Any higher and its not balanced.
    }

    [TestMethod]
    public void CreateTreeFromSortedList_Single()
    {
        var tree = Trees.CreateTreeFromSortedList([42]);
        Assert.AreEqual("<Bst>{42}", tree.ToString());
        Assert.AreEqual(1, tree.GetHeight());
    }

    [TestMethod]
    public void CreateTreeFromSortedList_Empty()
    {
        var tree = Trees.CreateTreeFromSortedList([]);
        Assert.AreEqual("<Bst>{}", tree.ToString());
        Assert.AreEqual(0, tree.GetHeight());
    }
}
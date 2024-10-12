using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a large queue, and add to the back. The item added should contain both data and priority. Including items with same priority, as well as one case with negative priority.
    // Expected Result: ["Alejandro", "Silas", "Elliot", "Autumn", "Michayla", "Erika", "Sean", "Shea", "Matt", "David", "Allyn"]
    // Defect #1 Found: Expected "Alejandro", got "Elliot". Cause: dequeue method was using >= instead of > as the comparitor for priorities, causing last seen item (of the appropriate priorty) to be dequeued first instead of the last seen item.  
    // Defect #2 Found: Expected "Silas", got "Alejandro". Cause: The code to remove an item was missing from the dequeue method.
    // Defect #3 Found: Expected "Erika", got "Sean". Cause, the dequeuemethod for loop conditional method had ovecorrected by using < and -1 simultaneously, causing the loop to end one iteration early. As a result. The loop ended 1 iteration early, and the item at the back of the queue, (in this test, "Erika") was never checked. 
    public void TestPriorityQueue_1()
    {

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Allyn",-1);
        priorityQueue.Enqueue("Autumn",1);
        priorityQueue.Enqueue("Michayla",1);
        priorityQueue.Enqueue("Sean",0);
        priorityQueue.Enqueue("Shea",0);
        priorityQueue.Enqueue("Alejandro",10);
        priorityQueue.Enqueue("Silas",10);
        priorityQueue.Enqueue("Elliot",10);
        priorityQueue.Enqueue("Matt",0);
        priorityQueue.Enqueue("David",0);
        priorityQueue.Enqueue("Erika",1);

        string[] expectedResults = ["Alejandro", "Silas", "Elliot", "Autumn", "Michayla", "Erika", "Sean", "Shea", "Matt", "David", "Allyn"];

        for (int i = 0; i < expectedResults.Length; i++)
        {
            Assert.AreEqual(expectedResults[i],priorityQueue.Dequeue());
        }
    
    }

    [TestMethod]
    // Scenario: Test for an empty queue exception by dequeueing an empty queue.
    // Expected Result: "The queue is empty."
    // Defect(s) Found: None
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        try 
        {
            priorityQueue.Dequeue();
            Assert.Fail("This should have failed.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(string.Format("Unexpected exception of {0} caught: {1}",e.GetType(),e.Message));
        }
    
    }

    // Add more test cases as needed below.
}
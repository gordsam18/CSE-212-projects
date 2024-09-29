using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue of people with varying priorites bob p2, Tim p5, Sue p3
    // Expected Result:  Tim
    // Defect(s) Found: Failure in dequeuing loop 
    public void TestPriorityQueue_CorrectPriority()
    {
        // set item variables 
        var bob = new PriorityItem("Bob", 2);
        var tim = new PriorityItem("Tim", 5);
        var sue = new PriorityItem("Sue", 3);
        
        // sets expected result
        PriorityItem expectedResult = tim;

        // Enqueue people with priorites
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);

        // dequeue person with highest priority 
        var highestPriorityPerson = priorityQueue.Dequeue();

        // Throws failure if incorrect person is dequeued
        if (expectedResult.Value != highestPriorityPerson)
        {
            Assert.Fail("Did not return the correct priority. ");
        }
        Assert.AreEqual(expectedResult.Value, highestPriorityPerson);
    }

    [TestMethod]
    // Scenario: Tests to see if the first highest priority item is taken from the queue when there are more than one item with the same priortiy 
    // Expected Result: tim 
    // Defect(s) Found: 
    public void TestPriorityQueue_RepeatPriority()
    {
        // Set priority items 
        var bob = new PriorityItem("Bob", 2);
        var tim = new PriorityItem("Tim", 5);
        var john = new PriorityItem("John", 4);
        var sue = new PriorityItem("Sue", 5);

        // set expected result 
        PriorityItem expectedResult = tim;

        // Enqueue values and priority
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(john.Value, john.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);
        
        // set first dequeued item 
        var highestPriorityPerson = priorityQueue.Dequeue();

        // throw expection to handle failure 
        if (expectedResult.Value != highestPriorityPerson)
        {
            Assert.Fail("Did not return the correct priority. ");
        }
        Assert.AreEqual(expectedResult.Value, highestPriorityPerson);
    }

    [TestMethod]
    // Scenario: Tests to see if the first highest priority item is taken from the queue when there are more than one item with the same priortiy 
    // Expected Result: tim 
    // Defect(s) Found: 
    public void TestPriorityQueue_EmptyQueue()
    {
        var item = new PriorityQueue();

        try
        {
            item.Dequeue();
            Assert.Fail("Exception should have been thrown.");
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
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}



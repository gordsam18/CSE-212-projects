using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue of people with varying priorites bob p2, Tim p5, Sue p3
    // Expected Result:  Tim
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var bob = new PriorityItem("Bob", 2);
        var tim = new PriorityItem("Tim", 5);
        var sue = new PriorityItem("Sue", 3);

        PriorityItem expectedResult = tim;


        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);

        var highestPriorityPerson = priorityQueue.Dequeue();

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
    public void TestPriorityQueue_2()
    {
        var bob = new PriorityItem("Bob", 2);
        var tim = new PriorityItem("Tim", 5);
        var john = new PriorityItem("John", 4);
        var sue = new PriorityItem("Sue", 5);

        PriorityItem expectedResult = tim;


        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(john.Value, john.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);

        var highestPriorityPerson = priorityQueue.Dequeue();

        if (expectedResult.Value != highestPriorityPerson)
        {
            Assert.Fail("Did not return the correct priority. ");
        }
        Assert.AreEqual(expectedResult.Value, highestPriorityPerson);
    }
}


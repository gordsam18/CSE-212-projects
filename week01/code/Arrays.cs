public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // start with an empty array variable 
        double[] multiples = new double[length];

        // Loop through the multipes array length amount of times
        // to find multiples times number by i + 1
        // increase the count 1 time in the loop
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i +1);

        }

        //return the results in the array
        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // start with an empty array varible 
        List<int> frontarray = new List<int>(data);

        // using the slicing method getrange
        // first get the new begining of the array by taking the amount from the end of the array
        frontarray = data.GetRange(data.Count - amount, amount);
        // remove the frontarray amount from data and then add it to the front
        data.RemoveRange(data.Count - amount, amount);
        data.InsertRange(0, frontarray);

    }
}

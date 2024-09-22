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

        //Allyn's comments: 
        //initialize an array with length matching the length parameter.
        //Create a for loop. loop according to int length. add the product of number and the loop counter to the array.
        //edit: the above logic is flawed. the number added to the array should be the product of the number and (the loop counter plus one)
        //return the array after the loop completes

        double[] multiples = new double[length];
        for (int i = 0; i < length; i++)
            {
                multiples[i] = number * (i + 1);
            }
        return multiples; // complete
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

        //Allyn's comments:
        //while the amount is larger than or equal to array length, remove the array length from amount. This prevents out of bounds operations.
        //while amount is less than zero, add the array count.
        
        //create a copy of the last (amount) elements of the list
        //delete those elements on the original list
        //insert copy at the beginning of original list.

        while (amount >= data.Count)
            {
                amount -= data.Count;
            }
        while (amount < 0)
            {
                amount += data.Count;
            }

        while (amount > 0)
            {
                data.Insert(0,data[data.Count - 1]);
                data.Remove(data.Count-1);
                amount--;
            }
        

    }
}

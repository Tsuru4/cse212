using System.Runtime.Serialization;

public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        int[] result = new int[select.Length];
        int count1 = 0;
        int count2 = 0;
        for (int i = 0; i < select.Length; i++)
            {
            if (select[i] == 1)
                {
                result[i] = list1[count1];
                count1++;
                }
            else
                {
                result[i] = list2[count2];
                count2++;
                }
            }
        return result;
    }
}
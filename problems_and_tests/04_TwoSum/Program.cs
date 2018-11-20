using System;
using System.Collections.Generic;
using System.Linq;

class TwoSum
{
    public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
    {
        var dict = new Dictionary<int, int>();

        for (int i = 0; i < list.Count; i++)
        {
            int complement = sum - list[i];
            if (dict.ContainsKey(complement))
                return new Tuple<int, int>(dict[complement], i);
            dict[list[i]] = i;
        }

       return null;
    }

    public static void Main(string[] args)
    {
        Tuple<int, int> indices = FindTwoSum(new List<int>() { 3, 1, 5, 7, 5, 9 }, 10);
        if (indices != null)
        {
            Console.WriteLine(indices.Item1 + " " + indices.Item2);
        }
        Console.ReadLine();
    }
}
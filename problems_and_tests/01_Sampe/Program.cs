using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Samlpe
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            IEnumerable<int> filteringQuery = from num in numbers
                                              where num < 3 || num > 7
                                              select num;
            IEnumerable<int> orderingQuery =
                from num in numbers
                where num < 3 || num > 7
                orderby num ascending
                select num;

            string[] groupingQuery = { "carrots", "cabbage", "broccoli", "beans", "barley" };

            IEnumerable<IGrouping<char, string>> queryFoodGroups =
                from item in groupingQuery
                group item by item[0];

            foreach (var i in queryFoodGroups)
            {
                Console.WriteLine(i.Key);
                foreach (var g in i)
                    Console.WriteLine(g);
            }

            List<int> grades = new List<int> { 78, 92, 100, 37, 81 };

            double average = grades.Average();
        }
    }
}

using System.Collections.Generic;

namespace Algorithms.Common
{
    public static class Helpers
    {
        public static void Swap<T>(this IList<T> list, int firstIndex, int secondIndex)
        {
            if (list.Count < 2 || firstIndex == secondIndex)
                return;

            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }

        ///// <summary>
        ///// Swaps two values in an ArrayList<T> collection given their indexes.
        ///// </summary>
        //public static void Swap<T>(this ArrayList<T> list, int firstIndex, int secondIndex)
        //{
        //    if (list.Count < 2 || firstIndex == secondIndex)   //This check is not required but Partition function may make many calls so its for perf reason
        //        return;
        //
        //    var temp = list[firstIndex];
        //    list[firstIndex] = list[secondIndex];
        //    list[secondIndex] = temp;
        //}


    }
}

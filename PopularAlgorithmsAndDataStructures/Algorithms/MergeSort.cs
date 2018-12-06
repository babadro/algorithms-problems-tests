using System;

namespace Algorithms
{
    public static class MergeSort
    {
        private static void Merge(int[] arr, int leftIndex, int middleIndex, int rightIndex)
        {
            int i, j, k;
            int leftLen = middleIndex - leftIndex + 1;
            int rightLen = rightIndex - middleIndex;

            var left = new int[leftLen];
            var right = new int[rightLen];

            for (i = 0; i < leftLen; i++)
                left[i] = arr[leftIndex + i];
            for (j = 0; j < rightLen; j++)
                right[j] = arr[middleIndex + 1 + j];

            i = 0;
            j = 0;
            k = leftIndex;

            while (i < leftLen && j < rightLen)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < leftLen)
            {
                arr[k] = left[i];
                i++;
                k++;
            }

            while (j < rightLen)
            {
                arr[k] = right[j];
                j++;
                k++;
            }
        }

        public static void Start(int[] arr, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int middle = (leftIndex + rightIndex) / 2;

                Start(arr, leftIndex, middle);
                Start(arr, middle + 1, rightIndex);

                Merge(arr, leftIndex, middle, rightIndex);
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace PostLogisticsApp
{
    // Частина 1: Узагальнені методи для обробки масивів
    public static class ArrayUtils
    {
        public static int FindIndex<T>(T[] array, T value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(array[i], value))
                    return i;
            }
            return -1;
        }

        public static void Invert<T>(T[] array)
        {
            int left = 0;
            int right = array.Length - 1;
            while (left < right)
            {
                T temp = array[left];
                array[left] = array[right];
                array[right] = temp;
                left++;
                right--;
            }
        }

        public static T GetMinimum<T>(T[] array) where T : IComparable<T>
        {
            T minVal = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(minVal) < 0)
                    minVal = array[i];
            }
            return minVal;
        }

        public static T GetMaximum<T>(T[] array) where T : IComparable<T>
        {
            T maxVal = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(maxVal) > 0)
                    maxVal = array[i];
            }
            return maxVal;
        }
    }
}

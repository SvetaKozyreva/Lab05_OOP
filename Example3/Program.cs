using System;

namespace Example3
{
    class Sorter
    {
        public static void SelectionSort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int index = i;
                for (int j = i + 1; j < array.Length; j++)
                    if (array[j].CompareTo(array[index]) < 0)
                        index = j;
                T t = array[index];
                array[index] = array[i];
                array[i] = t;
            }
        }
     }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int[] a = { 2, 5, 6, 1, 3, 4 };
            Console.WriteLine("Array:");
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }

            Sorter.SelectionSort<int>(a);
            Console.WriteLine("Sorted Array:");
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
    }
}

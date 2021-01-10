using BasicSortingTester.Sortings;
using System;
using System.Diagnostics;
using System.Numerics;

namespace BasicSortingTester
{
    class Program
    {
        private const int MAX_ARRAY_SIZE = 20000;

        static void Main()
        {
            Console.Write("Generating array to sort: ");
            int[] arrayToSort = new int[MAX_ARRAY_SIZE];
            var rGen = new Random();

            for (int i = 0; i < MAX_ARRAY_SIZE; i++)
            {
                var progressString = $"{i + 1}/{MAX_ARRAY_SIZE}";
                Console.Write(progressString);
                Console.SetCursorPosition(Console.CursorLeft - progressString.Length, Console.CursorTop);
                arrayToSort[i] = rGen.Next(0, MAX_ARRAY_SIZE);
            }

            var _bubbleSorter = new BubbleSorter<int>();
            var _mergeSorter = new MergeSorter<int>();
            var _insertionSorter = new InsertionSorter<int>();
            BigInteger totalMs = 0;

            Console.SetCursorPosition(0, Console.CursorTop + 2);

            totalMs += TestIntegersArraySortingMethod("Bubble sorting", _bubbleSorter, arrayToSort);
            totalMs += TestIntegersArraySortingMethod("Insertion sorting", _insertionSorter, arrayToSort);
            totalMs += TestIntegersArraySortingMethod("Merge sorting", _mergeSorter, arrayToSort);

            Console.WriteLine($"Test completed in {totalMs} ms");
            Console.SetCursorPosition(0, Console.CursorTop + 1);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static long TestIntegersArraySortingMethod(string sortingName, SorterBase<int> st, int[] arrayToSort)
        {
            var watch = Stopwatch.StartNew();
            Console.Write($"{sortingName}: running");

            ISortingService<SorterBase<int>, int> _sortingService = new SortingService<SorterBase<int>, int>(st);

            watch.Start();
            _sortingService.SortItems((int[])arrayToSort.Clone());
            watch.Stop();

            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine($"{sortingName} completed in \t\t {watch.ElapsedMilliseconds} ms");
            return watch.ElapsedMilliseconds;
        }
    }
}

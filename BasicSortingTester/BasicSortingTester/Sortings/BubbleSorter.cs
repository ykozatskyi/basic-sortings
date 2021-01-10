using System;

namespace BasicSortingTester.Sortings
{
    public class BubbleSorter<T> : SorterBase<T> where T : IComparable
    {
        public override void Sort(T[] input)
        {
            if (input.Length < 2)
                return;

            for (int i = 0; i < input.Length - 1; i++)
                for (int j = 1; j < input.Length - i; j++)
                    if (input[j - 1].CompareTo(input[j]) > 0)
                        Swap(input, j, j - 1);
        }
    }
}

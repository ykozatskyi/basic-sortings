using System;

namespace BasicSortingTester.Sortings
{
    public class InsertionSorter<T> : SorterBase<T> where T : IComparable
    {
        public override void Sort(T[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                T item = input[i];
                int itemIndex = i;

                while (itemIndex > 0 && input[itemIndex - 1].CompareTo(item) > 0)
                    input[itemIndex] = input[--itemIndex];

                input[itemIndex] = item;
            }
        }
    }
}

using System;

namespace BasicSortingTester.Sortings
{
    public abstract class SorterBase<T> where T : IComparable
    {
        public abstract void Sort(T[] input);

        public bool Ensure(T[] input)
        {
            for (int i = 0; i < input.Length; i++)
                if (i + 1 < input.Length && input[i].CompareTo(input[i + 1]) > 0)
                    return false;

            return true;
        }

        protected void Swap(T[] input, int targetIndex, int indexToSet)
        {
            T temp = input[targetIndex];
            input[targetIndex] = input[indexToSet];
            input[indexToSet] = temp;
        }
    }
}

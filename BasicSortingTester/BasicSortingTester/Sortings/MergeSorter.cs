using System;

namespace BasicSortingTester.Sortings
{
    public class MergeSorter<T> : SorterBase<T> where T : IComparable
    {
        public override void Sort(T[] input)
        {
            var sorted = DivideAndRule(input);
            for (var i = 0; i < input.Length; i++)
                input[i] = sorted[i];
        }

        private T[] DivideAndRule(T[] input)
        {
            if (input.Length < 2)
                return input;

            T[] left = new T[input.Length / 2];
            T[] right = new T[input.Length - (input.Length / 2)];

            for (int i = 0; i < left.Length; i++)
                left[i] = input[i];

            for (int i = 0; i < right.Length; i++)
                right[i] = input[i + left.Length];

            left = DivideAndRule(left);
            right = DivideAndRule(right);

            return CompairingMerge(left, right);
        }

        private T[] CompairingMerge(T[] left, T[] right)
        {
            T[] result = new T[left.Length + right.Length];
            int leftIndex = 0;
            int rightIndex = 0;
            int resultIndex = 0;
            while (leftIndex < left.Length || rightIndex < right.Length)
                if (leftIndex < left.Length && rightIndex < right.Length)
                    if (left[leftIndex].CompareTo(right[rightIndex]) <= 0)
                        result[resultIndex++] = left[leftIndex++];
                    else
                        result[resultIndex++] = right[rightIndex++];
                else if (leftIndex < left.Length)
                    result[resultIndex++] = left[leftIndex++];
                else if (rightIndex < right.Length)
                    result[resultIndex++] = right[rightIndex++];

            return result;
        }
    }
}

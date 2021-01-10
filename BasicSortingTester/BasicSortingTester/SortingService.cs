using BasicSortingTester.Sortings;
using System;

namespace BasicSortingTester
{
    public class SortingService<T1, T2> : ISortingService<T1, T2> where T1 : SorterBase<T2> where T2 : IComparable
    {
        private readonly T1 _sorter;

        public SortingService(T1 sortingMethod)
        {
            _sorter = sortingMethod;
        }

        public void SortItems(T2[] input)
        {
            _sorter.Sort(input);
            if (!_sorter.Ensure(input))
                throw new Exception();
        }
    }
}

using BasicSortingTester.Sortings;
using System;

namespace BasicSortingTester
{
    public interface ISortingService<T1, T2> where T1 : SorterBase<T2> where T2 : IComparable
    {
        void SortItems(T2[] input);
    }
}

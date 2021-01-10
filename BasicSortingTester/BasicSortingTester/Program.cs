using BasicSortingTester.Sortings;

namespace BasicSortingTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var _bubbleSorter = new BubbleSorter<int>();

            ISortingService<BubbleSorter<int>, int> _bubbleSortingService
                = new SortingService<BubbleSorter<int>, int>(_bubbleSorter);
            _bubbleSortingService.SortItems(new int[5] { 6, 8, 3, 2, 1 });
        }
    }
}

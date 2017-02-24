using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20170128_SortersDemo
{
    class QuickSorter : Sorter
    {
        public QuickSorter(double[] numbers)
            : base(numbers)
        {
        }

        public override string SortName
        {
            get
            {
                return "Quick";
            }
        }


        void QuickSortRecursion(double[] _numbers, int left, int right)
        {
            double pivot;
            pivot = _numbers[(right + left) / 2];
            int i = left;
            int j = right;
            do
            {
                while (IsLargeThan(_numbers[i], pivot)) i++;
                while (IsLargeThan(pivot, _numbers[j])) j--;

                if (i <= j)
                {
                    Swap(ref _numbers[i], ref _numbers[j]);
                    i++; j--;
                }
            } while (IsLargeThan(j, i));
            if (IsLargeThan(right, i)) QuickSortRecursion(_numbers, i, right);
            if (IsLargeThan(j, left)) QuickSortRecursion(_numbers, left, j);
        }




        public override void Sort()
        {
            base.onSortingEvent(State.Start);
            QuickSortRecursion(_numbers, 0, _numbers.Length - 1);
            base.onSortingEvent(State.Finish);

        }


    }
}

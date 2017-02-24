using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20170128_SortersDemo
{
    class InsertSorter : Sorter
    {
        public InsertSorter(double[] numbers) : base(numbers)
        {
        }

        public override string SortName
        {
            get 
            { 
                return "Insert"; 
            }
        }
        public  void InsertionSort(double[] _numbers, int left, int right)
        {
            for (int k = left;  k <= right; k++)
            {
               
                double temp = _numbers[k]; //запомним k-ый элемент   
                int j = k - 1;//будем идти начиная с k-1 элемента 
                while (j>= 0 && IsLargeThan(_numbers[j], temp))
                {
                    _numbers[j + 1] = _numbers[j];
                    //проталкиваем элемент вверх 
                    j--;
                }
                _numbers[j + 1] = temp;
                // возвращаем k-1 элемент 
            }
        }
        public override void Sort()
        {
            base.onSortingEvent(State.Start);
            InsertionSort(_numbers, 0, _numbers.Length - 1);
            base.onSortingEvent(State.Finish);

         

        }
    }
}

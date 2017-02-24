using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20170128_SortersDemo
{
    class MergeSort : Sorter
    {
        public MergeSort(double[] numbers)
            : base(numbers)
        {
        }

        public override string SortName
        {
            get
            {
                return "Merge";
            }
        }


        //don't touch!!
        double[] Sort1(double[] _numbers)
        {
            if (IsLargeThan(_numbers.Length, 1))
            {
                double[] left = new double[_numbers.Length / 2];
                double[] right = new double[_numbers.Length - left.Length];
                for (int i = 0; i < left.Length; i++)
                {
                    left[i] = _numbers[i];
                }
                for (int i = 0; i < right.Length; i++)
                {
                    right[i] = _numbers[left.Length + i];
                }
                if (IsLargeThan(left.Length, 1))
                    left = Sort1(left);
                if (IsLargeThan(right.Length, 1))
                    right = Sort1(right);
                _numbers = MergeSort1(left, right);
            }
            return _numbers;
        }
        double[] MergeSort1(double[] left, double[] right)
        {
            double[] mas = new double[left.Length + right.Length];
            int i = 0;  //соединенный массив
            int l = 0;  //левый массив
            int r = 0;  //правый массив
                        //сортировка сравнением элементов
            for (; i < mas.Length; i++)
            {
                //если правая часть уже использована, дальнейшее движение происходит только в левой
                //проверка на выход правого массива за пределы
                if (r >= right.Length)
                {
                    mas[i] = left[l];
                    l++;
                }
                //проверка на выход за пределы левого массива
                //и сравнение текущих значений обоих массивов
                else if (IsLargeThan(left.Length, l) && IsLargeThan(right[r], left[l]))
                {
                    mas[i] = left[l];
                    l++;
                }
                //если текущее значение правой части больше
                else
                {
                    mas[i] = right[r];
                    r++;
                }
            }
            return mas;
        }





        public override void Sort()
        {
            base.onSortingEvent(State.Start);
            Sort1(_numbers);
            base.onSortingEvent(State.Finish);

        }
    }
}

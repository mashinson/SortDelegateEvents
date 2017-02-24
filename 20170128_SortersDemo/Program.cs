using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20170128_SortersDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            double[] numbers = new double[1000];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.NextDouble();
            }


            TestSortMethod(new InsertSorter(numbers));
            TestSortMethod(new BoobleSorter(numbers));
            TestSortMethod(new QuickSorter(numbers));
            TestSortMethod(new MergeSort(numbers));
            Console.WriteLine();

            double[] numbers1 = new double[10000];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers1[i] = i;
            }

            TestSortMethod(new InsertSorter(numbers1));
            TestSortMethod(new BoobleSorter(numbers1));
            TestSortMethod(new QuickSorter(numbers1));
            TestSortMethod(new MergeSort(numbers1));
            Console.WriteLine();

            double[] numbers2 = new double[10000];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers2[i] = numbers.Length - i;
            }

            TestSortMethod(new InsertSorter(numbers2));
            TestSortMethod(new BoobleSorter(numbers2));
            TestSortMethod(new QuickSorter(numbers2));
            TestSortMethod(new MergeSort(numbers2));
            Console.WriteLine();
            Console.ReadKey();
        }

        private static void TestSortMethod(Sorter s)
        {
            Analysis an = new Analysis(s);
            s.Sort();
            Console.WriteLine(an);
            Console.WriteLine();

        }

  
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20170128_SortersDemo
{
    enum State
    {
        Finish,
        Start
    }

    abstract class Sorter
    {

        public const int DEF_SIZE = 10000;


        #region ctors

        public Sorter(int size = DEF_SIZE)
        {

            _numbers = new double[size];
            // инициализация с помощью Random !!!
        }

        public Sorter(double[] numbers)
        {
            _numbers = (double[])numbers.Clone();
        }

        #endregion
        public delegate void SortingBeginEnd(State msg);
        public event SortingBeginEnd SortingEvent;
        public virtual void onSortingEvent(State st)
        {
            if (SortingEvent != null)
            {
                SortingEvent(st);
            }

        }

        public delegate void SortingAnalysis();
        public event SortingAnalysis CompareEvent;
        public event SortingAnalysis SwapEvent;


        public abstract string SortName { get; }
        public abstract void Sort();

        protected bool IsLargeThan(double a, double b)
        {
            CompareEvent();
            return a > b;
        }

        protected void Swap(ref double a, ref double b)
        {
            SwapEvent();

            double c = b;
            b = a;
            a = c;
        }

       
        protected double[] _numbers = null;

      
    }
}

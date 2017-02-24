using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20170128_SortersDemo
{
    class Analysis
    {

        public Analysis(Sorter sr)
        {
            _name = sr.SortName;
            sr.CompareEvent += onCompareEvent;
            sr.SwapEvent += onSwapEvent;
            sr.SortingEvent += onSortingEvent;
        }

        private void onSortingEvent(State msg)
        {
           
            switch (msg)
            {
                case State.Finish:                 
                    _time = Environment.TickCount - _start;
                    break;
                case State.Start:                
                    _start = Environment.TickCount;
                    break;              
            }

        }

        private void onCompareEvent()
        {
            _compareCount += 1;
        }
        private void onSwapEvent()
        {
            _swapCount += 1;
        }

        public override string ToString()
        {
            return string.Format("SortName: {0}, compareCount: {1}, swapCount: {2}, time: {3}", _name, _compareCount, _swapCount, _time);
        }

        private uint _compareCount = 0;
        private uint _swapCount = 0;
        private double _time = 0;
        private double _start = 0;
        private string _name;
    }
}

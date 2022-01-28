using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursWinForms
{
    public class FindDifference
    {
        private int _Difference;
        public int Difference
        {
            get { return _Difference; }
        }
        public int FindDiff(int value1, int value2)
        {
            return value1 - value2 + 1;
        }
        public void SetDiff(int value)
        {
            _Difference = value;
        }
    }
}

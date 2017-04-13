using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProduction
{
    public struct SheetSizeInSM
    {
        public int lengthInSM;
        public int widthInSM;

        public SheetSizeInSM(int _lengthInSM, int _widthInSM)
        {
            lengthInSM = _lengthInSM;
            widthInSM = _widthInSM;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProduction
{
    public abstract class SheetPress: PrintingPress
    {
        public SheetPress(TaskToPrint taskToPrint) : 
            base(taskToPrint) { }

        internal override int GetImpressions()
        {
            return GetPrintingSheetsPerPrintRun() * (TaskToPrint.Colors.Total());
        }

        internal override int GetFittingOnPrintRun()
        {
            return (int)GetFittingPriceValue();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProduction
{
    public abstract class RolledPress : PrintingPress
    {
        public double Cutting { get; set; }
        public RolledPress(TaskToPrint taskToPrint) :
            base(taskToPrint) {}

        internal override int GetImpressions()
        {
            return GetPrintingSheetsPerPrintRun();
        }

        internal override int GetFittingOnPrintRun()
        {
            return (int)GetFittingPriceValue() * GetPrintingForms();
        }
    }
}

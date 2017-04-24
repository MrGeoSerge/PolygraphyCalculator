using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookProduction;
using BookProduction.BookComponents;
using BookProduction.Assembly;
using BookProduction.IssueParams;
using BookProduction.Paper;
using BookProduction.PriceLists;
using BookProduction.PrintingPresses;
using BookProduction.Tasks;
using BookProduction.TypographyManagement;

namespace BookProduction.PrintingPresses
{
    abstract public class PrintingPress
    {
        public TaskToPrint TaskToPrint { get; private set; }

        public IssueFormat PressSheetFormat { get; private set; }

        public PrintingPress(TaskToPrint taskToPrint)
        {
            this.TaskToPrint = taskToPrint;

            PressSheetFormat = GetPressSheetsFormat();
        }

        internal abstract double GetFormPriceValue();

        internal abstract double GetFittingPriceValue();

        internal abstract double GetTechNeedsPriceValue();

        internal abstract double GetImpressionPriceValue();

        internal abstract IssueFormat GetPressSheetsFormat();


        internal int GetPagesPerOneImposition()
        {
            return TaskToPrint.Format.Fraction / PressSheetFormat.Fraction;
        }

        internal double GetImpositionsPerBook()
        {
            return (double)TaskToPrint.PagesNumber / GetPagesPerOneImposition();
        }

        internal double GetPrintingSheetsPerBook()
        {
            return GetImpositionsPerBook() / 2;//лицо и оборот
        }

        internal int GetPrintingSheetsPerPrintRun()
        {
            return (int)Math.Round(GetPrintingSheetsPerBook() * TaskToPrint.PrintRun, 
                MidpointRounding.AwayFromZero);
        }

        internal int GetPrintingForms()
        {
            return TaskToPrint.Colors.Total() * (int)Math.Ceiling(GetPrintingSheetsPerBook());
        }

        internal double GetCostOfPrintingFoms()
        {
            return GetPrintingForms() * GetFormPriceValue();
        }

        internal abstract int GetImpressions();

        internal double GetCostOfImpressions()
        {
            return GetImpressions() * GetImpressionPriceValue();
        }

        internal double GetCostOfPrinting()
        {
            return GetCostOfPrintingFoms() + GetCostOfImpressions();
        }

        internal virtual int GetPaperConsumptionForTechnicalNeeds()
        {
            return (int)Math.Ceiling(((double)(int)((GetPrintingSheetsPerPrintRun() 
                * GetTechNeedsPriceValue() / 100) * 10)/10));
            //округляя до целых (количества листов), сначала отбрасываются сотые доли листа
        }

        internal abstract int GetFittingOnPrintRun();


        internal virtual int GetTotalPaperConsumptionInPressFormat()
        {
            return GetPrintingSheetsPerPrintRun() + GetPaperConsumptionForTechnicalNeeds()
                + GetFittingOnPrintRun();
        }

        public PressReport SendReport()
        {
            return new PressReport(this);
        }
    }
}

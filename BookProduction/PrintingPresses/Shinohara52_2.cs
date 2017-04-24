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
    public class Shinohara52_2 : SheetPress
    {
        public Shinohara52_2(TaskToPrint taskToPrint) : 
            base(taskToPrint)
        {
        }

        internal override double GetFormPriceValue()
        {
            return ShinoharaPressPriceList.Form;
        }

        internal override double GetFittingPriceValue()
        {
            return ShinoharaPressPriceList.Fitting;
        }

        internal override double GetTechNeedsPriceValue()
        {
            foreach (var printRun in ShinoharaPressPriceList.TechNeeds)
            {
                if (GetPrintingSheetsPerPrintRun() < printRun.Key)
                {
                    return printRun.Value;
                }
            }
            throw new ArgumentOutOfRangeException("для такого тиража технужды не указаны в прайсе");

        }


        internal override double GetImpressionPriceValue()
        {
            foreach (var printRun in ShinoharaPressPriceList.Impression)
            {
                if (GetPrintingSheetsPerPrintRun() < printRun.Key)
                {
                    return printRun.Value;
                }
            }
            throw new ArgumentOutOfRangeException("для такого тиража цена оттиска не указана в прайсе");
        }

        internal override IssueFormat GetPressSheetsFormat()
        {
            //Шинохара Форматы (370 * 520)
             //84 * 108 / 8 = 420мм * 270мм
             //70 * 100 / 4 = 350мм * 500мм
             //(предпочтительный!)
             //70 * 90 / 4 = 350мм * 450мм
             //60 * 90 / 4 = 300мм * 450мм

            switch (TaskToPrint.Format.PrintingSheet())
            {
                case "84*108":
                    return new IssueFormat("84*108/8");
                case "70*100":
                    return new IssueFormat("70*100/4");
                case "70*90":
                    return new IssueFormat("70*90/4");
                case "60*90":
                    return new IssueFormat("60*90/4");
                default:
                    throw new ArgumentOutOfRangeException(TaskToPrint.Format.PrintingSheet());
            }

        }

        internal override int GetTotalPaperConsumptionInPressFormat()
        {
            int totalPaperConsumption = GetPrintingSheetsPerPrintRun() + GetPaperConsumptionForTechnicalNeeds()
                + GetFittingOnPrintRun();

            //добавляется волшебный переплетный процент 1.65% на Шинохару (в прайсе нет)
            totalPaperConsumption += (int)Math.Round(totalPaperConsumption * 0.0165, MidpointRounding.AwayFromZero);

            return totalPaperConsumption;
        }

        internal override int GetFittingOnPrintRun()
        {
            return (int)GetFittingPriceValue() * GetPrintingForms();
        }

        internal new int GetPaperConsumptionForTechnicalNeeds()
        {
            return base.GetPaperConsumptionForTechnicalNeeds() * GetPrintingForms() ;
        }
    }
}

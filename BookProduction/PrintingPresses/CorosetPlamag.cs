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
    public class CorosetPlamag: RolledPress
    {
 
        public CorosetPlamag(TaskToPrint taskToPrint) :
            base(taskToPrint)
        {
            Cutting = 0.546;//рубка - параметр размера печатной ротационной машины
        }

        internal override double GetFormPriceValue()
        {
            return CorosetPressPriceList.Form;
        }

        internal override double GetFittingPriceValue()
        {
            return CorosetPressPriceList.Fitting;
        }

        internal override double GetTechNeedsPriceValue()
        {
            if (TaskToPrint.Colors.ToString() == "1+1")
            {
                return CorosetPressPriceList.TechNeeds["1+1"];
            }
            else
                return CorosetPressPriceList.TechNeeds["1+1"]
                    + CorosetPressPriceList.TechNeeds["2+2"]
                    * (TaskToPrint.Colors.Total() - 2);//-2 изначальных цвета
        }

        internal override double GetImpressionPriceValue()
        {
            //По факту закоментированное не считается
            //if (TaskToPrint.Colors.ToString() == "1+1")
            //{
            return CorosetPressPriceList.Impression["1+1"];
            //}
            //else
            //    return CorosetPressPriceList.Impression["1+1"]
            //        + CorosetPressPriceList.Impression["2+2"]
            //        * (TaskToPrint.Colors.Total() - 2);//-2 изначальных цвета
        }


        internal override IssueFormat GetPressSheetsFormat()
        {
            //Коросет Форматы (840 * 546)
            //84 * 108 / 2 = 840мм * 540мм(предпочтительный!)
            //70 * 100 / 2 = 700мм * 500мм
            //70 * 90 / 2 = 700мм * 450мм
            //60 * 90 / 2 = 600мм * 450мм
            switch (TaskToPrint.Format.PrintingSheet())
            {
                case "84*108":
                    return new IssueFormat("84*108/2");
                case "70*100":
                    return new IssueFormat("70*100/2");
                case "70*90":
                    return new IssueFormat("70*90/2");
                case "60*90":
                    return new IssueFormat("60*90/2");
                default:
                    throw new ArgumentOutOfRangeException(TaskToPrint.Format.PrintingSheet());
            }


        }

    }
}

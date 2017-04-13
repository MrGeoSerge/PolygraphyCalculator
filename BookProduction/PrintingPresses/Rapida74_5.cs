﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProduction
{
    public class Rapida74_5 : SheetPress
    {
        public Rapida74_5(TaskToPrint taskToPrint) :
            base(taskToPrint)
        { }

        //-----установка значений прайса-----
        //стоимость формы
        internal override double GetFormPriceValue()
        {
            return RapidaPressPriceList.Form;
        }


        //стоимость приладки
        internal override double GetFittingPriceValue()
        {
            //приладка(зависит от цветности) - и от тиража, то есть, если технужды > 0, приладка = 0
            if (GetTechNeedsPriceValue() > 0)
            {
                return 0.0;
            }

            foreach (var issueColors in RapidaPressPriceList.Fitting)
            {
                if (issueColors.Key == TaskToPrint.Colors)
                {
                    return issueColors.Value;
                }
            }
            throw new ArgumentOutOfRangeException("такой цветности издания в прайсе нет");
        }

        //процент технужд
        internal override double GetTechNeedsPriceValue()
        {
            foreach (var printRun in RapidaPressPriceList.TechNeeds)
            {
                if (GetPrintingSheetsPerPrintRun() < printRun.Key)
                {
                    return printRun.Value;
                }
            }
            throw new ArgumentOutOfRangeException("для такого тиража технужды не указаны в прайсе");
        }

        //стоимость оттиска
        internal override double GetImpressionPriceValue()
        {
            foreach (var printRun in RapidaPressPriceList.Impression)
            {
                if (GetPrintingSheetsPerPrintRun() < printRun.Key)
                {
                    return printRun.Value;
                }
            }
            throw new ArgumentOutOfRangeException("для такого тиража цена оттиска не указана в прайсе");

        }

        //метод вычисления формата листа оборудования 
        //в зависимости от заданного формата книги
        internal override IssueFormat GetPressSheetsFormat()
        {
            //Рапида Форматы (740 * 520)
            //84*108/4 = 420мм * 540мм
            //70*100/2 = 700мм * 500мм(предпочтительный!)
            //70*90/2 = 700мм * 450мм
            //60*90/2 = 600мм * 450мм
            switch (TaskToPrint.Format.PrintingSheet())
            {
                case "84*108":
                    return new IssueFormat("84*108/4");
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

﻿using System;
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

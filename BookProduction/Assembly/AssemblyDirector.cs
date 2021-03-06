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

namespace BookProduction.Assembly
{
    public class AssemblyDirector
    {
        IAssemblyDepartment assemblyDepartment;

        public AssemblyDirector(IAssemblyDepartment assemblyDepartment)
        {
            this.assemblyDepartment = assemblyDepartment;
        }

        public void Assemble()
        {
            assemblyDepartment.MakeLamination();
            assemblyDepartment.MakePerforation();
            assemblyDepartment.MakeBinding();
            assemblyDepartment.MakePackaging();
            assemblyDepartment.CalcTotalCostOfAssembly();
        }
    }
}

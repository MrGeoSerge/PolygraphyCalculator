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

namespace BookProduction.Assembly
{
    public interface IAssemblyDepartment
    {
        void MakeLamination();
        void MakePerforation();
        void MakeBinding();
        void MakePackaging();
        void CalcTotalCostOfAssembly();
        AssemblyReport GetReport();
    }
}

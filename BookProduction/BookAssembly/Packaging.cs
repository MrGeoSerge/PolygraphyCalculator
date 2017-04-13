using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProduction
{
    public class Packaging
    {


        double pricePerUnit;

        int PrintRun { set; get; }
        public Packaging(TaskToPackage _taskToPackage)
        {
            if (_taskToPackage.BindingType == BindingType.SaddleStitching)
            {
                pricePerUnit = Price.Packaging["PriceForStaple"];
            }
            else
            {
                pricePerUnit = Price.Packaging["PriceForClue"];
            }
            PrintRun = _taskToPackage.PrintRun;
        }

        public double CalcCostOfPackaging()
        {
            return pricePerUnit * PrintRun;
        }

    }
}

















        //Book myBook;
        //private double costOfPackaging;

        ////Цена за книгу на скобе
        //const double priceForStaple = 0.012;
        //const double priceForClue = 0.018;

        //public double CostOfPackaging
        //{
        //    get
        //    {
        //        return costOfPackaging;
        //    }

        //    set
        //    {
        //        costOfPackaging = value;
        //    }
        //}

        //public Packaging(Book book)
        //{
        //    myBook = book;
        //    CalcCostOfPackaging();
        //}

        //public double CalcCostOfPackaging()
        //{
        //    costOfPackaging = priceForStaple * myBook.PrintRun;

        //    return costOfPackaging;
        //}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookProduction;
using BookProduction.BookComponents;
using BookProduction.Assembly;
using BookProduction.IssueParams;
using BookProduction.Paper;
using BookProduction.PriceLists;
using BookProduction.PrintingPresses;
using BookProduction.Tasks;
using BookProduction.TypographyManagement;


namespace PolygraphyCalculator.Controllers
{
    public class PolygraphyResultController : Controller
    {
        #region бумага
        //---------на 60*90 на циркон
        //газетка 59,3/45
        PaperInKg gazetka59_D45 = new PaperInKg(PaperType.Newsprint, 45, 17.613, "Волга", 59.3);
        //офсет 60/60
        PaperInKg offset60_D60 = new PaperInKg(PaperType.Offset, 60, 23.25, "Котлас", 60);

        //-----------на 70*100 на рапиду
        //офсет 70/60
        PaperInSheets offset70_100_D60 = new PaperInSheets(PaperType.Offset, 60, 1.2851, "Люмисет", 70, 100);
        //офсет 70/80
        PaperInSheets offset70_100_D80 = new PaperInSheets(PaperType.Offset, 80, 1.574716416, "Люмисет", 70, 100);

        //-----------на 84*108 на Коросет
        //газетка 84/43
        PaperInKg gazetka84_D43 = new PaperInKg(PaperType.Newsprint, 43, 15.965, "Коростышев", 84);
        //офсет 84/60
        PaperInKg offset84_D60 = new PaperInKg(PaperType.Offset, 60, 24.75, "Люмисет", 84);
        //офсет 84/80 на Шинохару
        PaperInSheets offset84_D80 = new PaperInSheets(PaperType.Offset, 80, 1.0345, "Котлас", 84, 56);


        //на обложку
        //Картон хр.-эрз.пл.230 70х100(Умка)
        PaperInSheets hrom_erzats230 = new PaperInSheets(PaperType.FoldingBoxboard, 230, 3.172, "Умка", 70, 100);


        //на вкладки
        //Самоклейка 45х64 пл.80 
        PaperInSheets samokleyka = new PaperInSheets(PaperType.SelfAdhensivePaper, 80, 3.9857, "Самоклейка", 64, 45);
        #endregion


        // GET: PolygraphyResult
        public ActionResult PolygraphyCost()
        {
        //    #region бумага
        //    //---------на 60*90 на циркон
        //    //газетка 59,3/45
        //    PaperInKg gazetka59_D45 = new PaperInKg(PaperType.Newsprint, 45, 17.613, "Волга", 59.3);
        //    //офсет 60/60
        //    PaperInKg offset60_D60 = new PaperInKg(PaperType.Offset, 60, 23.25, "Котлас", 60);

        //    //-----------на 70*100 на рапиду
        //    //офсет 70/60
        //    PaperInSheets offset70_100_D60 = new PaperInSheets(PaperType.Offset, 60, 1.2851, "Люмисет", 70, 100);
        //    //офсет 70/80
        //    PaperInSheets offset70_100_D80 = new PaperInSheets(PaperType.Offset, 80, 1.574716416, "Люмисет", 70, 100);

        //    //-----------на 84*108 на Коросет
        //    //газетка 84/43
        //    PaperInKg gazetka84_D43 = new PaperInKg(PaperType.Newsprint, 43, 15.965, "Коростышев", 84);
        //    //офсет 84/60
        //    PaperInKg offset84_D60 = new PaperInKg(PaperType.Offset, 60, 24.75, "Люмисет", 84);
        //    //офсет 84/80 на Шинохару
        //    PaperInSheets offset84_D80 = new PaperInSheets(PaperType.Offset, 80, 1.0345, "Котлас", 84, 56);


        //    //на обложку
        //    //Картон хр.-эрз.пл.230 70х100(Умка)
        //    PaperInSheets hrom_erzats230 = new PaperInSheets(PaperType.FoldingBoxboard, 230, 3.172, "Умка", 70, 100);


        //    //на вкладки
        //    //Самоклейка 45х64 пл.80 
        //    PaperInSheets samokleyka = new PaperInSheets(PaperType.SelfAdhensivePaper, 80, 3.9857, "Самоклейка", 64, 45);
        //    #endregion

            Book Kanikularia = new Book("ОСК002", "Подорож країною Канікулярія. 2 клас", 28000,
                new BookPart("InnerBlock", new IssueFormat(70, 100, 16), offset70_100_D60, new IssueColors(2, 2), 48),
                new BookPart("Cover", new IssueFormat(70, 100, 16), hrom_erzats230, new IssueColors(4, 1), 4),
                new BookPart("Nakleyki", new IssueFormat(70, 100, 16), samokleyka, new IssueColors(4, 0), 2),
                new BookAssembly(BindingType.SaddleStitching, LaminationType.Glossy, true));


            DirectorOfTypography director = new DirectorOfTypography(Kanikularia);
            BookCostOfPolygraphy report = director.MakeBook();
            //Console.WriteLine(report.CostReport());



            return View(report);
        }

        //POST: метод будет вызываться только при пост запросах
        [HttpPost]
        public ActionResult PolygraphyCost(int pagesNumber, int printrun)
        {
            #region бумага
            //---------на 60*90 на циркон
            //газетка 59,3/45
            PaperInKg gazetka59_D45 = new PaperInKg(PaperType.Newsprint, 45, 17.613, "Волга", 59.3);
            //офсет 60/60
            PaperInKg offset60_D60 = new PaperInKg(PaperType.Offset, 60, 23.25, "Котлас", 60);

            //-----------на 70*100 на рапиду
            //офсет 70/60
            PaperInSheets offset70_100_D60 = new PaperInSheets(PaperType.Offset, 60, 1.2851, "Люмисет", 70, 100);
            //офсет 70/80
            PaperInSheets offset70_100_D80 = new PaperInSheets(PaperType.Offset, 80, 1.574716416, "Люмисет", 70, 100);

            //-----------на 84*108 на Коросет
            //газетка 84/43
            PaperInKg gazetka84_D43 = new PaperInKg(PaperType.Newsprint, 43, 15.965, "Коростышев", 84);
            //офсет 84/60
            PaperInKg offset84_D60 = new PaperInKg(PaperType.Offset, 60, 24.75, "Люмисет", 84);
            //офсет 84/80 на Шинохару
            PaperInSheets offset84_D80 = new PaperInSheets(PaperType.Offset, 80, 1.0345, "Котлас", 84, 56);


            //на обложку
            //Картон хр.-эрз.пл.230 70х100(Умка)
            PaperInSheets hrom_erzats230 = new PaperInSheets(PaperType.FoldingBoxboard, 230, 3.172, "Умка", 70, 100);


            //на вкладки
            //Самоклейка 45х64 пл.80 
            PaperInSheets samokleyka = new PaperInSheets(PaperType.SelfAdhensivePaper, 80, 3.9857, "Самоклейка", 64, 45);
            #endregion

            Book Kanikularia = new Book("ОСК002", "Подорож країною Канікулярія. 2 клас", printrun,
                new BookPart("InnerBlock", new IssueFormat(70, 100, 16), offset70_100_D60, new IssueColors(2, 2), pagesNumber),
                new BookPart("Cover", new IssueFormat(70, 100, 16), hrom_erzats230, new IssueColors(4, 1), 4),
                new BookPart("Nakleyki", new IssueFormat(70, 100, 16), samokleyka, new IssueColors(4, 0), 2),
                new BookAssembly(BindingType.SaddleStitching, LaminationType.Glossy, true));


            DirectorOfTypography director = new DirectorOfTypography(Kanikularia);
            BookCostOfPolygraphy report = director.MakeBook();

            return View(report);
        }


        [HttpPost]
        public ActionResult PolygraphyCost(BookModel _book)
        {
            Book theBook = new Book(_book);

            DirectorOfTypography director = new DirectorOfTypography(theBook);
            BookCostOfPolygraphy report = director.MakeBook();

            return View(report);

        }
    }
}
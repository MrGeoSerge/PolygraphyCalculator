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

namespace BookProduction
{
    public class Program
    {
        public static void Main(string[] args)
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


            //Book theBook = new Book("УММ034-д1", "Українська мова 8клас 2 семестр Нова програма Мій конспект", 1000, new BookPart("Внутренний блок", new IssueFormat(84,108,16),
            //    new PaperInKg (PaperType.Newsprint,45, 15.656, "Шклов",84),new IssueColors(1,1), 88),
            //    new BookPart("Обложка", new IssueFormat(84,108,16), new PaperInSheets(PaperType.FoldingBoxboard,230,2.5,"Умка",64,90),
            //    new IssueColors(4,1), 4), new BookAssembly(BindingType.SaddleStitching, LaminationType.Glossy, true, PerforationType.usual));

            //Book theBook = new Book("МДН3-д3", "Мій конспект. 4-й рік життя. ІІ півріччя", 1500, new BookPart("Внутренний блок", new IssueFormat(84,108,16),
            //    new PaperInKg (PaperType.Newsprint,45, 16.892, "Германия",84),new IssueColors(1,1), 208),
            //    new BookPart("Обложка", new IssueFormat(84,108,16), new PaperInSheets(PaperType.FoldingBoxboard,230,2.5,"Умка",64,90),
            //    new IssueColors(4,0), 4), new BookAssembly(BindingType.PerfectBinding, LaminationType.Glossy, true, PerforationType.usual));

            //Book theBook = new Book("МДН3-д3", "Мій конспект. 4-й рік життя. ІІ півріччя", 1000, new BookPart("Внутренний блок", new IssueFormat(60, 90, 16),
            //    new PaperInKg(PaperType.Newsprint, 45, 16.995, "Шклов", 59.4), new IssueColors(1, 1), 128),
            //    new BookPart("Обложка", new IssueFormat(60, 90, 16), new PaperInSheets(PaperType.FoldingBoxboard, 230, 2.5, "Умка", 70, 100),
            //    new IssueColors(4, 0), 4), new BookAssembly(BindingType.PerfectBinding, LaminationType.Glossy, true, PerforationType.usual));

            Book Kanikularia = new Book("ОСК002", "Подорож країною Канікулярія. 2 клас", 28000,
                new BookPart("InnerBlock", new IssueFormat(70, 100, 16), offset70_100_D60, new IssueColors(2, 2), 48),
                new BookPart("Cover", new IssueFormat(70, 100, 16), hrom_erzats230, new IssueColors(4, 1), 4),
                new BookPart("Nakleyki", new IssueFormat(70, 100, 16), samokleyka, new IssueColors(4, 0), 4),
                new BookAssembly(BindingType.SaddleStitching, LaminationType.Glossy, true));


            Console.WriteLine(Kanikularia);

            DirectorOfTypography director = new DirectorOfTypography(Kanikularia);
            BookCostOfPolygraphy report = director.MakeBook();
            Console.WriteLine(report.CostReport());

            //CorosetPlamag coroset1;
            //coroset1 = new CorosetPlamag(new TaskToPrint("internal block", new IssueFormat(84, 108, 16),
            //    new PaperInKg(PaperType.Newsprint, 43, 15.965, "Коростышев", 84), new IssueColors(1, 1), 152, 1000));

            //Book theBook = new Book("УММ034-д1", "Українська мова 8клас 2 семестр Нова програма Мій конспект", 1000, new BookPart("Внутренний блок", new IssueFormat(84,108,16),
            //    new PaperInKg (PaperType.Newsprint,43, 13.17473, "Змиев",84),new IssueColors(1,1), 88),
            //    new BookPart("Обложка", new IssueFormat(84,108,16), new PaperInSheets(PaperType.FoldingBoxboard,230,2.5,"Умка",64,90),
            //    new IssueColors(4,1), 4), new BookAssembly(BindingType.SaddleStitching, LaminationType.Glossy, true, PerforationType.usual));

            //DirectorOfTypography director = new DirectorOfTypography(theBook);
            //BookCostOfPolygraphy report =  director.MakeBook();
            //Console.WriteLine(report.CostReport());





            //Book MkBook = new Book("УММ034-д1", "Українська мова 8клас 2 семестр Нова програма Мій конспект", 1000,
            //    new BookPart("Внутренний блок",
            //       new IssueFormat(84, 108, 16),
            //       new PaperInKg(PaperType.Newsprint, 45, 15.656, "Шклов", 84),
            //       new IssueColors(1, 1), 88),
            //    new BookPart("Обложка",
            //       new IssueFormat(84, 108, 16),
            //       new PaperInSheets(PaperType.FoldingBoxboard, 230, 2.482, "Умка", 64, 90),
            //       new IssueColors(4, 1), 4),
            //    new BookAssembly(BindingType.SaddleStitching, LaminationType.Glossy, true, PerforationType.usual));

            ////director = new DirectorOfTypography(theBook);
            ////report = director.MakeBook();
            //DirectorOfTypography director = new DirectorOfTypography(MkBook);
            //BookCostOfPolygraphy report =  director.MakeBook();
            //Console.WriteLine(report.CostReport());

        }
    }
}

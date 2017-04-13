using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookProduction
{
    //Директор типографии раздает задания (- формирует Task-и) на печатные машины и другие виды работ
    public class DirectorOfTypography
    {
        Book book;

        public DirectorOfTypography(Book book)
        {
            this.book = book;
        }

        public BookCostOfPolygraphy MakeBook()
        {
            List<TaskToPrint> tasksToPrint = new List<TaskToPrint>();

            foreach (BookPart bookPart in book.BookParts)
            {
                tasksToPrint.Add(new TaskToPrint(bookPart.Name, bookPart.Format, bookPart.Paper,
                    bookPart.Colors, bookPart.PagesNumber, book.PrintRun));
            }

            List<PressReport> pressReports = new List<PressReport>();
            foreach (TaskToPrint taskToPrint in tasksToPrint)
            {
                pressReports.Add(PrintBookPart(taskToPrint));
            }

            foreach (PressReport pressReport in pressReports)
            {
                pressReport.ShowDetailedReport();
            }

            //записываем все затраты обратно в книгу и собираем (assemble) книгу
            return new BookCostOfPolygraphy(book, AssembleBook(), pressReports);
        }



        //сделать книгу - это отпечатать части книги (внутренний блок(и), обложку, вклейки)
        //и собрать (переплести, сделать ламинацию, перфорацию, упаковать)

        //отпечатать часть книги (внутренний блок, обложку или вклейку)
        private PressReport PrintBookPart(TaskToPrint _taskForPart)
        {
            PrintingPress printingPress;
            PressReport bookPartReport;

            //-----------выбираем, на каком станке печатать-----------

            //коросет, если 84*108 формат и плотность не более 60 г/м2
            if (_taskForPart.Format.Length == 84 && _taskForPart.Format.Width == 108
                && _taskForPart.Paper.Density <= 60)
            {
                printingPress = new CorosetPlamag(_taskForPart);
            }

            //циркон, если 60*90 формат и плотность не более 60 г/м2
            else if (_taskForPart.Format.Length == 60 && _taskForPart.Format.Width == 90
                && _taskForPart.Paper.Density <= 60)
            {
                printingPress = new ZirkonForta660(_taskForPart);
            }

            //шинохара, если 84*108 формат и плотность  более 80 г/м2
            else if (_taskForPart.Format.Length == 84 && _taskForPart.Format.Width == 108
                && _taskForPart.Paper.Density > 80)
            {
                printingPress = new Shinohara52_2(_taskForPart);
            }

            //роланд, если 70*100 формат и цветность больше 2+2
            //else if (_taskForPart.Format.Length == 70 && _taskForPart.Format.Width == 100 
            //    && _taskForPart.Colors.FrontColors >=2)
            //{
            //    printingPress = new Rapida(_taskForPart);
            //}

            //рапида для обложек - Хром-эрзац или для плотной бумаги
            else if (_taskForPart.Colors.Total() >= 4)
            {
                printingPress = new Rapida74_5(_taskForPart);
            }

            else
                throw new Exception("не нашли подходящий станок для печати" + _taskForPart);

            bookPartReport = printingPress.SendReport();
            return bookPartReport;
        }



        //cобрать книгу
        private AssemblyReport AssembleBook()
        {
            AssemblyReport assemblyReport = new AssemblyReport();

            //Переплет
            TaskToBind taskToBind = new TaskToBind(book.BookParts[0].Format, book.BookParts[0].PagesNumber, book.PrintRun);
            assemblyReport.AddCostOfBinding(MakeBinding(taskToBind));

            //Перфорация
            if (book.BookAssembly.Perforation != 0)
            {
                TaskToPerforation taskToPerforation = new TaskToPerforation(book.BookAssembly.Perforation, book.PrintRun,
                    book.BookAssembly.BindingType, book.BookParts[0].PagesNumber);
                assemblyReport.AddCostOfPerforation(MakePerforation(taskToPerforation));
            }

            //Ламинация 
            TaskToLamination taskToLamination = new TaskToLamination(book.BookParts[0].Format, book.BookAssembly.LaminationType, book.PrintRun);
            assemblyReport.AddCostOfLamination(MakeLamination(taskToLamination));

            //Упаковка
            TaskToPackage taskToPackage = new TaskToPackage(book.BookAssembly.BindingType, book.PrintRun);
            assemblyReport.AddCostOfPackaging(MakePackaging(taskToPackage));

            assemblyReport.CalcTotalCostOfAssembly();
            //assemblyReport.ShowDetailedReport();

            return assemblyReport;
        }



        //сделать переплет
        private double MakeBinding(TaskToBind _taskToBind)
        {
            Binding binding = null;
            switch (book.BookAssembly.BindingType)
            {
                case BindingType.PerfectBinding:
                    binding = new Perfect(_taskToBind);
                    break;

                case BindingType.SaddleStitching:
                    binding = new SaddleStitching(_taskToBind);
                    break;

                case BindingType.HardcoverBinding:
                    binding = new HardCover(_taskToBind);
                    break;
                default:
                    throw new Exception("неправильно указан переплет");
            }

            return binding.CalcCostOfBinding();
        }

        //сделать перфорацию
        private double MakePerforation(TaskToPerforation _taskToPerforation)
        {
            Perforation perforation = new Perforation(_taskToPerforation);
            return perforation.CalcCostOfPerforation();
        }

        //сделать ламинацию
        private double MakeLamination(TaskToLamination _taskToLamination)
        {
            return new Lamination(_taskToLamination).CalcCostOfLamination();
        }

        //сделать упаковку
        private double MakePackaging(TaskToPackage _taskToPackage)
        {
            Packaging packaging = new Packaging(_taskToPackage);
            return packaging.CalcCostOfPackaging();
        }
    }
}

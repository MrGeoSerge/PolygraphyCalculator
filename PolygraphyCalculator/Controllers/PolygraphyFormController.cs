using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookProduction;
using PolygraphyCalculator.Models;
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
    public class PolygraphyFormController : Controller
    {
        // GET: PolygraphyForm
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Index(BookModel _book)
        //{
        //    Book theBook = new Book(_book);

        //    DirectorOfTypography director = new DirectorOfTypography(theBook);
        //    BookCostOfPolygraphy report = director.MakeBook();
        //    ViewBag.Report = report;
        //    return View();
        //}

        //[HttpGet]
        //public ActionResult Start()
        //{
        //    Book theBook = new Book("УММ034-д1", "Українська мова 8клас 2 семестр Нова програма Мій конспект", 1000, new BookPart("Внутренний блок", new IssueFormat(84, 108, 16),
        //        new PaperInKg(PaperType.Newsprint, 45, 15.656, "Шклов", 84), new IssueColors(1, 1), 88),
        //        new BookPart("Обложка", new IssueFormat(84, 108, 16), new PaperInSheets(PaperType.FoldingBoxboard, 230, 2.5, "Умка", 64, 90),
        //        new IssueColors(4, 1), 4), new BookAssembly(BindingType.SaddleStitching, LaminationType.Glossy, true, PerforationType.usual));

        //    BookModel _book = new BookModel(theBook);
        //    return View(_book);
        //}

        //[HttpPost]
        //public ActionResult Start(BookModel _book)
        //{
        //    Book theBook = new Book(_book);

        //    DirectorOfTypography director = new DirectorOfTypography(theBook);
        //    BookCostOfPolygraphy report = director.MakeBook();
        //    ViewBag.Report = report;
        //    return View();
        //}

        //здесь начало приложения
        [HttpGet]
        public ActionResult Calculate()
        {
            List<PaperTypes> IB_PaperTypes = new List<PaperTypes>()
            {
                new PaperTypes() {Id = BookProduction.PaperFullType.Newsprint_45, Name="газетка 45 г/м2" },
                new PaperTypes() {Id = BookProduction.PaperFullType.Offset_60, Name="офсет 60 г/м2" },
                new PaperTypes() {Id = BookProduction.PaperFullType.Offset_80, Name="офсет 80 г/м2" }
            };
            ViewBag.IB_PaperTypes = IB_PaperTypes;

            List<PaperTypes> CoverPaperTypes = new List<PaperTypes>()
            {
                new PaperTypes() {Id = BookProduction.PaperFullType.FoldingBoxboard_230, Name="хром-эрзац 230 г/м2" },
                new PaperTypes() {Id = BookProduction.PaperFullType.CardboardAliaska_230, Name="картон Аляска 230 г/м2" }
            };
            ViewBag.CoverPaperTypes = CoverPaperTypes;

            return View();
        }

        [HttpPost]
        public ActionResult Calculate(BookModel _book)
        {
            List<PaperTypes> IB_PaperTypes = new List<PaperTypes>()
            {
                new PaperTypes() {Id = BookProduction.PaperFullType.Newsprint_45, Name="газетка 45 г/м2" },
                new PaperTypes() {Id = BookProduction.PaperFullType.Offset_60, Name="офсет 60 г/м2" },
                new PaperTypes() {Id = BookProduction.PaperFullType.Offset_80, Name="офсет 80 г/м2" }
            };
            ViewBag.IB_PaperTypes = IB_PaperTypes;

            List<PaperTypes> CoverPaperTypes = new List<PaperTypes>()
            {
                new PaperTypes() {Id = BookProduction.PaperFullType.FoldingBoxboard_230, Name="хром-эрзац 230 г/м2" },
                new PaperTypes() {Id = BookProduction.PaperFullType.CardboardAliaska_230, Name="картон Аляска 230 г/м2" }
            };
            ViewBag.CoverPaperTypes = CoverPaperTypes;

            if (ModelState.IsValid)
            {
                Book theBook = new Book(_book);
                DirectorOfTypography director = new DirectorOfTypography(theBook);
                BookCostOfPolygraphy report = director.MakeBook();
                ViewBag.Report = report;
                return View(_book);
            }
            return View();
        }

        public ActionResult Calculations(BookModel _book)
        {
            if (ModelState.IsValid)
            {
                Book theBook = new Book(_book);

                DirectorOfTypography director = new DirectorOfTypography(theBook);
                BookCostOfPolygraphy report = director.MakeBook();
               
                return PartialView(report);
            }
            return new EmptyResult();

        }
    }
}
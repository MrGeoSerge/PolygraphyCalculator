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


namespace BookProduction.BookComponents
{
    //части книги: внутренние блоки, обложки, вставки
    public class BookPart
    {
        public string Name { set; get; }
        public IssueFormat Format { set; get; }
        public AbstractPaper Paper { set; get; }
        public IssueColors Colors { set; get; }
        public int PagesNumber { set; get; }

        public BookPart(string _name, IssueFormat _format,AbstractPaper _paper, IssueColors _colors, int _pagesNumber)
        {
            Name = _name;
            Format = _format;
            Paper = _paper;
            Colors = _colors;
            PagesNumber = _pagesNumber;
        }

        public BookPart() { }
    }
}

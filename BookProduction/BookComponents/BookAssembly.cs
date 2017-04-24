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
    //сборка книги: переплет, упаковка, ламинация
    public class BookAssembly
    {
        public BindingType BindingType { private set; get; }
        public LaminationType LaminationType { private set; get; }
        public bool Packaging { private set; get; }
        public PerforationType Perforation { set; get; }

        public BookAssembly(BindingType _bindingType, LaminationType _laminationType, bool _packaging)
        {
            BindingType = _bindingType;
            LaminationType = _laminationType;
            Packaging = _packaging;
            Perforation = PerforationType.withoutPerforation;
        }
        public BookAssembly(BindingType _bindingType, LaminationType _laminationType, bool _packaging, PerforationType _perforation)
        {
            BindingType = _bindingType;
            LaminationType = _laminationType;
            Packaging = _packaging;
            Perforation = _perforation;
        }
    }

}

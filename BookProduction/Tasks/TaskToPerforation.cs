using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProduction
{
    public class TaskToPerforation
    {
        public PerforationType PerforationType { set; get; }

        public int PrintRun { set; get; }
        public BindingType BindingType { set; get; }

        public int PagesNumber { set; get; }

        public TaskToPerforation(PerforationType _perforationType, int _printRun, BindingType _bindingType, int _pagesNumber)
        {
            PerforationType = _perforationType;
            PrintRun = _printRun;
            BindingType = _bindingType;
            PagesNumber = _pagesNumber;
        }


    }
}

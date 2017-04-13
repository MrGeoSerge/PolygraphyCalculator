using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProduction
{
    public class TaskToPackage
    {
        public BindingType BindingType{set; get;}
        public int PrintRun { set; get; }

        public TaskToPackage(BindingType _bindingType, int _printRun)
        {
            BindingType = _bindingType;
            PrintRun = _printRun;
        }
    }
}

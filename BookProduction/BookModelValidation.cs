using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProduction
{
    class DivideByEightAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return true;
            return ((int)value) % 8 == 0 ? true: false ;
        }
    }
}

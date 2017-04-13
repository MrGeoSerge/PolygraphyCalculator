using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookProduction;

namespace PolygraphyCalculator.Models
{
	public class PaperTypes
    {
        public PaperFullType Id { get; set; }
        public string Name { get; set; }

    }

    public class BindingTypes
    {
        public BindingType Id { get; set; }
        public string Name { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookProduction.PriceLists;

namespace PolygraphyCalculator.Models
{
    public interface IRolledPressPriceModel
    {
        double Form { get; set; }

        int Fitting { get; set; }

        double TechNeeds1_1 { get; set; }

        double TechNeeds2_2 { get; set; }

        double Impression1_1 { get; set; }

        double Impression2_2 { get; set; }

        void UpdatePrice();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProduction
{
    //PressPrice - класс, где хранятся данные из прайса
    public static class RapidaPressPriceList
    {
        //4 параметра определяют прайс на печатную машину
        //стоимость изготовления формы (не зависит от тиража)
        static public double Form { set; get; }

        //приладка (зависит от цветности) - и от тиража, то есть, если технужды > 0, приладка = 0
        static public Dictionary<IssueColors, double> Fitting { set; get; }

        //технужды в процентах зависят от тиража
        static public Dictionary<int, double> TechNeeds { set; get; }

        //стоимость оттисков зависит от тиража
        static public Dictionary<int, double> Impression { set; get; }


        static RapidaPressPriceList()
        {
            Form = 108.0;

            Fitting = new Dictionary<IssueColors, double>();
            Fitting.Add(new IssueColors(4, 0), 300);
            Fitting.Add(new IssueColors(4, 1), 300);
            Fitting.Add(new IssueColors(2, 2), 300);
            Fitting.Add(new IssueColors(4, 2), 350);
            Fitting.Add(new IssueColors(4, 4), 350);

            TechNeeds = new Dictionary<int, double>();
            TechNeeds.Add(2999, 0);
            TechNeeds.Add(Int32.MaxValue, 8.0);

            Impression = new Dictionary<int, double>();
            Impression.Add(999, 0.132);
            Impression.Add(2999, 0.059);
            Impression.Add(4999, 0.050);
            Impression.Add(9999, 0.037);
            Impression.Add(Int32.MaxValue, 0.037);


        }

    }


 













}

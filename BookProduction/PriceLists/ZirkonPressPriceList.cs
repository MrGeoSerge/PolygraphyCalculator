using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProduction
{
    //PressPrice - класс, где хранятся данные из прайса
    //ZirkonForta660
    public static class ZirkonPressPriceList
    {
        //4 параметра определяют прайс на печатную машину
        //стоимость изготовления формы (не зависит от тиража)
        static public double Form { set; get; }

        //приладка (зависит от цветности) - и от тиража, то есть, если технужды > 0, приладка = 0
        static public int Fitting { set; get; }

        //технужды в процентах зависят от цветности
        static public Dictionary<string, double> TechNeeds { set; get; }

        //стоимость оттисков зависит от цветности
        static public Dictionary<string, double> Impression { set; get; }


        static ZirkonPressPriceList()
        {
            Form = 90;

            Fitting = 400;
 
            TechNeeds = new Dictionary<string, double>();
            TechNeeds.Add("1+1", 4.7);
            TechNeeds.Add("2+2", 1.2);//+1.2% на каждый доп. цвет

            Impression = new Dictionary<string, double>();
            Impression.Add("1+1", 0.0367);
            Impression.Add("2+2", 0.0174);//+0.0174 на каждый доп. цвет
        }

    }


 













}

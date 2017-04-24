using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookProduction.PriceLists;
using PolygraphyCalculator.Models;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace PolygraphyCalculator.Models
{
    public class CorosetPriceModel: IRolledPressPriceModel
    {
        [Display(Name = "Стоимость изготовления формы, грн")]
        [Required(ErrorMessage = "Введите стоимость формы")]
        [Range(126, 300, ErrorMessage = "Стоимость формы в пределах 126-300 грн")]
        public double Form { get; set; }

        [Display(Name = "Приладка на 1 форму, листов формата оборудования")]
        [Required(ErrorMessage = "Введите количество листов приладки")]
        [Range(400, 600, ErrorMessage = "Количество листов приладки в пределах 400-600")]
        public int Fitting { get; set; }

        [Display(Name = "Технужды, %")]
        [Required(ErrorMessage = "Введите процент технужд")]
        [Range(4.7, 6.0, ErrorMessage = "Процент технужд в пределах 4,7-6,0")]
        public double TechNeeds1_1 { get; set; }

        [Display(Name = "Технужды на дополнительный цвет, %")]
        [Required(ErrorMessage = "Введите процент технужд на дополнительный цвет")]
        [Range(1.2, 2.0, ErrorMessage = "Процент технужд на доп. цвет 1,2-2,0")]
        public double TechNeeds2_2 { get; set; }

        [Display(Name = "Стоимость оттисков, грн")]
        [Required(ErrorMessage = "Введите стоимость оттисков")]
        [Range(0.0735, 0.15, ErrorMessage = "Стоимость оттисков в пределах 0,0735-0,15")]
        public double Impression1_1 { get; set; }

        [Display(Name = "Стоимость оттисков на каждый дополнительный цвет")]
        [Required(ErrorMessage = "Введите стоимость оттисков на доп. цвет")]
        [Range(0.035, 0.1, ErrorMessage = "Стоимость оттисков на доп. цвет в пределах 0,035-0,1")]
        public double Impression2_2 { get; set; }

        public CorosetPriceModel()
        {
            Form = CorosetPressPriceList.Form;
            Fitting = CorosetPressPriceList.Fitting;
            TechNeeds1_1 = CorosetPressPriceList.TechNeeds["1+1"];
            TechNeeds2_2 = CorosetPressPriceList.TechNeeds["2+2"];
            Impression1_1 = CorosetPressPriceList.Impression["1+1"];
            Impression2_2 = CorosetPressPriceList.Impression["2+2"];
        }

        public void UpdatePrice()
        {
            CorosetPressPriceList.Form = Form;
            CorosetPressPriceList.Fitting = Fitting;
            CorosetPressPriceList.TechNeeds["1+1"] = TechNeeds1_1;
            CorosetPressPriceList.TechNeeds["2+2"] = TechNeeds2_2;
            CorosetPressPriceList.Impression["1+1"] = Impression1_1;
            CorosetPressPriceList.Impression["2+2"] = Impression2_2;

            try
            {
                ZirkonPressPriceList.WriteToFile();
            }
            catch (System.IO.IOException ex)
            {
                Debug.WriteLine(ex);
            }
        }

    }
}
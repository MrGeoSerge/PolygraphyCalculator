using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookProduction.PriceLists;
using PolygraphyCalculator.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace PolygraphyCalculator.Models
{
    public class ZirkonPriceModel: IRolledPressPriceModel
    {
        [Display(Name = "Стоимость изготовления формы, грн")]
        [Required(ErrorMessage = "Введите стоимость формы")]
        [Range(typeof(double), "90", "200", ErrorMessage = "Стоимость формы в пределах 90-200 грн")]
        public double Form { get; set; }

        [Display(Name = "Приладка на 1 форму, листов формата оборудования")]
        [Required(ErrorMessage = "Введите количество листов приладки")]
        [Range(typeof(int), "400", "600", ErrorMessage = "Количество листов приладки в пределах 400-600")]
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
        [Range(0.0367, 0.1, ErrorMessage = "Стоимость оттисков в пределах 0,0367-0,1")]
        public double Impression1_1 { get; set; }

        [Display(Name = "Стоимость оттисков на каждый дополнительный цвет")]
        [Required(ErrorMessage = "Введите стоимость оттисков на доп. цвет")]
        [Range(0.0174, 0.1, ErrorMessage = "Стоимость оттисков на доп. цвет в пределах 0,0174-0,05")]
        public double Impression2_2 { get; set; }


        public ZirkonPriceModel()
        {
            Form = ZirkonPressPriceList.Form;
            Fitting = ZirkonPressPriceList.Fitting;
            TechNeeds1_1 = ZirkonPressPriceList.TechNeeds["1+1"];
            TechNeeds2_2 = ZirkonPressPriceList.TechNeeds["2+2"];
            Impression1_1 = ZirkonPressPriceList.Impression["1+1"];
            Impression2_2 = ZirkonPressPriceList.Impression["2+2"];
        }

        public void UpdatePrice()
        {
            ZirkonPressPriceList.Form = Form;
            ZirkonPressPriceList.Fitting = Fitting;
            ZirkonPressPriceList.TechNeeds["1+1"] = TechNeeds1_1;
            ZirkonPressPriceList.TechNeeds["2+2"] = TechNeeds2_2;
            ZirkonPressPriceList.Impression["1+1"] = Impression1_1;
            ZirkonPressPriceList.Impression["2+2"] = Impression2_2;

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
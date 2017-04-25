using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookProduction.PriceLists;
using BookProduction.IssueParams;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace PolygraphyCalculator.Models
{
    public class RapidaPriceModel
    {
        [Display(Name = "Стоимость изготовления формы, грн")]
        [Required(ErrorMessage = "Введите стоимость формы")]
        [Range(typeof(double), "108", "200", ErrorMessage = "Стоимость формы в пределах 108-200 грн")]
        public double Form { get; set; }

        [Display(Name = "Цветность 4+0")]
        [Required(ErrorMessage = "Введите количество листов приладки")]
        [Range(300, 500, ErrorMessage = "Количество листов приладки в пределах 300-500")]
        public double Fitting4_0 { get; set; }

        [Display(Name = "Цветность 4+1")]
        [Required(ErrorMessage = "Введите количество листов приладки")]
        [Range(300, 500, ErrorMessage = "Количество листов приладки в пределах 300-500")]
        public double Fitting4_1 { get; set; }

        [Display(Name = "Цветность 2+2")]
        [Required(ErrorMessage = "Введите количество листов приладки")]
        [Range(300, 500, ErrorMessage = "Количество листов приладки в пределах 300-500")]
        public double Fitting2_2 { get; set; }

        [Display(Name = "Цветность 4+2")]
        [Required(ErrorMessage = "Введите количество листов приладки")]
        [Range(350, 500, ErrorMessage = "Количество листов приладки в пределах 350-500")]
        public double Fitting4_2 { get; set; }

        [Display(Name = "Цветность 4+4")]
        [Required(ErrorMessage = "Введите количество листов приладки")]
        [Range(350, 500, ErrorMessage = "Количество листов приладки в пределах 350-500")]
        public double Fitting4_4 { get; set; }

        [Display(Name = "до 3000, %")]
        [Required(ErrorMessage = "Введите процент технужд")]
        [Range(0.0, 2.0, ErrorMessage = "Процент технужд в пределах 0-2%")]
        public double TechNeedsLT2999 { get; set; }

        [Display(Name = "от 3000, %")]
        [Required(ErrorMessage = "Введите процент технужд")]
        [Range(8.0, 10.0, ErrorMessage = "Процент технужд в пределах 8-10%")]
        public double TechNeedsGT2999 { get; set; }

        [Display(Name = "до 999, грн")]
        [Required(ErrorMessage = "Введите стоимость оттисков")]
        [Range(0.132, 0.4, ErrorMessage = "Стоимость оттисков в пределах 0,132-0,4")]
        public double ImpressionLT999 { get; set; }

        [Display(Name = "от 1000 до 2999, грн")]
        [Required(ErrorMessage = "Введите стоимость оттисков")]
        [Range(0.059, 0.3, ErrorMessage = "Стоимость оттисков в пределах 0,059-0,3")]
        public double ImpressionLT2999 { get; set; }

        [Display(Name = "от 3000 до 4999, грн")]
        [Required(ErrorMessage = "Введите стоимость оттисков")]
        [Range(0.050, 0.3, ErrorMessage = "Стоимость оттисков в пределах 0,050-0,3")]
        public double ImpressionLT4999 { get; set; }

        [Display(Name = "от 5000 до 9999, грн")]
        [Required(ErrorMessage = "Введите стоимость оттисков")]
        [Range(0.037, 0.3, ErrorMessage = "Стоимость оттисков в пределах 0,037-0,3")]
        public double ImpressionLT9999 { get; set; }

        [Display(Name = "от 10 000, грн")]
        [Required(ErrorMessage = "Введите стоимость оттисков")]
        [Range(0.037, 0.3, ErrorMessage = "Стоимость оттисков в пределах 0,037-0,3")]
        public double ImpressionGT9999 { get; set; }


        public RapidaPriceModel()
        {
            Form = RapidaPressPriceList.Form;

            Fitting4_0 = RapidaPressPriceList.Fitting["4+0"];
            Fitting4_1 = RapidaPressPriceList.Fitting["4+1"];
            Fitting2_2 = RapidaPressPriceList.Fitting["2+2"];
            Fitting4_2 = RapidaPressPriceList.Fitting["4+2"];
            Fitting4_4 = RapidaPressPriceList.Fitting["4+4"];

            TechNeedsLT2999 = RapidaPressPriceList.TechNeeds[2999];
            TechNeedsGT2999 = RapidaPressPriceList.TechNeeds[Int32.MaxValue];

            ImpressionLT999 = RapidaPressPriceList.Impression[999];
            ImpressionLT2999 = RapidaPressPriceList.Impression[2999];
            ImpressionLT4999 = RapidaPressPriceList.Impression[4999];
            ImpressionLT9999 = RapidaPressPriceList.Impression[9999];
            ImpressionGT9999 = RapidaPressPriceList.Impression[Int32.MaxValue];
        }

        public void UpdatePrice()
        {
            RapidaPressPriceList.Form = Form;

            RapidaPressPriceList.Fitting["4+0"] = Fitting4_0;
            RapidaPressPriceList.Fitting["4+1"] = Fitting4_1;
            RapidaPressPriceList.Fitting["2+2"] = Fitting2_2;
            RapidaPressPriceList.Fitting["4+2"] = Fitting4_2;
            RapidaPressPriceList.Fitting["4+4"] = Fitting4_4;

            RapidaPressPriceList.TechNeeds[2999] = TechNeedsLT2999;
            RapidaPressPriceList.TechNeeds[Int32.MaxValue] = TechNeedsGT2999;

            RapidaPressPriceList.Impression[999] = ImpressionLT999;
            RapidaPressPriceList.Impression[2999] = ImpressionLT2999;
            RapidaPressPriceList.Impression[4999] = ImpressionLT4999;
            RapidaPressPriceList.Impression[9999] = ImpressionLT9999;
            RapidaPressPriceList.Impression[Int32.MaxValue] = ImpressionGT9999;

            try
            {
                RapidaPressPriceList.WriteToFile();
            }
            catch (System.IO.IOException ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
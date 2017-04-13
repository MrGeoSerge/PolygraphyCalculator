using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProduction
{
    //прайс типографии реализован в виде словарей на разные услуги
    public static class Price
    {
        //перфорация
        static public Dictionary<string, double> Perforation;

        //упаковка
        static public Dictionary<string, double> Packaging;

        //ламинация
        static public Dictionary<string, double> Lamination;

        //-----------Переплет--------------
        //ПереплетСкоба для формата 60*90/16 и подобных
        static public Dictionary<string, double> SaddleStitching60_90_16;

        //----------Печатные машины-----------
        //Циркон
        static public Dictionary<string, double> Tsirkon;

        //Рапида
        static public Dictionary<string, double> Rapida;

        static Price()
        {
            #region Perforation
            Perforation = new Dictionary<string, double>();
            
            //При 1 типе переплета (скоба)
            //'Перфорация, грн до48 стр. офсет 65г,/м2 , грн. 0,059
            Perforation.Add("Staple_First_48pages_Block", 0.059);

            //'Перфорация, за каждые дополнительные 16 стр. офсет 65г,/м2 грн. 0,033
            Perforation.Add("Staple_additional_16pages_Block", 0.033);

            //При 3 типе переплета(клей)
            //'Перфорация за каждую тетрадь, грн 0,033
            Perforation.Add("Clue_forEach16pages_Block", 0.033);

            //При 1 типе переплета(скоба)
            //Упрощенная перфорация, грн до48 стр.офсет 65г,/ м2, грн. 0, 050
            Perforation.Add("Simplified_Staple_First_48pages_Block", 0.050);

            //Упрощенная перфорация, за каждые дополнительные 16 стр.офсет 65г,/ м2 грн. 0, 025
            Perforation.Add("Simplified_Staple_additional_16pages_Block", 0.025);

            //При 3 типе переплета(клей)
            //'Перфорация за каждую тетрадь, грн 0,025
            Perforation.Add("Simplified_Clue_forEach16pages_Block", 0.025);

            //количество страниц в тетради
            Perforation.Add("PagesInBlock", 16.0);

            #endregion

            #region Packaging
            //Упаковка
            Packaging = new Dictionary<string, double>();

            //Упаковка(книги на скобе) 0,012
            Packaging.Add("PriceForStaple", 0.012);

            //Упаковка(клей) 0,018
            Packaging.Add("PriceForClue", 0.018);

            #endregion

            #region Lamination
            //ламинация
            Lamination = new Dictionary<string, double>();

            //Ламинация  (с материалом), грн.глянцевая	матовая
            //А1                                    2,7     3,72
            //А2                                    1,35    1,86
            //А3                                    0,675   0,93
            //А4                                  0,34    0,465
            Lamination.Add("A1_Glossy", 2.7);
            Lamination.Add("A1_Matte", 3.72);
            Lamination.Add("A2_Glossy", 1.35);
            Lamination.Add("A2_Matte", 1.86);
            Lamination.Add("A3_Glossy", 0.675);
            Lamination.Add("A3_Matte", 0.93);
            Lamination.Add("A4_Glossy", 0.34);
            Lamination.Add("A4_Matte", 0.465);


            #endregion

            #region Tsirkon
            Tsirkon = new Dictionary<string, double>();
            //Миллер,Циркон(формат А2) - рубка 0,452 м
            //Наименование затрат                                           Цветность печати
            //                                                 1 + 1       свыше 1 + 1
            //Стоимость изготовления формы, грн.                 90
            //Приладка на 1 форму, листов формата оборудования                400
            //Технужды,%                                       4,7 % +       1,2 % на цвет
            //Стоимость оттисков, грн.                        0,0367         + 0,0174 на каждый дополнительный цвет


            //Стоимость изготовления формы, грн. 90
            Tsirkon.Add("PriceOfFormProduction", 90.0);
            //Приладка на 1 форму, листов формата оборудования 400
            Tsirkon.Add("FittingOneFormInSheets", 400.0);
            //Технужды,%  4,7 % +
            Tsirkon.Add("techNeedsForOneColor", 4.7);
            //Технужды,%   +  1,2 % на цвет
            Tsirkon.Add("techNeedsForAdditionalColors", 1.2);
            //Стоимость оттисков, грн. 0,0367

            #endregion


            #region Rapida
            // Рапида(формат А2) 70*100/2
            Rapida = new Dictionary<string, double>();
            //!!! Тираж в листах формата оборудования!!! а не в тираже издания

            //Стоимость изготовления формы, грн. - 108 
            Rapida.Add("CostOfOneFormProduction", 108.0);

            //Приладка на весь тираж, в листах формата оборудования(цветность 4 + 0, 4 + 1, 2 + 2)тиражем до 3000 300
            Rapida.Add("FittingOnPrintRunInSheets4+0,4+1,2+2upTo3000PrintRun", 300.0);

            //Приладка на весь тираж, в листах формата оборудования (цветность 4 + 2, 4 + 4) тиражем до 3000 - 350
            Rapida.Add("FittingOnPrintRunInSheets4+2,4+4upTo3000PrintRun", 350.0);

            //Тираж, до которого считается приладка, а после  - технужды
            Rapida.Add("PrintRunBetweenFittingAndTechNeeds", 3000.0);

            //Технужды, % от 3000 тиража 8 %
            Rapida.Add("TechNeedsFrom3000PrintRun", 0.08);

            //Стоимость оттисков, грн. при тираже от 1 до 999 -  0,132
            Rapida.Add("CostOfOnePrintUpTo1000PrintRun", 0.132);

            //Стоимость оттисков, грн. при тираже 1000 - 2999 -  0,059
            Rapida.Add("CostOfOnePrintUpTo3000PrintRun", 0.059);

            //Стоимость оттисков, грн. при тираже 3000 - 4999 -  0,050
            Rapida.Add("CostOfOnePrintUpTo5000PrintRun", 0.050);
               
            //Стоимость оттисков, грн. при тираже 5000 - 9999 -  0,037
            Rapida.Add("CostOfOnePrintUpTo10000PrintRun", 0.037);

            //Стоимость оттисков, грн. при тираже более 10000 -  0,037
            Rapida.Add("CostOfOnePrintOver10000PrintRun", 0.037);
               
               





            #endregion

        }

    }
}

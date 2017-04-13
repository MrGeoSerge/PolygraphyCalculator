using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProduction
{
    public class AssemblyReport
    {
        public double costOfBinding { set; get; }

        public double costOfPerforation { set; get; }
        public double costOfLamination { set; get; }
        public double costOfPackaging { set; get; }

        public double totalCostOfAssembly { set; get; }

        public void AddCostOfBinding(double _costOfBinding)
        {
            costOfBinding = _costOfBinding;
        }

        public void AddCostOfPerforation(double _costOfPerforation)
        {
            costOfPerforation = _costOfPerforation;
        }

        public void AddCostOfLamination(double _costOfLamination)
        {
            costOfLamination = _costOfLamination;
        }

        public void AddCostOfPackaging(double _costOfPackaging)
        {
            costOfPackaging = _costOfPackaging;
        }



        public void CalcTotalCostOfAssembly()
        {
            totalCostOfAssembly = costOfBinding + costOfPerforation + costOfLamination + costOfPackaging;
        }

        public void ShowDetailedReport()
        {
            Console.WriteLine();
            Console.WriteLine("Отчет о сборке:");
            Console.WriteLine($"Стоимость переплета: {costOfBinding}");
            Console.WriteLine($"Стоимость перфорации: {costOfPerforation}");
            Console.WriteLine($"Стоимость ламинации: {costOfLamination}");
            Console.WriteLine($"Стоимость упаковки: {costOfPackaging}");
            Console.WriteLine($"Общая стоимость за сборку: {totalCostOfAssembly}");
        }
    }
}

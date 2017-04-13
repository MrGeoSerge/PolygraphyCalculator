using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProduction
{
    public class Lamination
    {
        public PaperFormat LaminationFormat { set; get; }
        private int PrintRun { set; get; }

        LaminationType laminationType;

        //цены на ламинацию из прайса

        public Lamination(TaskToLamination _tastToLamination)
        {
            LaminationFormat = _tastToLamination.LaminationFormat;
            PrintRun = _tastToLamination.PrintRun;
            laminationType = _tastToLamination.LaminationType;
        }

        public double CalcCostOfLamination()
        {
            double pricePerUnit;
            if (laminationType == LaminationType.Glossy)
            {
                switch (LaminationFormat)
                {
                    case PaperFormat.A1:
                        pricePerUnit = Price.Lamination["A1_Glossy"];
                        break;
                    case PaperFormat.A2:
                        pricePerUnit = Price.Lamination["A2_Glossy"];
                        break;
                    case PaperFormat.A3:
                        pricePerUnit = Price.Lamination["A3_Glossy"];
                        break;
                    case PaperFormat.A4:
                        pricePerUnit = Price.Lamination["A4_Glossy"];
                        break;
                    default:
                        throw new Exception("неверный формат ламинации");
                }
            }
            else if (laminationType == LaminationType.Matte)
            {
                switch (LaminationFormat)
                {
                    case PaperFormat.A1:
                        pricePerUnit = Price.Lamination["A1_Matte"];
                        break;
                    case PaperFormat.A2:
                        pricePerUnit = Price.Lamination["A2_Matte"];
                        break;
                    case PaperFormat.A3:
                        pricePerUnit = Price.Lamination["A3_Matte"];
                        break;
                    case PaperFormat.A4:
                        pricePerUnit = Price.Lamination["A4_Matte"];
                        break;
                    default:
                        throw new Exception("неверный формат ламинации");
                }
            }
            else
                throw new Exception("ламинация не была задана");
            return pricePerUnit * PrintRun;
        }
    }
}


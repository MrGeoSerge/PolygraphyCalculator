using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookProduction.PriceLists;
using PolygraphyCalculator.Models;

namespace PolygraphyCalculator.Controllers
{
    public class PriceUpdateController : Controller
    {
        public ActionResult PressesPriceList()
        {
            return View();
        }

        public ActionResult ZirkonUpdatePrice(ZirkonPriceModel zirkonPriceModel)
        {
            //если данные поступили, записываем их в прайс
            if (zirkonPriceModel.Form != 0)
            {
                if (ModelState.IsValid)
                {
                    zirkonPriceModel.UpdatePrice();
                }
            }
            else
            {
                zirkonPriceModel = new ZirkonPriceModel();
            }

            return PartialView(zirkonPriceModel);
        }

        public ActionResult CorosetUpdatePrice(CorosetPriceModel corosetPriceModel)
        {
            if (corosetPriceModel.Form != 0)
            {
                if (ModelState.IsValid)
                {
                    corosetPriceModel.UpdatePrice();
                }

            }
            else
            {
                corosetPriceModel = new CorosetPriceModel();
            }

            return PartialView(corosetPriceModel);
        }


        public ActionResult RapidaUpdatePrice(RapidaPriceModel rapidaPriceModel)
        {
            if(rapidaPriceModel.Form != 0)
            {
                if (ModelState.IsValid)
                {
                    rapidaPriceModel.UpdatePrice();
                }
            }
            else
            {
                rapidaPriceModel = new RapidaPriceModel();
            }
            return PartialView(rapidaPriceModel);

        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookProduction;
using BookProduction.BookComponents;
using BookProduction.Assembly;
using BookProduction.IssueParams;
using BookProduction.Paper;
using BookProduction.PriceLists;
using BookProduction.PrintingPresses;
using BookProduction.Tasks;
using BookProduction.TypographyManagement;

namespace BookProduction.Paper
{
    public class PaperInKg : AbstractPaper
    {
        //ширина роля
        double rolWidth;
        public double RolWidth
        {
            get
            {
                return rolWidth;
            }

            set
            {
                rolWidth = value;
            }
        }

        public PaperInKg()
        {
            Kind = PaperType.Newsprint;
            Density = 45;
            Manufacturer = "Шклов";
            Price = 15.656;
            Unit = PaperUnit.kg;
            RolWidth = 84;
        }

        public PaperInKg(PaperType kind, int density, double price, 
            string manufacturer, double rolWidth)
        {
            this.Kind = kind;
            this.Density = density;
            this.RolWidth = rolWidth;
            this.Manufacturer = manufacturer;
            this.Price = price;
            Unit = PaperUnit.kg;
        }

        public PaperInKg(PaperInKg paper)
        {
            this.Kind = paper.Kind;
            this.Density = paper.Density;
            this.RolWidth = paper.RolWidth;
            this.Manufacturer = paper.Manufacturer;
            this.Price = paper.Price;
        }




   
    }
}

﻿using AldyarOnlineShoppig.Models.Core.Products.Abstract;
using AldyarOnlineShoppig.Models.Enums;
namespace AldyarOnlineShoppig.Models
{
    public class FilletSteak : Beef
    {
        public override BeefCut Cut => BeefCut.FilletSteak;

        public FilletSteak(double weight)
        {
            // Sets product-specific properties
            SetWeight(weight);
            SetPricePerKg(12.99m);
        }
    }
}

﻿using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts.Concrete
{
    public class Sirloin : Beef
    {

        public override BeefCut Cut => BeefCut.Sirloin;

        public Sirloin(double weight)
        {
            SetWeight(weight);
            SetPricePerKg(15.99m);
        }

    }
}

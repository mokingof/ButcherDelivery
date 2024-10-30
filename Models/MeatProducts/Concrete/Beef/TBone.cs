﻿using AldyarOnlineShoppig.Models.Enums;
namespace AldyarOnlineShoppig.Models.MeatProducts.Abstract
{
    public class TBone : Beef
    {
        public override BeefCut Cut => BeefCut.TBone;

        public TBone(double weight)
        {
            SetWeight(weight);
            SetPricePerKg(20.99m);
        }
    }
}
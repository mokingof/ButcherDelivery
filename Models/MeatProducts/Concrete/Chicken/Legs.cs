﻿using AldyarOnlineShoppig.Models.Enums;

namespace AldyarOnlineShoppig.Models.MeatProducts.Abstract
{
    public class Legs : Chicken
    {
        public override ChickenCut Cut => ChickenCut.Legs;

        public Legs(double weight)
        {
            Weight = weight;
            PricePerKg = 4.99m;
        }
    }
}
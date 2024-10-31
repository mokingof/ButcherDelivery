using AldyarOnlineShoppig.Models.Core.Products.Abstract;
using AldyarOnlineShoppig.Models.Enums;
namespace AldyarOnlineShoppig.Models;

public class Legs : Chicken
{
    public override ChickenCut Cut => ChickenCut.Legs;

    public Legs(double weight)
    {
        SetWeight(weight);
        SetPricePerKg(6.99m);
    }
}

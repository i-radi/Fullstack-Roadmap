using System;

namespace DesignPattern.StructuralPatterns.Flyweight
{
    public interface IDiscountCalaculator
    {
       double GetDiscountValue(DateTime currentDate, string itemId=null);
    }
}
﻿namespace OnlineShop.Models.Products.Peripherals
{
    public class Mouse : Peripheral
    {
        public Mouse(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
        }
    }
}
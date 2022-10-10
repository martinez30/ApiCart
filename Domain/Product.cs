using System;
using ApiCart.Models;

namespace ApiCart.Domain
{
    public class Product : Base
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }

        public Product(ProductModel model){
            DataCreate = DateTime.Now;
            Name = model.Name;
            Code = model.Code;
            Quantity = model.Quantity;
            Value = model.Value;
        }
    }
}

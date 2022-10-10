using ApiCart.Domain;
using Newtonsoft.Json;

namespace ApiCart.Models
{
    public class ProductModel : BaseModel
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }

        public ProductModel(Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Code = product.Code;
            this.Quantity = product.Quantity;
            this.Value = product.Value;
        }

        [JsonConstructor]
        public ProductModel() { }
    }
}

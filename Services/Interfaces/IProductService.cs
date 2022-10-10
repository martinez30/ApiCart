using System.Collections.Generic;
using System.Threading.Tasks;
using ApiCart.Models;

namespace ApiCart.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductModel>> ListAll();
        Task<ProductModel> GetByID(long id);
        Task<ProductModel> Create(ProductModel product);
        Task Delete(long id);
    }
}

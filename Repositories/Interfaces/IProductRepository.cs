using System.Collections.Generic;
using System.Threading.Tasks;
using ApiCart.Domain;

namespace ApiCart.Repositories.Interfaces
{
    public interface IProductRepository 
    {
        Task<List<Product>> ListAll();
        Task<Product> GetByID(long id);
        Task<Product> CreateProduct(Product product);
        Task DeleteProduct(long id);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using ApiCart.Domain;

namespace ApiCart.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<List<Cart>> ListAll();
        Task<Cart> GetByID(long id);
        Task<Cart> CreateCart(List<ProductCart> products);
        Task<Cart> IncludeNewProduct(long id, long idProduct);
        Task DeleteProductByIdCart(long idCart, long idProduct);
        Task DeleteCart(long id);
    }
}

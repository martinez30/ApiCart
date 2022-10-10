using System.Collections.Generic;
using System.Threading.Tasks;
using ApiCart.Models;

namespace ApiCart.Services.Interfaces
{
    public interface ICartService
    {
        Task<List<CartModel>> ListAll();
        Task<CartModel> GetByID(long id);
        Task<CartModel> Create(List<ProductCartModel> products);
        Task<CartModel> InsertNewProducts(long idCart, ProductCartModel product);
        Task<FinishCartModel> Finish(int id);
        Task DeleteProductFromCart(long idCart, long idProduct);
        Task Delete(int id);
    }
}

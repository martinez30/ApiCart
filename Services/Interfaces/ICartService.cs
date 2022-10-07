using ApiCart.Models;

namespace ApiCart.Services.Interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<CartModel>> ListAll();
        Task<CartModel> GetByID(long id);
        Task<CartModel> Create(ProductModel product, long idCart);
        Task<CartModel> Update(ProductModel product, long idCart);
        Task<FinishCartModel> Finish(int id);
        Task<bool> Delete(int id);
    }
}

using ApiCart.Domain;

namespace ApiCart.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<List<Cart>> ListAll();
        Task<Cart> GetByID(long id);
        Task<Cart> Create(Product product, long id);
        Task DeleteProduct(long idCart, long idProduct);
        Task Delete(long id);
    }
}

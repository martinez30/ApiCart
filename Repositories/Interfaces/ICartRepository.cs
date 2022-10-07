using ApiCart.Domain;

namespace ApiCart.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<IList<Cart>> ListAll();
        Task<Cart> GetByID(long id);
        Task<Cart> Create(Product product, long id);
        Task<Cart> Update(Product product, long id);
        Task<bool> Delete(long id);
    }
}

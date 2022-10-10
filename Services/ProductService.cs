using System.Collections.Generic;
using System.Threading.Tasks;
using ApiCart.Domain;
using ApiCart.Models;
using ApiCart.Repositories.Interfaces;
using ApiCart.Services.Interfaces;

namespace ApiCart.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductModel> Create(ProductModel model)
        {
           var product = await _productRepository.CreateProduct(new Product(model));   
           return new ProductModel(product);
        }

        public async Task Delete(long id)
        {
            await _productRepository.DeleteProduct(id);
        }

        public async Task<ProductModel> GetByID(long id)
        {
            var product = await _productRepository.GetByID(id);
            return new ProductModel(product);
        }

        public async Task<List<ProductModel>> ListAll()
        {
            var products = await _productRepository.ListAll();
            return products.ConvertAll(p => new ProductModel(p));
        }
    }
}

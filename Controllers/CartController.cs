using ApiCart.Models;
using ApiCart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace ApiCart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(String), 400)]
    [ProducesResponseType(typeof(String), 404)]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;
        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpGet("listAll")]
        [ProducesResponseType(typeof(List<CartModel>), 200)]
        public async Task<IActionResult> ListAll()
        {
            try
            {
                var carts = await _service.ListAll();
                return Ok(carts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(CartModel), 200)]
        public async Task<IActionResult> GetByID(long id)
        {
            try
            {
                var cart = await _service.GetByID(id);
                return Ok(cart);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("create")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Insert([FromBody] List<ProductCartModel> produtos)
        {
            try
            {
                var create = await _service.Create(produtos);
                return Ok(create);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/product/{idCart}/{idProduct}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteProduct(long idCart, long idProduct)
        {
            try
            {
                await _service.DeleteProductFromCart(idCart, idProduct);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("finish/{id}")]
        [ProducesResponseType(typeof(FinishCartModel), 200)]
        public async Task<IActionResult> finish(int id)
        {
            try
            {
                var finished = await _service.Finish(id);
                return Ok(finished);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("new-product/{id}")]
        [ProducesResponseType(typeof(CartModel), 200)]
        public async Task<IActionResult> InsertNewProduct(int idCart, [FromBody] ProductCartModel model)
        {
            try
            {
                var cart = await _service.InsertNewProducts(idCart, model);
                return Ok(cart);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

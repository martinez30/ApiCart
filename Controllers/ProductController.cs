using ApiCart.Models;
using ApiCart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(String), 400)]
    [ProducesResponseType(typeof(String), 404)]
    public class ProductController : ControllerBase {
        
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("listAll")]
        [ProducesResponseType(typeof(List<ProductModel>), 200)]
        public async Task<IActionResult> ListAll()
        {
            try
            {
                var products = await _service.ListAll();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductModel), 200)]
        public async Task<IActionResult> CreateProduct([FromBody] ProductModel model)
        {
            try
            {
                var product = await _service.Create(model);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(ProductModel), 200)]
        public async Task<IActionResult> GetByID(long id)
        {
            try
            {
                return Ok(await _service.GetByID(id));
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
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
    }
}

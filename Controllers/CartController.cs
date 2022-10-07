using ApiCart.Models;
using ApiCart.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore;

namespace ApiCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;
        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpGet("listAll")]
        [Produces("application/json")]
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

        [HttpPost("create")]
        public async Task<IActionResult> Insert([FromBody]ProductModel product, long id)
        {
            try
            {
                var create = await _service.Create(product, id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ProductModel product, long id)
        {
            try
            {
                var update = await _service.Update(product, id);
                return Ok(update);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var delete = await _service.Delete(id);
            return Ok(delete);
        }

        [HttpPost("finish/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> finish(int id)
        {
            var finished = await _service.Finish(id);
            return Ok(finished);
        }
    }
}

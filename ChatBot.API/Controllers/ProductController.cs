using ChatBot.API.DTOs;
using ChatBot.BLL.Services;
using ChatBot.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatBot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ProductForm form)
        {
            await _productService.Add(form.Name, form.Description, form.ImageFile);
            return Ok();
        }
    }
}

using E_CommerceApi.Repository.IRepository;
using Laptopy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laptopy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository ProductRepository;

        public ProductController(IProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }
        [HttpGet]
        public IActionResult Index(int page = 1, string? search = null)
        {
            if (page <= 0)
                page = 1;

            IQueryable<Product> Products = ProductRepository.GetAll([e=>e.Category]);

            if (search != null && search.Length > 0)
            {
                search = search.TrimStart();
                search = search.TrimEnd();
                Products = Products.Where(e => e.Name.Contains(search));
            }

            Products = Products.Skip((page - 1) * 5).Take(5);

            if (Products.Any())
            {
                return Ok(Products.ToList());
            }

            return NotFound();
        }
        [HttpGet("Details")]
        public IActionResult Details(int productsId)
        {
            var products = ProductRepository.GetOne([e => e.Category],expression: e => e.Id == productsId);
            return Ok(products);
        }
        [HttpGet("FilterBrand")]
        public IActionResult FilterBrand(string? filter = null)
        {
            IQueryable<Product> products = ProductRepository.GetAll([e => e.Category]);

            if (!string.IsNullOrWhiteSpace(filter))
            {
                filter = filter.Trim().ToLower();
                products = products.Where(e => e.Brand.ToLower().Contains(filter));
                return Ok(products.ToList());
            }
            return NotFound();

        }
        [HttpGet("FilterPrice")]
        public IActionResult FilterPrice(decimal StartPrice , decimal EndPrice)
        {
            IQueryable<Product> products = ProductRepository.GetAll([e => e.Category],expression:e=>e.Price >= StartPrice&& e.Price <= EndPrice);
            return Ok(products.ToList());
        }
        [HttpGet("FilterRating")]
        public IActionResult FilterRating(int rate)
        {
            IQueryable<Product> products = ProductRepository.GetAll([e => e.Category],expression: e => e.Rate == rate);
            return Ok(products.ToList());
        }

    }
}

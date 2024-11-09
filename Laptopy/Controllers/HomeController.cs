using E_CommerceApi.Repository;
using E_CommerceApi.Repository.IRepository;
using Laptopy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laptopy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IProductRepository ProductRepository;

        public HomeController(IProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }
        [HttpGet]
        public IActionResult Index(int page = 1, string? search = null)
        {
            if (page <= 0)
                page = 1;

            IQueryable<Product> categories = ProductRepository.GetAll();

            if (search != null && search.Length > 0)
            {
                search = search.TrimStart();
                search = search.TrimEnd();
                categories = categories.Where(e => e.Name.Contains(search));
            }

            categories = categories.Skip((page - 1) * 5).Take(5);

            if (categories.Any())
            {
                return Ok(categories.ToList());
            }

            return NotFound();
        }


    }
}

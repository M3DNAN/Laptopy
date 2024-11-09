using Laptopy.Models;
using Laptopy.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laptopy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsRepository contactUsRepository;

        public ContactUsController(IContactUsRepository contactUsRepository)
        {
            this.contactUsRepository = contactUsRepository;
        }
        [HttpPost]
        public IActionResult Index(ContactUs contactUs) 
        {
            contactUsRepository.Create(contactUs);
            contactUsRepository.Commit();
            return Ok();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using CustomerPortal.Api.Models;
using CustomerPortal.Api.Repositories;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;

namespace CustomerPortal.Api.Controllers
{
    [Route("api/{customerNamespace}/[controller]")]
    [AllowAnonymous]
    public class AdCategoryController : CustomerSpecificPortalApiController
    {
        private readonly IAdCategoryRepository _adCategoryRepository;

        public AdCategoryController(IAdCategoryRepository adCategoryRepository, ICustomerRepository customerRepository) : base(customerRepository)
        {
            _adCategoryRepository = adCategoryRepository;
        }
        

        [HttpGet]
        public IEnumerable<AdCategory> Get()
        {
            return _adCategoryRepository.Get().ToList();
        }

        [HttpGet("{id}")]
        public AdCategory Get(string id)
        {
            return _adCategoryRepository.Get(id);
        }
    }
}
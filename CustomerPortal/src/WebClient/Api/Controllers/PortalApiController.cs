using CustomerPortal.Api.Repositories;
using Microsoft.AspNet.Mvc;

namespace CustomerPortal.Api.Controllers
{
    public class PortalApiController : Controller
    {
        protected readonly ICustomerRepository _customerRepository;

        public PortalApiController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
    }
}
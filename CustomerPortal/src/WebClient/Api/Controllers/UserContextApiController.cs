using System;
using CustomerPortal.Api.Models;
using CustomerPortal.Api.Repositories;
using Microsoft.AspNet.Mvc;

namespace CustomerPortal.Api.Controllers
{
    [Route("api/[Controller]")]
    public class UserContextController : PortalApiController
    {
        public UserContextController(ICustomerRepository customerRepository) : base(customerRepository)
        {
        }

        [HttpGet]
        public UserContext Get()
        {
            var user = new User
            {
                Id = new Guid("cf36dc77-5c15-4746-97f8-6b60da09bc97"),
                CustomerNamespace = "NFLNetwork",
                Username = "aaron@kingdango.com",
                FirstName = "Aaron",
                LastName = "King"
            };

            return new UserContext
            {
                User = user,
                Customer = _customerRepository.GetByNamespace(user.CustomerNamespace)
            };
        }
    }

    public class UserContext
    {
        public User User { get; set; }
        public Customer Customer { get; set; }
    }
}
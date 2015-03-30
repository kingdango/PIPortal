using System;
using System.Net;
using CustomerPortal.Api.Models;
using CustomerPortal.Api.Repositories;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;

namespace CustomerPortal.Api.Controllers
{
    public class CustomerSpecificPortalApiController : PortalApiController
    {
        public Customer CustomerContext { get; private set; }
        
        public CustomerSpecificPortalApiController(ICustomerRepository customerRepository) : base(customerRepository)
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var customerNamespace = context.RouteData.Values["customerNamespace"] as string;

            ResolveCustomer(customerNamespace);
        }

        private void ResolveCustomer(string customerNamespaceFromRoute)
        {
            var customer = _customerRepository.GetByNamespace(customerNamespaceFromRoute);

            if (customer == null)
                throw new Exception();

            this.CustomerContext = customer;
        }
    }
}
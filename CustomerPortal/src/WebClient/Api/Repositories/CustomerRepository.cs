using System;
using System.Collections.Generic;
using System.Linq;
using CustomerPortal.Api.Models;

namespace CustomerPortal.Api.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetByNamespace(string customerNamespace);
    }

    public class MockCustomerRepository : ICustomerRepository
    {
        public readonly List<Customer> CustomerData = new List<Customer> {
            new Customer { Id = new Guid("a5a027c8-5556-4b4a-841c-4e9e935d570d"), Name = "NFL Network", Namespace = "NFLNetwork", AdCategoryConfiguration = new CustomerAdCategoryConfiguration
            {
                ExcludeAllByDefault = false,
                ExceptionCategoryIds = new List<string> { "3" }
            } },
            new Customer { Id = new Guid("58bb2d20-8072-4d6f-8719-54ee0026dc19"), Name = "Disney Interactive", Namespace = "DisneyInteractive" },
            new Customer { Id = new Guid("d483cbcb-f28f-40cb-b410-ba1a39ed42cf"), Name = "CBS Sports", Namespace = "CBSSports" },
        };

        public Customer GetByNamespace(string customerNamespace)
        {
            return CustomerData.SingleOrDefault(i => i.Namespace.Equals(customerNamespace));
        }
    }
}
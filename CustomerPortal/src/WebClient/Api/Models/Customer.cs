using System;
using System.Collections.Generic;

namespace CustomerPortal.Api.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Namespace { set; get; }
        public List<Guid> AdminUserIds { get; set; }
        public CustomerAdCategoryConfiguration AdCategoryConfiguration { get; set; }
    }

    public class CustomerAdCategoryConfiguration
    {
        public bool ExcludeAllByDefault { get; set; }
        public List<string> ExceptionCategoryIds { get; set; }
    }

}
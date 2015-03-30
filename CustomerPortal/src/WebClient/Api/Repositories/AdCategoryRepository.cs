using CustomerPortal.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace CustomerPortal.Api.Repositories
{
    public class MockAdCategoryRepository : IAdCategoryRepository
    {
        public IEnumerable<AdCategory> Get()
        {
            return new List<AdCategory>
            {
                new AdCategory { Id = "1", Name = "Sports" },
                new AdCategory { Id = "2", Name = "Lifestyle" },
                new AdCategory { Id = "3", Name = "Adult" }
            };
        }

        public AdCategory Get(string id)
        {
            return Get().SingleOrDefault(i => i.Id == id);
        }
    }

    public interface IAdCategoryRepository
    {
        IEnumerable<AdCategory> Get();
        AdCategory Get(string id);
    }
}
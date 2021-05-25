using System.Collections.Generic;
using FirstApp.DAO;
using FirstApp.Models;

namespace FirstApp.Mocks
{
    public class MockCategory : IItemsCategory
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category {Name = "First", Desc = "some words"},
                new Category {Name = "Second", Desc = "some more words"}
            };
    }
}
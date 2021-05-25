using System.Collections;
using System.Collections.Generic;
using FirstApp.Models;

namespace FirstApp.DAO
{
    public interface IItemsCategory
    {
        public IEnumerable<Category> AllCategories { get; }
    }
}
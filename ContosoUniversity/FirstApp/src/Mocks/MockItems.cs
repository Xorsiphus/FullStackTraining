using System.Collections.Generic;
using System.Linq;
using FirstApp.DAO;
using FirstApp.Models;

namespace FirstApp.Mocks
{
    public class MockItems : IItems
    {
        private readonly IItemsCategory _categoryItems = new MockCategory();
        
        public IEnumerable<Item> Items
        {
            get
            {
                return new List<Item> {new Item{Name = "1", Desc = "super desc 1", 
                    Price = 123, Img = "/img/1.jpg", IsFavorite = true, 
                    Category = _categoryItems.AllCategories.First()},
                    new Item{Name = "2", Desc = "super desc 2", 
                        Price = 231, Img = "/img/2.jpg", IsFavorite = false, 
                        Category = _categoryItems.AllCategories.First()},
                    new Item{Name = "3", Desc = "super desc 3", 
                        Price = 321, Img = "/img/3.jpg", IsFavorite = false, 
                        Category = _categoryItems.AllCategories.Last()},
                    new Item{Name = "4", Desc = "super desc 4", 
                        Price = 111, Img = "/img/4.jpg", IsFavorite = false, 
                        Category = _categoryItems.AllCategories.Last()}
                    
                };
            }
            // set;
        }

        public IEnumerable<Item> GetFavouriteItems { get; set; }
        public Item GetItem(int id)
        {
            return null;
        }
    }
}
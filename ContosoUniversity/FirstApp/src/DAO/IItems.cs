using System.Collections.Generic;
using FirstApp.Models;

namespace FirstApp.DAO
{
    public interface IItems
    {
        public IEnumerable<Item> Items { get; }
        public IEnumerable<Item> GetFavouriteItems { get; set; }
        public Item GetItem(int id);
    }
}
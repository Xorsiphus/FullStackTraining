using System.Collections.Generic;
using FirstApp.Models;

namespace FirstApp.ViewModels
{
    public class ItemsListViewModel
    {
        public IEnumerable<Item> AllItems { get; set; }

        public string ItemCategory { get; set; }
    }
}
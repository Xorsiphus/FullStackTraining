using FirstApp.DAO;
using FirstApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItems _allItems;
        private readonly IItemsCategory _allCategories;

        public ItemsController(IItems items, IItemsCategory itemsCategories)
        {
            _allItems = items;
            _allCategories = itemsCategories;
        }

        public ViewResult Resolver()
        {
            ViewData["Title"] = "another one";
            ItemsListViewModel transfer = new ItemsListViewModel {AllItems = _allItems.Items, ItemCategory = "some items"};
            return View(transfer);
        }
        
    }
}
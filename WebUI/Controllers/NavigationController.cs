using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class NavigationController : Controller
    {
        public PartialViewResult Menu(string menuItem = null)
        {
            ViewBag.SelectedMenuItem = menuItem;
            var listMenuItem = new List<MenuLinkModels>
                {
                    new MenuLinkModels {Name = "Home", Controller = "Home", Action = "Index"},
                    new MenuLinkModels {Name = "Wallet", Controller = "Wallet", Action = "Index"},
                };

            return PartialView(listMenuItem);
        }
    }
}

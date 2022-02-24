using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission9Final.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mission9Final.Controllers
{
    public class ShopperController : Controller
    {
        private IShopperRepository repo { get; set; }

        private Basket basket { get; set; }

        public ShopperController(IShopperRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        // GET: /<controller>/
        public IActionResult Checkout()
        {
            return View(new Shopper());
        }

        [HttpPost]
        public IActionResult Checkout(Shopper shopper)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                shopper.Lines = basket.Items.ToArray();
                repo.SaveShopper(shopper);
                basket.ClearBasket();
                return RedirectToPage("/ShoppingCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}

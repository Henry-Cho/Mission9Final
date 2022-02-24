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
        // GET
        public IActionResult Checkout()
        {
            // Show a form and put a Shopper instance in the parameter.
            return View(new Shopper());
        }

        // POST
        [HttpPost]
        public IActionResult Checkout(Shopper shopper)
        {
            // If there is no item in the basket
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            // If this model is valid
            if (ModelState.IsValid)
            {
                // Make a array of basket items and put it in shopper.Lines
                shopper.Lines = basket.Items.ToArray();
                // Save the shopper
                repo.SaveShopper(shopper);
                // Clear the current basket after check out
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

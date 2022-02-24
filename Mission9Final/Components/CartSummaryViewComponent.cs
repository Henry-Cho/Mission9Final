using Microsoft.AspNetCore.Mvc;
using Mission9Final.Models;

namespace Mission9Final.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket repo;

        public CartSummaryViewComponent(Basket temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            // Show Cart summary
            return View(repo);
        }
    }
}

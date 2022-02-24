using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission9Final.Infrastructure;
using Mission9Final.Models;

namespace Mission9Final.Pages
{
    public class ShoppingModel : PageModel
    {
        private IBookRepository repo { get; set; }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public ShoppingModel(IBookRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        // Get
        public void OnGet(string returnUrl)
        {
            // set the ReturnUrl which is going to be where a user can go back
            ReturnUrl = returnUrl ?? "/";
        }

        // Post
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            // Get the specific book info that matches the given bookId
            Book p = repo.Books.FirstOrDefault(x => x.BookID == bookId);

            // Add item to the basket
            basket.AddItem(p, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        // Remove Item (Post)
        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            // Find a specific book info by its BookId
            //Book b = repo.Books.FirstOrDefault(x => x.BookID == bookId);
            //basket.RemoveItem(b);

            basket.RemoveItem(basket.Items.First(x => x.Book.BookID == bookId).Book);
            // The code below this one line code (Functioning the same with the code above)
            // basket.RemoveItem(basket.Items.First(x => x.ProjectId == projectId).Project);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}

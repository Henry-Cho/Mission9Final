﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission9Final.Models;
using Mission9Final.Models.ViewModels;

namespace Mission9Final.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository repo;

        public HomeController(IBookRepository context)
        {
            repo = context;
        }

        // Get the data from the Book databse and display its data in the index.cshtml
        // default page number is 1
        public IActionResult Index(string categoryType, int pageNum = 1)
        {
            // display 10 items per page
            // A page should have a list of 10 books
            int pageSize = 10;

            // define x with assigning a BooksViewModel instance
            // the instance has Books model and PageInfo model
            var x = new BooksViewModel
            {
                // Have a Books model with 10 items without the 10 previous items.
                // Use Where function to enable to show the items based on the categoryType a user clicks
                // If the categoryType is null, just show all the books
                Books = repo.Books
                .Where(x => x.Category == categoryType || categoryType == null)
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                // Define total number of projects, projects per page, and current page.
                // When the categoryType is not null, the number of items displayed is the length of the filtered object by the categoryType
                PageInfo = new PageInfo
                {
                    TotalNumProjects = (categoryType == null ? repo.Books.Count() : repo.Books.Where(x => x.Category == categoryType).Count()),
                    ProjectsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            // return a view that contains BooksViewModel information
            return View(x);
        }

    }
}

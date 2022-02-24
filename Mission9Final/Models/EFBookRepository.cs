﻿using System;
using System.Linq;

namespace Mission9Final.Models
{
    public class EFBookRepository : IBookRepository
    {
        private BookContext context { get; set; }
        public EFBookRepository(BookContext _context)
        {
            context = _context;
        }
        // Create a IQuerayble instance (Books type) which has an instance of BookContext
        public IQueryable<Book> Books => context.Books;
    }
}

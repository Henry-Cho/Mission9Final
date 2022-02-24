using System;
using System.Linq;

namespace Mission9Final.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}

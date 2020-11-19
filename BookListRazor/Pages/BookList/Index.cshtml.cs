using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly BookDbContext _context;
        public IndexModel(BookDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> Books { get; set; }
        public async Task OnGet()
        {
            Books = await _context.Book.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var DeBook = await _context.Book.FindAsync(id);
            if (DeBook == null)
            {
               return  NotFound();
            }
            _context.Book.Remove(DeBook);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}

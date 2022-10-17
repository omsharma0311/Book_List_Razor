using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_List_Razor.DataServices;
using Book_List_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Book_List_Razor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly BookDbContext _db;

        public IndexModel(BookDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> Books { get; set; }

        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _db.Book.Remove(book);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}

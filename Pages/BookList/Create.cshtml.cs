using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_List_Razor.DataServices;
using Book_List_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book_List_Razor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly BookDbContext _db;

        public CreateModel(BookDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}

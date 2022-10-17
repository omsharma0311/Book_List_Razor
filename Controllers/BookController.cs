using Book_List_Razor.DataServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_List_Razor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly BookDbContext _db;

        public BookController(BookDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Book.ToListAsync() });
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await _db.Book.FirstOrDefaultAsync(u => u.Id == id);
            if (bookFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Book.Remove(bookFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}

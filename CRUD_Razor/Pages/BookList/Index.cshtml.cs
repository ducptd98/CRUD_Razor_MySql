using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD_Razor.Model;

namespace CRUD_Razor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly CRUD_Razor.Model.ApplicationDBContext _context;

        [TempData] public string Message { get; set; }
        public IndexModel(CRUD_Razor.Model.ApplicationDBContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Books.ToListAsync();
        }
    }
}

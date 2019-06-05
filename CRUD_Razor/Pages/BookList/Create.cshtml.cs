using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUD_Razor.Model;

namespace CRUD_Razor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly CRUD_Razor.Model.ApplicationDBContext _context;

        [TempData]
        public string Message { get; set; }
        public CreateModel(CRUD_Razor.Model.ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();
            Message = "Book has been created";
            return RedirectToPage("./Index");
        }
    }
}
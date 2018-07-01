using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesCV.Models;

namespace RazorPagesCV
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesCV.Models.RazorPagesCVContext _context;

        public CreateModel(RazorPagesCV.Models.RazorPagesCVContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CuriculumVitae CuriculumVitae { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CuriculumVitae.Add(CuriculumVitae);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
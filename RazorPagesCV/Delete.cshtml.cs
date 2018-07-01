using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesCV.Models;

namespace RazorPagesCV
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesCV.Models.RazorPagesCVContext _context;

        public DeleteModel(RazorPagesCV.Models.RazorPagesCVContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CuriculumVitae CuriculumVitae { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CuriculumVitae = await _context.CuriculumVitae.SingleOrDefaultAsync(m => m.ID == id);

            if (CuriculumVitae == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CuriculumVitae = await _context.CuriculumVitae.FindAsync(id);

            if (CuriculumVitae != null)
            {
                _context.CuriculumVitae.Remove(CuriculumVitae);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

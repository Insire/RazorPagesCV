using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesCV.Models;

namespace RazorPagesCV
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesCV.Models.RazorPagesCVContext _context;

        public EditModel(RazorPagesCV.Models.RazorPagesCVContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CuriculumVitae).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuriculumVitaeExists(CuriculumVitae.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CuriculumVitaeExists(int id)
        {
            return _context.CuriculumVitae.Any(e => e.ID == id);
        }
    }
}

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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesCV.Models.RazorPagesCVContext _context;

        public DetailsModel(RazorPagesCV.Models.RazorPagesCVContext context)
        {
            _context = context;
        }

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
    }
}

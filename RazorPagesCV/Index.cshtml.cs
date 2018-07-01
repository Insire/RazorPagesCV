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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesCV.Models.RazorPagesCVContext _context;

        public IndexModel(RazorPagesCV.Models.RazorPagesCVContext context)
        {
            _context = context;
        }

        public IList<CuriculumVitae> CuriculumVitae { get;set; }

        public async Task OnGetAsync()
        {
            CuriculumVitae = await _context.CuriculumVitae.ToListAsync();
        }
    }
}

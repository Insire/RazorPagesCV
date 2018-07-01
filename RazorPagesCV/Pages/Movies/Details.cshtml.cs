using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using RazorPagesCV.Models;

using System.Threading.Tasks;

namespace RazorPagesCV.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly MoviesContext _context;

        public DetailsModel(MoviesContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
                return NotFound();

            return Page();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCV.Models;
using System.Threading.Tasks;

namespace RazorPagesCV.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesCV.Models.MoviesContext _context;

        public CreateModel(RazorPagesCV.Models.MoviesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return RedirectToPage("./Index");
        }
    }
}

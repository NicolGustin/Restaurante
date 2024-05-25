using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Pages.Platos
{
    public class CreateModel : PageModel
    {
        private readonly InventarioContext _context;

        public CreateModel(InventarioContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]

        public Plato Plato { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid||_context.Platos==null||Plato==null)
            {
                return Page();
            }

            _context.Platos.Add(Plato);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}

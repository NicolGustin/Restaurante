using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Pages.Ingredientes
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

        public Ingrediente Ingrediente { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid||_context.Ingredientes==null||Ingrediente == null)
            {
                return Page();
            }

            _context.Ingredientes.Add(Ingrediente);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}

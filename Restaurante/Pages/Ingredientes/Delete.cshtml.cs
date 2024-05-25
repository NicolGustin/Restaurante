using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Pages.Ingredientes
{
    public class DeleteModel : PageModel
    {
        private readonly InventarioContext _context;
        public DeleteModel(InventarioContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Ingrediente Ingrediente { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Ingredientes == null)
            {
                return NotFound();
            }
            var ingrediente = await _context.Ingredientes.FindAsync(id);

            if (ingrediente != null)
            {
                Ingrediente = ingrediente;
                _context.Ingredientes.Remove(ingrediente);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}

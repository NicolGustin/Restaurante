using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Pages.Platos
{
    public class DeleteModel : PageModel
    {
        private readonly InventarioContext _context;
        public DeleteModel(InventarioContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Plato Plato { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Platos == null)
            {
                return NotFound();
            }
            var Plato = await _context.Platos.FindAsync(id);

            if (Plato != null)
            {
                Plato = Plato;
                _context.Platos.Remove(Plato);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}

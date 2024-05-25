using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Pages.Proveedor
{
    public class DeleteModel : PageModel
    {
        private readonly InventarioContext _context;
        public DeleteModel(InventarioContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Proveedor Proveedor { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Proveedor == null)
            {
                return NotFound();
            }
            var Poveedor = await _context.Proveedor.FindAsync(id);

            if (Poveedor != null)
            {
                Poveedor = Poveedor;
                _context.Proveedor.Remove(Poveedor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

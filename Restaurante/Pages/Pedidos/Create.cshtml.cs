using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Pages.Pedidos
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
            Proveedores = new SelectList(_context.Proveedores, "IdProveedor", "NombreEmpresa");
            return Page();
        }

        [BindProperty]
        public Pedido Pedido { get; set; } = default!;

        public SelectList Proveedores { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Pedidos == null || Pedido == null)
            {
                Proveedores = new SelectList(_context.Proveedores, "IdProveedor", "NombreEmpresa");
                return Page();
            }

            _context.Pedidos.Add(Pedido);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}

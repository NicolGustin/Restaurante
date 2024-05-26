using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Pages.Pedidos
{
    public class EditModel : PageModel
    {
        private readonly InventarioContext _context;

        public EditModel(InventarioContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pedido Pedido { get; set; }
        public SelectList Proveedores { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pedido = await _context.Pedidos.FindAsync(id);

            if (Pedido == null)
            {
                return NotFound();
            }

            Proveedores = new SelectList(await _context.Proveedores.ToListAsync(), "IdProveedor", "NombreEmpresa");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Proveedores = new SelectList(await _context.Proveedores.ToListAsync(), "IdProveedor", "NombreEmpresa");
                return Page();
            }

            _context.Attach(Pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(Pedido.IdPedido))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.IdPedido == id);
        }
    }
}

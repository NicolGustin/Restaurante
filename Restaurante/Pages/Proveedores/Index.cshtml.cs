using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Pages.Proveedores
{
    [Authorize]
    public class IndexModel : PageModel
    {

        private readonly InventarioContext _context;

        public IndexModel(InventarioContext context)
        {
            _context = context;
        }


        public IList<Proveedor> Proveedor { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Proveedor != null)
            {
                Proveedor = await _context.Proveedor.ToListAsync();
            }
        }
    }
}


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Pages.Platos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly InventarioContext _context;

        public IndexModel(InventarioContext context)
        {
            _context = context;
        }


        public IList<Plato> Platos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Platos != null)
            {
                Platos = await _context.Platos.ToListAsync();                  
            }
        }
    }
}
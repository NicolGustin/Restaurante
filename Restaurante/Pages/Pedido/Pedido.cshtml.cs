using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurante.Data;

namespace Restaurante.Pages.Pedido
{
    public class PedidoModel : PageModel
    {
        private readonly InventarioContext _context;

        private readonly InventarioContext _context;
        {
            _context = context;
        }

        public IList<Pedido> Pedidos { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Pedidos!= null)
            {
                Pedidos = await _context.Pedidos.ToListAsync();
            }
        } 
    } 
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Pages.Platos
{
    public class EditModel : PageModel
    {
        private readonly InventarioContext _context;

        public EditModel(InventarioContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Plato Plato { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Platos == null)
            {
                return NotFound();
            }

            var Plato = await _context.Platos.FirstOrDefaultAsync(m => m.Id == id);
            if (Plato == null)
            {
                return NotFound();
            }
            Plato = Plato;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Plato).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Plato.Id))
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
        private bool ProductExists(int id)
        {
            return (_context.Platos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

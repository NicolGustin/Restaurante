using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Pages.Ingredientes
{
    public class EditModel : PageModel
    {
        private readonly InventarioContext _context;

        public EditModel(InventarioContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ingrediente Ingrediente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ingredientes == null)
            {
                return NotFound();
            }

            var ingrediente = await _context.Ingredientes.FirstOrDefaultAsync(m => m.Id == id);
            if (ingrediente == null)
            {
                return NotFound();
            }
            Ingrediente = ingrediente;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Ingrediente).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Ingrediente.Id))
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
            return (_context.Ingredientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using System.Security.Claims; // Đảm bảo namespace đúng

namespace PawFundSystemPagePagesPets
{
    [Authorize(Roles = "Customer")]
    public class UpdateHealthModel : PageModel
    {
        private readonly PawFundContext _context;

        public UpdateHealthModel(PawFundContext context)
        {
            _context = context;
        }
        public List<Pet> Pets { get; set; } // Danh sách thú cưng

        [BindProperty]
        public Pet Pet { get; set; } // Thêm thuộc tính Pet


        public async Task OnGetAsync()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userId = 0;
            if (int.TryParse(user, out userId))
            {
                Pets = await _context.Pets
                .Where(p => p.OwnerId == userId)
                .ToListAsync();
            }
            
        }

        public async Task<IActionResult> OnPostUpdateHealthAsync(int id, string healthStatus)
        {
            var petToUpdate = await _context.Pets.FindAsync(id);
            if (petToUpdate == null || petToUpdate.IsAdopted != true)
            {
                return NotFound();
            }

            petToUpdate.HealthStatus = healthStatus; 
            await _context.SaveChangesAsync();

            return RedirectToPage(); 
        }
    }
}
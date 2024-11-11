using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.IService;
using System.Collections.Generic;
using System.Threading.Tasks;



public class AdoptedPetsModel : PageModel
{
    private readonly IPetService _petService;

    public AdoptedPetsModel(IPetService petService)
    {
        _petService = petService;
    }

    public IList<Pet> AdoptedPets { get; set; }

    public async Task OnGetAsync()
    {
        // Giả sử userId là 1
        int userId = (int)HttpContext.Session.GetInt32("UserId");
        AdoptedPets = await _petService.GetAdoptedPetsByUserIdAsync(userId);
    }

    public async Task<IActionResult> OnPostUpdateHealthAsync(int petId, string healthStatus)
    {
        // Cập nhật trạng thái sức khỏe cho thú cưng
        await _petService.UpdatePetHealthStatusAsync(petId, healthStatus);

        // Quay lại trang hiện tại
        return RedirectToPage();
    }
}
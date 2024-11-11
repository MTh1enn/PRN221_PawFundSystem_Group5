using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Service.IService;
using Microsoft.AspNetCore.Identity;
using Service.Service;

public class AdoptionRequestModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IPetService _petService;
    private readonly IAdoptionRequestService _adoptionRequestService; 

    public AdoptionRequestModel(UserManager<IdentityUser> userManager, IPetService petService, IAdoptionRequestService adoptionRequestService)
    {
        _userManager = userManager;
        _petService = petService;
        _adoptionRequestService = adoptionRequestService;
    }

    public List<Pet> Pets { get; set; }
    public bool ShowForm { get; set; }
    public AdoptionRequest AdoptionRequest { get; set; } = new AdoptionRequest();
    public string SuccessMessage { get; set; }

    public async Task OnGetAsync()
    {
        Pets = await _petService.GetAllPetsAsync();

        var user = await _userManager.GetUserAsync(User);
        int userId = 0;
        if (int.TryParse(user.Id, out userId))
        {
            AdoptionRequest.UserId = userId;
        }
    }

    public void ShowAdoptionForm(int petId)
    {
        ShowForm = true;
        AdoptionRequest.PetId = petId;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (int.TryParse(AdoptionRequest.PetId.ToString(), out int petId))
        {
            AdoptionRequest.PetId = petId;
        }
        else
        {
            // Xử lý lỗi nếu không thể chuyển đổi
            ModelState.AddModelError("AdoptionRequest.PetId", "ID thú cưng không hợp lệ.");
            return Page();
        }

        await _adoptionRequestService.CreateAdoptionRequestAsync(AdoptionRequest);
        SuccessMessage = "Yêu cầu nhận nuôi đã được gửi thành công!";

        // Giữ nguyên trang hiện tại
        return Page();
    }
}
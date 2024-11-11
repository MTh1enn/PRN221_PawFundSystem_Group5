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
    private readonly IPetService _petService;
    private readonly IAdoptionRequestService _adoptionRequestService;
    //private readonly UserManager<IdentityUser> _userManager;

    public AdoptionRequestModel(IPetService petService, IAdoptionRequestService adoptionRequestService)
    {
        _petService = petService;
        _adoptionRequestService = adoptionRequestService;
        //_userManager = userManager;
    }

    public IList<Pet> Pets { get; set; }

    [BindProperty]
    public int UserId { get; set; }

    public async Task OnGetAsync()
    {
        Pets = await _petService.GetAllPetsAsync();
    }

    public async Task<IActionResult> OnPostAdoptAsync(int petId)
    {
        //var user = await _userManager.GetUserAsync(User);
        //if (user == null)
        //{
        //    return RedirectToPage("/Login"); 
        //}
        int userId = (int)HttpContext.Session.GetInt32("UserId");
        var adoptionRequest = new AdoptionRequest
        {
            PetId = petId,
            UserId = userId, 
            RequestDate = DateTime.Now,
            Status = "PENDING"
        };

        await _adoptionRequestService.CreateAdoptionRequestAsync(adoptionRequest);
        return RedirectToPage("./Pets");
    }
}
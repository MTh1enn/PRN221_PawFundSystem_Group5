using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.IService;
using Service.Service;

namespace PRN221_PawFundSystem_Group5.Pages.FeedbackPage
{
    public class CreateModel : PageModel
    {
        private readonly IFeedbackService _feedbackService;

        public CreateModel()
        {
            _feedbackService = new FeedbackService();
        }

        [BindProperty]
        public Feedback Feedback { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _feedbackService.AddFeedback(Feedback);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

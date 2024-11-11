using BusinessObjects.Models;
using DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.IService;

namespace PRN221_PawFundSystem_Group5.Pages.FeedbackPage
{
    public class EditModel : PageModel
    {
        private readonly FeedbackDAO _feedbackDAO; 

        public EditModel()
        {
            _feedbackDAO = FeedbackDAO.Instance; 
        }

        [BindProperty]
        public Feedback Feedback { get; set; } 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Feedback = _feedbackDAO.GetFeedbackById(id); 

            if (Feedback == null)
            {
                return NotFound(); 
            }

            return Page(); 
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }


            bool isUpdated = _feedbackDAO.UpdateFeedback(Feedback);
            if (!isUpdated)
            {
                ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi cập nhật feedback.");
                return Page();
            }

            return RedirectToPage("./Index"); 
        }
    }
}
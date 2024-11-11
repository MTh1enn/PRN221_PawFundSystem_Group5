using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.IService;
using Service.Service;
using BusinessObjects.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRN221_PawFundSystem_Group5.Pages.FeedbackPage
{
    public class IndexModel : PageModel
    {
        private readonly IFeedbackService _feedbackService;

        public IndexModel()
        {
            _feedbackService = new FeedbackService();
        }

        public List<Feedback> Feedbacks { get; set; }

        public async Task OnGetAsync()
        {
            Feedbacks = _feedbackService.GetFeedbacks();
        }
    }
}

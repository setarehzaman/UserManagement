using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagement.Domain.Core.Contracts.AppService;
using UserManagement.Domain.Core.Entities;

namespace WebApplication1.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IUserAppService _userAppService;

        public CreateModel(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        [BindProperty]
        public User User { get; set; }
        public IActionResult OnPost()
        {
            if (!_userAppService.AddUser(User))
            {
                return Page();
            }
            return RedirectToPage("Index");
        }
    }
}

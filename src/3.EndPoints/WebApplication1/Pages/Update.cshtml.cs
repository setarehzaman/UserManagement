using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagement.Domain.Core.Contracts.AppService;
using UserManagement.Domain.Core.Entities;

namespace WebApplication1.Pages
{
    public class UpdateModel : PageModel
    {
        private readonly IUserAppService _userAppService;

        public UpdateModel(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        [BindProperty]
        public User User { get; set; }
        public void OnGet(int id)
        {
            User = _userAppService.GetUserById(id);
        }
        public IActionResult OnPost()
        {

            var result = _userAppService.UpdateUser(User);

            if (!result)
            {
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
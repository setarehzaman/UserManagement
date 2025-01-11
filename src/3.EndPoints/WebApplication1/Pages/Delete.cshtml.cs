using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagement.Domain.Core.Contracts.AppService;
using UserManagement.Domain.Core.Entities;

namespace WebApplication1.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IUserAppService _userAppService;

        public DeleteModel(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        public IActionResult OnGet(int id)
        {
            var result = _userAppService.DeleteUser(id);
            if (!result)
            {
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
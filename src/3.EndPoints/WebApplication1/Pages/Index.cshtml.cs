using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagement.Domain.Core.Contracts.AppService;
using UserManagement.Domain.Core.Entities;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserAppService _userAppService;

        public IndexModel(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        [BindProperty]
        public List<User> Users { get; set; }    
        
        [BindProperty(SupportsGet = true)]
        public string Prompt { get; set; }
        public IActionResult OnGet()
        {
            if (string.IsNullOrWhiteSpace(Prompt))
            {
                Users = _userAppService.GetAllUsers();
            }
            else
            {
                Users = _userAppService.SearchUsersByPrompt(Prompt);
            }

            return Page();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyBlog.Pages
{
    public class RegisterModel : PageModel
    {
        private ILogger<RegisterModel> logger;
        public RegisterModel(ILogger<RegisterModel> logger)
        {
            this.logger = logger;
        }
    
        public void OnGet()
        {
        }
    }
}

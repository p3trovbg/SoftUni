namespace Library.Models
{
    using System.ComponentModel.DataAnnotations;
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Confirm password doesn't match, Type again !")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}

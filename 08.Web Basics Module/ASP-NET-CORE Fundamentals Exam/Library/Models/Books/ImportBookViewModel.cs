namespace Library.Models.Books
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.ComponentModel.DataAnnotations;
    public class ImportBookViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        public string Title { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        public string Author { get; set; }

        [Required]
        [StringLength(5_000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "10.00")]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string? UserId { get; set; }

        public IEnumerable<SelectListItem>? Categories { get; set; }
    }
}

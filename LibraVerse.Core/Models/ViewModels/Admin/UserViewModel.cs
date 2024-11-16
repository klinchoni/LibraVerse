namespace LibraVerse.Core.Models.ViewModels.Admin
{
    using System.ComponentModel.DataAnnotations;
    using static LibraVerse.Data.Constants.DataConstants.PublisherConstants;

    public class UserViewModel
    {
        [Required]
        [RegularExpression(PublisherEmailRegex)]
        public string Email { get; set; } = null!;
    }
}
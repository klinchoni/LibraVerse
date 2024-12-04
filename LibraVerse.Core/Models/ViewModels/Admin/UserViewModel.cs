namespace LibraVerse.Core.Models.ViewModels.Admin
{
    using System.ComponentModel.DataAnnotations;
    using static LibraVerse.Common.Constants.EntityValidationConstants.Publisher;

    public class UserViewModel
    {
        [Required]
        [RegularExpression(PublisherEmailRegex)]
        public string Email { get; set; } = null!;
    }
}
namespace LibraVerse.Data.Models.Roles
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static LibraVerse.Common.EntityValidationConstants.ApplicationUser;

    public class ApplicationUser : IdentityUser
    {
        [Required]
        [PersonalData]
        [MaxLength(ApplicationUserFirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [PersonalData]
        [MaxLength(ApplicationUserLastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;
    }

    public static class PublisherConstants
    {
        public const string PublisherEmailRegex = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";
    }

}

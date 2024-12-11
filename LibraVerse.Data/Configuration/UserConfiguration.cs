namespace LibraVerse.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using LibraVerse.Data.Models.Roles;
    using LibraVerse.Data.Seeding;

    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var data = new DataSeed();

            builder.HasData(new ApplicationUser[] { data.GuestUser, data.PublisherUser, data.AdminUser, data.RandomUser1, data.RandomUser2 });
        }
    }
}
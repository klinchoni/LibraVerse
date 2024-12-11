namespace LibraVerse.Data.Configuration
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using LibraVerse.Data.Seeding;

    public class UserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            var data = new DataSeed();


            builder.HasData(data.AdminUserClaim, data.PublisherUserClaim, data.GuestUserClaim, data.RandomUser1Claim, data.RandomUser2Claim);
        }
    }
}
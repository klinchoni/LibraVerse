namespace LibraVerse.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using LibraVerse.Data.Models.Roles;
    using LibraVerse.Data.Seeding;

    internal class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Publisher[] { data.Publisher, data.PublisherAdmin });
        }
    }
}
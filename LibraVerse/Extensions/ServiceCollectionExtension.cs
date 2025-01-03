﻿namespace Microsoft.Extensions.DependencyInjection
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using LibraVerse.Core.Contracts;
    using LibraVerse.Core.Services;

    using LibraVerse.Data.Repository;
    using LibraVerse.Data;
    using LibraVerse.Data.Models.Roles;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBookStoreService, BookStoreService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<UserManager<ApplicationUser>>();
            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<LibraDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<LibraDbContext>();

            return services;
        }
    }
}
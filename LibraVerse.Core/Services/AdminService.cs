﻿namespace LibraVerse.Core.Services
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using LibraVerse.Core.Contracts;
    using LibraVerse.Core.Models.QueryModels.Admin;

    using LibraVerse.Data.Repository;
    using LibraVerse.Data.Models.Roles;

    using static LibraVerse.Common.AdminConstants;


    public class AdminService : IAdminService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository repository;
        private readonly IPublisherService publisherService;
        private readonly IUserService userService;

        public AdminService(UserManager<ApplicationUser> userManager, IRepository repository, IPublisherService publisherService, IUserService userService)
        {
            this.userManager = userManager;
            this.repository = repository;
            this.publisherService = publisherService;
            this.userService = userService;
        }

        public async Task<int> AddPublisherAsync(string userId)
        {
            ApplicationUser user = userService.GetUserByIdAsync(userId).Result;

            Publisher publisher = new Publisher()
            {
                UserId = user.Id
            };

            await repository.AddAsync(publisher);
            await repository.SaveChangesAsync();

            return publisher.Id;
        }

        public async Task<UserServiceModel> RemovePublisherAsync(string userId)
        {
            ApplicationUser? user = repository.GetByIdAsync<ApplicationUser>(userId).Result;

            var deleteForm = new UserServiceModel()
            {
                Id = userId,
                FullName =  $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                IsPublisher = publisherService.ExistsByUserIdAsync(userId).Result,
                IsAdmin = userManager.IsInRoleAsync(user, AdminRole).Result
            };

            return deleteForm;
        }

        public async Task<int> RemovePublisherConfirmedAsync(string userId)
        {
            Publisher? publisher = repository.All<Publisher>().FirstOrDefaultAsync(p => p.UserId == userId).Result;

            await repository.RemoveAsync<Publisher>(publisher);
            await repository.SaveChangesAsync();

            return publisher.Id;
        }

        public async Task<string> AddAdminAsync(string userId)
        {
            ApplicationUser user = userService.GetUserByIdAsync(userId).Result;

            await userManager.AddToRoleAsync(user, AdminRole);
            await repository.SaveChangesAsync();

            return user.Id;
        }

        public async Task<UserServiceModel> RemoveAdminAsync(string userId)
        {
            ApplicationUser? user = repository.GetByIdAsync<ApplicationUser>(userId).Result;

            var removeForm = new UserServiceModel()
            {
                Id = userId,
                FullName =  $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                IsPublisher = publisherService.ExistsByUserIdAsync(userId).Result,
                IsAdmin = userManager.IsInRoleAsync(user, AdminRole).Result
            };

            return removeForm;
        }

        public async Task<string> RemoveAdminConfirmedAsync(string userId)
        {
            ApplicationUser? user = repository.GetByIdAsync<ApplicationUser>(userId).Result;

            await userManager.RemoveFromRoleAsync(user, AdminRole);
            await repository.SaveChangesAsync();

            return userId;
        }
    }
}
﻿namespace LibraVerse.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using LibraVerse.Core.Contracts;
    using LibraVerse.Core.Models.QueryModels.Admin;

    using LibraVerse.Data.Models.Roles;

    using System.Security.Claims;
    using static System.Security.Claims.ClaimsPrincipalExtensions;

    using static LibraVerse.Common.AdminConstants;


    public class UserController : AdminBaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;
        private readonly IPublisherService publisherService;
        private readonly IAdminService adminService;

        public UserController(IPublisherService publisherService, IUserService userService, IAdminService adminService, UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            this.publisherService = publisherService;
            this.adminService = adminService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllUsersQueryModel model)
        {
            var allUsers = await userService.AllAsync(
                User.Id(),
                model.SearchTerm,
                model.RoleStatus,
                model.CurrentPage,
                model.UsersPerPage);

            model.TotalUsersCount = allUsers.TotalUsersCount;
            model.Users = allUsers.Users;

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string userId)
        {
            var user = await userService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return BadRequest();
            }

            var currentUserDetails = await userService.DetailsAsync(userId);

            return View(currentUserDetails);
        }

        //Publisher
        [HttpGet]
        public async Task<IActionResult> AddPublisher(string id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }
            else if (await publisherService.ExistsByUserIdAsync(id))
            {
                return RedirectToAction(nameof(All));
            }

            var user = await userService.GetUserByIdAsync(id);

            var publisherForm = new UserServiceModel()
            {
                Id = id,
                FullName = userService.UserFullNameAsync(id).Result,
                Email = user.Email,
                IsPublisher = publisherService.ExistsByUserIdAsync(id).Result,
                IsAdmin = userManager.IsInRoleAsync(user, AdminRole).Result
            };

            return View(publisherForm);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddPublisherConfirmed(string id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }
            else if (await publisherService.ExistsByUserIdAsync(id))
            {
                return RedirectToAction(nameof(All));
            }

            await adminService.AddPublisherAsync(id);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> RemovePublisher(string id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }
            else if (!await publisherService.ExistsByUserIdAsync(id))
            {
                return RedirectToAction(nameof(All));
            }

            var user = await userService.GetUserByIdAsync(id);

            var publisherForm = new UserServiceModel()
            {
                Id = id,
                FullName = userService.UserFullNameAsync(id).Result,
                Email = user.Email,
                IsPublisher = publisherService.ExistsByUserIdAsync(id).Result,
                IsAdmin = userManager.IsInRoleAsync(user, AdminRole).Result
            };

            return View(publisherForm);
        }

        [HttpPost]
        public async Task<IActionResult> RemovePublisherConfirmed(string id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }
            else if (!await publisherService.ExistsByUserIdAsync(id))
            {
                return RedirectToAction(nameof(All));
            }

            await adminService.RemovePublisherConfirmedAsync(id);

            return RedirectToAction(nameof(All));
        }

        //Admin
        [HttpGet]
        public async Task<IActionResult> AddAdmin(string id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }

            var user = await userService.GetUserByIdAsync(id);

            if (await userManager.IsInRoleAsync(user, AdminRole))
            {
                return RedirectToAction(nameof(All));
            }

            var adminForm = new UserServiceModel()
            {
                Id = id,
                FullName = userService.UserFullNameAsync(id).Result,
                Email = user.Email,
                IsPublisher = publisherService.ExistsByUserIdAsync(id).Result,
                IsAdmin = userManager.IsInRoleAsync(user, AdminRole).Result
            };

            return View(adminForm);
        }

        [HttpPost]
        public async Task<IActionResult> AddAdminConfirmed(string id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }

            var user = await userService.GetUserByIdAsync(id);

            if (await userManager.IsInRoleAsync(user, AdminRole))
            {
                return RedirectToAction(nameof(All));
            }

            await adminService.AddAdminAsync(id);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> RemoveAdmin(string id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }

            var user = await userService.GetUserByIdAsync(id);

            if (!await userManager.IsInRoleAsync(user, AdminRole))
            {
                return RedirectToAction(nameof(All));
            }

            var adminForm = new UserServiceModel()
            {
                Id = id,
                FullName = userService.UserFullNameAsync(id).Result,
                Email = user.Email,
                IsPublisher = publisherService.ExistsByUserIdAsync(id).Result,
                IsAdmin = userManager.IsInRoleAsync(user, AdminRole).Result
            };

            return View(adminForm);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAdminConfirmed(string id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }

            var user = await userService.GetUserByIdAsync(id);

            if (!await userManager.IsInRoleAsync(user, AdminRole))
            {
                return RedirectToAction(nameof(All));
            }

            await adminService.RemoveAdminConfirmedAsync(id);

            return RedirectToAction(nameof(All));
        }
    }
}
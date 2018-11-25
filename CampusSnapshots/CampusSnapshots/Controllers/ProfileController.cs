using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SnapshotsData.Models;
using CampusSnapshots.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SnapshotsData;
using CampusSnapshots.Models;

namespace CampusSnapshots.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        #region Fields

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IApplicationUser userService;
        private readonly IPost postService;
        private readonly IHostingEnvironment _hosting;

        #endregion

        #region Controller

        public ProfileController(UserManager<ApplicationUser> userManager, IApplicationUser userService, IPost postService, IHostingEnvironment he)
        {
            this.userManager = userManager;
            this.userService = userService;
            this.postService = postService;
            this._hosting = he;
        }

        #endregion

        #region Actions

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var profiles = userService.GetAll()
                .Select(user => new ProfileViewModel
                {
                    Username = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    IsEmailConfirmed = user.EmailConfirmed,
                    DateJoined = user.DateJoined
                });

            var viewMod = new ProfileListViewModel()
            {
                Profiles = profiles
            };

            return View(viewMod);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var user = userService.GetById(id);
            var userRoles = await userManager.GetRolesAsync(user);

            var viewMod = new ProfileViewModel
            {
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsEmailConfirmed = user.EmailConfirmed,
                DateJoined = user.DateJoined,
                Posts = postService.GetAllPostsForUser(user.Id),
                ProfileImageUrl = user.ProfileImageUrl
            };

            return View(viewMod);
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfileImage(IFormFile file)
        {
            string filename = string.Empty;
            var userId = userManager.GetUserId(User);

            if (file != null)
            {
                filename = UploadImage(file);
                string url = "/images/" + Path.GetFileName(file.FileName);
                await userService.SetProfileImage(userId, url);
            }

            return RedirectToAction("Detail", "Profile", new { id = userId });
        }

        #endregion

        public string UploadImage(IFormFile img)
        {
            var filePath = Path.Combine(_hosting.WebRootPath + "\\images", Path.GetFileName(img.FileName));
            img.CopyTo(new FileStream(filePath, FileMode.Create));

            return filePath;
        }
    }
}
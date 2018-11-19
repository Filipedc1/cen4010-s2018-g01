using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusSnapshots.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SnapshotsData;

namespace CampusSnapshots.Controllers
{
    public class UserController : Controller
    {
        #region Fields

        private readonly SnapshotsDbContext dbContext;

        #endregion

        #region Constructor

        public UserController(SnapshotsDbContext context)
        {
            this.dbContext = context;
        }

        #endregion

        #region Actions

        public IActionResult Index()
        {
            var users = dbContext.ApplicationUsers.ToList();

            var vM = new UserIndexViewModel
            {
                Users = users
            };

            return View(vM);
        }

        #endregion
    }
}
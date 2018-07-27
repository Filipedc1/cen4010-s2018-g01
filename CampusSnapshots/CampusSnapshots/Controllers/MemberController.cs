using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusSnapshots.Data;
using CampusSnapshots.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SnapshotsData;

namespace CampusSnapshots.Controllers
{
    public class MemberController : Controller
    {
        #region Fields

        private readonly ApplicationDbContext database;


        #endregion

        #region Constructor

        public MemberController(ApplicationDbContext context)
        {
            this.database = context;
        }

        #endregion

        #region Methods

        public IActionResult Index()
        {
            var users = database.Users.ToList();

            var vM = new MemberIndexViewModel
            {
                Users = users
            };
            
            return View(vM);
        }

        #endregion
    }
}
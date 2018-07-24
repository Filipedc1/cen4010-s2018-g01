using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnapshotsData;

namespace CampusSnapshots.Controllers
{
    public class MemberController : Controller
    {
        #region Fields

        private readonly IMember _member;

        #endregion

        #region Constructor

        public MemberController(IMember member)
        {
            this._member = member;
        }

        #endregion

        #region Methods

        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}
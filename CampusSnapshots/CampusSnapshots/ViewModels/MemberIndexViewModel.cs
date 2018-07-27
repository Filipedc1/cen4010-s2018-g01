using CampusSnapshots.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusSnapshots.ViewModels
{
    public class MemberIndexViewModel
    {
        public IEnumerable<ApplicationUser> Users   { get; set; }
    }
}

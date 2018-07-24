using SnapshotsData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusSnapshots.ViewModels
{
    public class PostIndexViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public string PageTitle { get; set; }
    }
}

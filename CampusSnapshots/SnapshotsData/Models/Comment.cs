using CampusSnapshots.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnapshotsData.Models
{
    public class Comment
    {
        public int Id                        { get; set; }
        public string Content                { get; set; }
        public DateTime SendTime             { get; set; }
        public Post Post                     { get; set; }

        public virtual ApplicationUser User  { get; set; }
    }
}

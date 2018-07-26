using SnapshotsData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusSnapshots.ViewModels
{
    public class PostDetailViewModel
    {
        public int PostId                        { get; set; }
        public string Title                      { get; set; }
        public string Description                { get; set; }
        public DateTime DateCreated              { get; set; }
        public string ImageUrl                   { get; set; }
        public PostType EventOrIssue             { get; set; }
        public Status Status                     { get; set; }
        public IEnumerable<Comment> Comments     { get; set; }
        public Campus Campus                     { get; set; }
        public Comment Comment                   { get; set; } //used for adding new comment. TESTING
    }
}

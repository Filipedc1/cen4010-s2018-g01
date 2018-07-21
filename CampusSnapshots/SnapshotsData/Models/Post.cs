using System;
using System.Collections.Generic;
using System.Text;

namespace SnapshotsData.Models
{
    public enum PostType { Event, Issue }

    public class Post
    {
        public int Id                           { get; set; }
        public string Title                     { get; set; } 
        public string Description               { get; set; }
        public DateTime DateCreated             { get; set; }
        public string Url                       { get; set; }
        public Status Status                    { get; set; } 
        public PostType PostType                { get; set; }
        public IEnumerable<Comment> Comments    { get; set; }
        public Campus Campus                    { get; set; }
    }
}

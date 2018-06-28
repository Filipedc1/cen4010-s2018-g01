using SnapshotsData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusSnapshots.ViewModels
{
    public enum FormType { New, Edit }

    public class PostFormViewModel
    {
        public int Id                  { get; set; }
        public FormType FormType           { get; set; }
        public string Title            { get; set; }
        public string Description      { get; set; }
        public DateTime DateCreated    { get; set; }
        public string Url              { get; set; }
        public PostType PostType       { get; set; }
        public Status Status           { get; set; }

        public PostFormViewModel()
        {
            DateCreated = DateTime.Now;
        }
    }
}

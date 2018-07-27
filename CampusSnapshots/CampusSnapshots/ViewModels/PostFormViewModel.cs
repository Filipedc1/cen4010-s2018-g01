using Microsoft.AspNetCore.Http;
using SnapshotsData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampusSnapshots.ViewModels
{
    public enum FormType { New, Edit }

    public class PostFormViewModel
    {
        public int Id                           { get; set; }
        public FormType FormType                { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "No more than 30 characters permitted")]
        public string Title                     { get; set; }

        [Required]
        public string Description               { get; set; }

        public DateTime DateCreated             { get; set; }
        public string Url                       { get; set; }
        public PostType PostType                { get; set; }
        public Status Status                    { get; set; }
        public IEnumerable<Status> Statuses     { get; set; }
        public IFormFile ImageUpload            { get; set; }
        public IEnumerable<Campus> Campuses     { get; set; }

        [Required]
        public Campus Campus                    { get; set; }

        #region Constructor

        public PostFormViewModel()
        {
            DateCreated = DateTime.Now;

            Campus = new Campus
            {
                Name = "N/A",
                Address = "N/A",
                PhoneNumber = "N/A"
            };

            Status = new Status
            {
                Name = "N/A",
                Description = "N/A"
            };

        }

        #endregion
    }
}

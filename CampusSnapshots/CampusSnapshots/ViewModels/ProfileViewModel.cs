using Microsoft.AspNetCore.Http;
using SnapshotsData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusSnapshots.ViewModels
{
    public class ProfileViewModel
    {
        public string UserId                { get; set; }
        public string Username              { get; set; }
        public string FirstName             { get; set; }
        public string LastName              { get; set; }
        public string ProfileImageUrl       { get; set; }
        public bool IsAdmin                 { get; set; }
        public bool IsEmailConfirmed        { get; set; }

        public DateTime DateJoined          { get; set; }
        public IFormFile ImageUpload        { get; set; }

        public IEnumerable<Post> Posts      { get; set; }

        [Required]
        [EmailAddress]
        public string Email                 { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber           { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}

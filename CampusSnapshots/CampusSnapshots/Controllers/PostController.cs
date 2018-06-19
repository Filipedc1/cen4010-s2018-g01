using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusSnapshots.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SnapshotsData;

namespace CampusSnapshots.Controllers
{
    public class PostController : Controller
    {
        #region Fields

        private readonly IPost _posts;

        #endregion

        #region Constructor

        public PostController(IPost post)
        {
            this._posts = post;
        }

        #endregion
        
        #region Methods

        //Display List of posts or gallery of posts
        public IActionResult Index()
        {
            var posts = _posts.GetAll();

            var viewModel = new PostIndexViewModel()
            {
                Posts = posts
            };

            return View(viewModel);
        }

        //Displays details about a post when selected
        public IActionResult Detail(int id)
        {
            var post = _posts.GetById(id);
           
            var viewModel = new PostDetailViewModel()
            {
                PostId = post.Id,
                Title = post.Title,
                Description = post.Description,
                DateCreated = post.DateCreated,
                ImageUrl = post.Url,
                EventOrIssue = post.PostType,
                Status = post.Status
            };

            return View(viewModel);
        }

        #endregion
    }
}


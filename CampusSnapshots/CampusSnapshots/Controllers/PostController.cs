using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusSnapshots.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SnapshotsData;
using SnapshotsData.Models;

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
        public IActionResult Issues()
        {
            var posts = _posts.GetAll().Where(p => p.PostType == PostType.Issue);

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
                Status = post.Status,
                Comments = _posts.GetAllCommentsByPostId(post.Id)
                //Comments = post.Comments?.Where(p => p.Post.Id == id)
            };

            return View(viewModel);
        }

        public IActionResult NewPost()
        {
            var formVM = new PostFormViewModel();

            return View("PostForm", formVM);
        }

        public IActionResult Delete(int id)
        {
            if (_posts.DeletePost(id))
            {
                return RedirectToAction("Issues");
            }

            return BadRequest();
        }

        public IActionResult Edit(int id)
        {
            var post = _posts.GetById(id);

            if (post == null)
            {
                return BadRequest();
            }

            var vM = new PostFormViewModel
            {
                Id = post.Id,
                FormType = FormType.Edit,
                Title = post.Title,
                Description = post.Description,
                DateCreated = post.DateCreated,
                Url = post.Url,
                PostType = post.PostType,
                Status = post.Status
            };


            return View("PostForm", vM);
        }

        [HttpPost]
        public IActionResult SaveForm(Post post) 
        {
            //if not valid, return the user the New Post page
            if (!ModelState.IsValid)
            {
                var vM = new PostFormViewModel();

                return View("PostForm", vM);
            }

            //if true, then it's a new post
            if (post.Id == 0)
            {
                if (_posts.AddNewPost(post))
                {
                    return RedirectToAction("Issues");
                }
            }
            else 
            {
                if (_posts.EditPost(post))
                {
                    return RedirectToAction("Detail", new { post.Id });
                }
            }

            return BadRequest();
        }

        //if this doesnt work, just add a second argument to Details with type PostDetailViewModel!
        [HttpPost]
        public IActionResult AddComment(PostDetailViewModel vm)
        {
            if (!ModelState.IsValid || vm.Comment == null)
            {
                return BadRequest();
            }

            if (_posts.AddNewComment(vm.PostId, vm.Comment))
            {
                return RedirectToAction("Detail", "Post" , new { @id = vm.PostId });
            }

            return BadRequest();
        }

        #endregion
    }
}


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CampusSnapshots.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnapshotsData;
using SnapshotsData.Models;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace CampusSnapshots.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        #region Fields

        private readonly IHostingEnvironment _hosting;
        private readonly IPost _posts;
        private readonly ICampus _campus; 

        #endregion

        #region Constructor

        public PostController(IPost post, ICampus campus, IHostingEnvironment he)
        {
            this._posts = post;
            this._campus = campus;
            this._hosting = he; 
        }

        #endregion
        
        #region Post Methods

        //Display List of posts or gallery of posts
        public IActionResult Issues()
        {
            var posts = _posts.GetAll().Where(p => p.PostType == PostType.Issue);

            var viewModel = new PostIndexViewModel()
            {
                Posts = posts,
                PageTitle = "Issues"
            };

            return View(viewModel);
        }

        public IActionResult Events()
        {
            var posts = _posts.GetAll().Where(post => post.PostType == PostType.Event);

            var view = new PostIndexViewModel();
            view.Posts = posts;
            view.PageTitle = "Events";

            return View("Issues", view);
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
                Comments = _posts.GetAllCommentsByPostId(post.Id),
                Campus = post.Campus
                //Comments = post.Comments?.Where(p => p.Post.Id == id)
            };

            return View(viewModel);
        }

        public IActionResult NewPost()
        {
            var campuses = _campus.GetAll();
            var formVM = new PostFormViewModel()
            {
                Campuses = campuses,
                Statuses = _posts.GetListOfStatus()
            };

            return View("PostForm", formVM);
        }

        public IActionResult Delete(int id)
        {
            var post = _posts.GetById(id);

            if (_posts.DeletePost(post))
            {
                if (post.PostType == PostType.Issue)
                {
                    return RedirectToAction("Issues");
                }
                else
                {
                    return RedirectToAction("Events");
                }
            }

            return BadRequest();
        }

        public void DeleteImageFromHostingEnvironment(string url)
        {
            var filename = Path.GetFileName(url);
            string t = _hosting.WebRootPath + "\\images";
            var files = Directory.GetFiles(t);
            var file = files.Where(f => Path.GetFileName(f) == filename).Single();
            System.IO.File.Delete(file);
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
                Status = post.Status,
                Campus = post.Campus,
                Campuses = _campus.GetAll(),
                Statuses = _posts.GetListOfStatus()
            };


            return View("PostForm", vM);
        }

        [HttpPost]
        public IActionResult SaveForm(PostFormViewModel postVM, IFormFile pic) 
        {
            //if not valid, return the user the New Post page
            if (!ModelState.IsValid)
            {
                var vM = new PostFormViewModel()
                {
                    Campuses = _campus.GetAll(),
                    Statuses = _posts.GetListOfStatus()
                };

                return View("PostForm", vM);
            }

            var post = new Post
            {
                Id = postVM.Id,
                Title = postVM.Title,
                Description = postVM.Description,
                DateCreated = postVM.DateCreated,
                Url = postVM.Url,
                Status = postVM.Status,
                PostType = postVM.PostType,
                Campus = _campus.GetById(postVM.Campus.Id)
            };

            //if true, then it's a new post
            if (postVM.Id == 0)
            {
                string filename = string.Empty;

                //upload image if not null
                if (pic != null)
                {
                    filename = UploadImage(pic);
                    post.Url = "/images/" + Path.GetFileName(pic.FileName);
                }

                if (_posts.AddNewPost(post))
                {
                    return (postVM.PostType == PostType.Issue) ? RedirectToAction("Issues") : RedirectToAction("Events");
                }
            }
            else 
            {
                if (_posts.EditPost(post))
                {
                    return RedirectToAction("Detail", new { postVM.Id });
                }
            }

            return BadRequest();
        }

        #endregion

        #region Comment Methods

        [HttpPost]
        public IActionResult AddComment(PostDetailViewModel vm)
        {
            if (!ModelState.IsValid || vm.Comment == null)
            {
                return BadRequest();
            }

            if (_posts.AddNewComment(vm.PostId, vm.Comment))
            {
                return RedirectToAction("Detail", "Post", new { @id = vm.PostId });
            }

            return BadRequest();
        }

        public IActionResult DeleteComment(int id)
        {
            var comment = _posts.GetCommentById(id);
            var post = _posts.GetById(comment.Post.Id);

            if (_posts.DeleteComment(comment))
            {
                return RedirectToAction("Detail", new { post.Id });
            }

            return BadRequest();
        }

        #endregion

        #region Image methods

        //will need to change when dealing with Azure
        public string UploadImage(IFormFile img)
        {
            var filePath = Path.Combine(_hosting.WebRootPath + "\\images", Path.GetFileName(img.FileName));
            img.CopyTo(new FileStream(filePath, FileMode.Create));

            return filePath;
        }

        #endregion
    }
}


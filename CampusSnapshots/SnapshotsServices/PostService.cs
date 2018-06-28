using Microsoft.EntityFrameworkCore;
using SnapshotsData;
using SnapshotsData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnapshotsServices
{
    public class PostService : IPost
    {
        #region Fields

        private readonly SnapshotsDbContext context;

        #endregion

        #region Constructor

        public PostService(SnapshotsDbContext context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        public IEnumerable<Post> GetAll()
        {
            return context.Posts
                .Include(p => p.Status);
        }

        public Post GetById(int id)
        {
            return context.Posts
                .Include(p => p.Status)
                .FirstOrDefault(post => post.Id == id);
        }

        public bool AddNewPost(Post post)
        {
            if (post == null)
            {
                return false;
            }

            post.DateCreated = DateTime.Now;

            //sets the default status for the post as "reported"
            post.Status = SetStatusForNewPosts();

            context.Posts.Add(post);
            context.SaveChanges();
            return true;
        }

        //All new posts will have the status of 'Reported'
        public Status SetStatusForNewPosts()
        {
            return context.Status.FirstOrDefault(x => x.Id == 1);
        }

        public bool DeletePost(int id)
        {
            var post = context.Posts.FirstOrDefault(p => p.Id == id);

            if (post != null)
            {
                context.Remove(post);
                context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool EditPost(Post post)
        {
            if (post == null)
                return false;

            var postInDatabase = GetById(post.Id);
            if (postInDatabase != null)
            {
                postInDatabase.Title = post.Title;
                postInDatabase.Description = post.Description;
                postInDatabase.PostType = post.PostType;

                context.SaveChanges();
                return true;
            }

            return false;
        }

        #endregion
    }
}

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
                .Include(location => location.Campus)
                .Include(p => p.Status);
        }

        public Post GetById(int id)
        {
            return context.Posts
                .Include(p => p.Status)
                .Include(location => location.Campus)
                .FirstOrDefault(post => post.Id == id);
        }

        public bool AddNewPost(Post post)
        {
            if (post == null)
            {
                return false;
            }

            post.DateCreated = DateTime.Now;

            //sets the default status for the post as "reported" If its a User
            if (post.Status.Id == 0)
            {
                post.Status = SetStatusForNewPosts();
            }
            else //Admins are required to set the status themselves in the UI
            {
                post.Status = GetStatusById(post.Status.Id);
            }

            context.Posts.Add(post);
            context.SaveChanges();
            return true;
        }

        //All new posts will have the status of 'Reported'
        public Status SetStatusForNewPosts()
        {
            return context.Status.FirstOrDefault(x => x.Id == 1);
        }

        public IEnumerable<Status> GetListOfStatus()
        {
            return context.Status;
        }

        public Status GetStatusById(int id)
        {
            return context.Status.FirstOrDefault(s => s.Id == id);
        }

        public bool DeletePost(Post post)
        {
            if (post == null)
            {
                return false;
            }

            //need to remove all comments for a post before deleting the post from the database
            var commentsForPost = GetAllCommentsByPostId(post.Id); 
            if (commentsForPost != null && commentsForPost.Count() > 0)
            {
                context.Comment.RemoveRange(commentsForPost);
            }

            context.Posts.Remove(post);
            context.SaveChanges();
            return true;
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
                postInDatabase.Campus = post.Campus;
                postInDatabase.Status = GetStatusById(post.Status.Id);

                context.SaveChanges();
                return true;
            }

            return false;
        }

        #endregion

        #region Comment Helper Methods

        public bool AddNewComment(int postId, Comment comment)
        {
            if (comment == null)
                return false;

            var postInDB = GetById(postId);
            if (postInDB != null)
            {
                comment.Post = postInDB;
                comment.SendTime = DateTime.Now;

                context.Comment.Add(comment);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteComment(Comment comment)
        {
            if (comment == null)
                return false;

            context.Comment.Remove(comment);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Comment> GetAllCommentsByPostId(int postId)
        {
            return context.Comment
                .Include(p => p.Post)
                .Where(c => c.Post.Id == postId)
                .ToList();
        }

        public Comment GetCommentById(int id)
        {
            return context.Comment
                .Include(c => c.Post)
                .FirstOrDefault(c => c.Id == id);
        }

        #endregion
    }
}

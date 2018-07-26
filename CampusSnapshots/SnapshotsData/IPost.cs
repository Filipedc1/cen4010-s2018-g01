using SnapshotsData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnapshotsData
{
    public interface IPost
    {
        //get all posts
        IEnumerable<Post> GetAll();

        Post GetById(int id);

        bool AddNewPost(Post post);

        bool DeletePost(Post post);

        bool EditPost(Post id);

        Status SetStatusForNewPosts();

        Status GetStatusById(int id);

        IEnumerable<Status> GetListOfStatus();

        bool AddNewComment(int postId, Comment comment);

        IEnumerable<Comment> GetAllCommentsByPostId(int id);

        Comment GetCommentById(int id);

        bool DeleteComment(Comment comment);
    }
}

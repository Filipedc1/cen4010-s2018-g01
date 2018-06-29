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

        bool DeletePost(int id);

        bool EditPost(Post id);

        Status SetStatusForNewPosts();

        bool AddNewComment(int postId, Comment comment);

        IEnumerable<Comment> GetAllCommentsByPostId(int id);
    }
}

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
    }
}

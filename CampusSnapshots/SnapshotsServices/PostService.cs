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

        #endregion
    }
}

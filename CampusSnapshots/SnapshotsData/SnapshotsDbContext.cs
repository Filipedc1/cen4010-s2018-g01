using Microsoft.EntityFrameworkCore;
using SnapshotsData.Models;

namespace SnapshotsData
{
    public class SnapshotsDbContext : DbContext
    {
        public SnapshotsDbContext(DbContextOptions options)
            : base(options)
        {

        }

        //this represents a table in the database
        public DbSet<Member> Members    { get; set; }
        public DbSet<Post> Posts        { get; set; }
        public DbSet<Status> Status     { get; set; }  //dont apply migrations since table already exists. Need this dbset here to be able to access the table
        public DbSet<Comment> Comment   { get; set; }  //dont apply migrations since table already exists. Need this dbset here to be able to access the table
        public DbSet<Campus> Campus    { get; set; }
    }
}

using CampusSnapshots.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SnapshotsData.Models;

namespace SnapshotsData
{
    public class SnapshotsDbContext : IdentityDbContext<ApplicationUser>
    {
        public SnapshotsDbContext(DbContextOptions<SnapshotsDbContext> options)
            : base(options)
        {

        }

        //this represents a table in the database
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Post> Posts        { get; set; }
        public DbSet<Status> Status     { get; set; }  
        public DbSet<Comment> Comment   { get; set; }  
        public DbSet<Campus> Campus     { get; set; }
    }
}

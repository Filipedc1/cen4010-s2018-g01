using CampusSnapshots.Models;
using SnapshotsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapshotsServices
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly SnapshotsDbContext dbContext;

        public ApplicationUserService(SnapshotsDbContext context)
        {
            dbContext = context;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return dbContext.ApplicationUsers;
        }

        public ApplicationUser GetById(string id)
        {
            return GetAll().FirstOrDefault(user => user.Id == id);
        }
    }
}

using SnapshotsData;
using SnapshotsData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnapshotsServices
{
    public class CampusService : ICampus
    {
        private SnapshotsDbContext _context;

        public CampusService(SnapshotsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Campus> GetAll()
        {
            return _context.Campus;
        }

        public Campus GetById(int id)
        {
            /* var p = from c in _context.Campus
                    where c.Id == post.Campus.Id
                    select c;  */

            return _context.Campus.FirstOrDefault(c => c.Id == id);
        }
    }
}

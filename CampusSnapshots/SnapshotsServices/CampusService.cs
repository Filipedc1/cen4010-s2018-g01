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
        #region Fields

        private readonly SnapshotsDbContext database;

        #endregion

        #region Constructors

        public CampusService(SnapshotsDbContext database)
        {
            this.database = database;
        }

        #endregion

        #region Methods

        public IEnumerable<Campus> GetAll()
        {
            return database.Campus;
        }

        public Campus GetById(int id)
        {
            return database.Campus.FirstOrDefault(c => c.Id == id);
        }

        #endregion
    }
}

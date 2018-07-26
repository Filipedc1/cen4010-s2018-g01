using SnapshotsData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnapshotsData
{
    public interface ICampus
    {
        IEnumerable<Campus> GetAll();
        Campus GetById(int id);
    }
}

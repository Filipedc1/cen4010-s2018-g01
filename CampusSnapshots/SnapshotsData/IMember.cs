using SnapshotsData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnapshotsData
{
    public interface IMember
    {
        Member Get(int id);
        IEnumerable<Member> GetAll();
        void Add(Member newMember);

        //IEnumerable<PostHistory> GetCheckoutHistory(int memberId); maybe?
    }
}

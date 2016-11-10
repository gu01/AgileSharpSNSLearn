using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace AgileSharp.SNS.Model.Entities
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public int MemberCount { get; set; }
        public string Description { get; set; }
        public Account CreatedAccount { get; set; }
        public bool IsPublic { get; set; }

        List<Account> Members { get; set; }
        public Binary Version { get; set; }
             
    }
}

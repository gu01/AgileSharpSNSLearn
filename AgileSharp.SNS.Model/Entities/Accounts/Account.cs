using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Model.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool EmailVerfied { get; set; }       

        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int TermId { get; set; }
        public DateTime AgreedToTermsDate { get; set; }
        public bool IsDeleted { get; set; }
        public Binary Version { get; set; }

        public Profile Profile { get; set; }
        public Permission Permission { get; set; }
        List<Friend> Friends { get; set; }
        List<Folder> Folders{get;set;}
        List<FileInfo> Files { get; set; }      
    }
}

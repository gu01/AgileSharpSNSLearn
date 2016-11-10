using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace AgileSharp.SNS.Services.ViewModels
{
    public class AccountViewModel
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
        
        public virtual ProfileViewModel Profile { get; set; }
        public virtual List<FriendViewModel> Friends { get; set; }
        public virtual List<FolderViewModel> Folders { get; set; }
        public virtual List<FileInfoViewModel> Files { get; set; }
        public virtual PermissionViewModel PermissionInfo { get; set; }
    }
}

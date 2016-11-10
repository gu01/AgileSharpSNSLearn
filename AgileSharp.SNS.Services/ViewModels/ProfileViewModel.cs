using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace AgileSharp.SNS.Services.ViewModels
{
    public class ProfileViewModel
    {
        public int ProfileId { get; set; }
        public string ProfileName { get; set; }
        public string Avatar { get; set; }
        public int AccountId { get; set; }

        public string HomePageUrl { get; set; }
        public string RealName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string IM { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public Binary Version { get; set; }
    }
}

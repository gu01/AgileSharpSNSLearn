using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Services.ViewModels;

namespace AgileSharp.SNS.Services.Messages
{
    public class ProfileResponse : ResponseBase
    {
        public ProfileViewModel ProfileInfo { get; set; }
        public List<ProfileAttributeViewModel> Attributes { get; set; }
    }
}

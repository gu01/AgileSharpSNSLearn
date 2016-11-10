using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Services.ViewModels;

namespace AgileSharp.SNS.Services.Messages
{
    public class SearchAccountResponse : ResponseBase   
    {
        public List<AccountViewModel> Accounts { get; set; }
        public int TotalCount { get; set; }
    }
}

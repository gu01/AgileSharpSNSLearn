using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Services.ViewModels;

namespace AgileSharp.SNS.Services.Interfaces
{
    public interface IPermissionService
    {
        PermissionViewModel GetPermissionByAccountId(int accountId);
    }
}

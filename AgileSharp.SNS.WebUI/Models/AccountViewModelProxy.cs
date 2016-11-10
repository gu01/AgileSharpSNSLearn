using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AgileSharp.SNS.Services.ViewModels;
using StructureMap;
using AgileSharp.SNS.Services.Interfaces;

namespace AgileSharp.SNS.WebUI.Models
{
    public class AccountViewModelProxy : AccountViewModel
    {
        private PermissionViewModel permissionInfo = null;

        public bool HasLoadPermission { get; set; }

        public override PermissionViewModel PermissionInfo
        {
            get
            {
                if (!HasLoadPermission)
                {
                    permissionInfo = ObjectFactory.GetInstance<IPermissionService>().
                        GetPermissionByAccountId(base.AccountId);
                    HasLoadPermission = true;

                }
                return permissionInfo;
            }
            set
            {
                permissionInfo = value;
            }
        }
    }

}

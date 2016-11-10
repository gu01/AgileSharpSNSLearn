using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Model.Repositories
{
    public interface IPermissionRepository
    {
        Permission FindPermissionByAccountId(int accountId);
        List<Permission> GetAll();

        void Save(Permission permission);
        void Delete(int permissionId);
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Model.Repositories
{
    public interface IFolderRepository
    {
        List<Folder> GetFoldersByAccountId(int accountId);
        bool CreateFolder(Account account, Folder folder);
        bool DeleteFolder(Folder folder);
    }
}

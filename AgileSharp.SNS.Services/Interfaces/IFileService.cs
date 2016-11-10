using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Services.Interfaces
{
    public interface IFileService
    {
        List<Folder> GetFoldersByAccountId(int accountId);
        bool CreateFolder(Account account, Folder folder);
        bool DeleteFolder(Folder folder);

        bool SaveFile(FileInfo fileInfo, Folder folder);
        bool DeleteFile(FileInfo fileInfo);

        List<FileInfo> GetFilesByAccountId(int accountId, int startIndex,
            int requestSize, ref int totalCount);

    }
}

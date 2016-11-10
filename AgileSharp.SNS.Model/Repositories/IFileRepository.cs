using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Model.Repositories
{
    public interface IFileRepository
    {
        bool SaveFile(FileInfo fileInfo, Folder folder);
        bool DeleteFile(FileInfo fileInfo);

        List<FileInfo> GetFilesByAccountId(int accountId, int startIndex, int requestSize, ref int totalCount);
    }
}

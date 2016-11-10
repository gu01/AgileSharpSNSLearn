using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Model.Repositories
{
    public interface IMessagerRepository
    {
        List<MessageWithRecipient> GetMessageByAccountId(int accountId, int startIndex, int requestSize, MessageFolderType folder);
        bool DeleteMessage(Message messge);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Services.Interfaces
{
    public interface IMessageService
    {
        List<MessageWithRecipient> GetMessageByAccountId(int accountId, int startIndex,
            int requestSize, MessageFolderType folderType);


        bool DeleteMessage(Message messge);
        bool DeleteMessageRecipient(MessageRecipient messageRecipient);
        void SendMessage(Account from, string body, string subject, string[] to);
    }
}

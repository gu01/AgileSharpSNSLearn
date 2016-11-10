using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileSharp.SNS.Model.Entities
{
    public class MessageRecipient
    {
        public int MessageRecipientId { get; set; }
        public int MessageId { get; set; }       
        public int AccountId { get; set; }
        public MessageFolderType FolderName { get; set; }
        public MessageStatusType MessageStatusType { get; set; }
    }
}

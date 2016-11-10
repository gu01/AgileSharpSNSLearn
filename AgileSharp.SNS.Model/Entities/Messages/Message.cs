using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace AgileSharp.SNS.Model.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public int SendByAccountId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreateDate { get; set; }
        public Binary Version { get; set; }
        public MessageType MessageType { get; set; }
    }
}

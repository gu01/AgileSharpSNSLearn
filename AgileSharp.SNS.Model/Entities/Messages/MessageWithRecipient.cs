using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileSharp.SNS.Model.Entities
{
    public class MessageWithRecipient
    {
        public Account Sender { get; set; }
        public Message Message { get; set; }
        public MessageRecipient Recipient { get; set; }
    }
}

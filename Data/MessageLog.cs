using System;
using System.Collections.Generic;

#nullable disable

namespace MyChat.Data
{
    public partial class MessageLog
    {
        public Guid MessageUn { get; set; }
        public string Username { get; set; }
        public string MessageText { get; set; }
        public int ChannelId { get; set; }
        public string UserColor { get; set; }
        public DateTime? Optime { get; set; }
    }
}

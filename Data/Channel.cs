using System;
using System.Collections.Generic;

#nullable disable

namespace MyChat.Data
{
    public partial class Channel
    {
        public int Id { get; set; }
        public string ChannelName { get; set; }
        public bool IsActive { get; set; }
    }
}

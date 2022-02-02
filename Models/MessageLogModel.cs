using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MyChat.Models
{
	public class MessageLogModel
	{
		[Key]
		[Column("ID")]
		[DataMember]
		public Guid MessageUN { get; set; }

		[StringLength(255)]
		[DataMember]
		public string Username { get; set; }

		[StringLength(999)]
		[DataMember]
		public string MessageText { get; set; }

		[DataMember]
		public int ChannelID { get; set; }

		[DataMember]
		public string UserColor { get; set; }
		
		[DataMember]
		public DateTime Optime { get; set; }

		[DataMember]
		public string OptimeStr { get; set; }
	}
}

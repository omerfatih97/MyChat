using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MyChat.Models
{
	public class ChannelModel
	{
		[Key]
		[Column("ID")]
		[DataMember]
		public int ID { get; set; }

		[StringLength(255)]
		[DataMember]
		public string ChannelName { get; set; }

		[DataMember]
		public bool IsActive { get; set; }
	}
}

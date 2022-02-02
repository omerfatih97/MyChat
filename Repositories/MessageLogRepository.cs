using MyChat.Data;
using MyChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChat.Repositories
{
	public interface IMessageLogRepository
	{
		List<MessageLog> GetMessageLog(int channelID);
		void MessageLogAdd(MessageLogModel model);
	}

	public class MessageLogRepository : GenericRepository<MessageLog>, IMessageLogRepository
	{
		public List<MessageLog> GetMessageLog(int channelID)
		{
			return this.List(x => x.ChannelId == channelID);
		}

		public void MessageLogAdd(MessageLogModel model)
		{
			MessageLog u = new MessageLog()
			{
				MessageUn = Guid.NewGuid(),
				Username = model.Username,
				MessageText = model.MessageText,
				ChannelId = model.ChannelID,
				UserColor = model.UserColor,
				Optime = DateTime.Now,
			};

			this.TAdd(u);
		}
	}
}

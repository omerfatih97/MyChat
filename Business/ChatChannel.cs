using Microsoft.AspNetCore.SignalR;
using MyChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChat.Business
{
	public class ChatChannel : Hub
	{
		private static BsMessageLogs bsMessageLogs = new BsMessageLogs();
		private static BsChannels bsChannels = new BsChannels();
		private static List<MessageLogModel> messageLogs = new List<MessageLogModel>();
		private static List<ChannelModel> channels = new List<ChannelModel>();
		private static int ChannelID = -1;

		public async Task SendMessage(string userName, string message, string userColor, int channelID)
		{
			if (!message.Equals("channelClick"))
			{
				MessageLogModel newMessage = new MessageLogModel
				{
					ChannelID = channelID,
					Username = userName,
					MessageText = message,
					UserColor = userColor,
					Optime = DateTime.Now,
				};

				try
				{
					bsMessageLogs.MessageLogAdd(newMessage);
				}
				catch (Exception e)
				{

				}
			}
			else
			{
				messageLogs = new List<MessageLogModel>();
			}

			if (messageLogs.Count() == 0 || ChannelID != channelID)
			{
				ChannelID = channelID;
				this.getFromDB(channelID);
			}
			else
			{
				if(!message.Equals("channelClick"))
					await Clients.All.SendAsync("ReceiveMessage", userName, message, userColor, DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
			}

		}

		public async Task getFromDB(int channelID)
		{
			messageLogs = bsMessageLogs.GetMessageLog(channelID);
			foreach (var item in messageLogs.OrderBy(x => x.Optime).ToList())
			{
				string user = item.Username;
				string message1 = item.MessageText;
				string userColor1 = item.UserColor;
				string optime1 = item.Optime.ToString("dd/MM/yyyy HH:mm");
				await Clients.All.SendAsync("ReceiveMessage", user, message1, userColor1, optime1);
			}
		}

		public async Task GetChannels()
		{
			channels = bsChannels.GetChannel();
			foreach (var item in channels)
			{
				int channelid = item.ID;
				string channelname = item.ChannelName;
				await Clients.All.SendAsync("ReceiveChannel", channelid, channelname);
			}
		}

		public async Task AddChannels(string name)
		{
			try
			{
				bsChannels.ChannelAdd(new ChannelModel { ChannelName = name, IsActive = true });
			}
			catch (Exception e)
			{

			}			
		}
	}
}

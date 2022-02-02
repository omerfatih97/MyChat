using MyChat.Data;
using MyChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChat.Repositories
{
	public interface IChannelRepository
	{
		List<Channel> GetChannels();
		void ChannelAdd(ChannelModel model);
	}

	public class ChannelRepository : GenericRepository<Channel>, IChannelRepository
	{
		public void ChannelAdd(ChannelModel model)
		{
			Channel u = new Channel()
			{
				ChannelName = model.ChannelName,
				IsActive = true
			};

			this.TAdd(u);
		}

		public List<Channel> GetChannels()
		{
			return this.List(x => x.IsActive == true);
		}
	}
}

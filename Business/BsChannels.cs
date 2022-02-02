using MyChat.Data;
using MyChat.Models;
using MyChat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChat.Business
{
	public class BsChannels
    {
        private readonly IChannelRepository _channelRepo = new ChannelRepository();

        public void ChannelAdd(ChannelModel model)
        {
            _channelRepo.ChannelAdd(model);
        }

        public List<ChannelModel> GetChannel()
        {
            List<ChannelModel> result = new List<ChannelModel>();
            var tmp = _channelRepo.GetChannels();
            foreach (var item in tmp)
            {
                ChannelModel newChannel = new ChannelModel()
                {
                    ID = item.Id,
                    ChannelName = item.ChannelName,
                };

                result.Add(newChannel);
            }
            return result;
        }
    }
}

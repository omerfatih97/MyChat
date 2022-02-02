using MyChat.Data;
using MyChat.Models;
using MyChat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChat.Business
{
	public class BsMessageLogs
	{
        private readonly IMessageLogRepository _messageLogRepo = new MessageLogRepository();

        public void MessageLogAdd(MessageLogModel model)
        {
            _messageLogRepo.MessageLogAdd(model);
        }

        public List<MessageLogModel> GetMessageLog(int channelID)
        {
            List<MessageLogModel> model = new List<MessageLogModel>();
            var tmp = _messageLogRepo.GetMessageLog(channelID);
            foreach (var item in tmp)
            {
                MessageLogModel newMessageLog = new MessageLogModel()
                {
                    Username = item.Username,
                    MessageText = item.MessageText,
                    ChannelID = item.ChannelId,
                    UserColor = item.UserColor,
                    Optime = item.Optime.GetValueOrDefault(),
                    OptimeStr = item.Optime.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm")
            };

                model.Add(newMessageLog);
            }
            return model.OrderBy(x => x.Optime).ToList() ;
        }
    }
}

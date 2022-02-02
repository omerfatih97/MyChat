using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MyChat.Business;
using MyChat.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyChat.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private static BsChannels bsChannels = new BsChannels();
		private static BsMessageLogs bsMessageLogs = new BsMessageLogs();

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public JsonResult GetChanells()
		{
			var resultList = bsChannels.GetChannel();
			return Json(resultList);
		}

		public JsonResult GetChannelMessages(int channelID)
		{
			var resultList = bsMessageLogs.GetMessageLog(channelID);
			return Json(resultList);
		}

		public JsonResult AddChannel(string name)
		{
			try
			{
				bsChannels.ChannelAdd(new ChannelModel { ChannelName = name, IsActive = true });
			}
			catch (Exception e)
			{

			}
			return Json("");
		}

	}
}

#pragma checksum "C:\Users\omery\source\repos\MyChat\MyChat\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00bd3fdefebd9621b9d159948eb187990ec7b6b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\omery\source\repos\MyChat\MyChat\Views\_ViewImports.cshtml"
using MyChat;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\omery\source\repos\MyChat\MyChat\Views\_ViewImports.cshtml"
using MyChat.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00bd3fdefebd9621b9d159948eb187990ec7b6b2", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4ea935540d98096af355a1a01a1d48b93f99225", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\omery\source\repos\MyChat\MyChat\Views\Home\Index.cshtml"
  
	ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>

	var channelID = 1;
	var channelEntered = 0;
	var messageListTmp = document.createElement(""ul"");;

	const connection = new signalR.HubConnectionBuilder().withUrl(""/chatChannel"").build();
	connection.on(""ReceiveMessage"", (user, message, userColor, optime) => {
		debugger;
		var encodedMsg = optime + "" | "" + user + "" : "" + message;
		var li = document.createElement(""li"");
		li.setAttribute('style', 'color: ' + userColor + '');
		li.textContent = encodedMsg;
		li.color = userColor;
		document.getElementById(""messageList"").appendChild(li);
		document.getElementById(""messageListTmp"").id = ""messageListTmp"" + channelID;
		document.getElementById(""messageListTmp"").appendChild(li);

	});

	connection.on(""ReceiveChannel"", (channelid, channelname) => {

		var btn = document.createElement(""a"");
		btn.textContent = ""Join "" + channelname;
		btn.id = channelid;
		btn.style = ""width:250px;""
		btn.name = ""chn"" + channelid;
		btn.onclick = function () { chnBtnClick(this); };
		document.g");
            WriteLiteral(@"etElementById(""channelListItems"").appendChild(btn);

		var br = document.createElement(""br"");
		document.getElementById(""channelListItems"").appendChild(br);

	});

	connection.start().then(function () {
		document.getElementById(""sendMessageBtn"").disabled = false;
		getChannelsFromDB();
		getMessagesFromDB();
	}).catch(function (err) {
		return console.error(err.toString());
	});

	$(document).ready(function () {
		//getChannelsFromDB();
		

	});

	function chnBtnClick(e) {
		debugger;
		channelID = e.id;
		document.getElementById(""katilBtnDiv"").style.display = ""block"";
		//document.getElementById(""infoDiv"").style.display = ""none"";
		document.getElementById(""messageArea"").style.display = ""none"";
		channelEntered = 0;

		document.getElementById(""katilBtnDiv"").style.display = ""none"";
		document.getElementById(""messageList"").innerHTML = """";

		this.connection.invoke(""getFromDB"", userName, message, currentUserColor, channelID).then(function () {
			document.getElementById(""message");
            WriteLiteral(@""").value = """";
		}).catch(function (err) {
			//debugger;
			return console.error(err.toString());
		});

		event.preventDefault();
		enterChannel();
	}
</script>

<div class=""text-center"">
	<h1 class=""display-4"">Welcome To MyChat</h1>
</div>
<br />
<br />

<div class=""container"">
	<div id=""userInfo"" style=""text-align:center"" align=""center"">
		<div class=""row""><label for=""username"">Please enter your nickname</label></div><br />
		<div class=""row""><input type=""text"" class=""form-control"" id=""username"" name=""username"" style=""width:500px;"" /></div><br />
		<div class=""row""><button type=""button"" class=""btn btn-block btn-primary"" onclick=""SetUsername();"" id=""enterBtn"" style=""width:fit-content"">Enter</button></div>
		
	</div>

	<div id=""infoDiv"" class=""row"" style=""display:none"">
		<h1>Please Select New Channel</h1>
	</div>

	<div id=""katilBtnDiv"" class=""row"" style=""display:none"">
		<button type=""button"" class=""btn btn-block"" id=""joinChnBtn"">Join Channel</button>
	</div>
	<div id=""mess");
            WriteLiteral(@"ageArea"" class=""row"" style=""display:none"">
		<div><b><span> Nickname: </span> <span id=""chatUserName""></span></b></div>
		<hr />
		<div class=""row"">
			<div class=""col-6"">
				<ul id=""messageList""></ul>
			</div>
		</div>
		<hr />
		<input type=""text"" id=""message"" style=""width:500px;"" autocomplete=""off"" />
		<input type=""button"" id=""sendMessageBtn"" value=""Send"" />
	</div>
</div>


<script>

	var userName = """";
	var currentUserColor = """";
	document.getElementById(""sendMessageBtn"").disabled = true;

	
	document.getElementById(""sendMessageBtn"").addEventListener(""click"", function (event) {
		var message = document.getElementById(""message"").value;
		connection.invoke(""SendMessage"", userName, message, currentUserColor, channelID).then(function () {
			document.getElementById(""message"").value = """";
		}).catch(function (err) {
			//debugger;
			return console.error(err.toString());
		});

		event.preventDefault();
	});

	/*document.getElementById(""joinChnBtn"").addEventListener(""click");
            WriteLiteral(@""", function (event) {
		//debugger;
		channelEntered = 0;

		document.getElementById(""katilBtnDiv"").style.display = ""none"";
		document.getElementById(""messageList"").innerHTML = """";

		enterChannel();
	});*/

	function SetUsername() {
		var usernameinput = document.getElementById(""username"").value;
		if (usernameinput === """") {
			alert(""please enter your user name"")
			return;
		}

		userName = usernameinput;

		document.getElementById(""userInfo"").style.display = ""none"";
		document.getElementById(""chatUserName"").innerText = usernameinput;

		currentUserColor = ""#"" + Math.floor(Math.random() * 16777215).toString(16).padStart(6, '0').toUpperCase();
		document.getElementById(""chatUserName"").style.color = currentUserColor;


		document.getElementById(""channelList"").style.display = ""block"";
		//document.getElementById(""infoDiv"").style.display = ""block"";

		//buras??
		document.getElementById(""messageArea"").style.display = ""block"";


	}

	function enterChannel() {
		debugger;

	");
            WriteLiteral(@"	if (channelID > -1 && channelEntered == 0) {
			document.getElementById(""message"").value = """";
			//getMessagesFromDB();
			document.getElementById(""messageArea"").style.display = ""block"";
			document.getElementById(""katilBtnDiv"").style.display = ""none"";
		}
	}

	function getChannelsFromDB() {

		connection.invoke(""GetChannels"").then(function () {
		}).catch(function (err) {
			return console.error(err.toString());
		});

		event.preventDefault();		
	}

	function getMessagesFromDB() {

		connection.invoke(""SendMessage"", userName, ""channelClick"", currentUserColor, channelID).then(function () {
			document.getElementById(""message"").value = """";
		}).catch(function (err) {
			return console.error(err.toString());
		});

		event.preventDefault();

	}
</script>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

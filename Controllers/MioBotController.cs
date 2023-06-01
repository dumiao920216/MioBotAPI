using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using MioBotAPI.Socket;
using MioBotAPI.Helper;

namespace MioBotAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MioBotController : Controller
    {
        //构造对象
        public class PostData 
        {
            public string? Msg { get; set; }
            public string? Qq { get; set; }
            public string? Group { get; set; }
        }

        [HttpGet]
        public ActionResult<JsonObject> Get()
        {
            var jsontext = "{\"Hello\":\"World\"}";
            return JsonNode.Parse(jsontext)!.AsObject(); ;
        }

        [HttpPost]
        public ActionResult<JsonObject> Post([FromForm] PostData obj)
        {
            //组装数据
            string msg = obj.Msg!;
            string qq = obj.Qq!;
            string group = obj.Group!;
            string str = msg + "|" + qq + "|" + group;
            LogHelper.logger.Info("已接收数据：{0}", str);
            //发送数据
            Client.Send(str);
            return Ok();
        }
    }
}
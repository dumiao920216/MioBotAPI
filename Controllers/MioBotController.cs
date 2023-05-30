using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using MioBotAPI.Socket;

namespace MioBotAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MioBotController : Controller
    {
        [HttpGet]
        public ActionResult<JsonObject> Get()
        {
            var jsontext = "{\"Hello\":\"World\"}";
            return JsonNode.Parse(jsontext)!.AsObject(); ;
        }
        [HttpPost]
        public ActionResult<JsonObject> Post(string msg,string qq,string group)
        {
            string str = msg + "|" + qq + "|" + group;
            Client.Send(str);
            var jsontext = "{\"success\":\"true\"}";
            return JsonNode.Parse(jsontext)!.AsObject(); ;
        }
    }
}

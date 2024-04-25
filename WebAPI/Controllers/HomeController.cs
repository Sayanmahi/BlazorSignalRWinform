using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebAPI.Hubs;
using WebAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHubContext<SignalHub> _hubContext;
        public HomeController(IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
        }

        // POST api/<HomeController>
        [HttpPost("[action]")]
        public IActionResult Post(Employee emp)
        {
            Employee e = new Employee();
            e.Id = emp.Id;
            e.Name = emp.Name;
            e.PhoneNo = emp.PhoneNo;
            _hubContext.Clients.Client(emp.clientid).SendAsync("ReceiveEmployee", e);
            PushMessage("New Employee Added");
            return Ok("Done");
        }
        [HttpGet("[action]")]
        public IActionResult PushMessage(string message)
        {
            _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
            return Ok("Done");
        }
        [HttpGet("[action]")]
        public async Task<ResponseDTO> SeeConnectedUsers()
        {
            ResponseDTO d = new ResponseDTO();
            d.Result=ConnectedUsers.Ids.ToList();
            return (d);
        }
    }
}

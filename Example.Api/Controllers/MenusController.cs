using Example.Contracts.Menus;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    [Route("hosts/{hostId}/menus")]
    public class MenusController : ApiController
    {
        [HttpPost]
        public IActionResult CreateMenu(
            CreateMenuRequest request,
            string hostId)
        {
            return Ok(request);
        }
    }
}
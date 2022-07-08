using FoodOrder.Application.Services.Interfaces;
using FoodOrder.Entity.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodOrder.API.Controllers
{
    [ApiController]
    [Route(APIEndPoint.User)]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }
    }
}

using APIService.IServices;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IUserService _userService;
        public UserController(ILogger<ProductController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost(Name = "InsertUser")]
        public int Post([FromBody] UserItem userItem)
        {
            return _userService.InsertUser(userItem);
        }
    }
}

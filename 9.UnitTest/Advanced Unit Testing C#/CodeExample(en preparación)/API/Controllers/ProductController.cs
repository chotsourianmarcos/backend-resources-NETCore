using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController
    {
        //private readonly IUserSecurityService _userSecurityService;
        //private readonly IUserService _userService;

        //public UserController(IUserSecurityService userSecurityService, IUserService userService)
        //{
        //    _userSecurityService = userSecurityService;
        //    _userService = userService;
        //}

        //[EndpointAuthorize(AllowsAnonymous = true)]
        //[HttpPost(Name = "LoginUser")]
        //public string Login([FromBody] LoginRequest loginRequest)
        //{

        //    return _userSecurityService.GenerateAuthorizationToken(loginRequest.UserName, loginRequest.UserPassword);
        //}
    }
}

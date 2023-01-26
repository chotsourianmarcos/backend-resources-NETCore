using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Resources.FilterModels;
using Resources.RequestModels;
using RRHHWebAPI.IServices;
using System.Security.Authentication;
using System.Xml.Linq;

namespace RRHHWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private ISecurityService _securityService;
        private IUserService _userService;
        public UserController(ISecurityService securityService, IUserService userService)
        {
            _securityService = securityService;
            _userService = userService;
        }

        [HttpPost(Name = "InsertUser")]
        public int Post([FromHeader] UserCredentials userCredentials, [FromBody] NewUserRequest newUserRequest)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userCredentials.UserName, userCredentials.UserPassword, 1);
            if(validCredentials == true)
            {
                return _userService.InsertUser(newUserRequest);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetAllUsers")]
        public List<UserItem> GetAll([FromHeader] UserCredentials userCredentials)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userCredentials.UserName, userCredentials.UserPassword, 1);
            if (validCredentials == true)
            {
                return _userService.GetAllUsers();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModifyUser")]
        public void Patch([FromHeader] UserCredentials userCredentials, [FromBody] UserItem userItem)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userCredentials.UserName, userCredentials.UserPassword, 1);
            if (validCredentials == true)
            {
                _userService.UpdateUser(userItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "DeleteUser")]
        public void Delete([FromHeader] UserCredentials userCredentials, [FromQuery] int id)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userCredentials.UserName, userCredentials.UserPassword, 1);
            if (validCredentials == true)
            {
                _userService.DeleteUser(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetUsersByCriteria")]
        public List<UserItem> GetByCriteria([FromHeader] UserCredentials userCredentials, [FromQuery] UserFilter userFilter)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userCredentials.UserName, userCredentials.UserPassword, 1);
            if (validCredentials == true)
            {
                return _userService.GetUsersByCriteria(userFilter);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
    }
}

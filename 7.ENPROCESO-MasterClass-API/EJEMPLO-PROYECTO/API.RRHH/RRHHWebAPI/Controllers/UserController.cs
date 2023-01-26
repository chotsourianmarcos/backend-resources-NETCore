using Microsoft.AspNetCore.Mvc;
using Resources.RequestModels;
using RRHHWebAPI.IServices;
using System.Security.Authentication;
using System.Xml.Linq;

namespace RRHHWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public int Post([FromBody] NewUserRequest newUserRequest)
        {
            var validCredentials = _securityService.ValidateUserCredentials(newUserRequest.Credentials.UserName, newUserRequest.Credentials.UserPassword, 1);
            if(validCredentials == true)
            {
                return _userService.InsertUser(newUserRequest);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        //[HttpGet(Name = "GetAllProducts")]
        //public int Get([FromBody] ProductItem productItem)
        //{
        //    //     _userService.ValidateCredentials(userItem);
        //    return _productService.InsertProduct(productItem);
        //}

        //[HttpPatch(Name = "ModifyProduct")]
        //public int Patch([FromBody] ProductItem productItem)
        //{
        //    //     _userService.ValidateCredentials(userItem);
        //    return _productService.InsertProduct(productItem);
        //}

        //[HttpGet(Name = "DeleteProduct")]
        //public int Delete([FromBody] ProductItem productItem)
        //{
        //    //     _userService.ValidateCredentials(userItem);
        //    return _productService.InsertProduct(productItem);
        //}

        //[HttpGet(Name = "GetAllProducts")]
        //public List<ProductItem> GetAll()
        //{
        //    //     _userService.ValidateCredentials(userItem);
        //    return _productService.GetAllProducts();
        //}
    }
}

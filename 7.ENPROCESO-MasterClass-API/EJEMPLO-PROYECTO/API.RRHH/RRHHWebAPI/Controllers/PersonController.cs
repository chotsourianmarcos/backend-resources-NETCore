using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using RRHHWebAPI.IServices;
using System.Security.Authentication;

namespace RRHHWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private ISecurityService _securityService;
        private IPersonService _personService;
        public PersonController(ISecurityService securityService, IPersonService personService)
        {
            _securityService = securityService;
            _personService = personService;
        }

        [HttpPost(Name = "InsertPerson")]
        public int Post([FromHeader] string userName, [FromHeader] string userPassword, [FromBody] PersonItem personItem)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1);
            if (validCredentials == true)
            {
                return _personService.InsertPerson(personItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModifyPerson")]
        public void Patch([FromHeader] string userName, [FromHeader] string userPassword, [FromBody] PersonItem personItem)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1);
            if (validCredentials == true)
            {
                _personService.UpdatePerson(personItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
    }
}

using BCrypt.Net;
using Data;
using Entities.Entities;
using Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class UserSecurityLogic : IUserSecurityLogic
    {
        private readonly ServiceContext _serviceContext;
        public UserSecurityLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public string GenerateAuthorizationToken(string userName, string userPassword)
        {
            var user = _serviceContext.Set<UserItem>()
                     .Where(u => u.UserName == userName).SingleOrDefault();

            if (user != null)
            {
                if(user.IsActive)
                {
                    if (user.EncryptedPassword == EncryptString(userPassword))
                    {
                        var secureRandomString = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
                        user.EncryptedToken = EncryptString(secureRandomString);
                        user.TokenExpireDate = DateTime.Now.AddMinutes(10);
                        _serviceContext.SaveChanges();
                        return secureRandomString;
                    }
                    else
                    {
                        throw new UnauthorizedAccessException("La contraseña es incorrecta.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("El usuario no está activo.");
                }
            }
            else
            {
                throw new InvalidCredentialException("El usuario no existe o bien está replicado.");
            }
        }

        public bool ValidateUserToken(string userName, string token, string controller, string action, string method)
        {
            var user = _serviceContext.Set<UserItem>()
                     .Where(u => u.UserName == userName).FirstOrDefault();

            if (user != null)
            {
                var userAuthorization = _serviceContext.Set<UserAuthorizationItem>()
                     .Where(a => a.IdUserRol == user.IdRol
                            && a.ControllerName == controller
                            && a.ActionName == action
                            && a.HTTPMethodType == method
                            && a.IsActive == true)
                     .FirstOrDefault();

                if(userAuthorization == null) 
                {
                    throw new UnauthorizedAccessException("El usuario no está autorizado para la acción.");
                }
                
                if (user.IsActive)
                {
                    if(user.EncryptedToken == EncryptString(token))
                    {
                        if(DateTime.Now > user.TokenExpireDate)
                        {
                            throw new UnauthorizedAccessException("El token ha expirado.");
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        throw new UnauthorizedAccessException("El token es incorrecto.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("El usuario no está activo.");
                }
            }
            else
            {
                throw new InvalidCredentialException("El usuario no existe");
            }
        }

        private string EncryptString(string key)
        {
            return BCrypt.Net.BCrypt.HashPassword(key);
        }
    }
}

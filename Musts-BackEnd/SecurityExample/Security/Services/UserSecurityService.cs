﻿using Logic.ILogic;
using Security.IServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Security.Services
{
    public class UserSecurityService : IUserSecurityService
    {
        private readonly IUserSecurityLogic _userSecurityLogic;
        public UserSecurityService(IUserSecurityLogic userSecurityLogic) 
        {
            _userSecurityLogic = userSecurityLogic;
        }
        public string GenerateAuthorizationToken(string userName, string userPassword)
        {
            return _userSecurityLogic.GenerateAuthorizationToken(userName, userPassword);
        }
        public bool ValidateUserToken(string authorization, string controller, string action, string method)
        {
            var indexToSplit = authorization.IndexOf(':');
            var userName = authorization.Substring(0, indexToSplit);
            var token = authorization.Substring(indexToSplit +1, authorization.Length - userName.Length -1);
            return _userSecurityLogic.ValidateUserToken(userName, token, controller, action, method);
        }
    }
}

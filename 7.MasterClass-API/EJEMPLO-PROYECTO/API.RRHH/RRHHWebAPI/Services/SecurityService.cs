using Data;
using Entities.Entities;
using RRHHWebAPI.IServices;

namespace RRHHWebAPI.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly ServiceContext _serviceContext;
        public SecurityService(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public bool ValidateUserCredentials(string userName, string userPassWord, int idRol)
        {
            var selectedUser =_serviceContext.Set<UserItem>()
                                .Where(u => u.Name == userName
                                    && u.Password == userPassWord
                                    && u.IdRol == idRol).FirstOrDefault();

            if(selectedUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
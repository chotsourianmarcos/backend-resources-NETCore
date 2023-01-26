namespace RRHHWebAPI.IServices
{
    public interface ISecurityService
    {
        bool ValidateCredentials(string userName, string userPassWord, int idRol);
    }
}

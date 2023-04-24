using API.Models.Entities;

namespace API.IServices
{
    public interface IEmailService
    {
        void SendNewOrderNotification(OrderItem orderItem);
    }
}

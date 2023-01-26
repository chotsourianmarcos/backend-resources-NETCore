using Entities.Entities;

namespace RRHHWebAPI.Models.Requests
{
    public class NewUserRequest
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public UserItem ToUserItem()
        {
            return new UserItem();
        }
    }
}

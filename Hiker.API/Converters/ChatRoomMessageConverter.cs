using Hiker.API.Converters.Interfaces;
using Hiker.API.DTO.Resource.Query;
using Hiker.Persistence.DAO;

namespace Hiker.API.Converters
{
    public class ChatRoomMessageConverter : IChatRoomMessageConverter
    {
        public ChatRoomMessageResource Convert(ChatRoomMessage msg)
        {
            return new ChatRoomMessageResource
            {
                Username = $"{msg.User.FirstName} {msg.User.LastName}",
                Content = msg.Content,
                UserImgUrl = $"{Consts.FacebookAPI}{msg.User.FacebookId}/picture?width=300&height=300"
            };
        }
    }
}
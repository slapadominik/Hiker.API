using System.Collections.Generic;
using System.Linq;
using Hiker.Persistence.DAO;
using Hiker.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hiker.Persistence.Repositories
{
    public class ChatRoomMessageRepository : IChatRoomMessageRepository
    {
        private readonly AppDbContext _appDbContext;

        public ChatRoomMessageRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<ChatRoomMessage> GetByChatRoomId(int chatRoomId)
        {
            return _appDbContext.ChatRoomMessages.Include(x => x.User).Where(x => x.TripId == chatRoomId);
        }

        public void Add(ChatRoomMessage msg)
        {
            _appDbContext.Add(msg);
            _appDbContext.SaveChanges();
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hiker.Persistence.DAO
{
    public class ChatRoomMessage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
        
        public string Content { get; set; }

        public Trip Trip { get; set; }
        public int TripId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace OIDt.Models.DB
{
    public class GameStarts
    {
        [Key]
        public int GameId { get; set; }
        public string EventDate { get; set; }

        public string UserId { get; set; }
        public Users User { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
namespace OIDt.Models.DB
{
    public class EndStages
    {
        [Key]
        public int EndId { get; set; }
        public string EventDate { get; set; }
        public int Stage { get; set; }
        public bool Win { get; set; }
        public int Time { get; set; }
        public int Income { get; set; }

        public string UserId { get; set; }
        public Users User { get; set; }
    }
}
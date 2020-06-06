
using System.ComponentModel.DataAnnotations;
namespace OIDt.Models.DB
{
    public class StartStages
    {
        [Key]
        public int StartId { get; set; }
        public string EventDate { get; set; }
        public int Stage { get; set; }

        public string UserId { get; set; }
        public Users User { get; set; }
    }
}
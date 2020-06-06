using System.ComponentModel.DataAnnotations;

namespace OIDt.Models.DB
{
    public class UserData
    {
        [Key]
        public int DataId { get; set; }
        public string EventDate { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        public string UserId { get; set; }
        public Users User { get; set; }
    }
}
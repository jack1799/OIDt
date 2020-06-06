using System.ComponentModel.DataAnnotations;

namespace OIDt.Models.DB
{
    public class Users
    {
        [Key]
        public string UserId { get; set; }
}
}
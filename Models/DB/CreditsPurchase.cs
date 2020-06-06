
using System.ComponentModel.DataAnnotations;
namespace OIDt.Models.DB
{
    public class CreditsPurchase
    {
        [Key]
        public int CreditsId { get; set; }
        public string EventDate { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Income { get; set; }

        public string UserId { get; set; }
        public Users User { get; set; }
    }
}
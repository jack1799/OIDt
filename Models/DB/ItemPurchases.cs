using System.ComponentModel.DataAnnotations;

namespace OIDt.Models.DB
{
    public class ItemPurchases
    {
        [Key]
        public int ItemId { get; set; }
        public string EventDate { get; set; }
        public string Item { get; set; }
        public float Price { get; set; }

        public string UserId { get; set; }
        public Users User { get; set; }
    }
}
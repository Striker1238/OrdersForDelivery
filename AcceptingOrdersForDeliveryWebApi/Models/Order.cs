using System.ComponentModel.DataAnnotations.Schema;

namespace AcceptingOrdersForDeliveryWebApi.Models
{
    [Table("orders")]
    public class Order
    {
        public int Id { get; set; }
        public string? SenderCity { get; set; }
        public string? SenderAddress { get; set; }
        public string? ReceiverCity { get; set; }
        public string? ReceiverAddress { get; set; }
        public float Weight { get; set; }
        public string? PickupDate { get; set; }
        public string? OrderNumber { get; set; }
    }
}

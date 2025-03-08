using System.ComponentModel.DataAnnotations;

namespace AcceptingOrdersForDeliveryMVC.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Город отправителя")]
        public string? SenderCity { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Адрес отправителя")]
        public string? SenderAddress { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Город получателя")]
        public string? ReceiverCity { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Адрес получателя")]
        public string? ReceiverAddress { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Вес должен быть больше 0")]
        [Display(Name = "Вес груза (кг)")]
        public float Weight { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата забора груза")]
        public DateTime PickupDate { get; set; }

        [Display(Name = "Номер заказа")]
        public string? OrderNumber { get; set; }
    }
}
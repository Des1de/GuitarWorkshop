using System.ComponentModel.DataAnnotations;

namespace GuitarWorkshopUI.DTO
{
    public class GuitarOrderDTO
    {
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public int BuildId { get; set; }

        public DateTime OrderDateTime { get; set; }

        public decimal Price { get; set; }

        public string OrderStatus { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string DeliveryAddress { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
    }
}

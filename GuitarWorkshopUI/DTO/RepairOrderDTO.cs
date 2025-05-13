namespace GuitarWorkshopUI.DTO
{
    public class RepairOrderDTO
    {
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public int ReapairTypeId { get; set; }

        public DateTime OrderDateTime { get; set; }

        public decimal Price { get; set; }

        public string OrderStatus { get; set; }
    }
}

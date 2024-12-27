namespace ApiYemek23.Entities.AppEntities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int RestaurantId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public User User { get; set; }
        

    }
}

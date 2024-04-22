namespace NomNom.Web.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        
        public ICollection<GrilledCheese> GrilledCheeses { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string Status { get; set; }

    }
}

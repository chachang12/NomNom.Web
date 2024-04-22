namespace NomNom.Web.Models
{
    public class GrilledCheese
    {
        public int GrilledCheeseId { get; set; }
        
        public Order? Order { get; set; }
        
        public int OrderId { get; set; }

        public string Bread { get; set; } = "White";

        public string Cheese { get; set; } = "Swiss";

        public string Butter { get; set; } = "Salted";

        public string? Extras { get; set; }

        public string? Condiments { get; set; }

         
    }
}

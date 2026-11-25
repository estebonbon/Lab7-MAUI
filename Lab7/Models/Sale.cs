namespace Lab7.Models
{
    public class Sale
    {
        public string? Description { get; set; }
        public double Price { get; set; }

        public Sale() { }
        public Sale(string? description, double price)
        {
            Description = description;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Description}: {Price:C2}";
        }
    }
}

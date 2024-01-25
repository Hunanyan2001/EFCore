namespace ConsoleApp2.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public ICollection<ProductSupplier> ProductSupplier { get; set; }
    }
}

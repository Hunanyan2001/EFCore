namespace ConsoleApp2.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductSupplier> ProductSupplier { get; set; }
    }
}

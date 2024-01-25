using System.ComponentModel.DataAnnotations;

namespace ConsoleApp2.Models
{
    public class ProductSupplier
    {
        [Key]
        public int Id { get; set; } 

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }
    }
}
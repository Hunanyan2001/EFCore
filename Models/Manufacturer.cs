using System.ComponentModel.DataAnnotations;

namespace ConsoleApp2.Models
{
    public  class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

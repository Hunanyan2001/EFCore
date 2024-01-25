using ConsoleApp2.Interface;
using ConsoleApp2.Models;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp2.ProductHelper
{
    public class ProductManagerHelper
    {

        private readonly IRepositary<Product> _productManager;
        private readonly IRepositary<Category> _categoryManager;

        public ProductManagerHelper(IRepositary<Product> productManager, IRepositary<Category> categoryManager)
        {
            _productManager = productManager ?? throw new ArgumentNullException(nameof(productManager));
            _categoryManager = categoryManager;
        }

        public async Task AddProduct()
        {
            var product = WriteProductDetails();

            CheckingCategory(product.CategoryId);

            var result = await _productManager.AddAsync(product);
            if (result.Success)
                Console.WriteLine("Product Added");
            else
                Console.WriteLine(result.Message);
        }

        public async Task DeleteProduct()
        {
            Console.WriteLine("Write Product Id");
            int productId = int.Parse(Console.ReadLine());
            var result = await _productManager.DeleteAsync(productId);
            if (result.Success)
                Console.WriteLine("Product Deleted");
            else
                Console.WriteLine("Product can not Delete");
        }

        public async Task UpdateProduct()
        {
            Console.WriteLine("Write Product Id");
            var productMessage = WriteProductDetails();
           
            CheckingCategory(productMessage.CategoryId);

            var result = await _productManager.UpdateAsync(productMessage);

            if (result.Success)
                Console.WriteLine("Success updated Product");
            else 
                Console.Write(result.Message);
        }

        public async Task ViewProduct()
        {
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine());
            var product = await _productManager.GetByIdAsync(productId);

            if (product != null)
            {
                PrintProductDetails(product);
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public async Task ViewAllProducts()
        {
            Console.Write("All Products: ");

            var products = await _productManager.GetAllAsync();
            if (products != null)
            {
                foreach (var item in products)
                {
                    PrintProductDetails(item);
                }
            }
        }

        static void PrintProductDetails(Product product)
        {
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.WriteLine($"ID: {product.Id}");
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Category: {product.Category}");
            Console.WriteLine($"Price: {product.Price:C}");
            Console.WriteLine($"Description: {product.Description}");
        }

        public static Product WriteProductDetails()
        {
            Console.WriteLine("Write Produc Name :");
            string name = Console.ReadLine();

            Console.WriteLine("Write Produc Description :");
            string description = Console.ReadLine();

            Console.WriteLine("Write Produc Price :");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid price format.");
                return null;
            }

            Console.WriteLine("Write Product Category Id:");
            int categoryId = int.Parse(Console.ReadLine());
            
            return new Product
            {
                Name = name,
                Description = description,
                Price = price,
                CategoryId = categoryId
            };
        }
        public void CheckingCategory(int categoryId)
        {
            if (_categoryManager.GetByIdAsync(categoryId) == null)
            {
                Category category = new Category();
                category.Name = "Default";
                category.Id = categoryId;
                _categoryManager.AddAsync(category);
            }
        }
    }
}

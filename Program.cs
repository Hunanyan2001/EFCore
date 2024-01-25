using ConsoleApp2.Entity;
using ConsoleApp2.Interface;
using ConsoleApp2.Manager;
using ConsoleApp2.ProductHelper;

namespace ConsoleApp2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new EntityContext();
            IProductManager productManager = new ProductManager(dbContext);

            ProductManagerHelper helper = new ProductManagerHelper(productManager);
            while (true)
            {
                PrintMenu();
                if (Enum.TryParse(Console.ReadLine(), out MenuOptions choice))
                {
                    switch (choice)
                    {
                        case MenuOptions.AddProduct:
                            helper.AddProduct();
                            break;
                        case MenuOptions.DeleteProduct:
                            helper.DeleteProduct();
                            break;
                        case MenuOptions.UpdateProduct:
                            helper.UpdateProduct();
                            break;
                        case MenuOptions.ViewProduct:
                            helper.ViewProduct();
                            break;
                        case MenuOptions.ViewAllProducts:
                            helper.ViewAllProducts();
                            break;
                        case MenuOptions.Quit:
                            Console.WriteLine("Exiting program.");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid menu option.");
                }
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Delete Product");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. View Product");
            Console.WriteLine("5. View All Products");
            Console.WriteLine("6. Quit");
            Console.Write("Enter your choice (1-6): ");
        }

        enum MenuOptions
        {
            AddProduct,
            DeleteProduct,
            UpdateProduct,
            ViewProduct,
            ViewAllProducts,
            Quit
        }
    }
}
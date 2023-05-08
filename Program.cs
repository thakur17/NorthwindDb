using static System.Console;
using Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Database
{
    class Program
    {
        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
             WriteLine("Categories and how many products they have:");
                // a query to get all categories and their related product                       WriteLine("Categories and how many products they have:");
                // a query to get all categories and their related products 
                
                IQueryable<Category> cats = db.Categories
                      .Include(c => c.Products);
                        
                       foreach (Category cc in cats)
                       {
                       WriteLine($"{cc.CategoryID}: {cc.CategoryName} has {cc.Products.Count} products.");
                       }
                
           
            }
        }
        static void QueryingProducts()
        {
            using (var db1 = new Northwind())
            {
            WriteLine("Products that cost more than a price, highest at top.");


                string input;
                decimal price;
                do
                {
                    Write("Enter a product price: ");
                    input = ReadLine();
                } while (!decimal.TryParse(input, out price));

                IQueryable<Product> prods = db1.Products
                .Where(Pr => (double)Pr.Cost > (double)price)
                .OrderByDescending(Pr => (double)Pr.Cost);
               
                foreach (Product item in prods)
                {
                WriteLine("{0}: {1} costs {2:$#,##0.00} and has {3} in stock.",
 item.ProductID, item.ProductName, item.Cost, item.Stock);
                }
            }
        }
                static void Main(string[] args)
        {
           QueryingCategories();
            QueryingProducts();
        }
    }
}
    


    

    



using RouteOOP;
using System;


class Program
{
    // Task 01  Smart Product Search

    /*
    SearchProducts uses Func<Product, bool>    
    func: we use it as delegate cuz we need function that takes product and return bool
    Makes function flexiable by changing the filter without changing the function  
    */

    static List<Product> SearchProducts(
        List<Product> products,
        Func<Product, bool> filter)
    {
        List<Product> result = new List<Product>();

        foreach (Product product in products)
        {
            if (filter(product))
            {
                result.Add(product);
            }
        }

        return result;
    }


    // Task 03 [1] : Print Reports

    /*
    PrintReport uses Action<Product>

    Action: is used because we don't need return anything we only print something for each product
    */

    static void PrintReport(
        List<Product> products,
        Action<Product> action)
    {
        foreach (Product product in products)
        {
            action(product);
        }
    }


    // Task 03 [2] : Transform Products
    /*
    TransformProducts uses Func<Product, string>
    Func : because we take a product and return a string
    
    */

    static List<string> TransformProducts(
        List<Product> products,
        Func<Product, string> transform)
    {
        List<string> result = new List<string>();

        foreach (Product product in products)
        {
            result.Add(transform(product));
        }

        return result;
    }


    // Task 03 [3] : Filter Products

    /*
    FilterProducts uses Predicate<Product>
    Predicate : we need condition that return boolen [True , False]
    */

    static List<Product> FilterProducts(
        List<Product> products,
        Predicate<Product> condition)
    {
        List<Product> result = new List<Product>();

        foreach (Product product in products)
        {
            if (condition(product))
            {
                result.Add(product);
            }
        }

        return result;
    }



    static void Main(string[] args)
    {

        //* Product Catalog

        List<Product> catalog = new()
        {
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Category = "Electronics",
                Price = 1200,
                Stock = 10
            },

            new Product
            {
                Id = 2,
                Name = "Phone",
                Category = "Electronics",
                Price = 800,
                Stock = 25
            },

            new Product
            {
                Id = 3,
                Name = "T-Shirt",
                Category = "Clothing",
                Price = 30,
                Stock = 100
            },

            new Product
            {
                Id = 4,
                Name = "Jeans",
                Category = "Clothing",
                Price = 60,
                Stock = 50
            },

            new Product
            {
                Id = 5,
                Name = "Chocolate",
                Category = "Food",
                Price = 5,
                Stock = 200
            },

            new Product
            {
                Id = 6,
                Name = "Coffee Beans",
                Category = "Food",
                Price = 15,
                Stock = 80
            },

            new Product
            {
                Id = 7,
                Name = "C# Book",
                Category = "Books",
                Price = 45,
                Stock = 30
            },

            new Product
            {
                Id = 8,
                Name = "Novel",
                Category = "Books",
                Price = 20,
                Stock = 60
            },

            new Product
            {
                Id = 9,
                Name = "Headphones",
                Category = "Electronics",
                Price = 150,
                Stock = 40
            },

            new Product
            {
                Id = 10,
                Name = "Jacket",
                Category = "Clothing",
                Price = 120,
                Stock = 15
            }
        };


        // *****************************************
        // Task 01   [Smart Product Search]


        // 1- All Electronics products

        Console.WriteLine("--- Electronics ---");

        List<Product> electronics =
            SearchProducts(
                catalog,
                product => product.Category == "Electronics"
            );


        foreach (Product product in electronics)
        {
            Console.WriteLine(
                $"{product.Name} - ${product.Price} (Stock: {product.Stock})"
            );
        }


        // 2- Products under  $50

        Console.WriteLine("\n--- Under $50 ---");

        List<Product> under50 =
            SearchProducts(
                catalog,
                product => product.Price < 50
            );


        foreach (Product product in under50)
        {
            Console.WriteLine(
                $"{product.Name} - ${product.Price} (Stock: {product.Stock})"
            );
        }


        // 3- Products that are in stock

        Console.WriteLine("\n--- In Stock ---");

        List<Product> inStock =
            SearchProducts(
                catalog,
                product => product.Stock > 0
            );


        foreach (Product product in inStock)
        {
            Console.WriteLine(
                $"{product.Name} - ${product.Price} (Stock: {product.Stock})"
            );
        }


        // 4- Clothing products under $100

        Console.WriteLine("\n--- Clothing Under $100 ---");

        List<Product> clothingUnder100 =
            SearchProducts(
                catalog,
                product =>
                    product.Category == "Clothing"
                    && product.Price < 100
            );


        foreach (Product product in clothingUnder100)
        {
            Console.WriteLine(
                $"{product.Name} - ${product.Price} (Stock: {product.Stock})"
            );
        }



        // Task 03 [1] Print Reports


        Console.WriteLine("\n--- Short Report ---");


        // Short Report

        PrintReport(
            catalog,
            product =>
            {
                Console.WriteLine(
                    $"{product.Name} - ${product.Price}"
                );
            }
        );


        Console.WriteLine("\n--- Detailed Report ---");


        // Detailed Report

        PrintReport(
            catalog,
            product =>
            {
                Console.WriteLine(
                    $"[{product.Category}] {product.Name} | " +
                    $"Price: ${product.Price} | " +
                    $"Stock: {product.Stock}"
                );
            }
        );



        // Task 03 [2]Transform Products

        Console.WriteLine("\n--- Summary List ---");


        // Summary List

        List<string> summaryList =
            TransformProducts(
                catalog,
                product =>
                    $"{product.Name} (${product.Price})"
            );


        foreach (string item in summaryList)
        {
            Console.WriteLine(item);
        }


        Console.WriteLine("\n--- Price Labels ---");


        // Price Label

        List<string> priceLabels =
            TransformProducts(
                catalog,
                product =>
                    $"{product.Name}: " +
                    $"{(product.Price > 100 ? "Expensive!" : "Affordable")}"
            );


        foreach (string item in priceLabels)
        {
            Console.WriteLine(item);
        }



        // Task 03 [3] Filter Products


        Console.WriteLine("\n--- Low-Stock Alert ---");


        //  Alert for low Stock

        List<Product> lowStock =
            FilterProducts(
                catalog,
                product => product.Stock < 20
            );


        foreach (Product product in lowStock)
        {
            Console.WriteLine(
                $"[LOW STOCK] {product.Name}: only {product.Stock} left!"
            );
        }
    }
}
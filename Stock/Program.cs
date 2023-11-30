using Stock;
using System.Diagnostics.CodeAnalysis;

var filePath = "Phones.csv";
var lines = File.ReadAllLines(filePath);

var allProducts = new List<Product>();
foreach (var line in lines.Skip(1))
{
    var row = line.Replace(", ", ",");
    var data = line.Split(',');

    var newProduct = new Product();
    newProduct.Id = int.Parse(data[0]);
    newProduct.Name = data[1];
    newProduct.Quantity = int.Parse(data[2]);
    newProduct.Price = decimal.Parse(data[3].Replace(".", ","));
    allProducts.Add(newProduct);
}

// Console-ban kérjük be, hogy melyik termék árát akarjuk módosítani
int productId;
Product product;
do
{
    Console.WriteLine("Melyik telefon árát szeretnénk módosítani? (Id)");
    if (int.TryParse(Console.ReadLine(), out productId))
    {
        product = allProducts. (product => product.Id == productId);
        if (product is not null )
        {
            break;
        }

        Console.WriteLine("Telefon nem található");
        continue;
    }

    Console.WriteLine("Hibás formátumú Id-t adott meg");
} while (true);

Console.WriteLine("Kiválasztott telefon:");
Console.WriteLine($"{product.Id} {product.Name} {product.Quantity} {product.Price}");
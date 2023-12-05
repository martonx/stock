using Stock;

var filePath = "Phones.csv";
var allProducts = ParseDataFromCsv(filePath);
var product = SearchProduct();
SetNewPrice();
WriteIntoFile(filePath);

List<Product> ParseDataFromCsv(string filePath)
{
    var lines = File.ReadAllLines(filePath);
    var products = new List<Product>();
    foreach (var line in lines.Skip(1))
    {
        var row = line.Replace(", ", ",");
        var data = line.Split(',');

        var newProduct = new Product();
        newProduct.Id = int.Parse(data[0]);
        newProduct.Name = data[1];
        newProduct.Quantity = int.Parse(data[2]);
        newProduct.Price = decimal.Parse(data[3].Replace(".", ","));
        products.Add(newProduct);
    }

    return products;
}

Product SearchProduct()
{
    do
    {
        Console.WriteLine("Melyik telefon árát szeretnénk módosítani? (Id)");
        if (int.TryParse(Console.ReadLine(), out int productId))
        {
            product = allProducts.FirstOrDefault(product => product.Id == productId);
            if (product is not null)
            {
                Console.WriteLine("Kiválasztott telefon:");
                Console.WriteLine($"{product.Id} {product.Name} {product.Quantity} {product.Price}");
                return product;
            }

            Console.WriteLine("Telefon nem található");
            continue;
        }

        Console.WriteLine("Hibás formátumú Id-t adott meg");
    } while (true);
}

void SetNewPrice()
{
    do
    {
        Console.WriteLine("Mi legyen az új ár? (100-1000)");
        if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
        {
            if (99 < newPrice && newPrice < 1001)
            {
                product.Price = newPrice;
                break;
            }

            Console.WriteLine("Nem megfelelő új ár");
            continue;
        }

        Console.WriteLine("Hibás formátumú új ár");
    } while (true);
}

void WriteIntoFile(string filePath)
{
    var newRows = new List<string> { "Id,Name,Quantity,Price" };
    foreach (var item in allProducts)
    {
        var newRow = $"{item.Id},{item.Name},{item.Quantity},{item.Price}";
        newRows.Add(newRow);
    }

    File.WriteAllLines(filePath, newRows);
}
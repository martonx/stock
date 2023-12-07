using Stock;

var filePath = "Phones.csv";
var fileService = new FileService(filePath);

var allProducts = fileService.ParseDataFromCsv();
var product = SearchProduct();
SetNewPrice();
fileService.WriteIntoFile(allProducts);

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
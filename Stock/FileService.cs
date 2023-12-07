namespace Stock;

public class FileService
{
    private string filePath;

    public FileService(string filePath)
    {
        this.filePath = filePath;
    }

    public List<Product> ParseDataFromCsv()
    {
        var lines = File.ReadAllLines(filePath);
        var products = new List<Product>();
        foreach (var line in lines.Skip(1))
        {
            var row = line.Replace(", ", ",");
            var data = row.Split(',');

            var newProduct = new Product();
            newProduct.Id = int.Parse(data[0]);
            newProduct.Name = data[1];
            newProduct.Quantity = int.Parse(data[2]);
            newProduct.Price = decimal.Parse(data[3].Replace(".", ","));
            products.Add(newProduct);
        }

        return products;
    }

    public void WriteIntoFile(List<Product> allProducts)
    {
        var newRows = new List<string> { "Id,Name,Quantity,Price" };
        foreach (var item in allProducts)
        {
            var newRow = $"{item.Id},{item.Name},{item.Quantity},{item.Price}";
            newRows.Add(newRow);
        }

        File.WriteAllLines(filePath, newRows);
    }
}

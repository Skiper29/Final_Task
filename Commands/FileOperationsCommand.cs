using OnlineStore.Models;
using OnlineStore.Models.Dairy.Implementation;
using OnlineStore.Models.Meats.Implementation;
using Spectre.Console;

namespace OnlineStore.Commands;

public class FileOperationsCommand : ICommand
{
    private readonly List<IProduct> _products;

    public FileOperationsCommand(List<IProduct> products)
    {
        _products = products;
    }

    public void Execute()
    {
        AnsiConsole.MarkupLine("[bold green]File Operations[/]");

        var action = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose file operation")
                .AddChoices("Save products to file", "Load products from file")
        );

        switch (action)
        {
            case "Save products to file":
                SaveProductsToFile();
                break;

            case "Load products from file":
                LoadProductsFromFile();
                break;
        }
    }

    private void SaveProductsToFile()
    {
        var filePath = AnsiConsole.Prompt(new TextPrompt<string>("Enter file name to save:"));
        using var writer = new StreamWriter(filePath);
        _products.ForEach(product =>
            writer.WriteLine(
                $"{product.GetType().Name}, {product.Id}, {product.Description}, {product.Stock}, {product.Price}"));
        AnsiConsole.MarkupLine("[bold green]Products saved successfully![/]");
    }

    private void LoadProductsFromFile()
    {
        var filePath = AnsiConsole.Prompt(new TextPrompt<string>("Enter file name to load from:"));
        if (!File.Exists(filePath))
        {
            AnsiConsole.MarkupLine("[bold red]File not found![/]");
            Logger.LogInfo("File not found");
            return;
        }

        foreach (var line in File.ReadLines(filePath))
        {
            try
            {
                var newProduct = ParseProduct(line);
                if (_products.Exists(p => p.Id == newProduct.Id))
                    throw new Exception("Product with this id already exists");
                _products.Add(newProduct);
            }
            catch (Exception e)
            {
                AnsiConsole.MarkupLine($"[bold red]Error parsing product: {e.Message}[/]");
                Logger.LogError("Error parsing product", e);
            }
        }

        AnsiConsole.MarkupLine("[bold green]Products loaded![/]");
    }

    private IProduct ParseProduct(string line)
    {
        var productData = line.Split(", ");
        var productType = productData[0];
        var id = int.Parse(productData[1]);
        var description = productData[2];
        var stock = int.Parse(productData[3]);
        var price = decimal.Parse(productData[4]);

        return productType switch
        {
            "Milk" => new Milk(id, stock, price, description),
            "Kefir" => new Kefir(id, stock, price, description),
            "Sausage" => new Sausage(id, stock, price, description),
            "Meat" => new Meat(id, stock, price, description),
            _ => throw new Exception("Invalid product type")
        };
    }
}
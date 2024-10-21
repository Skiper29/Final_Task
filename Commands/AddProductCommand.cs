using OnlineStore.Models;
using OnlineStore.Models.Dairy.Implementation;
using OnlineStore.Models.Meats.Implementation;
using Spectre.Console;

namespace OnlineStore.Commands;

public class AddProductCommand : ICommand
{
    private readonly List<IProduct?> _products;
    private static int _nextId = 1;

    public static int NextId
    {
        set => _nextId = value;
    }

    public AddProductCommand(List<IProduct> products)
    {
        _products = products!;
    }


    public void Execute()
    {
        AnsiConsole.MarkupLine("[bold green]Add a new product[/]");
        var productType = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("What type of product do you want to add?")
                .AddChoices("Milk", "Kefir", "Sausage", "Meat"));

        var id = GenerateUniqueId();
        var description = AnsiConsole.Prompt(new TextPrompt<string>("Enter product description:"));

        var price = AnsiConsole.Prompt(new TextPrompt<decimal>("Enter product price:")
            .Validate(n =>
                n > 0
                    ? ValidationResult.Success()
                    : ValidationResult.Error("[yellow]Price must be greater than 0[/]")));

        var stock = AnsiConsole.Prompt(new TextPrompt<int>("Enter product stock quantity:")
            .Validate(n =>
                n >= 0
                    ? ValidationResult.Success()
                    : ValidationResult.Error("[yellow]Stock quantity must be greater than or equal to 0[/]")));

        IProduct newProduct = productType switch
        {
            "Milk" => new Milk(id, stock, price, description),
            "Kefir" => new Kefir(id, stock, price, description),
            "Sausage" => new Sausage(id, stock, price, description),
            "Meat" => new Meat(id, stock, price, description),
            _ => throw new Exception("Invalid product type")
        };

        _products.Add(newProduct);
        AnsiConsole.MarkupLine("[bold blue]Product added successfully![/]");
    }


    private int GenerateUniqueId()
    {
        if (_products.Exists(p => p?.Id == _nextId))
        {
            while (_products.Exists(p => p?.Id == _nextId))
            {
                _nextId++;
            }

            return _nextId;
        }

        return _nextId++;
    }
}
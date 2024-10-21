using OnlineStore.Models;
using Spectre.Console;

namespace OnlineStore.Commands;

public class DisplayAllProductsCommand : ICommand
{
    private readonly List<IProduct> _products;

    public DisplayAllProductsCommand(List<IProduct> products)
    {
        _products = products;
    }

    public void Execute()
    {
        if (_products.Count == 0)
        {
            AnsiConsole.MarkupLine("[bold red]No products available.[/]");
            Logger.LogInfo("No products available.");
            return;
        }

        var table = new Table();

        table.AddColumn("[yellow]Id[/]");
        table.AddColumn("[yellow]Description[/]");
        table.AddColumn("[yellow]Price[/]");
        table.AddColumn("[yellow]Stock[/]");
        table.AddColumn("[yellow]Product Type[/]");
        table.Border(TableBorder.Rounded);

        foreach (var product in _products)
        {
            table.AddRow(
                product.Id.ToString(),
                product.Description,
                product.Price.ToString("C"),
                product.Stock.ToString(),
                product.GetType().Name
            );
        }

        AnsiConsole.Write(table);
    }
}
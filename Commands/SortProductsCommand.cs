using OnlineStore.Models;
using Spectre.Console;

namespace OnlineStore.Commands;

public class SortProductsCommand : ICommand
{
    private readonly List<IProduct> _products;
    private static readonly string Ascending = "Ascending";

    public SortProductsCommand(List<IProduct> products)
    {
        _products = products;
    }

    public void Execute()
    {
        if (_products.Count == 0)
        {
            AnsiConsole.MarkupLine("[bold red]No products available to sort![/]");
            Logger.LogInfo("No products available to sort!");
            return;
        }

        var sortOption = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select a parameter to sort by:")
                .AddChoices("Id", "Price", "Stock", "Description")
        );

        var sortOrder = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select sort order:")
                .AddChoices(Ascending, "Descending")
        );

        List<IProduct> sortedProducts = new();

        switch (sortOption)
        {
            case "Id":
                sortedProducts = sortOrder == Ascending
                    ? _products.OrderBy(p => p.Id).ToList()
                    : _products.OrderByDescending(p => p.Id).ToList();
                break;

            case "Price":
                sortedProducts = sortOrder == Ascending
                    ? _products.OrderBy(p => p.Price).ToList()
                    : _products.OrderByDescending(p => p.Price).ToList();
                break;

            case "Stock":
                sortedProducts = sortOrder == Ascending
                    ? _products.OrderBy(p => p.Stock).ToList()
                    : _products.OrderByDescending(p => p.Stock).ToList();
                break;

            case "Description":
                sortedProducts = sortOrder == Ascending
                    ? _products.OrderBy(p => p.Description).ToList()
                    : _products.OrderByDescending(p => p.Description).ToList();
                break;
        }
        var displayAllProductsCommand = new DisplayAllProductsCommand(sortedProducts);
        displayAllProductsCommand.Execute();
    }
}
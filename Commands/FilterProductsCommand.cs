using OnlineStore.Models;
using Spectre.Console;

namespace OnlineStore.Commands;

public class FilterProductsCommand : ICommand
{
    private readonly List<IProduct> _products;
    private readonly string AllProducts = "All products";

    public FilterProductsCommand(List<IProduct> products)
    {
        _products = products;
    }


    public void Execute()
    {
        AnsiConsole.MarkupLine("[bold green]Filter products[/]");

        var filterOption = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select a filter parameter")
                .AddChoices("Filter by price", "Filter by stock", "Filter by description")
        );

        var productType = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select product type")
                .AddChoices(AllProducts, "Dairy", "Meat")
        );

        switch (filterOption)
        {
            case "Filter by price":
                FilterByPrice(productType);
                break;

            case "Filter by stock":
                FilterByStock(productType);
                break;

            case "Filter by description":
                FilterByDescription(productType);
                break;
        }
    }

    private void FilterByDescription(string productType)
    {
        AnsiConsole.MarkupLine("[bold green] Filter by description[/]");

        var description = AnsiConsole.Prompt(new TextPrompt<string>("Enter product description:"));
        var filteredProducts = _products
            .Where(p => (productType == AllProducts || p.ToString()!.Contains(productType)) &&
                        p.Description.Contains(description, StringComparison.OrdinalIgnoreCase)).ToList();

        DisplayFilteredProducts(filteredProducts);
    }

    private void FilterByStock(string productType)
    {
        AnsiConsole.MarkupLine("[bold green] Filter by stock[/]");

        var stock = AnsiConsole.Prompt(new TextPrompt<int>("Enter minimum stock quantity:"));
        var filteredProducts = _products
            .Where(p => (productType == AllProducts || p.ToString()!.Contains(productType)) &&
                        p.Stock >= stock).ToList();

        DisplayFilteredProducts(filteredProducts);
    }

    private void FilterByPrice(string productType)
    {
        AnsiConsole.MarkupLine("[bold green] Filter by price[/]");

        var minPrice = AnsiConsole.Prompt(new TextPrompt<decimal>("Enter minimum price:"));
        var maxPrice = AnsiConsole.Prompt(new TextPrompt<decimal>("Enter maximum price:"));
        var filteredProducts = _products
            .Where(p => (productType == AllProducts || p.ToString()!.Contains(productType)) &&
                        p.Price >= minPrice && p.Price <= maxPrice).ToList();

        DisplayFilteredProducts(filteredProducts);
    }

    private static void DisplayFilteredProducts(List<IProduct> filteredProducts)
    {
        if (filteredProducts.Any())
        {
            var displayAllProductsCommand = new DisplayAllProductsCommand(filteredProducts);
            displayAllProductsCommand.Execute();
        }
        else
        {
            AnsiConsole.MarkupLine("[bold red]No products found matching the filter criteria![/]");
            Logger.LogInfo("No products found matching the filter criteria!");
        }
    }
}
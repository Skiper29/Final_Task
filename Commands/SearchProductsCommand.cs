using OnlineStore.Models;
using Spectre.Console;

namespace OnlineStore.Commands;

public class SearchProductsCommand : ICommand
{
    private readonly List<IProduct> _products;

    public SearchProductsCommand(List<IProduct> products)
    {
        _products = products;
    }


    public void Execute()
    {
        if (!_products.Any())
        {
            AnsiConsole.Markup("[red]No products available to search.[/]");
            return;
        }

        var searchParameter = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select a [green]search parameter[/] to filter by:")
                .AddChoices("ID", "Stock", "Price", "Description", "Type")
        );

        List<IProduct> filteredProducts = [];

        switch (searchParameter)
        {
            case "ID":
                int searchId = AnsiConsole.Prompt(
                    new TextPrompt<int>("Enter product ID to search:"));
                filteredProducts = _products.Where(p => p.Id == searchId).ToList();
                break;

            case "Stock":
                int searchStock = AnsiConsole.Prompt(
                    new TextPrompt<int>("Enter product stock quantity to search:"));
                filteredProducts = _products.Where(p => p.Stock == searchStock).ToList();
                break;

            case "Price":
                decimal searchPrice = AnsiConsole.Prompt(
                    new TextPrompt<decimal>("Enter product price to search:"));
                filteredProducts = _products.Where(p => p.Price == searchPrice).ToList();
                break;

            case "Description":
                string searchDescription = AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter product description to search:"));
                filteredProducts = _products.Where(p =>
                    p.Description.Contains(searchDescription, StringComparison.OrdinalIgnoreCase)).ToList();
                break;

            case "Type":
                var productTypes = _products.Select(p => p.GetType().Name).Distinct().ToList();
                string searchType = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select product [green]type[/] to search:")
                        .AddChoices(productTypes)
                );
                filteredProducts = _products.Where(p => p.GetType().Name == searchType).ToList();
                break;
        }
        
        if (!filteredProducts.Any())
        {
            AnsiConsole.Markup("[red]No products found matching the search criteria.[/]");
        }
        else
        {
            ICommand displayFilteredProductsCommand = new DisplayAllProductsCommand(filteredProducts.ToList());
            displayFilteredProductsCommand.Execute();
        }
    }
}
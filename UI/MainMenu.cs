using OnlineStore.Commands;
using OnlineStore.Models;
using Spectre.Console;

namespace OnlineStore.UI;

public class MainMenu
{
    private readonly List<IProduct> _products;

    public MainMenu(List<IProduct> products)
    {
        _products = products;
    }

    public void DisplayMenu()
    {
        while (true)
        {
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Main Menu[/]")
                    .PageSize(10)
                    .AddChoices("Add Product", "Display All Products", "Search Products", "Filter Products",
                        "Sort Products", "File Operations", "Serialization Operations",
                        "Delete Product", "Exit")
            );

            switch (selection)
            {
                case "Add Product": 
                    new AddProductCommand(_products).Execute();
                    break;
                case "Display All Products":
                    new DisplayAllProductsCommand(_products).Execute();
                    break;
                case "Search Products":
                    new SearchProductsCommand(_products).Execute();
                    break;
                case "Filter Products":
                    new FilterProductsCommand(_products).Execute();
                    break;
                case "Sort Products":
                    new SortProductsCommand(_products).Execute();
                    break;
                case "File Operations":
                    new FileOperationsCommand(_products).Execute();
                    break;
                case "Serialization Operations":
                    new SerializationCommand(_products).Execute();
                    break;
                case "Delete Product":
                    new DeleteProductCommand(_products).Execute();
                    break;
                case "Exit":
                    AnsiConsole.MarkupLine("[bold green]Exiting program...[/]");
                    return;
            }
        }
    }
}
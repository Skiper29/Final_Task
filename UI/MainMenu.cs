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
                    .AddChoices("Add Product", "Display All Products", "Filter Products", "Sort Products",
                        "File Operations",
                        "Serialization Operations", "Delete Product", "Exit")
            );

            switch (selection)
            {
                case "Add Product":
                    var addProductCommand = new AddProductCommand(_products);
                    addProductCommand.Execute();
                    break;
                case "Display All Products":
                    var displayAllProductsCommand = new DisplayAllProductsCommand(_products);
                    displayAllProductsCommand.Execute();
                    break;
                case "Filter Products":
                    var filterProductsCommand = new FilterProductsCommand(_products);
                    filterProductsCommand.Execute();
                    break;
                case "Sort Products":
                    var sortProductsCommand = new SortProductsCommand(_products);
                    sortProductsCommand.Execute();
                    break;
                case "File Operations":
                    var fileOperationsCommand = new FileOperationsCommand(_products);
                    fileOperationsCommand.Execute();
                    break;
                case "Serialization Operations":
                    var serializationCommand = new SerializationCommand(_products);
                    serializationCommand.Execute();
                    break;
                case "Delete Product":
                    var deleteProductCommand = new DeleteProductCommand(_products);
                    deleteProductCommand.Execute();
                    break;
                case "Exit":
                    AnsiConsole.MarkupLine("[bold green]Exiting program...[/]");
                    return;
            }
        }
    }
}
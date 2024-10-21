using OnlineStore.Models;
using Spectre.Console;

namespace OnlineStore.Commands;

public class DeleteProductCommand : ICommand
{
    private readonly List<IProduct> _products;

    public DeleteProductCommand(List<IProduct> products)
    {
        _products = products;
    }


    public void Execute()
    {
        AnsiConsole.MarkupLine("[bold green]Delete product[/]");

        var action = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose delete operation")
                .AddChoices("Delete a specific product", "Delete all products")
        );

        switch (action)
        {
            case "Delete a specific product":
                DeleteSpecificProduct();
                break;

            case "Delete all products":
                DeleteAllProducts();
                break;
        }
    }

    private void DeleteSpecificProduct()
    {
        if (_products.Count == 0)
        {
            AnsiConsole.MarkupLine("[bold red]No products to delete![/]");
            Logger.LogInfo("No products to delete!");
            return;
        }

        var selectedProduct = AnsiConsole.Prompt(
            new SelectionPrompt<IProduct>()
                .Title("Select product to delete")
                .PageSize(10)
                .AddChoices(_products).UseConverter(product =>
                    $"ID: {product.Id}, Description: {product.Description}, Price: {product.Price}, Stock: {product.Stock}, Type: {product.GetType().Name}")
        );
        
        _products.Remove(selectedProduct);
        AnsiConsole.MarkupLine("[bold green]Product deleted successfully![/]");
    }

    private void DeleteAllProducts()
    {
        _products.Clear();
        AnsiConsole.MarkupLine("[bold green]All products deleted successfully![/]");
    }
}
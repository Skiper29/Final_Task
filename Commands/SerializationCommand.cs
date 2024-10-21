using System.Runtime.Serialization.Json;
using OnlineStore.Models;
using OnlineStore.Models.Dairy.Implementation;
using OnlineStore.Models.Meats.Implementation;
using Spectre.Console;

namespace OnlineStore.Commands;

public class SerializationCommand : ICommand
{
    private readonly List<IProduct> _products;

    public SerializationCommand(List<IProduct> products)
    {
        _products = products;
    }

    public void Execute()
    {
        AnsiConsole.MarkupLine("[bold green]Serialization Operations[/]");

        var action = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose serialization operation")
                .AddChoices("Serialize to JSON", "Deserialize from JSON")
        );

        switch (action)
        {
            case "Serialize to JSON":
                SerializeToJson();
                break;

            case "Deserialize from JSON":
                DeserializeFromJson();
                break;
        }
    }

    private void SerializeToJson()
    {
        var filePath = AnsiConsole.Prompt(new TextPrompt<string>("Enter JSON file name to serialize to:"));
        try
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<IProduct>),
                [typeof(Meat), typeof(Milk), typeof(Kefir), typeof(Sausage)]);
            using FileStream stream = new FileStream(filePath, FileMode.Create);
            serializer.WriteObject(stream, _products);
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex);
            Logger.LogError("Failed to serialize products to JSON", ex);
        }
        AnsiConsole.MarkupLine("[bold green]Products serialized to JSON successfully![/]");
    }

    private void DeserializeFromJson()
    {
        var filePath = AnsiConsole.Prompt(new TextPrompt<string>("Enter JSON file name to deserialize from:"));
        
        if (!File.Exists(filePath))
        {
            AnsiConsole.MarkupLine("[bold red]File not found![/]");
            return;
        }

        try
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<IProduct>),
                [typeof(Meat), typeof(Milk), typeof(Kefir), typeof(Sausage)]);
            using FileStream stream = new FileStream(filePath, FileMode.Open);
            var products = (List<IProduct>)serializer.ReadObject(stream)!;
            _products.AddRange(products);
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex);
            Logger.LogError("Failed to deserialize products from JSON", ex);
            throw;
        }
        
        AnsiConsole.MarkupLine("[bold green]Products deserialized from JSON successfully![/]");
    }
}
using System.Runtime.Serialization;
using OnlineStore.Models.Dairy.Implementation;

namespace OnlineStore.Models.Dairy;

[DataContract]
[KnownType(typeof(Milk)), KnownType(typeof(Kefir))]
public abstract class DairyProduct : IProduct
{
    [DataMember] public int Id { get; set; }
    [DataMember] public string Name { get; set; }
    [DataMember] public decimal Price { get; set; }
    [DataMember] public int Stock { get; set; }
    [DataMember] public string Description { get; set; }
    
    protected DairyProduct(int id, string name, int stock, decimal price, string description)
    {
        Id = id;
        Name = name;
        Stock = stock;
        Price = price;
        Description = description;
    }

    protected DairyProduct()
    {
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Price: {Price:C}, Stock: {Stock}, Description: {Description}, Category: Dairy";
    }
}
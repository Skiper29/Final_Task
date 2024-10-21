using System.Runtime.Serialization;
using OnlineStore.Models.Meats.Implementation;

namespace OnlineStore.Models.Meats;

[DataContract]
[KnownType(typeof(Meat)), KnownType(typeof(Sausage))]
public abstract class MeatProduct : IProduct
{
    [DataMember] public int Id { get; set; }
    [DataMember] public string Name { get; set; }
    [DataMember] public decimal Price { get; set; }
    [DataMember] public int Stock { get; set; }
    [DataMember] public string Description { get; set; }

    protected MeatProduct(int id, string name, int stock, decimal price, string description)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
        Description = description;
    }

    protected MeatProduct()
    {
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Price: {Price:C}, Stock: {Stock}, Description: {Description}, Category: Meat";
    }
}
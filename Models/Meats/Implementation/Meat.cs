using System.Runtime.Serialization;

namespace OnlineStore.Models.Meats.Implementation;

[DataContract]
public class Meat : MeatProduct
{
    public Meat(int id,  int stock,decimal price, string description) : base(id, "Meat", stock, price, description)
    {
    }

    public Meat()
    {
    }
}
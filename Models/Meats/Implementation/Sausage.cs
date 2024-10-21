using System.Runtime.Serialization;

namespace OnlineStore.Models.Meats.Implementation;

[DataContract]
public class Sausage : MeatProduct
{
    public Sausage(int id, int stock, decimal price, string description) : base(id, "Sausage", stock, price,
        description)
    {
    }

    public Sausage()
    {
    }
}
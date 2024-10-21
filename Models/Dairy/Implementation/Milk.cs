using System.Runtime.Serialization;

namespace OnlineStore.Models.Dairy.Implementation;

[DataContract]
public class Milk : DairyProduct
{
    public Milk(int id, int stock, decimal price, string description) : base(id, "Milk", stock, price,
        description)
    {
    }

    public Milk()
    {
    }
}
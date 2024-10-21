using System.Runtime.Serialization;

namespace OnlineStore.Models.Dairy.Implementation;

[DataContract]
public class Kefir: DairyProduct
{
    public Kefir(int id, int stock, decimal price, string description) : base(id, "Kefir", stock, price,
        description)
    {
    }

    public Kefir()
    {
        
    }
}
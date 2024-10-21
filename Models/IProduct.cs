namespace OnlineStore.Models;

public interface IProduct : IComparable<IProduct>
{
    public int Id { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public string Name { get; }
    public string Description { get; set; }

    int IComparable<IProduct>.CompareTo(IProduct? other)
    {
        if (other == null) return 1;
        return Id.CompareTo(other.Id);
    }
}
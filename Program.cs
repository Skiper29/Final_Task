using System.Text;
using OnlineStore.Models;
using OnlineStore.Models.Dairy.Implementation;
using OnlineStore.Models.Meats.Implementation;
using OnlineStore.UI;

namespace OnlineStore;

class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        List<IProduct> products =
        [
            new Milk(1, 30, 50, "Fresh milk from the farm"),
            new Kefir(2, 25, 30, "Organic kefir"),
            new Sausage(3, 120, 10, "Premium beef sausage"),
            new Meat(4, 150, 25, "Fresh pork meat"),
            new Milk(5, 32, 40, "Skimmed milk"),
            new Kefir(6, 26, 35, "Low-fat kefir"),
            new Sausage(7, 130, 8, "Smoked sausage"),
            new Meat(8, 160, 20, "Lean beef meat"),
            new Milk(9, 28, 45, "Whole milk"),
            new Kefir(10, 27, 30, "Probiotic kefir")
        ];

        MainMenu menu = new MainMenu(products);
        menu.DisplayMenu();
    }
}
using Sajam_knjiga.Core.DAO;
using Sajam_knjiga.Core.Utils;
using Sajam_knjiga.ConsoleClient;
namespace Sajam_knjiga;

class Program
{
    static void Main()
    {
        AdresaDAO adresaDao = new AdresaDAO();
        AutorKnjigaDAO autorKnjigaDao = new AutorKnjigaDAO();
        AutorDAO autorDao = new AutorDAO(adresaDao, autorKnjigaDao);
        KnjigaDAO knjigaDao = new KnjigaDAO(autorKnjigaDao);

        Povezivanje.PoveziAutore(autorDao, adresaDao, knjigaDao, autorKnjigaDao);

        AutorConsoleView autorView = new AutorConsoleView(autorDao, adresaDao);
        KnjigaConsoleView knjigaView = new KnjigaConsoleView(knjigaDao);

        while (true)
        {
            Console.WriteLine("\n=== SAJAM KNJIGA ===");
            Console.WriteLine("1: Autori");
            Console.WriteLine("2: Knjige");
            Console.WriteLine("0: Izlaz");

            string userInput = Console.ReadLine() ?? "0";
            if (userInput == "0") break;

            switch (userInput)
            {
                case "1":
                    autorView.RunMenu();
                    break;
                case "2":
                    knjigaView.RunMenu();
                    break;
            }
        }
    }
}
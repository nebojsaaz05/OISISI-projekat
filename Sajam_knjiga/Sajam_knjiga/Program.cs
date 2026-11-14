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
        PosetilacKnjigaDAO posetilacKnjigaLZ = new PosetilacKnjigaDAO("posetilacKnjigaLP.txt");
        PosetilacKnjigaDAO posetilacKnjigaSK = new PosetilacKnjigaDAO("posetilacKnjigaSK.txt");
        AutorDAO autorDao = new AutorDAO(adresaDao, autorKnjigaDao);
        KnjigaDAO knjigaDao = new KnjigaDAO(autorKnjigaDao);
        PosetilacDAO posetilacDao = new PosetilacDAO(adresaDao, posetilacKnjigaLZ, posetilacKnjigaSK);

        Povezivanje.PoveziAutore(autorDao, adresaDao, knjigaDao, autorKnjigaDao);

        AutorConsoleView autorView = new AutorConsoleView(autorDao, adresaDao);
        KnjigaConsoleView knjigaView = new KnjigaConsoleView(knjigaDao);
        PosetilacConsoleView posetilacView = new PosetilacConsoleView(posetilacDao, adresaDao);

        while (true)
        {
            Console.WriteLine("\n=== SAJAM KNJIGA ===");
            Console.WriteLine("1: Autori");
            Console.WriteLine("2: Knjige");
            Console.WriteLine("3. Posetioci");
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
                case "3":
                    posetilacView.RunMenu();
                    break;
            }
        }
    }
}
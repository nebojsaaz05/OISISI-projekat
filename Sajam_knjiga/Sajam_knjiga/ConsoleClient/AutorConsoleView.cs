using Sajam_knjiga.Core.DAO;
using Sajam_knjiga.Core.Model;
namespace Sajam_knjiga.ConsoleClient;
// Po uzoru na VehicleConsoleView iz CRUDExample (vjezbe)
public class AutorConsoleView
{
    private readonly AutorDAO _autorDao;
    private readonly AdresaDAO _adresaDao;

    public AutorConsoleView(AutorDAO autorDao, AdresaDAO adresaDao)
    {
        _autorDao = autorDao;
        _adresaDao = adresaDao;
    }

    public void RunMenu()
    {
        while (true)
        {
            ShowMenu();
            string userInput = Console.ReadLine() ?? "0";
            if (userInput == "0") break;
            HandleMenuInput(userInput);
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine("\nIzaberite mogucnost: ");
        Console.WriteLine("1: Prikaz autora");
        Console.WriteLine("2: Dodavanje autora");
        Console.WriteLine("3: Izmjena autora");
        Console.WriteLine("4: Brisanje autora");
        Console.WriteLine("0: Nazad");
    }

    private void HandleMenuInput(string input)
    {
        switch (input)
        {
            case "1":
                ShowAllAutori();
                break;
            case "2":
                break;
            case "3":
                break;
            case "4":
                break;
        }
    }

    private void ShowAllAutori()
    {
        PrintAutori(_autorDao.GetAllAutori());
    }

    private void PrintAutori(List<Autor> autori)
    {
        if (autori.Count == 0)
        {
            Console.WriteLine("Nema autora.");
            return;
        }

        Console.WriteLine("Autori: ");
        foreach (Autor a in autori)
        {
            Console.WriteLine(a);
        }

    }
}

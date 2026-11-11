using Sajam_knjiga.Core.DAO;
using Sajam_knjiga.Core.Model;
namespace Sajam_knjiga.ConsoleClient;
// Po uzoru na VehicleConsoleView iz CRUDExample (vjezbe)

public class KnjigaConsoleView
{
    private readonly KnjigaDAO _knjigaDao;

    public KnjigaConsoleView(KnjigaDAO knjigaDao)
    {
        _knjigaDao = knjigaDao;
    }

    private void ShowMenu()
    {
        Console.WriteLine("\nIzaberite mogucnost: ");
        Console.WriteLine("1: Prikaz knjiga");
        Console.WriteLine("2: Brisanje knjige");
        Console.WriteLine("0: Nazad");
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

    private void HandleMenuInput(string input)
    {
        switch (input)
        {
            case "1":
                ShowAllKnjige();
                break;
            case "2":
                RemoveKnjiga();
                break;
        }
    }

    private void ShowAllKnjige()
    {
        PrintKnjige(_knjigaDao.GetAllKnjige());
    }

    private void PrintKnjige(List<Knjiga> knjige)
    {
        if (knjige.Count == 0)
        {
            Console.WriteLine("Nema knjiga.");
            return;
        }

        Console.WriteLine("Knjige: ");
        foreach (Knjiga k in knjige)
        {
            Console.WriteLine(k);
        }

    }

    private int InputId()
    {
        Console.WriteLine("Unesite ID knjige: ");
        return ConsoleViewUtils.SafeInputInt();
    }

    private void RemoveKnjiga()
    {
        int id = InputId();
        Knjiga? removedKnjiga = _knjigaDao.RemoveKnjiga(id);
        if (removedKnjiga is null)
        {
            Console.WriteLine("Knjiga nije pronadjena :(");
            return;
        }

        Console.WriteLine("Knjiga obrisana.");
    }
}


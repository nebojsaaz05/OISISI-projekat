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
        Console.WriteLine("2: Dodavanje knjige");
        Console.WriteLine("3: Izmena knjige");
        Console.WriteLine("4: Brisanje knjige");
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
                AddKnjiga();
                break;
            case "3":
                UpdateKnjiga();
                break;
            case "4":
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

    private Knjiga InputKnjiga()
    {
        Console.WriteLine("Unesite ISBN knjige: ");
        string isbn = ConsoleViewUtils.SafeInputString();

        Console.WriteLine("Unesite naziv knjige: ");
        string naziv = ConsoleViewUtils.SafeInputString();

        Console.WriteLine("Unesite zanr knjige: ");
        string zanr = ConsoleViewUtils.SafeInputString();

        Console.WriteLine("Unesite godinu izdanja knjige: ");
        int godinaIzdanja = ConsoleViewUtils.SafeInputInt();

        Console.WriteLine("Unesite cenu knjige: ");
        decimal cena = ConsoleViewUtils.SafeInputDecimal();

        Console.WriteLine("Unesite broj strana knjige: ");
        int br_strana = ConsoleViewUtils.SafeInputInt();

        return new Knjiga(isbn, naziv, zanr, godinaIzdanja, cena, br_strana, -1);
    }

    private void AddKnjiga()
    {
        Knjiga knjiga = InputKnjiga();
        _knjigaDao.AddKnjiga(knjiga);
        Console.WriteLine("Knjiga dodata.");
    }

    private void UpdateKnjiga()
    {
        int id = InputId();
        Knjiga? postojeci = _knjigaDao.GetKnjigaById(id);
        if (postojeci is null)
        {
            Console.WriteLine("Knjiga nije pronadjena :(");
            return;
        }

        Knjiga knjiga = InputKnjiga();
        knjiga.Id = id;

        _knjigaDao.UpdateKnjiga(knjiga);
        Console.WriteLine("Knjiga izmijenjena.");
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


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
                AddAutor();
                break;
            case "3":
                UpdateAutor();
                break;
            case "4":
                RemoveAutor();
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

    private int InputId()
    {
        Console.WriteLine("Unesite ID autora: ");
        return ConsoleViewUtils.SafeInputInt();
    }

    private Adresa InputAdresa()
    {
        Console.WriteLine("Unesite naziv ulice: ");
        string ulica = ConsoleViewUtils.SafeInputString();

        Console.WriteLine("Unesite broj kuce: ");
        string broj = ConsoleViewUtils.SafeInputString();

        Console.WriteLine("Unesite naziv grada: ");
        string grad = ConsoleViewUtils.SafeInputString();

        Console.WriteLine("Unesite naziv drzave: ");
        string drzava = ConsoleViewUtils.SafeInputString();

        return new Adresa(ulica, broj, grad, drzava);
    }

    private Autor InputAutor()
    {
        Console.WriteLine("Unesite ime autora: ");
        string ime = ConsoleViewUtils.SafeInputString();

        Console.WriteLine("Unesite prezime autora: ");
        string prezime = ConsoleViewUtils.SafeInputString();

        Console.WriteLine("Unesite datum rodjenja autora (dd.MM.yyyy): ");
        DateOnly datumRodjenja = ConsoleViewUtils.SafeInputDate();

        Console.WriteLine("Unesite telefon autora: ");
        string telefon = ConsoleViewUtils.SafeInputString();

        Console.WriteLine("Unesite email autora: ");
        string email = ConsoleViewUtils.SafeInputString();

        Console.WriteLine("Unesite broj licne karte autora: ");
        string brojLK = ConsoleViewUtils.SafeInputString();

        Console.WriteLine("Unesite godine iskustva autora: ");
        int godIskustva = ConsoleViewUtils.SafeInputInt();

        return new Autor(ime, prezime, datumRodjenja, 0, telefon, email, brojLK, godIskustva);
    }

    private void AddAutor()
    {
        Autor autor = InputAutor();
        Adresa adresa = InputAdresa();
        _adresaDao.AddAdresa(adresa);      // sad adresa ima Id
        autor.AdresaId = adresa.Id;
        autor.Adresa = adresa;
        _autorDao.AddAutor(autor);
        Console.WriteLine("Autor dodat.");
    }

    private void UpdateAutor()
    {
        int id = InputId();
        Autor? postojeci = _autorDao.GetAutorById(id);
        if (postojeci is null)
        {
            Console.WriteLine("Autor nije pronadjen :(");
            return;
        }

        Autor autor = InputAutor();
        autor.Id = id;
        autor.AdresaId = postojeci.AdresaId; 

        Adresa adresa = InputAdresa();
        adresa.Id = postojeci.AdresaId;       
        _adresaDao.UpdateAdresa(adresa);

        _autorDao.UpdateAutor(autor);
        Console.WriteLine("Autor izmijenjen.");
    }

    private void RemoveAutor()
    {
        int id = InputId();
        Autor? removedAutor = _autorDao.RemoveAutor(id);
        if (removedAutor is null)
        {
            Console.WriteLine("Autor nije pronadjen :(");
            return;
        }

        Console.WriteLine("Autor obrisan.");
    }
}

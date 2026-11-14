using System;
using System.Collections.Generic;
using System.Text;

using Sajam_knjiga.Core.Model;
using Sajam_knjiga.Core.DAO;

namespace Sajam_knjiga.ConsoleClient;

public class PosetilacConsoleView
{
    private readonly PosetilacDAO _posetilacDao;
    private readonly AdresaDAO _adresaDao;

    public PosetilacConsoleView(PosetilacDAO posetilacDao,  AdresaDAO adresaDao)
    {
        _posetilacDao = posetilacDao;
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
        Console.WriteLine("1: Prikaz posetilaca");
        Console.WriteLine("2: Dodavanje posetioca");
        Console.WriteLine("3: Izmjena posetioca");
        Console.WriteLine("4: Brisanje posetioca");
        Console.WriteLine("0: Nazad");
    }

    private void HandleMenuInput(string input)
    {
        switch (input)
        {
            case "1":
                ShowAllPosetioci();
                break;
            case "2":
                AddPosetilac();
                break;
            case "3":
                UpdatePosetilac();
                break;
            case "4":
                RemovePosetilac();
                break;
        }
    }

    private void ShowAllPosetioci()
    {
        PrintPosetioci(_posetilacDao.GetAllPosetioci());
    }

    private void PrintPosetioci(List<Posetilac> posetioci)
    {
        if (posetioci.Count == 0)
        {
            Console.WriteLine("Nema posetilaca :( ");
            return;
        }

        Console.WriteLine("Posetioci: ");
        foreach (Posetilac p in posetioci)
        {
            Console.WriteLine(p);
        }

    }

    private int InputId()
    {
        Console.WriteLine("Unesite ID posetioca: ");
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

    private Posetilac InputPosetilac()
    {
        Console.WriteLine("Unesite ime posetioca: ");
        string ime = ConsoleViewUtils.SafeInputString();

        Console.WriteLine("Unesite prezime posetioca: ");
        string prezime = ConsoleViewUtils.SafeInputString();

        Console.WriteLine("Unesite datum rodjenja posetioca (dd.MM.yyyy): ");
        DateOnly datumRodjenja = ConsoleViewUtils.SafeInputDate();

        Console.WriteLine("Unesite telefon posetioca: ");
        string telefon = ConsoleViewUtils.SafeInputString();

        Console.WriteLine("Unesite email posetioca: ");
        string email = ConsoleViewUtils.SafeInputString();

        Console.WriteLine("Unesite broj clanske karte posetioca: ");
        string brojCK = ConsoleViewUtils.SafeInputString();

        Console.WriteLine("Unesite godine clanstva posetioca: ");
        int godClanstva = ConsoleViewUtils.SafeInputInt();

        Console.WriteLine("Uneiste status posetioca: \n1. Redovan\n2. VIP");
        StatusPosetioca statusP = (ConsoleViewUtils.SafeInputStatus() == 1) ? StatusPosetioca.P : StatusPosetioca.V;

        Console.WriteLine("Unesite prosecnu ocenu posetioca: ");
        double prosecnaOcena = ConsoleViewUtils.SafeInputDouble();

        return new Posetilac(ime, prezime, datumRodjenja, 0, telefon, email, brojCK, godClanstva, statusP, prosecnaOcena);
    }

    private void AddPosetilac()
    {
        Posetilac posetilac = InputPosetilac();
        Adresa adresa = InputAdresa();
        _adresaDao.AddAdresa(adresa);      // sad adresa ima Id
        posetilac.AdresaId = adresa.Id;
        posetilac.Adresa = adresa;
        _posetilacDao.AddPosetilac(posetilac);
        Console.WriteLine("Posetilac dodat dodat.");
    }

    private void UpdatePosetilac()
    {
        int id = InputId();
        Posetilac? postojeci = _posetilacDao.GetPosetilacById(id);
        if (postojeci is null)
        {
            Console.WriteLine("Posetilac nije pronadjen :(");
            return;
        }

        Posetilac posetilac = InputPosetilac();
        posetilac.Id = id;
        posetilac.AdresaId = postojeci.AdresaId;

        Adresa adresa = InputAdresa();
        adresa.Id = postojeci.AdresaId;
        _adresaDao.UpdateAdresa(adresa);

        _posetilacDao.UpdatePosetilac(posetilac);
        Console.WriteLine("Posetilac izmijenjen.");
    }

    private void RemovePosetilac()
    {
        int id = InputId();
        Posetilac? removedPosetilac = _posetilacDao.RemovePosetilac(id);
        if (removedPosetilac is null)
        {
            Console.WriteLine("Posetilac nije pronadjen :(");
            return;
        }

        Console.WriteLine("Posetilac obrisan.");
    }
}


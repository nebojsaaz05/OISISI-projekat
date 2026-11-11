using Sajam_knjiga.Core.Model;
using Sajam_knjiga.Core.Storage;

namespace Sajam_knjiga.Core.DAO;

/*
 * Po uzoru na VehiclesDAO iz CRUDExample (vjezbe)
 * Klasa za pristup podacima o adresama (Data Access Object).
 * Enkapsulira listu Adresa objekata i pruza metode za
 * dodavanje, izmjenu, brisanje i pregled adresa.
 * Koristi Storage za ucitavanje i cuvanje u fajl adrese.txt.
 */
public class AdresaDAO
{
    private readonly List<Adresa> _adrese;
    private readonly Storage<Adresa> _storage;

    public AdresaDAO()
    {
        _storage = new Storage<Adresa>("adrese.txt");
        _adrese = _storage.Load();
    }

    // vraca sljedeci slobodan ID (najveci postojeci + 1)
    private int GenerateId()
    {
        if (_adrese.Count == 0) return 0;
        return _adrese.Max(a => a.Id) + 1;
    }

    public Adresa AddAdresa(Adresa adresa)
    {
        adresa.Id = GenerateId();
        _adrese.Add(adresa);
        _storage.Save(_adrese);
        return adresa;
    }

    public Adresa? UpdateAdresa(Adresa adresa)
    {
        Adresa? staraAdresa = GetAdresaById(adresa.Id);
        if (staraAdresa is null) return null;

        staraAdresa.Ulica = adresa.Ulica;
        staraAdresa.Broj = adresa.Broj;
        staraAdresa.Grad = adresa.Grad;
        staraAdresa.Drzava = adresa.Drzava;

        _storage.Save(_adrese);
        return staraAdresa;
    }

    public Adresa? RemoveAdresa(int id)
    {
        Adresa? adresa = GetAdresaById(id);
        if (adresa is null) return null;

        _adrese.Remove(adresa);
        _storage.Save(_adrese);
        return adresa;
    }

    public Adresa? GetAdresaById(int id)
    {
        return _adrese.Find(a => a.Id == id);
    }

    public List<Adresa> GetAllAdrese()
    {
        return _adrese;
    }
}
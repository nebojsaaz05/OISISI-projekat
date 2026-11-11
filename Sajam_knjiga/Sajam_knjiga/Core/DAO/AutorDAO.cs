using Sajam_knjiga.Core.Model;
using Sajam_knjiga.Core.Storage;

namespace Sajam_knjiga.Core.DAO;

/*
 * Po uzoru na VehiclesDAO iz CRUDExample (vjezbe)
 * Klasa za pristup podacima o autorima (Data Access Object).
 * Pruza metode za dodavanje, izmjenu, brisanje i pregled autora.
 * Pri brisanju autora brise i njegovu adresu i veze sa knjigama.
 * Koristi Storage za ucitavanje i cuvanje u fajl autori.txt.
 */
public class AutorDAO
{
    private readonly List<Autor> _autori;
    private readonly Storage<Autor> _storage;
    private readonly AdresaDAO _adresaDao;
    private readonly AutorKnjigaDAO _autorKnjigaDao;

    public AutorDAO(AdresaDAO adresaDao, AutorKnjigaDAO autorKnjigaDao) // kad brisem autora moram obrisati i njegovu adresu i njegove veze sa knjigama
    {
        _adresaDao = adresaDao;
        _autorKnjigaDao = autorKnjigaDao;
        _storage = new Storage<Autor>("autori.txt");
        _autori = _storage.Load();
    }

    // vraca sljedeci slobodan ID (najveci postojeci + 1)
    private int GenerateId()
    {
        if (_autori.Count == 0) return 0;
        return _autori.Max(a => a.Id) + 1;
    }

    public Autor AddAutor(Autor autor)
    {
        autor.Id = GenerateId();
        _autori.Add(autor);
        _storage.Save(_autori);
        return autor;
    }

    public Autor? UpdateAutor(Autor autor)
    {
        Autor? stariAutor = GetAutorById(autor.Id);
        if (stariAutor is null) return null;

        stariAutor.Ime = autor.Ime;
        stariAutor.Prezime = autor.Prezime;
        stariAutor.DatumRodjenja = autor.DatumRodjenja;
        stariAutor.AdresaId = autor.AdresaId;
        stariAutor.Telefon = autor.Telefon;
        stariAutor.Email = autor.Email;
        stariAutor.BrojLicneKarte = autor.BrojLicneKarte;
        stariAutor.GodineIskustva = autor.GodineIskustva;

        _storage.Save(_autori);
        return stariAutor;
    }

    public Autor? RemoveAutor(int id)
    {
        Autor? autor = GetAutorById(id);
        if (autor is null) return null;

        _autorKnjigaDao.RemoveByAutor(id);  // brise veze autora sa knjigama
        _adresaDao.RemoveAdresa(autor.AdresaId); // brise adresu autora

        _autori.Remove(autor);
        _storage.Save(_autori);
        return autor;
    }

    public Autor? GetAutorById(int id)
    {
        return _autori.Find(a => a.Id == id);
    }

    public List<Autor> GetAllAutori()
    {
        return _autori;
    }
}
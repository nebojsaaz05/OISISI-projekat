using Sajam_knjiga.Core.Model;
using Sajam_knjiga.Core.Storage;

namespace Sajam_knjiga.Core.DAO;

/*
 * Po uzoru na VehiclesDAO iz CRUDExample (vjezbe)
 * Klasa za pristup podacima o knjigama (Data Access Object).
 * Pruza metode za dodavanje, izmjenu, brisanje i pregled knjiga.
 * Pri brisanju knjige brise i njene veze sa autorima.
 * Koristi Storage za ucitavanje i cuvanje u fajl knjige.txt.
 */
public class KnjigaDAO
{
    private readonly List<Knjiga> _knjige;
    private readonly Storage<Knjiga> _storage;
    private readonly AutorKnjigaDAO _autorKnjigaDao;

    public KnjigaDAO(AutorKnjigaDAO autorKnjigaDao) // kad brisem knjigu moram obrisati i njene veze sa autorima
    {
        _autorKnjigaDao = autorKnjigaDao;
        _storage = new Storage<Knjiga>("knjige.txt");
        _knjige = _storage.Load();
    }

    // vraca sljedeci slobodan ID (najveci postojeci + 1)
    private int GenerateId()
    {
        if (_knjige.Count == 0) return 0;
        return _knjige.Max(k => k.Id) + 1;
    }

    public Knjiga AddKnjiga(Knjiga knjiga)
    {
        knjiga.Id = GenerateId();
        _knjige.Add(knjiga);
        _storage.Save(_knjige);
        return knjiga;
    }

    public Knjiga? UpdateKnjiga(Knjiga knjiga)
    {
        Knjiga? staraKnjiga = GetKnjigaById(knjiga.Id);
        if (staraKnjiga is null) return null;

        staraKnjiga.Isbn = knjiga.Isbn;
        staraKnjiga.Naziv = knjiga.Naziv;
        staraKnjiga.Zanr = knjiga.Zanr;
        staraKnjiga.GodinaIzdanja = knjiga.GodinaIzdanja;
        staraKnjiga.Cena = knjiga.Cena;
        staraKnjiga.BrojStrana = knjiga.BrojStrana;
        staraKnjiga.IzdavacId = knjiga.IzdavacId;

        _storage.Save(_knjige);
        return staraKnjiga;
    }

    public Knjiga? RemoveKnjiga(int id)
    {
        Knjiga? knjiga = GetKnjigaById(id);
        if (knjiga is null) return null;

        _autorKnjigaDao.RemoveByKnjiga(id); // brise veze knjige sa autorima

        _knjige.Remove(knjiga);
        _storage.Save(_knjige);
        return knjiga;
    }

    public Knjiga? GetKnjigaById(int id)
    {
        return _knjige.Find(k => k.Id == id);
    }

    public List<Knjiga> GetAllKnjige()
    {
        return _knjige;
    }
}
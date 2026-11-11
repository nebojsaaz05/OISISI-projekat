using Sajam_knjiga.Core.Model;
using Sajam_knjiga.Core.Storage;

namespace Sajam_knjiga.Core.DAO;

/*
 * Po uzoru na VehiclesDAO iz CRUDExample (vjezbe)
 * Klasa za pristup vezama autor-knjiga (vise-na-vise).
 * Svaka veza je par (AutorId, KnjigaId) i cuva se u fajlu autorKnjiga.txt.
 * Veza nema svoj ID niti izmjenu - ili postoji ili ne postoji.
 */
public class AutorKnjigaDAO
{
    private readonly List<AutorKnjiga> _veze;
    private readonly Storage<AutorKnjiga> _storage;

    public AutorKnjigaDAO()
    {
        _storage = new Storage<AutorKnjiga>("autorKnjiga.txt");
        _veze = _storage.Load();
    }

    public void AddVeza(int autorId, int knjigaId)
    {
        // ista veza se ne upisuje dva puta
        bool postoji = _veze.Any(v => v.AutorId == autorId && v.KnjigaId == knjigaId);
        if (postoji) return;

        _veze.Add(new AutorKnjiga(autorId, knjigaId));
        _storage.Save(_veze);
    }

    public void RemoveVeza(int autorId, int knjigaId)
    {
        _veze.RemoveAll(v => v.AutorId == autorId && v.KnjigaId == knjigaId);
        _storage.Save(_veze);
    }

    // brise sve veze autora - koristi se pri brisanju autora
    public void RemoveByAutor(int autorId)
    {
        _veze.RemoveAll(v => v.AutorId == autorId);
        _storage.Save(_veze);
    }
    // brise sve veze knjige - koristi se pri brisanju knjige
    public void RemoveByKnjiga(int knjigaId)
    {
        _veze.RemoveAll(v => v.KnjigaId == knjigaId);
        _storage.Save(_veze);
    }

    public List<AutorKnjiga> GetAllVeze()
    {
        return _veze;
    }
}
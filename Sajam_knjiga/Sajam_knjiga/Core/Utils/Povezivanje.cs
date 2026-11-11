using Sajam_knjiga.Core.DAO;
using Sajam_knjiga.Core.Model;

namespace Sajam_knjiga.Core.Utils;

// Po uzoru na uvezivanje objekata u Program.cs iz SerializationExample (vjezbe)
public static class Povezivanje
{
    public static void PoveziAutore(AutorDAO autorDao, AdresaDAO adresaDao, KnjigaDAO knjigaDao, AutorKnjigaDAO autorKnjigaDao)
    {
        // 1. autor -> adresa
        foreach (Autor autor in autorDao.GetAllAutori())
        {
            autor.Adresa = adresaDao.GetAdresaById(autor.AdresaId);
        }

        // 2. autor <-> knjiga
        foreach (AutorKnjiga veza in autorKnjigaDao.GetAllVeze())
        {
            Autor? autor = autorDao.GetAutorById(veza.AutorId);
            Knjiga? knjiga = knjigaDao.GetKnjigaById(veza.KnjigaId);
            if (autor == null || knjiga == null) continue;
            autor.Knjige.Add(knjiga);
            knjiga.Autori.Add(autor);
        }
    }
}
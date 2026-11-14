using System;
using System.Collections.Generic;
using System.Text;
using Sajam_knjiga.Core.Model;
using Sajam_knjiga.Core.Storage;

namespace Sajam_knjiga.Core.DAO;

public class PosetilacKnjigaDAO 
{
    private readonly List<PosetilacKnjiga> _veze;
    private readonly Storage<PosetilacKnjiga> _storage;

    // Posetilac ima listu zelja koje su knjige i spisak kupovina koje su knjige
    public PosetilacKnjigaDAO(string filename)
    {
        _storage = new Storage<PosetilacKnjiga>(filename);
        _veze = _storage.Load();
    }

    public void AddVeza(int posetilacId, int knjigaId)
    {
        bool postoji = _veze.Any(v => v.PosetilacId == posetilacId && v.KnjigaId == knjigaId);
        if (postoji) return;

        _veze.Add(new PosetilacKnjiga(posetilacId, knjigaId));
        _storage.Save(_veze);
    }

    public void RemoveVeza(int posetilacId, int knjigaId) { 
        _veze.RemoveAll(v => v.PosetilacId == posetilacId && v.KnjigaId==knjigaId);
        _storage.Save(_veze);
    }

    public void RemoveByPosetilac(int posetilacId)
    {
        _veze.RemoveAll(v => v.PosetilacId==posetilacId);
        _storage.Save(_veze);
    }

    public void RemoveByKnjiga(int knjigaId)
    {
        _veze.RemoveAll(v => v.KnjigaId == knjigaId);
        _storage.Save(_veze);
    }

    public List<PosetilacKnjiga> GetAllVeze()
    {
        return _veze;
    }
}


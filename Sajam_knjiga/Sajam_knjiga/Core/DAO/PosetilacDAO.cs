using System;
using System.Collections.Generic;
using System.Text;
using Sajam_knjiga.Core.Model;
using Sajam_knjiga.Core.Storage;

namespace Sajam_knjiga.Core.DAO;

public class PosetilacDAO
{
    private readonly List<Posetilac> _posetioci;
    private readonly Storage<Posetilac> _storage;
    private readonly AdresaDAO _adresaDao;
    private readonly PosetilacKnjigaDAO _posetilacKnjigaDaoLz;
    private readonly PosetilacKnjigaDAO _posetilacKnjigaDaoSk;
    
    public PosetilacDAO(AdresaDAO adresaDao, PosetilacKnjigaDAO listaZeljaDao, PosetilacKnjigaDAO spisakKupovinaDao)
    {
        _adresaDao = adresaDao;
        _posetilacKnjigaDaoLz = listaZeljaDao;
        _posetilacKnjigaDaoSk = spisakKupovinaDao;
        _storage = new Storage<Posetilac>("posetioci.txt");
        _posetioci = _storage.Load();
    }

    private int GenerateId()
    {
        if (_posetioci.Count == 0) return 0;
        return _posetioci.Max(p => p.Id) + 1 ;
    }

    public Posetilac AddPosetilac(Posetilac posetilac)
    {
        posetilac.Id = GenerateId();
        _posetioci.Add(posetilac);
        _storage.Save(_posetioci);
        return posetilac;
    }

    public Posetilac? UpdatePosetilac(Posetilac posetilac)
    {
        Posetilac? stariPosetilac = GetPosetilacById(posetilac.Id);
        if (stariPosetilac is null) return null;

        stariPosetilac.Ime = posetilac.Ime;
        stariPosetilac.Prezime = posetilac.Prezime;
        stariPosetilac.DatumRodjenja = posetilac.DatumRodjenja;
        stariPosetilac.AdresaId = posetilac.AdresaId;
        stariPosetilac.KontaktTelefon = posetilac.KontaktTelefon;
        stariPosetilac.EMail = posetilac.EMail;
        stariPosetilac.BrClanske = posetilac.BrClanske;
        stariPosetilac.TrenutnaGodinaClanstva = posetilac.TrenutnaGodinaClanstva;
        stariPosetilac.Status = posetilac.Status;
        stariPosetilac.ProsecnaOcena = posetilac.ProsecnaOcena;

        _storage.Save(_posetioci);
        return stariPosetilac;
    }

    public Posetilac? RemovePosetilac(int id)
    {
        Posetilac? posetilac = GetPosetilacById(id);
        if (posetilac is null) return null;

        _posetilacKnjigaDaoLz.RemoveByPosetilac(posetilac.Id);
        _posetilacKnjigaDaoSk.RemoveByPosetilac(posetilac.Id);
        _adresaDao.RemoveAdresa(posetilac.AdresaId);

        _posetioci.Remove(posetilac);
        _storage.Save(_posetioci);
        return posetilac;
    }

    public Posetilac? GetPosetilacById(int id)
    {
        return _posetioci.Find(p => p.Id == id);
    }

    public List<Posetilac> GetAllPosetioci()
    {
        return _posetioci;
    }
}
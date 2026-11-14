using Sajam_knjiga.Core.Storage.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Sajam_knjiga.Core.Model;

public enum StatusPosetioca { R, V}

public class Posetilac: ISerializable
{
    public int Id {  get; set; }
    public string Ime {  get; set; } = string.Empty;
    public string Prezime { get; set; } = string.Empty;
    public DateOnly DatumRodjenja { get; set; }
    public int AdresaId { get; set; }
    public Adresa? Adresa { get; set; }
    public string KontaktTelefon { get; set; } = string.Empty;
    public string EMail { get; set; } = string.Empty;
    public string BrClanske { get; set; } = string.Empty;
    public int TrenutnaGodinaClanstva {  get; set; }
    public StatusPosetioca Status { get; set; }
    public double ProsecnaOcena { get; set; }
    public List<Knjiga> SpisakKupovina { get; set; } = new();
    public List<Knjiga> ListaZelja { get; set; } = new();

    public Posetilac()
    {
    }

    public Posetilac(string ime, string prezime, DateOnly datumRodjenja, int adresaId, string kontaktTelefon, string eMail, string brClanske, int trenutnaGodinaClanstva, StatusPosetioca status, double prosecnaOcena)
    {
        this.Ime = ime;
        this.Prezime = prezime;
        this.DatumRodjenja = datumRodjenja;
        this.AdresaId = adresaId;
        this.KontaktTelefon = kontaktTelefon;
        this.EMail = eMail;
        this.BrClanske = brClanske;
        this.TrenutnaGodinaClanstva = trenutnaGodinaClanstva;
        this.Status = status;
        this.ProsecnaOcena = prosecnaOcena;
    }

    public Posetilac(int id, string ime, string prezime, DateOnly datumRodjenja, int adresaId, string kontaktTelefon, string eMail, string brClanske, int trenutnaGodinaClanstva, StatusPosetioca status, double prosecnaOcena)
    {
        this.Id = id;
        this.Ime = ime;
        this.Prezime = prezime;
        this.DatumRodjenja = datumRodjenja;
        this.AdresaId = adresaId;
        this.KontaktTelefon = kontaktTelefon;
        this.EMail = eMail;
        this.BrClanske = brClanske;
        this.TrenutnaGodinaClanstva = trenutnaGodinaClanstva;
        this.Status = status;
        this.ProsecnaOcena = prosecnaOcena;
    }

    public override string ToString()
    {
        return $"ID: {Id,5} | Ime: {Ime,20} | Prezime: {Prezime,20} | Datum rodjenja: {DatumRodjenja:dd.MM.yyyy} | Adresa ID: {AdresaId,5} | Kontakt Telefon: {KontaktTelefon,11} | " +
               $"E-mail: {EMail,30} | Broj clanske: {BrClanske,20} | Trenutna godina clanstva: {TrenutnaGodinaClanstva,4} | Status: {Status,1} | Prosecna ocena: {ProsecnaOcena,4} |";
    }

    public string[] ToCSV()
    {
        string[] csvValues =
        {
            Id.ToString(),
            Ime,
            Prezime,
            DatumRodjenja.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
            AdresaId.ToString(),
            KontaktTelefon,
            EMail,
            BrClanske,
            TrenutnaGodinaClanstva.ToString(),
            Status.ToString(),
            ProsecnaOcena.ToString()
        };
        return csvValues;
    }

    public void FromCSV(string[] values)
    {
        Id = int.Parse(values[0]);
        Ime = values[1];
        Prezime = values[2];
        DatumRodjenja = DateOnly.ParseExact(values[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
        AdresaId = int.Parse(values[4]);
        KontaktTelefon = values[5];
        EMail = values[6];
        BrClanske = values[7];
        TrenutnaGodinaClanstva = int.Parse(values[8]);
        Status = (values[9] == "P") ? StatusPosetioca.R : StatusPosetioca.V;
        ProsecnaOcena = double.Parse(values[10]);
    }
}

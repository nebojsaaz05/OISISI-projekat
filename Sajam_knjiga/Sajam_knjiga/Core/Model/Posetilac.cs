using Sajam_knjiga.Core.Storage.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Sajam_knjiga.Core.Model;

public enum StatusPosetioca { P, V}

public class Posetilac: ISerializable
{
    public int id {  get; set; }
    public string ime {  get; set; } = string.Empty;
    public string prezime { get; set; } = string.Empty;
    public DateOnly datumRodjenja { get; set; }
    public int adresaId;
    public Adresa? adresa { get; set; }
    public string kontaktTelefon { get; set; } = string.Empty;
    public string eMail { get; set; } = string.Empty;
    public string brClanske { get; set; } = string.Empty;
    public int trenutnaGodinaClanstva {  get; set; }
    public StatusPosetioca status { get; set; }
    public double prosecnaOcena { get; set; }
    public List<Knjiga> spisakKupovina { get; set; } = new();
    public List<Knjiga> listaZelja { get; set; } = new();

    public Posetilac()
    {
    }

    public Posetilac(string ime, string prezime, DateOnly datumRodjenja, int adresaId, string kontaktTelefon, string eMail, string brClanske, int trenutnaGodinaClanstva, StatusPosetioca status, double prosecnaOcena)
    {
        this.ime = ime;
        this.prezime = prezime;
        this.datumRodjenja = datumRodjenja;
        this.adresaId = adresaId;
        this.kontaktTelefon = kontaktTelefon;
        this.eMail = eMail;
        this.brClanske = brClanske;
        this.trenutnaGodinaClanstva = trenutnaGodinaClanstva;
        this.status = status;
        this.prosecnaOcena = prosecnaOcena;
    }

    public Posetilac(int id, string ime, string prezime, DateOnly datumRodjenja, int adresaId, string kontaktTelefon, string eMail, string brClanske, int trenutnaGodinaClanstva, StatusPosetioca status, double prosecnaOcena)
    {
        this.id = id;
        this.ime = ime;
        this.prezime = prezime;
        this.datumRodjenja = datumRodjenja;
        this.adresaId = adresaId;
        this.kontaktTelefon = kontaktTelefon;
        this.eMail = eMail;
        this.brClanske = brClanske;
        this.trenutnaGodinaClanstva = trenutnaGodinaClanstva;
        this.status = status;
        this.prosecnaOcena = prosecnaOcena;
    }

    public override string ToString()
    {
        return $"ID: {id,5} | Ime: {ime,20} | Prezime: {prezime,20} | Datum rodjenja: {datumRodjenja:dd.MM.yyyy} | Adresa ID: {adresaId,5} | Kontakt Telefon: {kontaktTelefon,11} | " +
               $"E-mail: {eMail,30} | Broj clanske: {brClanske,20} | Trenutna godina clanstva: {trenutnaGodinaClanstva,4} | Status: {status,1} | Prosecna ocena: {prosecnaOcena,4} |";
    }

    public string[] ToCSV()
    {
        string[] csvValues =
        {
            id.ToString(),
            ime,
            prezime,
            datumRodjenja.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
            adresaId.ToString(),
            kontaktTelefon,
            eMail,
            brClanske,
            trenutnaGodinaClanstva.ToString(),
            status.ToString(),
            prosecnaOcena.ToString()
        };
        return csvValues;
    }

    public void FromCSV(string[] values)
    {
        id = int.Parse(values[0]);
        ime = values[1];
        prezime = values[2];
        datumRodjenja = DateOnly.ParseExact(values[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
        adresaId = int.Parse(values[4]);
        kontaktTelefon = values[5];
        eMail = values[6];
        brClanske = values[7];
        trenutnaGodinaClanstva = int.Parse(values[8]);
        status = (values[9] == "P") ? StatusPosetioca.P : StatusPosetioca.V;
        prosecnaOcena = double.Parse(values[10]);
    }
}

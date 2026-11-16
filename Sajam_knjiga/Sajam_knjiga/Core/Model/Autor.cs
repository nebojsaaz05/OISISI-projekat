using Sajam_knjiga.Core.Storage.Serialization;
using System.Globalization;
namespace Sajam_knjiga.Core.Model;

public class Autor : ISerializable
{
    public int Id { get; set; }
    public string Ime { get; set; } = string.Empty;
    public string Prezime { get; set; } = string.Empty;
    public DateOnly DatumRodjenja { get; set; }
    public int AdresaId { get; set; }
    public Adresa? Adresa { get; set; }
    public string Telefon { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string BrojLicneKarte { get; set; } = string.Empty;
    public int GodineIskustva { get; set; }
    public List<Knjiga> Knjige { get; set; } = new();

    public Autor()
    { 
    }
    public Autor(string ime, string prezime, DateOnly datumRodjenja, int adresaId, string telefon, string email, string brojLicneKarte, int godineIskustva)
    {
        Ime = ime;
        Prezime = prezime;
        DatumRodjenja = datumRodjenja;
        AdresaId = adresaId;
        Telefon = telefon;
        Email = email;
        BrojLicneKarte = brojLicneKarte;
        GodineIskustva = godineIskustva;
    }
    public Autor(int id, string ime, string prezime, DateOnly datumRodjenja, int adresaId, string telefon, string email, string brojLicneKarte, int godineIskustva)
    {
        Id = id;
        Ime = ime;
        Prezime = prezime;
        DatumRodjenja = datumRodjenja;
        AdresaId = adresaId;
        Telefon = telefon;
        Email = email; 
        BrojLicneKarte = brojLicneKarte;
        GodineIskustva = godineIskustva;
    }
    public override string ToString()
    {
        string ret_str = "";
        ret_str += "ID: " + Id.ToString() + "\n";
        ret_str += "Ime: " + Ime + "\n";
        ret_str += "Prezime: " + Prezime + "\n";
        ret_str += "Datum rodjenja: " + DatumRodjenja.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture) + "\n";
        ret_str += "Adresa ID: " + AdresaId + "\n";
        ret_str += "Telefon: " + Telefon + "\n";
        ret_str += "Email: " + Email + "\n";
        ret_str += "Broj licne karte: " + BrojLicneKarte + "\n";
        ret_str += "Godine iskustva: " + GodineIskustva.ToString();
        return ret_str;
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
            Telefon,
            Email,
            BrojLicneKarte,
            GodineIskustva.ToString()
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
        Telefon = values[5];
        Email = values[6];
        BrojLicneKarte = values[7];
        GodineIskustva = int.Parse(values[8]);
    }
}


using Sajam_knjiga.Core.Storage.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace Sajam_knjiga.Core.Model;

public class Knjiga : ISerializable
{
    public int Id { get; set; }
    public string Isbn { get; set; } = string.Empty;
    public string Naziv { get; set; } = string.Empty;
    public string Zanr { get; set; } = string.Empty;
    public int GodinaIzdanja { get; set; }
    public decimal Cena {  get; set; }
    public int BrojStrana { get; set; }
    public int IzdavacId { get; set; }

    public List<Autor> Autori { get; set; } = new();
    public List<Posetilac> Kupci { get; set; } = new();
    public List<Posetilac> ListaZelja { get; set; } = new();

    public Knjiga()
    {
    }
    public Knjiga(string isbn, string naziv, string zanr, int godinaIzdanja, decimal cena, int brojStrana, int izdavacId)
    {
        Isbn = isbn;
        Naziv = naziv;
        Zanr = zanr;
        GodinaIzdanja = godinaIzdanja;
        Cena = cena;
        BrojStrana = brojStrana;
        IzdavacId = izdavacId;
    }
    public Knjiga(int id, string isbn, string naziv, string zanr, int godinaIzdanja, decimal cena, int brojStrana, int izdavacId)
    {
        Id = id;
        Isbn = isbn;
        Naziv = naziv;
        Zanr = zanr;
        GodinaIzdanja = godinaIzdanja;
        Cena = cena;
        BrojStrana = brojStrana;
        IzdavacId = izdavacId;
    }

    public override string ToString()
    {
        return $"ID: {Id,5} | ISBN: {Isbn,17} | Naziv: {Naziv,30} | Zanr: {Zanr,15} | Godina izdanja: {GodinaIzdanja,4} | Cena: {Cena,10:F2} | Broj strana: {BrojStrana,5} | IzdavacId: {IzdavacId,5} |";
    }

    public string[] ToCSV()
    {
        string[] csvValues =
        {
            Id.ToString(),
            Isbn,
            Naziv,
            Zanr,
            GodinaIzdanja.ToString(),
            Cena.ToString(CultureInfo.InvariantCulture),
            BrojStrana.ToString(),
            IzdavacId.ToString()
        };
        return csvValues;
    }
    public void FromCSV(string[] values)
    {
        Id = int.Parse(values[0]);
        Isbn = values[1];
        Naziv = values[2];
        Zanr = values[3];
        GodinaIzdanja = int.Parse(values[4]);
        Cena = decimal.Parse(values[5], CultureInfo.InvariantCulture);
        BrojStrana = int.Parse(values[6]);
        IzdavacId = int.Parse(values[7]);
    }

}
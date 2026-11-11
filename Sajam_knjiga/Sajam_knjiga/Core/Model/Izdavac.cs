using System;
using System.Collections.Generic;
using Sajam_knjiga.Core.Storage.Serialization;
using System.Text;
using System.Buffers;

namespace Sajam_knjiga.Core.Model;

public class Izdavac: ISerializable
{
    public int Id { get; set; }
    public string Sifra {  get; set; } = string.Empty;
    public string Naziv { get; set; } = string.Empty;
    public int SefIzdavacaId { get; set; }
    public Autor? SefIzdavaca { get; set; }
    public List<Autor> SpisakAutora { get; set; } = new();
    public List<Knjiga> SpisakKnjiga { get; set; } = new();

    public Izdavac() 
    {
    }

    public Izdavac(string sifra, string naziv, int sefIzdavacaId)
    {
        this.Sifra = sifra;
        this.Naziv = naziv;
        this.SefIzdavacaId = sefIzdavacaId;
    }

    public Izdavac(int id, string sifra, string naziv, int sefIzdavacaId)
    {
        this.Id = id;
        this.Sifra = sifra;
        this.Naziv = naziv;
        this.SefIzdavacaId = sefIzdavacaId;
    }

    public override string ToString()
    {
        return $"ID: {Id,5} | Sifra: {Sifra,20} | Naziv: {Naziv,20} | SefIzdavacaId: {SefIzdavacaId,5} |";
    }

    public string[] ToCSV()
    {
        string[] csvValues =
        {
            Id.ToString(),
            Sifra,
            Naziv,
            SefIzdavacaId.ToString()
        };
        return csvValues;
    }

    public void FromCSV(string[] values)
    {
        Id = int.Parse(values[0]);
        Sifra = values[1];
        Naziv = values[2];
        SefIzdavacaId = int.Parse(values[3]);
    }
}

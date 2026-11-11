using System;
using System.Collections.Generic;
using Sajam_knjiga.Core.Storage.Serialization;
using System.Text;
using System.Buffers;

namespace Sajam_knjiga.Core.Model;

public class Izdavac: ISerializable
{
    public int id { get; set; }
    public string sifra {  get; set; } = string.Empty;
    public string naziv { get; set; } = string.Empty;
    public int sefIzdavacaId { get; set; }
    public Autor? sefIzdavaca { get; set; }
    public List<Autor> spisakAutora { get; set; } = new();
    public List<Knjiga> spisakKnjiga { get; set; } = new();

    public Izdavac() 
    {
    }

    public Izdavac(string sifra, string naziv, int sefIzdavacaId)
    {
        this.sifra = sifra;
        this.naziv = naziv;
        this.sefIzdavacaId = sefIzdavacaId;
    }

    public Izdavac(int id, string sifra, string naziv, int sefIzdavacaId)
    {
        this.id = id;
        this.sifra = sifra;
        this.naziv = naziv;
        this.sefIzdavacaId = sefIzdavacaId;
    }

    public override string ToString()
    {
        return $"ID: {id,5} | Sifra: {sifra,20} | Naziv: {naziv,20} | SefIzdavacaId: {sefIzdavacaId,5} |";
    }

    public string[] ToCSV()
    {
        string[] csvValues =
        {
            id.ToString(),
            sifra,
            naziv,
            sefIzdavacaId.ToString()
        };
        return csvValues;
    }

    public void FromCSV(string[] values)
    {
        id = int.Parse(values[0]);
        sifra = values[1];
        naziv = values[2];
        sefIzdavacaId = int.Parse(values[3]);
    }
}

using Sajam_knjiga.Core.Storage.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Sajam_knjiga.Core.Model;

public class Kupovina: ISerializable
{
    public int Id { get; set; }
    public Posetilac? KPosetilac { get; set; }
    public int PosetilacId  { get; set; }
    public Knjiga? KKnjiga { get; set; }
    public int KnjigaId { get; set; }
    public DateOnly DatumKupovine { get; set; }
    public int Ocena {  get; set; }
    public string Komentar { get; set; } = string.Empty;

    public Kupovina()
    {
    }

    public Kupovina(int posetilacId, int knjigaId, DateOnly datumKupovine,int ocena, string komentar)
    {
        this.PosetilacId = posetilacId;
        this.KnjigaId = knjigaId;
        this.DatumKupovine = datumKupovine;
        this.Ocena = ocena;
        this.Komentar = komentar;
    }

    public Kupovina(int id, int posetilacId, int knjigaId, DateOnly datumKupovine,int ocena, string komentar)
    {
        this.Id = id;
        this.PosetilacId = posetilacId;
        this.KnjigaId = knjigaId;
        this.DatumKupovine = datumKupovine;
        this.Ocena = ocena;
        this.Komentar = komentar;
    }

    public override string ToString()
    {
        string ret_str = "";
        ret_str += "ID: " + Id.ToString() + "\n";
        ret_str += "PosetilacID: " + PosetilacId.ToString() + "\n";
        ret_str += "KnjigaID: " + KnjigaId.ToString() + "\n";
        ret_str += "Datum kupovine: " + DatumKupovine.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture) + "\n";
        ret_str += "Ocena: " + Ocena.ToString() + "\n";
        ret_str += "Komentar: " + Komentar;
        return ret_str;
    }

    public string[] ToCSV()
    {
        string[] csvValues = {
            Id.ToString(),
            PosetilacId.ToString(),
            KnjigaId.ToString(),
            DatumKupovine.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
            Ocena.ToString(),
            Komentar
        };
        return csvValues;
    }

    public void FromCSV(string[] values)
    {
        Id = int.Parse(values[0]);
        PosetilacId = int.Parse(values[1]);
        KnjigaId = int.Parse(values[2]);
        DatumKupovine = DateOnly.ParseExact(values[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
        Ocena = int.Parse(values[4]);
        Komentar = values[5];
    }
}

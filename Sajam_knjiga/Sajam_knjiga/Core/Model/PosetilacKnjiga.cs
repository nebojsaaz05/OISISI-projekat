using System;
using System.Collections.Generic;
using System.Text;
using Sajam_knjiga.Core.Storage.Serialization;


namespace Sajam_knjiga.Core.Model;

public class PosetilacKnjiga : ISerializable
{
    public int PosetilacId { get; set; }
    public int KnjigaId { get; set; }

    public PosetilacKnjiga()
    {
    }

    public PosetilacKnjiga(int posetilacId, int knjigaId)
    {
        this.PosetilacId = posetilacId;
        this.KnjigaId = knjigaId;
    }

    public void FromCSV(string[] values)
    {
        PosetilacId = int.Parse(values[0]);
        KnjigaId = int.Parse(values[1]);
    }

    public string[] ToCSV()
    {
        string[] csvValues =
        {
            PosetilacId.ToString(),
            KnjigaId.ToString()
        };
        return csvValues;
    }
}
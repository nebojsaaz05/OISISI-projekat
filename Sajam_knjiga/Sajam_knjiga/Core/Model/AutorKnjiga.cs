// Po uzoru na StudentSubject iz SerializationExample (vjezbe)
using Sajam_knjiga.Core.Storage.Serialization;
namespace Sajam_knjiga.Core.Model;

public class AutorKnjiga : ISerializable
{
    public int AutorId { get; set; }
    public int KnjigaId { get; set; }  

    public AutorKnjiga()
    {
    }
    public AutorKnjiga(int autorId, int knjigaId)
    {
        AutorId = autorId;
        KnjigaId = knjigaId;
    }
    public void FromCSV(string[] values)
    {
        AutorId = int.Parse(values[0]);
        KnjigaId = int.Parse(values[1]);
    }
    public string[] ToCSV()
    {
        string[] csvValues =
        {
            AutorId.ToString(),
            KnjigaId.ToString()
        };
        return csvValues;
    }
}
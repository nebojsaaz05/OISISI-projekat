namespace Sajam_knjiga.Core.Storage.Serialization;
// Preuzeto sa vjezbi (CRUDExample, Storage.cs), izmijenjena putanja
public interface ISerializable
{
    string[] ToCSV();

    void FromCSV(string[] values);
}
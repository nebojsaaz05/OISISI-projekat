namespace Sajam_knjiga.Core.Storage.Serialization;

public interface ISerializable
{
    string[] ToCSV();

    void FromCSV(string[] values);
}
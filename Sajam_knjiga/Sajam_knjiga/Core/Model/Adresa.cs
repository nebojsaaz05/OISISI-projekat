using Sajam_knjiga.Core.Storage.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sajam_knjiga.Core.Model;

public class Adresa : ISerializable
{
    public int Id {  get; set; }
    public string Ulica {  get; set; } = string.Empty;
    public string Broj { get; set; } = string.Empty;
    public string Grad {  get; set; } = string.Empty;
    public string Drzava { get; set; } = string.Empty;

    public Adresa()
    {
    }

    public Adresa (string ulica, string broj, string grad, string drzava)
    {
        Ulica = ulica;
        Broj = broj;
        Grad = grad;
        Drzava = drzava;
    }

    public Adresa(int id, string ulica, string broj, string grad, string drzava)
    {
        Id = id;
        Ulica = ulica;
        Broj = broj;
        Grad = grad;
        Drzava = drzava;
    }

    public override string ToString()
    {
        string ret_str = "";
        ret_str += "ID: " + Id.ToString() + "\n";
        ret_str += "Ulica: " + Ulica + "\n";
        ret_str += "Broj: " + Broj + "\n";
        ret_str += "Grad: " + Grad + "\n";
        ret_str += "Drzava: " + Id.ToString();
        return ret_str;
    }

    public string[] ToCSV()
    {
        string[] csvValues =
        {
            Id.ToString(),
            Ulica,
            Broj,
            Grad,
            Drzava
        };
        return csvValues;
    }

    public void FromCSV(string[] values)
    {
        Id = int.Parse(values[0]);
        Ulica = values[1];
        Broj = values[2];
        Grad = values[3];
        Drzava = values[4];
    }

}
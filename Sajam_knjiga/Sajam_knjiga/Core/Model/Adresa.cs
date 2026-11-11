using Sajam_knjiga.Core.Storage.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sajam_knjiga.Core.Model;

public class Adresa : ISerializable
{
    public int Id {  get; set; }
    public string Ulica {  get; set; }
    public string Broj { get; set; }
    public string Grad {  get; set; }
    public string Drzava { get; set; }

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
        return $"ID: {Id,5} | Ulica: {Ulica,20} | Broj: {Broj,5} | Grad: {Grad, 20} | Drzava: {Drzava, 20} |";
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
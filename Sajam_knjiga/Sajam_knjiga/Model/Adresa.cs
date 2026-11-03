using CRUDExample.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sajam_knjiga.Model;

public class Adresa : ISerializable
{
    private int id {  get; set; }
    private string ulica {  get; set; }
    private string broj { get; set; }
    private string grad {  get; set; }
    private string drzava { get; set; }

    public Adresa()
    {
    }

    public Adresa (string ulica, string broj, string grad, string drzava)
    {
        this.ulica = ulica;
        this.broj = broj;
        this.grad = grad;
        this.drzava = drzava;
    }

    public Adresa(int id, string ulica, string broj, string grad, string drzava)
    {
        this.id = id;
        this.ulica = ulica;
        this.broj = broj;
        this.grad = grad;
        this.drzava = drzava;
    }

    public override string ToString()
    {
        return $"ID: {id,5} | Ulica: {ulica,20} | Broj: {broj,5} | Grad: {grad, 20} | Drzava: {drzava, 20} |";
    }

    public string[] ToCSV()
    {
        string[] csvValues =
        {
            id.ToString(),
            ulica,
            broj,
            grad,
            drzava
        };
        return csvValues;
    }

    public void FromCSV(string[] values)
    {
        id = int.Parse(values[0]);
        ulica = values[1];
        broj = values[2];
        grad = values[3];
        drzava = values[4];
    }

}
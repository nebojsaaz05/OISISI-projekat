using System;
using System.Collections.Generic;
using System.Text;
using CRUDExample.Serialization;

namespace Sajam_knjiga.Model;

public enum StatusPosetioca { P, V}

public class Posetilac: ISerializable
{
    private int id {  get; set; }
    private string ime {  get; set; }
    private string prezime { get; set; }
    private string datum_rodjenja { get; set; }
    private Adresa adresa { get; set; }
    private string kontakt_telefon { get; set; }
    private string e_mail { get; set; }
    private string br_clanske { get; set; }
    private int trenutna_godina_clanstva {  get; set; }
    private StatusPosetioca status { get; set; }
    private double prosecna_ocena { get; set; }
    // spisak kupovina (Student 2 neka uradi neophodno, treba knjiga za celokupnu kupovinu)
    // lista zelja (Student 2 neka uradi neophodno, knjiga fali :( )

    public Posetilac()
    {
    }

    public Posetilac(string ime, string prezime, string datum_rodjenja, Adresa adresa, string kontakt_telefon, string e_mail, string br_clanske, int trenutna_godina_clanstva, StatusPosetioca status, double prosecna_ocena)
    {
        this.ime = ime;
        this.prezime = prezime;
        this.datum_rodjenja = datum_rodjenja;
        this.adresa = adresa;
        this.kontakt_telefon = kontakt_telefon;
        this.e_mail = e_mail;
        this.br_clanske = br_clanske;
        this.trenutna_godina_clanstva = trenutna_godina_clanstva;
        this.status = status;
        this.prosecna_ocena = prosecna_ocena;
    }

    public Posetilac(int id, string ime, string prezime, string datum_rodjenja, Adresa adresa, string kontakt_telefon, string e_mail, string br_clanske, int trenutna_godina_clanstva, StatusPosetioca status, double prosecna_ocena)
    {
        this.id = id;
        this.ime = ime;
        this.prezime = prezime;
        this.datum_rodjenja = datum_rodjenja;
        this.adresa = adresa;
        this.kontakt_telefon = kontakt_telefon;
        this.e_mail = e_mail;
        this.br_clanske = br_clanske;
        this.trenutna_godina_clanstva = trenutna_godina_clanstva;
        this.status = status;
        this.prosecna_ocena = prosecna_ocena;
    }

    public override string ToString()
    {
        return $"ID: {id,5} | Ime: {ime,20} | Prezime: {prezime,20} | Datum Rodjenja: {datum_rodjenja,20} | " + adresa.ToString() +
               $" Kontakt Telefon: {kontakt_telefon,20} | E-mail: {e_mail,30} | Broj clanske karte: {br_clanske,10} | Trenutna godina clanstva: {id,2} |" +
               $" Status: {status,1} | Prosecna ocena: {prosecna_ocena,5}"; 
    }

    public string[] ToCSV()
    {
        // Treba dodati adresu i status posto je enum
        string[] csvValues =
        {
            id.ToString(),
            ime,
            prezime,
            datum_rodjenja,
            kontakt_telefon,
            e_mail,
            br_clanske,
            trenutna_godina_clanstva.ToString(),
            prosecna_ocena.ToString(),
        };
        return csvValues;
    }

    public void FromCSV(string[] values)
    {
        id = int.Parse(values[0]);
        ime = values[1];
        prezime = values[2];
        datum_rodjenja = values[3];
        kontakt_telefon = values[4];
        e_mail = values[5];
        br_clanske = values[6];
        trenutna_godina_clanstva = int.Parse(values[7]);
        prosecna_ocena = double.Parse(values[8]);
    }
}

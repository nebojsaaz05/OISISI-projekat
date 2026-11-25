using System.ComponentModel;
using Sajam_knjiga.Core.Model;

// Po uzoru na VehicleDTO iz CRUDExample (vjezbe 5 i 6)
namespace GUI.DTO
{
    public class AutorDTO : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int AdresaId { get; set; }

        private string ime = string.Empty;
        public string Ime
        {
            get { return ime; }
            set
            {
                if (value != ime)
                {
                    ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

        private string prezime = string.Empty;
        public string Prezime
        {
            get { return prezime; }
            set
            {
                if (value != prezime)
                {
                    prezime = value;
                    OnPropertyChanged("Prezime");
                }
            }
        }

        private DateTime datumRodjenja = DateTime.Today;
        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set
            {
                if (value != datumRodjenja)
                {
                    datumRodjenja = value;
                    OnPropertyChanged("DatumRodjenja");
                }
            }
        }

        private string telefon = string.Empty;
        public string Telefon
        {
            get { return telefon; }
            set
            {
                if (value != telefon)
                {
                    telefon = value;
                    OnPropertyChanged("Telefon");
                }
            }
        }

        private string email = string.Empty;
        public string Email
        {
            get { return email; }
            set
            {
                if (value != email)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        private string brojLicneKarte = string.Empty;
        public string BrojLicneKarte
        {
            get { return brojLicneKarte; }
            set
            {
                if (value != brojLicneKarte)
                {
                    brojLicneKarte = value;
                    OnPropertyChanged("BrojLicneKarte");
                }
            }
        }

        private int godineIskustva;
        public int GodineIskustva
        {
            get { return godineIskustva; }
            set
            {
                if (value != godineIskustva)
                {
                    godineIskustva = value;
                    OnPropertyChanged("GodineIskustva");
                }
            }
        }

        // adresa autora
        private string ulica = string.Empty;
        public string Ulica
        {
            get { return ulica; }
            set
            {
                if (value != ulica)
                {
                    ulica = value;
                    OnPropertyChanged("Ulica");
                }
            }
        }

        private string broj = string.Empty;
        public string Broj
        {
            get { return broj; }
            set
            {
                if (value != broj)
                {
                    broj = value;
                    OnPropertyChanged("Broj");
                }
            }
        }

        private string grad = string.Empty;
        public string Grad
        {
            get { return grad; }
            set
            {
                if (value != grad)
                {
                    grad = value;
                    OnPropertyChanged("Grad");
                }
            }
        }

        private string drzava = string.Empty;
        public string Drzava
        {
            get { return drzava; }
            set
            {
                if (value != drzava)
                {
                    drzava = value;
                    OnPropertyChanged("Drzava");
                }
            }
        }

        public AutorDTO()
        {
        }

        public AutorDTO(Autor autor)
        {
            Id = autor.Id;
            AdresaId = autor.AdresaId;
            Ime = autor.Ime;
            Prezime = autor.Prezime;
            DatumRodjenja = autor.DatumRodjenja.ToDateTime(TimeOnly.MinValue);
            Telefon = autor.Telefon;
            Email = autor.Email;
            BrojLicneKarte = autor.BrojLicneKarte;
            GodineIskustva = autor.GodineIskustva;

            if (autor.Adresa != null)
            {
                Ulica = autor.Adresa.Ulica;
                Broj = autor.Adresa.Broj;
                Grad = autor.Adresa.Grad;
                Drzava = autor.Adresa.Drzava;
            }
        }

        public Autor ToAutor()
        {
            return new Autor(Id, Ime, Prezime, DateOnly.FromDateTime(DatumRodjenja), AdresaId,
                             Telefon, Email, BrojLicneKarte, GodineIskustva);
        }

        public Adresa ToAdresa()
        {
            return new Adresa(AdresaId, Ulica, Broj, Grad, Drzava);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
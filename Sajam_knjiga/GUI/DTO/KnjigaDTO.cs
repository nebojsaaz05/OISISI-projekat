using System.ComponentModel;
using Sajam_knjiga.Core.Model;

// Po uzoru na VehicleDTO iz CRUDExample (vjezbe 5 i 6)
namespace GUI.DTO
{
    public class KnjigaDTO : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int IzdavacId { get; set; }

        private string isbn = string.Empty;
        public string Isbn
        {
            get { return isbn; }
            set
            {
                if (value != isbn)
                {
                    isbn = value;
                    OnPropertyChanged("Isbn");
                }
            }
        }

        private string naziv = string.Empty;
        public string Naziv
        {
            get { return naziv; }
            set
            {
                if (value != naziv)
                {
                    naziv = value;
                    OnPropertyChanged("Naziv");
                }
            }
        }

        private string zanr = string.Empty;
        public string Zanr
        {
            get { return zanr; }
            set
            {
                if (value != zanr)
                {
                    zanr = value;
                    OnPropertyChanged("Zanr");
                }
            }
        }

        private int godinaIzdanja;
        public int GodinaIzdanja
        {
            get { return godinaIzdanja; }
            set
            {
                if (value != godinaIzdanja)
                {
                    godinaIzdanja = value;
                    OnPropertyChanged("GodinaIzdanja");
                }
            }
        }

        private int brojStrana;
        public int BrojStrana
        {
            get { return brojStrana; }
            set
            {
                if (value != brojStrana)
                {
                    brojStrana = value;
                    OnPropertyChanged("BrojStrana");
                }
            }
        }

        private decimal cena;
        public decimal Cena
        {
            get { return cena; }
            set
            {
                if (value != cena)
                {
                    cena = value;
                    OnPropertyChanged("Cena");
                }
            }
        }

        public KnjigaDTO()
        {
        }

        public KnjigaDTO(Knjiga knjiga)
        {
            Id = knjiga.Id;
            IzdavacId = knjiga.IzdavacId;
            Isbn = knjiga.Isbn;
            Naziv = knjiga.Naziv;
            Zanr = knjiga.Zanr;
            GodinaIzdanja = knjiga.GodinaIzdanja;
            BrojStrana = knjiga.BrojStrana;
            Cena = knjiga.Cena;
        }

        public Knjiga ToKnjiga()
        {
            return new Knjiga(Id, Isbn, Naziv, Zanr, GodinaIzdanja, Cena, BrojStrana, IzdavacId);
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
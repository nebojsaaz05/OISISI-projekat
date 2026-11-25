using GUI.DTO;
using GUI.View;
using Sajam_knjiga.Core.DAO;      
using Sajam_knjiga.Core.Model;      
using Sajam_knjiga.Core.Observer;
using Sajam_knjiga.Core.Utils;      
using System.Collections.ObjectModel;
using System.Windows;
// Po uzoru na MainWindow iz CRUDExample (vjezbe 6)

namespace GUI
{
    public partial class MainWindow : Window, IObserver
    {
        public ObservableCollection<AutorDTO> Autori { get; set; } = new();
        public AutorDTO? SelectedAutor { get; set; }

        public ObservableCollection<KnjigaDTO> Knjige { get; set; } = new();
        public KnjigaDTO? SelectedKnjiga { get; set; }

        private readonly AdresaDAO _adresaDao;
        private readonly AutorKnjigaDAO _autorKnjigaDao;
        private readonly AutorDAO _autorDao;
        private readonly KnjigaDAO _knjigaDao;

        public MainWindow()
        {
            InitializeComponent();
            // prozor zauzima 3/4 sirine i visine ekrana (specifikacija 8.5), Microsoft dokumentacija: SystemParameters
            Width = SystemParameters.PrimaryScreenWidth * 0.75;
            Height = SystemParameters.PrimaryScreenHeight * 0.75;

            DataContext = this;

            _adresaDao = new AdresaDAO();
            _autorKnjigaDao = new AutorKnjigaDAO();
            _autorDao = new AutorDAO(_adresaDao, _autorKnjigaDao);
            _knjigaDao = new KnjigaDAO(_autorKnjigaDao);
            Povezivanje.PoveziAutore(_autorDao, _adresaDao, _knjigaDao, _autorKnjigaDao);

            _autorDao.AutorSubject.Subscribe(this);
            _knjigaDao.KnjigaSubject.Subscribe(this);

            Update();
        }

        public void Update()
        {
            Autori.Clear();
            foreach (Autor autor in _autorDao.GetAllAutori())
                Autori.Add(new AutorDTO(autor));

            Knjige.Clear();
            foreach (Knjiga knjiga in _knjigaDao.GetAllKnjige())
                Knjige.Add(new KnjigaDTO(knjiga));
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            AddAutor addAutor = new AddAutor(_autorDao, _adresaDao);
            addAutor.Show();
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedAutor == null)
            {
                MessageBox.Show("Izaberite autora kog želite da izmijenite!");
            }
            else
            {
                Autor? autor = _autorDao.GetAutorById(SelectedAutor.Id);
                if (autor != null)
                {
                    UpdateAutor updateAutor = new UpdateAutor(_autorDao, _adresaDao, autor);
                    updateAutor.Show();
                }
            }
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Pretraga_Click(object sender, RoutedEventArgs e)
        {
        }

    }
}
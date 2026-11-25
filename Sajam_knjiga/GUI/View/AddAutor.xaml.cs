using GUI.DTO;
using Sajam_knjiga.Core.DAO;
using Sajam_knjiga.Core.Model;
using System.Windows;

// Po uzoru na AddVehicle iz CRUDExample (vjezbe 6)
namespace GUI.View
{
    public partial class AddAutor : Window
    {
        public AutorDTO Autor { get; set; }

        private AutorDAO autorDAO;
        private AdresaDAO adresaDAO;

        public AddAutor(AutorDAO autorDAO, AdresaDAO adresaDAO)
        {
            InitializeComponent();
            DataContext = this;
            Autor = new AutorDTO();
            this.autorDAO = autorDAO;
            this.adresaDAO = adresaDAO;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // isti redoslijed kao AddAutor u AutorConsoleView:
            // adresa se snima prva da dobije ID
            Adresa adresa = Autor.ToAdresa();
            adresaDAO.AddAdresa(adresa);
            Autor.AdresaId = adresa.Id;

            Autor autor = Autor.ToAutor();
            autor.Adresa = adresa;
            autorDAO.AddAutor(autor);

            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
using GUI.DTO;
using Sajam_knjiga.Core.DAO;
using Sajam_knjiga.Core.Model;
using System.Windows;

// Po uzoru na AddVehicle iz CRUDExample (vjezbe 6)
namespace GUI.View
{
    public partial class UpdateAutor : Window
    {
        public AutorDTO Autor { get; set; }

        private AutorDAO autorDAO;
        private AdresaDAO adresaDAO;

        public UpdateAutor(AutorDAO autorDAO, AdresaDAO adresaDAO, Autor autor)
        {
            InitializeComponent();
            DataContext = this;
            Autor = new AutorDTO(autor);   // forma se popuni podacima autora (konstruktor iz vjezbi 5)
            this.autorDAO = autorDAO;
            this.adresaDAO = adresaDAO;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            adresaDAO.UpdateAdresa(Autor.ToAdresa());   // ista adresa (isti AdresaId), novi podaci
            autorDAO.UpdateAutor(Autor.ToAutor());      // isti Id, novi podaci
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
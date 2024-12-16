using AirCesiModel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirCesiWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour ListeVols.xaml
    /// </summary>
    public partial class ListeVols : UserControl
    {
        public ListeVols()
        {
            InitializeComponent();

            List<VolDto> liste = new();
            liste.Add(new VolDto { 
                Id = 1, 
                CompagnieName = "Air France", 
                AeroportDepart = "Air'Py", 
                AeroportArrivee = "Orly",
                DateDepart = new DateTime(2024, 11, 24, 14, 35, 0),
                DateArrivee = new DateTime(2024, 11, 24, 15, 40, 0),
                EstOuvert = true
            });
            liste.Add(new VolDto
            {
                Id = 1,
                CompagnieName = "Ryanair",
                AeroportDepart = "Air'Py",
                AeroportArrivee = "Standsted",
                DateDepart = new DateTime(2024, 11, 24, 10, 10, 0),
                DateArrivee = new DateTime(2024, 11, 24, 11, 25, 0),
                EstOuvert = true
            });
            liste.Add(new VolDto
            {
                Id = 1,
                CompagnieName = "Volotea",
                AeroportDepart = "Air'Py",
                AeroportArrivee = "Adolfo Suarez",
                DateDepart = new DateTime(2024, 11, 24, 18, 10, 0),
                DateArrivee = new DateTime(2024, 11, 24, 19, 40, 0),
                EstOuvert = true
            });
            liste.Add(new VolDto
            {
                Id = 1,
                CompagnieName = "Easy Jet",
                AeroportDepart = "Air'Py",
                AeroportArrivee = "Léonard de Vinci",
                DateDepart = new DateTime(2024, 11, 24, 20, 20, 0),
                DateArrivee = new DateTime(2024, 11, 24, 23, 10, 0),
                EstOuvert = true
            });
            liste.Add(new VolDto
            {
                Id = 1,
                CompagnieName = "Air France",
                AeroportDepart = "Air'Py",
                AeroportArrivee = "Bâle Mulhouse",
                DateDepart = new DateTime(2024, 11, 24, 21, 20, 0),
                DateArrivee = new DateTime(2024, 11, 24, 22, 10, 0),
                EstOuvert = true
            });

            dtg.ItemsSource = liste;    

        }
    }
}

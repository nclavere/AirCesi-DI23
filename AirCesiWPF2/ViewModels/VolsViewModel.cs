using AirCesiModel.Dto;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace AirCesiWPF2.ViewModels;

/// <summary>
/// ViewModel de la liste des vols
/// </summary>
internal class VolsViewModel : INotifyPropertyChanged
{
	private ObservableCollection<VolDto>? listeVols;
    private ICollectionView? listeVolsView;
    public Visibility DetailVisibility { get; set; } = Visibility.Collapsed;

    public ObservableCollection<VolDto> ListeVols
    {
		get { 
			if(listeVols == null)
            {
                //Récupération des données
                listeVols = new ObservableCollection<VolDto>();
                listeVols!.Add(new VolDto { 
					Id = 1, 
					DateDepart = DateTime.Now, 
					DateArrivee = DateTime.Now.AddHours(2),
                    CompagnieName = "Air France",
                    AeroportDepart = "Aeroport 1",
                    AeroportArrivee = "Aeroport 2",
                });

                //Initialisation de ICollectionView sur la liste observable
                listeVolsView = CollectionViewSource.GetDefaultView(listeVols);

                //Initialisation la notification de changement du current item (solution globale)
                listeVolsView.CurrentChanged += (sender, e) => OnPropertyChanged(nameof(VolSelected));


            }
            return listeVols; 
		}
		set { listeVols = value; }
	}


    public VolDto VolSelected
    {
        get {
            return (VolDto)listeVolsView!.CurrentItem;
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    internal void AfficherDetailVol()
    {
        DetailVisibility= Visibility.Visible;
        OnPropertyChanged(nameof(DetailVisibility));

        //Initialisation la notification de changement du current item
        //(solution spécifique si on utilise pas la solutio globale)
        //OnPropertyChanged(nameof(VolSelected)); 
    }

    internal void CacherDetailVol()
    {
        DetailVisibility = Visibility.Collapsed;
        OnPropertyChanged(nameof(DetailVisibility));
    }

    internal void AjouterUnVol()
    {
        listeVols!.Add(new VolDto
        {
            Id = 1,
            DateDepart = DateTime.Now,
            DateArrivee = DateTime.Now.AddHours(2),
            CompagnieName = "Air Cesi",
            AeroportDepart = "Aeroport 3",
            AeroportArrivee = "Aeroport 4",
        });
    }
}

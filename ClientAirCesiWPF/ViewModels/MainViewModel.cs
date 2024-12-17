using AirCesiModel.Dto;
using ClientAirCesiWPF.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ClientAirCesiWPF.ViewModels;
internal class MainViewModel : ViewModelBase
{
    public ObservableCollection<VolViewModel> ListeVols { get; set; } = new();
    public int NombreListeVols { get => ListeVols.Count(); }

    public void RechercherLesVols(DateTime dateJour)
    {
        Task.Run(async () =>
        {
            return await HttpClientService.GetVolLights(dateJour);

        }).ContinueWith(t =>
        {
            ListeVols.Clear();
            foreach (var vol in t.Result)
            {
                var vm = new VolViewModel(vol);
                vm.ViewRequested += (o, e) =>
                {
                    VolSelected = vm;
                    DetailVolVisibility = Visibility.Visible;
                    OnPropertyChanged(nameof(VolSelected));
                    OnPropertyChanged(nameof(DetailVolVisibility));
                };
                ListeVols.Add(vm);
            }

            OnPropertyChanged(nameof(NombreListeVols));

        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    
    //Gestion de la commande de recherche des vols
    public DateTime DateSelected { get; set; } = DateTime.Now;

    public RelayCommand SearchCommand { get; set; }

    public MainViewModel()
    {
        SearchCommand = new RelayCommand(() =>
        {
            RechercherLesVols(DateSelected);
        });
    }

    //Gestion de la visibilité du détail
    public Visibility DetailVolVisibility { get; set; } = Visibility.Collapsed;

    public VolViewModel? VolSelected { get; set; }



}

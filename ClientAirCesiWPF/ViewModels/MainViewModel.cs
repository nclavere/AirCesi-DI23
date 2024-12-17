﻿using AirCesiModel.Dto;
using ClientAirCesiWPF.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAirCesiWPF.ViewModels;
internal class MainViewModel : ViewModelBase
{
    public ObservableCollection<VolDto> ListeVols { get; set; } = new();
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
                ListeVols.Add(vol);
            }

            OnPropertyChanged(nameof(NombreListeVols));

        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

}

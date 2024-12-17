using AirCesiModel.Dto;

namespace ClientAirCesiWPF.ViewModels;
internal class VolViewModel : ViewModelBase
{
    public VolDto Vol { get; set; }

    public RelayCommand ViewCommand { get; set; }

    public event EventHandler? ViewRequested;

    public VolViewModel(VolDto vol)
    {
        Vol = vol;

        ViewCommand = new RelayCommand(() =>
        {
            ViewRequested?.Invoke(this, EventArgs.Empty);
        });
    }

    public double Duree
    {
        get
        {
            return (Vol.DateArrivee - Vol.DateDepart).TotalMinutes;
        }
    }

    


}

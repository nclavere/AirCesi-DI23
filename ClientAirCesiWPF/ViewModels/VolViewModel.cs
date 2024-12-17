using AirCesiModel.Dto;

namespace ClientAirCesiWPF.ViewModels;
internal class VolViewModel : ViewModelBase
{
    public VolDto Vol { get; set; }

    public RelayCommand ViewCommand { get; set; }
    public event EventHandler? ViewRequested;

    public RelayCommand CloseCommand { get; set; }
    public event EventHandler? CloseRequested;

    public VolViewModel(VolDto vol)
    {
        Vol = vol;

        ViewCommand = new RelayCommand(() =>
        {
            ViewRequested?.Invoke(this, EventArgs.Empty);
        });

        CloseCommand = new RelayCommand(() =>
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
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

using ClientAirCesiWPF.Service;
using ClientAirCesiWPF.ViewModels;
using System.Windows;

namespace ClientAirCesiWPF;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        this.DataContext = new MainViewModel();

        Task.Run(async () => await HttpClientService.Login("nclavere@adista.fr", "aZ123456@"));
    }

    //private void Search_Click(object sender, RoutedEventArgs e)
    //{        
    //    if (dtpDate.SelectedDate.HasValue)
    //    {
    //        var vm = (MainViewModel)this.DataContext;
    //        //Recherche ...
    //        var date = dtpDate.SelectedDate;
    //        vm.RechercherLesVols(date.Value);
    //    }
    //}
}
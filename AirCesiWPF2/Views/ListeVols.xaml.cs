using System.Windows.Controls;

namespace AirCesiWPF2.Views;
/// <summary>
/// Logique d'interaction pour ListeVols.xaml
/// </summary>
public partial class ListeVols : UserControl
{
    public ListeVols()
    {
        InitializeComponent();
    }

    private void Detail_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        var vm = (ViewModels.VolsViewModel)this.DataContext;
        vm.AfficherDetailVol();
    }
}

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoContentControl;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Articles_Click(object sender, RoutedEventArgs e)
    {
        var control = new Views.Articles();
        control.DataContext = new ViewModels.ArticlesViewModel();
        mainCC.Content = control;
    }

    private void Commandes_Click(object sender, RoutedEventArgs e)
    {
        var control = new Views.Commandes();
        control.DataContext = new ViewModels.CommandesViewModel();
        mainCC.Content = control;
    }
}
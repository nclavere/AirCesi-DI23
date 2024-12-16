using AirCesiModel.Dto;
using AirCesiWPF.Views;
using System.Windows;
using System.Windows.Controls;

namespace AirCesiWPF;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Nouveau_Click(object sender, RoutedEventArgs e)
    {
        NouvelOnglet(new VolDto());
    }

    private void Open_Click(object sender, RoutedEventArgs e)
    {
        var selectedItem = ucListe.dtg.SelectedItem;
        if (selectedItem != null)
        {
            NouvelOnglet((VolDto)selectedItem);
        }   
    }

    private void NouvelOnglet(VolDto vol)
    {
        var uc = new DetailVol();
        uc.DataContext = vol;

        var tbi = new TabItem();
        tbi.Header = "Vol";
        tbi.Content = uc;

        MainTab.Items.Add(tbi);
        MainTab.SelectedItem = tbi;
    }

}
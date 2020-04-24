using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace KaoChat
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		ObservableCollection<Soba> Sobe = new ObservableCollection<Soba>();

		public MainWindow()
		{
			InitializeComponent();
			Sobe.Add(new Soba("Prva"));
			Sobe.Add(new Soba("Druga"));
			Sobe.Add(new Soba("Treca"));

			cmb.ItemsSource = Sobe;
			cmb.DisplayMemberPath = "Naziv";
			cmb.SelectedIndex = 0;
		}

		private void Klik(object sender, RoutedEventArgs e)
		{
			var k = (sender as Control).DataContext as Korisnik;
			k.PoslajiPoruku();
			ic.ItemsSource = k.Poruke.ToList();
		}

		//private void PromenaSobe(object sender, SelectionChangedEventArgs e)
		//{
		//	((sender as Control).DataContext as Korisnik).TrenutnaSoba = (sender as ComboBox).SelectedItem as Soba;
		//}
	}
}

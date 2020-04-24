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
	/// Interaction logic for ChatUI.xaml
	/// </summary>
	public partial class ChatUI : UserControl
	{
		public Korisnik Kor { get; set; }

		public ChatUI(ObservableCollection<Soba> s)
		{
			InitializeComponent();
			DataContext = this;

			cmb.ItemsSource = s;
			cmb.DisplayMemberPath = "Naziv";
			cmb.SelectedIndex = 0;
		}

		private void Klik(object sender, RoutedEventArgs e)
		{
			Kor.PoslajiPoruku();
		}
	}
}

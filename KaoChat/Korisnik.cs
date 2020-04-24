using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaoChat
{
	public class Korisnik : INotifyPropertyChanged
	{
		public Korisnik(string i) => Ime = i;
		public string Ime { get; set; }

		private Soba trenutnaSoba;
		public Soba TrenutnaSoba 
		{ 
			get => trenutnaSoba; 
			set
			{
				if (TrenutnaSoba != null)
					TrenutnaSoba.PosaljiPoruku -= this.PrimiPoruku;
				trenutnaSoba = value;
				if (TrenutnaSoba != null)
					TrenutnaSoba.PosaljiPoruku += this.PrimiPoruku;
			}
		}

		private string unos;
		public string Unos 
		{ 
			get => unos;
			set
			{
				unos = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Unos"));
			}
		}

		public ObservableCollection<string> Poruke { get; set; } = new ObservableCollection<string>();

		public event PropertyChangedEventHandler PropertyChanged;

		//Prva stvar u lancu dogadjaja. Korisnik poziva metodu sobe i daje joj poruku
		public void PoslajiPoruku()
		{
			TrenutnaSoba.PrimiPoruku(Unos, this);
			Unos = "";
		}

		//Treci korak eventa, korisnik dobija poruku od eventa
		public void PrimiPoruku(object soba, PosaljiPorukuArgs p)
		{
			Poruke.Add($"{DateTime.Now} - {(soba as Soba).Naziv} -- {p.Kor.Ime}:  {p.Poruka}");
		}
	}
}

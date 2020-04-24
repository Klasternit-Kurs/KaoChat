using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaoChat
{

	public class PosaljiPorukuArgs
	{
		public string Poruka;
		public Korisnik Kor;
		public PosaljiPorukuArgs(string p, Korisnik k)
		{
			Poruka = p;
			Kor = k;
		}
	}

	public class Soba
	{
		public string Naziv { get; set; }

		public delegate void PosaljiPorukuHandler(object soba, PosaljiPorukuArgs pp);
		public event PosaljiPorukuHandler PosaljiPoruku;

		//Drugi korak, soba prima poruku, i samo je prosledi eventu, koji poziva sve koji ga slusaju
		public void PrimiPoruku(string p, Korisnik k)
		{
			PosaljiPoruku?.Invoke(this, new PosaljiPorukuArgs(p, k));
		}

		public Soba(string n) => Naziv = n;
	}
}

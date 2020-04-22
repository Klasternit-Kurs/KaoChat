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
		public PosaljiPorukuArgs(string p)
		{
			Poruka = p;
		}
	}

	public class Soba
	{
		public string Naziv { get; set; }

		public delegate void PosaljiPorukuHandler(object soba, PosaljiPorukuArgs pp);
		public event PosaljiPorukuHandler PosaljiPoruku;

		//Drugi korak, soba prima poruku, i samo je prosledi eventu, koji poziva sve koji ga slusaju
		public void PrimiPoruku(string p)
		{
			PosaljiPoruku?.Invoke(this, new PosaljiPorukuArgs(DateTime.Now + "---" + p));
		}
	}
}

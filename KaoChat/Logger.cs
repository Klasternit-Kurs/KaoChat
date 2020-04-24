using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KaoChat
{
	public class Logger
	{
		public static void SpremiPoruku(object sender, PosaljiPorukuArgs a) =>
			File.AppendAllText($"{(sender as Soba).Naziv}.txt", $"{DateTime.Now} -- {a.Kor.Ime}:  {a.Poruka}" +
				Environment.NewLine);
	}
}

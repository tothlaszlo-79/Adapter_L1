using System;
using System.Collections.Generic;

namespace DI_Minta
{
	class Program
	{
		static void Main(string[] args)
		{
			//Konstruktor DI hívása
			//var u = new Ügyfél(new Buborék());
			var u = new Ügyfél(new Binalis());
			
			//tulajdonság DI hívása
			u.DITulajdonsag = new Buborék();
			//Metódus DI hívása
			u.RendezésMetódus(new Buborék());
			u.Munka();
			Console.ReadLine();

		}

		public interface IRendez{
			List<double> Rendez(List<double> Eredeti, bool Növekvő);
			}

		public class Buborék : IRendez
		{
			public List<double> Rendez(List<double> Eredeti, bool Növekvő)
			{
				var új = new List<double>(Eredeti);
				for (var i = 0; i < új.Count; i++)
					for (var j = 1; j < új.Count; j++)
						if ((Növekvő && (új[j - 1] > új[j])) || (!Növekvő && (új[j] > új[j - 1])))
						{
							var m = új[j - 1];
							új[j - 1] = új[j];
							új[j] = m;
						}
				return új;
			}
		}

        public class Binalis : IRendez
        {
            public List<double> Rendez(List<double> Eredeti, bool Növekvő)
            {
                throw new NotImplementedException();
            }
        }


        public class Ügyfél
		{
			IRendez Rendező;
			List<double> Adatok;

			//tualjdonságon keresztüli DI megvalósítása
			public IRendez DITulajdonsag { get; set; }

			//Metódus DI, hibát ad ha nincsen az Adatok tulajdonságban érték
			public void RendezésMetódus(IRendez rendezo)
            {
				Kiír(rendezo.Rendez(Adatok, true));
            }

			public Ügyfél(IRendez R)
			{
				Rendező = R;
				//Adatok feltöltése, hogy ne adjon hibát a DI lehetőségeknél
				Feltölt(10);
			}

			

			void Feltölt(int db)
			{
				Adatok = new List<double>();
				var r = new Random();
				for (var i = 0; i < db; i++)
					Adatok.Add(r.NextDouble());
			}

			public void Kiír(List<Double> Számok)
			{
				foreach (var sz in Számok)
					Console.Write("{0,5:F3}, ", sz);
				Console.WriteLine();
			}

			public void Munka()
			{
				//Tulajdonságon keresztük lapott DI meghívása
				//DITulajdonsag.Rendez(Adatok, true);
				Console.WriteLine("Az eredeti számsor:");
				Kiír(Adatok);
				var Növekvő = Rendező.Rendez(Adatok, true);
				Console.WriteLine("Növekvő sorba rendezve:");
				Kiír(Növekvő);
				var Csökkenő = Rendező.Rendez(Adatok, false);
				Console.WriteLine("Csökkenő sorba rendezve:");
				Kiír(Csökkenő);
			}
		}



	}
}

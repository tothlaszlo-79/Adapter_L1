using System;

namespace Adapter_L1
{
    class Program
    {
        static void Main(string[] args)
        {
            Adapter a = new Adapter("Nagyon", "Ügyes");
           
            Ügyfél ü = new Ügyfél(a);
            ü.Kiír();
            Console.ReadLine();
        }

        public class Személy
        {
            public Személy(string V, string U) {
                Vezetéknév = V; 
                Utónév = U; 
            }
            public string Vezetéknév { get; set; }
            public string Utónév { get; set; }
        }

        interface INév { 
            string Vezetéknév { get; set; } 
            string Utónév { get; set; } 
            string TeljesNév { get; } 
        }

        class Ügyfél
        {
            private INév n; 
            public Ügyfél(INév újNév) 
            { n = újNév; }
            public void Kiír()
            {
                Console.WriteLine(n.Vezetéknév + "\t" + n.Utónév + "\t" + "\t" + n.TeljesNév);
            }
        }

        class Adapter : Személy, INév
        {
            public Adapter(string V, string U) : base(V, U) { }

            public string TeljesNév
            {
                get
                {
                    return Vezetéknév + " " + Utónév;
                }
            }
        }

    }

    
}

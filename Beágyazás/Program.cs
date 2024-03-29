﻿using System;

namespace Beágyazás
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
            public Személy(string V, string U) { Vezetéknév = V; Utónév = U; }
            public string Vezetéknév { get; set; }
            public string Utónév { get; set; }
        }

        interface INév
        {
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
        public class Adapter : INév
        {
            Személy Személy;

            public string TeljesNév
            {
                get { return Személy.Vezetéknév + " " + Személy.Utónév; }
            }
            public string Vezetéknév
            {
                get { return Személy.Vezetéknév; }
                set { Személy.Vezetéknév = value; }
            }
            public string Utónév
            {
                get { return Személy.Utónév; }
                set { Személy.Utónév = value; }
            }
            public Adapter(string V, string U)
            {
                Személy = new Személy(V, U);
            }
        }

 
    }
}

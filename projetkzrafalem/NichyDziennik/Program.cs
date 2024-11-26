using System;
using System.Collections.Generic;
using System.Linq;

namespace DziennikOcen
{
    public class Przedmiot
    {
        public string NazwaPrzedmiotu { get; set; } 
        public List<decimal> Oceny { get; private set; } 

        public Przedmiot(string nazwaPrzedmiotu)
        {
            this.NazwaPrzedmiotu = nazwaPrzedmiotu; 
            Oceny = new List<decimal>();
        }

        public void DodajOcene(decimal ocena)
        {
            Oceny.Add(ocena);
        }
        public decimal ObliczSrednia()
        {
            if (Oceny.Count == 0)
                return 0;

            return Oceny.Average();
        }
        public void WyswietlInformacje()
        {
            Console.WriteLine($"Przedmiot: {NazwaPrzedmiotu}");
            Console.WriteLine($"Średnia ocen: {ObliczSrednia():F2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Przedmiot przedmiot = new Przedmiot("Matematyka");

            przedmiot.DodajOcene(5.0m); // m oznacza zmiane typu danych z double na dec
            przedmiot.DodajOcene(4.0m);
            przedmiot.DodajOcene(3.0m);

            przedmiot.WyswietlInformacje();
        }
    }
}
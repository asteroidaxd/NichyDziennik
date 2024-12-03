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
        public decimal ObliczNajwyzszaOcene()
        {
            if (Oceny.Count == 0)
                return 0;

            return Oceny.Max();
        }
        public decimal ObliczSrednia()
        {
            if (Oceny.Count == 0)
                return 0;

            return Oceny.Average();
        }
        public decimal ObliczNajmniejszaOcene()
        {
            if (Oceny.Count == 0)
                return 0;

            return Oceny.Min();
        }

        public void WyswietlInformacje()
        {
            Console.WriteLine($"Przedmiot: {NazwaPrzedmiotu}");
            Console.WriteLine($"Średnia ocen: {ObliczSrednia():F2}");
            Console.WriteLine($"Najwyższa ocena: {ObliczNajwyzszaOcene()}");
            Console.WriteLine($"Najniższa ocena: {ObliczNajmniejszaOcene()}");
        }
    }

        class Program
    {
        static string wybor;
        static bool poprawny = false;
        static void Main(string[] args)
        {
            string wybor;
            bool poprawny = false;
            while (true) { wyswietlOceny(); }



        }


        static void wyswietlOceny()
        {
            Console.Clear();
            //przykladowe dane
            Console.WriteLine("oceny: ");
            Console.WriteLine("matematyka(3,8): 4,3,3,3");
            Console.WriteLine("polski(1,1): 1,1,1,1,2");
            Console.WriteLine("wf(6,0): 6");

            //nawigacja
            Console.WriteLine("\nWpisz \"max\" lub \"min\" aby zobaczyc takie oceny z kazdego przedmiotu");
            Console.WriteLine("wpisz \"e\" aby dodac lub usunac ocene lub przedmiot");
            Console.WriteLine("wpisz \"q\" aby wyjsc");
            wybor = Console.ReadLine();
            Console.Clear();

            while (poprawny == false)
            {
                if (wybor == "e") { Console.Clear(); edycja(); poprawny = true; }
                else if (wybor == "max") { Console.Clear(); maxOcena(); poprawny = true; }
                else if (wybor == "min") { Console.Clear(); minOcena(); poprawny = true; }
                else if (wybor == "q") { Environment.Exit(1); }
                else if (wybor == "") { Console.Clear(); wyswietlOceny(); }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nWpisz \"max\" lub \"min\" aby zobaczyc oceny");
                    Console.WriteLine("wpisz \"E\" aby dodac lub usunac ocene lub przedmiot");
                    wybor = Console.ReadLine();
                }
            }
            poprawny = false;
        }

        static void edycja()
        {
            Console.Clear();
            Console.WriteLine("Co chesz zmodyfikowac: ");
            Console.WriteLine("oceny (o(+/-))     przedmioty (p(+/-))         przyklad:\"p-\"");
            wybor = Console.ReadLine();
            Console.Clear();
            while (poprawny == false)
            {
                if (wybor == "o+") { Console.Clear(); dodajOcene(); poprawny = true; break; }
                else if (wybor == "o-") { Console.Clear(); usunOcene(); poprawny = true; break; }
                else if (wybor == "p+") { Console.Clear(); dodajPrzedmiot(); poprawny = true; break; }
                else if (wybor == "p-") { Console.Clear(); usunPrzedmiot(); poprawny = true; break; }
                else { Console.Clear(); edycja(); }
            }
            poprawny = false;
        }



        static void dodajOcene()
        {
            Console.WriteLine("Wpisz: przedmiot,ocena");
            Console.WriteLine("przedmioty w dzienniku:");
            Console.WriteLine("matematyka,polski,wf");
            Console.ReadLine();
            zapisz();
        }
        static void usunOcene()
        {
            Console.WriteLine("Wpisz: przedmiot,ocena,numer oceny liczac od 1 od najnowszych do najstarszych");
            Console.WriteLine("przedmioty w dzienniku:");
            Console.WriteLine("matematyka,polski,wf");
            Console.ReadLine();
            zapisz();
        }

        static void dodajPrzedmiot()
        {
            Console.WriteLine("wpisz nazwe przedmiotu do dodania:");
            Console.ReadLine();
            zapisz();
        }
        static void usunPrzedmiot()
        {
            Console.WriteLine("wpisz nazwe przedmiotu do usuniecia:");
            Console.ReadLine();
            zapisz();
        }

        static void minOcena()
        {
            Console.WriteLine("matematyka: 1");
            Console.WriteLine("polski: 2");
            Console.WriteLine("wf: 1");
            Console.WriteLine("\nnacisnij enter aby wrocic");
            Console.ReadLine();
        }
        static void maxOcena()
        {
            Console.WriteLine("matematyka: 5");
            Console.WriteLine("polski: 2");
            Console.WriteLine("wf: 6");
            Console.WriteLine("\nnacisnij enter aby wrocic");
            Console.ReadLine();
        }
        static void zapisz()
        {
            Console.WriteLine("zapisano stan do pliku");
        }
    }



}
}
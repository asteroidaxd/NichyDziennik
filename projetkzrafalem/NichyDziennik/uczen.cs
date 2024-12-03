using System;
using System.Collections.Generic;
using System.Linq;

namespace DziennikOcen
{
    public class Uczen
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public List<Przedmiot> Przedmioty { get; private set; }

        public Uczen(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Przedmioty = new List<Przedmiot>();
        }

        public void DodajPrzedmiot(Przedmiot przedmiot)
        {
            Przedmioty.Add(przedmiot);
        }

        public void WyswietlInformacje()
        {
            Console.WriteLine($"Uczeń: {Imie} {Nazwisko}");
            foreach (var przedmiot in Przedmioty)
            {
                przedmiot.WyswietlInformacje();
            }
        }
    }
}
namespace NichyDziennik
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
    }

    class Program
    {

        static string wybor;
        static bool poprawny = false;
        static void Main()
        {

            string wybor;
            bool poprawny = false;
            while (true) { wyswietlOceny(); }

        }

        static string przedmiotszkolny;
        public static List<Przedmiot> listaprzedmiotow = [];

        static void wyswietlOceny()
        {

            Console.Clear();
            //przykladowe dane
            Console.WriteLine("oceny: ");

            foreach (var przedmiot in listaprzedmiotow)
            {
                Console.Write(przedmiot.NazwaPrzedmiotu);
                Console.Write(": ");
                int liczbaocen = przedmiot.Oceny.Count;

                for (int i = 0; i < liczbaocen; i++)
                {
                    Console.Write(przedmiot.Oceny[i]);
                    if (i != liczbaocen - 1)
                    {
                        Console.Write(", ");
                    }
                }

                Console.Write("\n");
            }

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
                    //nawigacja
                    Console.WriteLine("\nWpisz \"max\" lub \"min\" aby zobaczyc takie oceny z kazdego przedmiotu");
                    Console.WriteLine("wpisz \"e\" aby dodac lub usunac ocene lub przedmiot");
                    Console.WriteLine("wpisz \"q\" aby wyjsc");
                    wybor = Console.ReadLine();
                    Console.Clear();
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
            foreach (var name in listaprzedmiotow)
            {
                Console.WriteLine(name.NazwaPrzedmiotu);
            }

            string input = Console.ReadLine();
            string[] parts = input.Split(',');
            if (parts.Length == 2 && decimal.TryParse(parts[1], out decimal ocena))
            {
                string subjectName = parts[0].Trim();
                // Find the subject in the list
                Przedmiot foundSubject = listaprzedmiotow.FirstOrDefault(p => p.NazwaPrzedmiotu.Equals(subjectName, StringComparison.OrdinalIgnoreCase));
                if (foundSubject != null)
                {
                    foundSubject.DodajOcene(ocena);
                    Console.WriteLine($"Dodano ocenę {ocena} do przedmiotu {foundSubject.NazwaPrzedmiotu}.");
                }
                else
                {
                    Console.WriteLine($"Nie znaleziono przedmiotu o nazwie: {subjectName}");
                }
            }
            else
            {
                Console.WriteLine("Niepoprawny format. Upewnij się, że wpisujesz 'przedmiot,ocena'.");
            }



            zapisz();
        }
        static void usunOcene()
        {
            Console.WriteLine("Wpisz: przedmiot, numer oceny (licząc od 1 od najnowszych do najstarszych)");
            foreach (var name in listaprzedmiotow)
            {
                Console.WriteLine(name.NazwaPrzedmiotu);
            }

            string input = Console.ReadLine();
            string[] parts = input.Split(',');

            if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int index))
            {
                string subjectName = parts[0].Trim();
                // Find the subject in the list
                Przedmiot foundSubject = listaprzedmiotow.FirstOrDefault(p => p.NazwaPrzedmiotu.Equals(subjectName, StringComparison.OrdinalIgnoreCase));

                if (foundSubject != null)
                {
                    // Check if the index is valid (1-based index)
                    if (index > 0 && index <= foundSubject.Oceny.Count)
                    {
                        // Convert to 0-based index
                        int zeroBasedIndex = foundSubject.Oceny.Count - index;
                        decimal removedGrade = foundSubject.Oceny[zeroBasedIndex];
                        foundSubject.Oceny.RemoveAt(zeroBasedIndex);
                        Console.WriteLine($"Usunięto ocenę {removedGrade} z przedmiotu {foundSubject.NazwaPrzedmiotu}.");
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawny numer oceny. Upewnij się, że podajesz numer w zakresie.");
                    }
                }
                else
                {
                    Console.WriteLine($"Nie znaleziono przedmiotu o nazwie: {subjectName}");
                }
            }
            else
            {
                Console.WriteLine("Niepoprawny format. Upewnij się, że wpisujesz 'przedmiot,numer oceny'.");
            }

            zapisz();
        }

        static void dodajPrzedmiot()
        {
            Console.WriteLine("wpisz nazwe przedmiotu do dodania:");
            przedmiotszkolny = Console.ReadLine();
            Przedmiot newSubject = new Przedmiot(przedmiotszkolny);
            listaprzedmiotow.Add(newSubject);
            zapisz();
            
        }
        static void usunPrzedmiot()
        {
            Console.WriteLine("wpisz nazwe przedmiotu do usuniecia:");
            przedmiotszkolny = Console.ReadLine();
            listaprzedmiotow.RemoveAll(p => p.NazwaPrzedmiotu.Equals(przedmiotszkolny, StringComparison.OrdinalIgnoreCase));
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
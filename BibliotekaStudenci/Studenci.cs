using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using BibliotekaStudent;

namespace BibliotekaStudenci
{
    public class Studenci
    {
        public static List<Student> listaStudentów = new List<Student>();
        public static string sciezkaBazyDanych = "dane.dat";

        public static void DodajStudentaDziennego()
        {
            Console.WriteLine("Podaj imię:");
            string imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko:");
            string nazwisko = Console.ReadLine();
            Console.WriteLine("Podaj adres:");
            string adres = Console.ReadLine();
            Console.WriteLine("Podaj wydział:");
            string wydział = Console.ReadLine();
            Console.WriteLine("Podaj kierunek:");
            string kierunek = Console.ReadLine();
            Console.WriteLine("Podaj rok urodzenia:");
            int rok;
            int.TryParse(Console.ReadLine(), out rok);
            Console.WriteLine("Podaj miesiac urodzenia:");
            int miesiac;
            int.TryParse(Console.ReadLine(), out miesiac);
            Console.WriteLine("Podaj dzien urodzenia:");
            int dzien;
            int.TryParse(Console.ReadLine(), out dzien);
            Console.WriteLine("Podaj pesel:");
            int pesel;
            int.TryParse(Console.ReadLine(), out pesel);
            Console.WriteLine("Podaj numer indeksu:");
            int numerIndeksu;
            int.TryParse(Console.ReadLine(), out numerIndeksu);
            Console.WriteLine("Podaj semestr na którym aktualnie znajduje się student:");
            int aktualnySemestr;
            int.TryParse(Console.ReadLine(), out aktualnySemestr);
            StudentDzienny s = new StudentDzienny(imie, nazwisko, adres, wydział, kierunek, rok, miesiac, dzien, pesel, numerIndeksu, aktualnySemestr);
            listaStudentów.Add(s);
        }

        public static void DodajStudentaZaocznego()
        {
            Console.WriteLine("Podaj imię:");
            string imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko:");
            string nazwisko = Console.ReadLine();
            Console.WriteLine("Podaj adres:");
            string adres = Console.ReadLine();
            Console.WriteLine("Podaj wydział:");
            string wydział = Console.ReadLine();
            Console.WriteLine("Podaj kierunek:");
            string kierunek = Console.ReadLine();
            Console.WriteLine("Podaj rok urodzenia:");
            int rok;
            int.TryParse(Console.ReadLine(), out rok);
            Console.WriteLine("Podaj miesiac urodzenia:");
            int miesiac;
            int.TryParse(Console.ReadLine(), out miesiac);
            Console.WriteLine("Podaj dzien urodzenia:");
            int dzien;
            int.TryParse(Console.ReadLine(), out dzien);
            Console.WriteLine("Podaj pesel:");
            int pesel;
            int.TryParse(Console.ReadLine(), out pesel);
            Console.WriteLine("Podaj numer indeksu:");
            int numerIndeksu;
            int.TryParse(Console.ReadLine(), out numerIndeksu);
            Console.WriteLine("Podaj semestr na którym aktualnie znajduje się student:");
            int aktualnySemestr;
            int.TryParse(Console.ReadLine(), out aktualnySemestr);
            Console.WriteLine("Podaj wartość płatności za semestr:");
            int płatnośćZaSemestr;
            int.TryParse(Console.ReadLine(), out płatnośćZaSemestr);
            Console.WriteLine("Czy student uregulował płatności?[t/n]");
            bool czyOpłaconeCzesne;
            if (Console.ReadLine() == "t")
            {
                czyOpłaconeCzesne = true;
            }
            else
            {
                czyOpłaconeCzesne = false;
            }
            StudentZaoczny s = new StudentZaoczny(imie, nazwisko, adres, wydział, kierunek, rok, miesiac, dzien, pesel, numerIndeksu, aktualnySemestr, płatnośćZaSemestr, czyOpłaconeCzesne);
            listaStudentów.Add(s);
        }

        public static void Serializuj(string sciezka, List<Student> lista)
        {
            FileStream fs = new FileStream(sciezka, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, lista);
            fs.Close();
        }

        public static List<Student> Deserializuj(string sciezka)
        {
            if (File.Exists(sciezka))
            {
                FileStream fs = new FileStream(sciezka, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                List<Student> lista = (List<Student>)bf.Deserialize(fs);
                fs.Close();
                return lista;
            }
            return new List<Student>();
        }

        public static void Wyświetl(List<Student> lista)
        {
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
        }

        public static List<Student> WyszukajStudentówDziennych()
        {
            List<Student> lista = new List<Student>();
            foreach (var item in listaStudentów)
            {
                if (item is StudentDzienny)
                {
                    lista.Add(item);
                }
            }
            return lista;
        }

        public static List<Student> WyszukajStudentówZaocznych()
        {
            List<Student> lista = new List<Student>();
            foreach (var item in listaStudentów)
            {
                if (item is StudentZaoczny)
                {
                    lista.Add(item);
                }
            }
            return lista;
        }

        public static void PytanieOZapisywanie(List<Student> lista)
        {
            Console.WriteLine("Czy chcesz zapisać ostatnio wyświetlone elementy bazy danych? [t/n]");
            string odp = Console.ReadLine();
            if (odp == "t" || odp == "T")
            {
                Console.WriteLine("Podaj nazwe pliku do zapisu(pomietaj o dopisaniu rozszerzenia pliku)");
                string nazwa = Console.ReadLine();
                if (nazwa != Studenci.sciezkaBazyDanych)
                {
                    Studenci.Serializuj(nazwa, lista);
                }
                else
                {
                    Console.WriteLine("Ta nazwa jest zastrzerzona");
                }
            }
        }

        public static List<Student> Wczytywanie()
        {
            List<Student> lista = new List<Student>();
            Console.WriteLine("Podaj nazwę pliku do wczytania");
            string nazwa = Console.ReadLine();
            if (File.Exists(nazwa))
            {
                lista = Studenci.Deserializuj(nazwa);
            }
            else
            {
                Console.WriteLine("Nie ma tekiego pliku");
            }

            return lista;
        }

        public static int ZnajdźStudenta()
        {
            Console.WriteLine("1. Wyszukiwanie na podstawie numeru indeksu");
            Console.WriteLine("2. Wyszukiwanie na podstawie imienia i nazwiska");
            int wybor;
            int.TryParse(Console.ReadLine(), out wybor);
            if (wybor == 1)
            {
                Console.WriteLine("Podaj numer indeksu:");
                int numerIndeksu;
                int.TryParse(Console.ReadLine(), out numerIndeksu);
                for (int i = 0; i < listaStudentów.Count; i++)
                {
                    if (listaStudentów[i].NumerIndeksu == numerIndeksu)
                    {
                        return i;
                    }
                }
                Console.WriteLine("Nie ma takiego studenta");
                return -1;
            }
            else if (wybor == 2)
            {
                Console.WriteLine("Podaj imie:");
                string imie = Console.ReadLine();
                Console.WriteLine("Podaj nazwisko:");
                string nazwisko = Console.ReadLine();
                for (int i = 0; i < listaStudentów.Count; i++)
                {
                    if (listaStudentów[i].Imie == imie && listaStudentów[i].Nazwisko == nazwisko)
                    {
                        return i;
                    }
                }
                Console.WriteLine("Nie ma takiego studenta");

            }
            return -1;
        }
    }
}

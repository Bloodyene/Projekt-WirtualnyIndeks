using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibiliotekaIndeks;

namespace BibliotekaStudent
{
    [Serializable]
    public abstract class Student : IComparable<Student>
    {
        protected string imie, nazwisko, adres, wydział, kierunek;
        public string Imie { get { return imie; } }
        public string Nazwisko { get { return nazwisko; } }
        protected DateTime dataUrodzenia;
        protected int pesel;
        protected Indeks indeks;
        public int NumerIndeksu { get { return indeks.numerIndeksu; } }
        protected int wiek { get { return DateTime.Now.Year - dataUrodzenia.Year; } }

        public Student(string imie, string nazwisko, string adres, string wydział, string kierunek, int rok
            , int miesiac, int dzien, int pesel, int numerIndeksu, int aktualnySemestr)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.adres = adres;
            this.wydział = wydział;
            this.kierunek = kierunek;
            this.pesel = pesel;
            dataUrodzenia = new DateTime(rok, miesiac, dzien);
            this.indeks = new Indeks(numerIndeksu, aktualnySemestr);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}, adres:{2}, wydział:{3}, kierunek:{4}, data urodzenia:{5}, wiek:{6}, pesel:{7}, średnia:{8}"
                , imie, nazwisko, adres, wydział, kierunek, dataUrodzenia, wiek, pesel, indeks.Średnia());
        }
        public void WyświetlPełneInformacje()
        {
            Console.WriteLine(this);
            Console.WriteLine(indeks);
            indeks.WyświetlOceny();
        }

        public void ZmieńOcene()
        {
            Console.WriteLine("Podaj semestr:");
            int semestr;
            int.TryParse(Console.ReadLine(), out semestr);
            Console.WriteLine("Podaj nazwe przedmiotu:");
            string nazwaPrzedmiotu = Console.ReadLine();
            Console.WriteLine("Podaj ocene:");
            double ocena;
            double.TryParse(Console.ReadLine(), out ocena);
            indeks.ZmienOcene(semestr, nazwaPrzedmiotu, ocena);
        }

        public void DodajSzkolenie()
        {
            Console.WriteLine("Podaj nazwę szkolenia zaliczonego przez studenta");
            string szkolenie = Console.ReadLine();
            indeks.DodajZaliczoneSzkolenie(szkolenie);
        }

        public int CompareTo(Student other)
        {
            return string.Compare(this.Nazwisko, other.Nazwisko);
        }
        public class PoWydziale : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                return string.Compare(x.wydział, y.wydział);
            }
        }
        public class PoKierunku : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                return string.Compare(x.kierunek, y.kierunek);
            }
        }
        public class PoŚredniej : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                if (x.indeks.Średnia() > y.indeks.Średnia())
                {
                    return 1;
                }
                else if (x.indeks.Średnia() < y.indeks.Średnia())
                {
                    return -1;
                }
                return 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibiliotekaIndeks
{
    public interface IŚrednia
    {
        double Średnia();
    }
    [Serializable]
    public class Indeks : IŚrednia
    {
        public int numerIndeksu, aktualnySemestr;
        private List<string> listaZaliczonychSzkoleń = new List<string>();
        private Dictionary<int, List<KeyValuePair<string, double>>> oceny = new Dictionary<int, List<KeyValuePair<string, double>>>();

        public Indeks(int numerIndeksu, int aktualnySemestr)
        {
            this.numerIndeksu = numerIndeksu;
            this.aktualnySemestr = aktualnySemestr;
        }
        public void DodajPrzedmioty(int semestr, string przedmiot, int ocena)
        {
            if (!oceny.ContainsKey(semestr))
            {
                oceny.Add(semestr, new List<KeyValuePair<string, double>>());
            }
            oceny[semestr].Add(new KeyValuePair<string, double>(przedmiot, ocena));
        }
        public void ZmienOcene(int semestr, string nazwaPrzedmiotu, double ocena)
        {
            if (oceny.ContainsKey(semestr))
            {
                if (Znajdz(semestr, nazwaPrzedmiotu) >= 0)
                {
                    oceny[semestr][Znajdz(semestr, nazwaPrzedmiotu)] = new KeyValuePair<string, double>(nazwaPrzedmiotu, ocena);
                }
                else
                {
                    oceny[semestr].Add(new KeyValuePair<string, double>(nazwaPrzedmiotu, ocena));
                }
            }
            else
            {
                oceny.Add(semestr, new List<KeyValuePair<string, double>>());
                oceny[semestr].Add(new KeyValuePair<string, double>(nazwaPrzedmiotu, ocena));
            }
        }
        private int Znajdz(int semestr, string nazwaPrzedmiotu)
        {
            for (int i = 0; i < oceny[semestr].Count; i++)
            {
                if (oceny[semestr][i].Key == nazwaPrzedmiotu)
                {
                    return i;
                }
            }
            return -1;
        }

        public void DodajZaliczoneSzkolenie(string szkolenie)
        {
            listaZaliczonychSzkoleń.Add(szkolenie);
        }

        public double Średnia()
        {
            double srednia = 0;
            if (oceny.ContainsKey(aktualnySemestr))
            {
                foreach (var item in oceny[aktualnySemestr])
                {
                    srednia += item.Value;
                }
                return srednia / oceny[aktualnySemestr].Count;
            }

            return srednia;
        }
        public override string ToString()
        {
            return string.Format("Nr indeksu: {0},aktualny semestr: {1}", numerIndeksu, aktualnySemestr);
        }
        public void WyświetlOceny()
        {
            foreach (var item in oceny.Keys)
            {
                Console.WriteLine(item);
                foreach (var i in oceny[item])
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}

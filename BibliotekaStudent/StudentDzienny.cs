using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotekaStudent
{
    [Serializable]
    public class StudentDzienny : Student
    {
        public StudentDzienny(string imie, string nazwisko, string adres, string wydział, string kierunek, int rok
            , int miesiac, int dzien, int pesel, int numerIndeksu, int aktualnySemestr)
            : base(imie, nazwisko, adres, wydział, kierunek, rok, miesiac, dzien, pesel, numerIndeksu, aktualnySemestr)
        {
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

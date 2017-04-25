using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotekaStudent
{
    [Serializable]
    public class StudentZaoczny : Student
    {
        private double płatnośćZaSemestr;
        private bool czyOpłaconoCzesne;
        public StudentZaoczny(string imie, string nazwisko, string adres, string wydział, string kierunek, int rok
            , int miesiac, int dzien, int pesel, int numerIndeksu, int aktualnySemestr, double płatnośćZaSemestr, bool czyOpłaconoCzesne)
            : base(imie, nazwisko, adres, wydział, kierunek, rok, miesiac, dzien, pesel, numerIndeksu, aktualnySemestr)
        {
            this.płatnośćZaSemestr = płatnośćZaSemestr;
            this.czyOpłaconoCzesne = czyOpłaconoCzesne;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}, adres:{2}, wydział:{3}, kierunek:{4}, data urodzenia:{5}, wiek:{6}, pesel:{7}, średnia:{10}, płatność za semestr:{8}, czy opłacone czesne?{9}"
                , imie, nazwisko, adres, wydział, kierunek, dataUrodzenia, wiek, pesel, płatnośćZaSemestr, czyOpłaconoCzesne, indeks.Średnia());
        }
    }
}

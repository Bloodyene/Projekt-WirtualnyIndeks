using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaStudenci;

namespace Projekt
{
    class Modyfikacja
    {
        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Dodaj oceny studenta");
            Console.WriteLine("2. Dodaj zaliczone szkolenie");
            Console.WriteLine("3. Usuń studenta");
            Console.WriteLine("0. Powrót do poprzedniego menu");
            int wybor;
            int.TryParse(Console.ReadLine(), out wybor);
            return wybor;
        }

        public static void Wybor(int numer)
        {
            int i;
            do
            {
                i = Menu();
                switch (i)
                {
                    case 1:
                        Studenci.listaStudentów[numer].ZmieńOcene();
                        break;
                    case 2:
                        Studenci.listaStudentów[numer].DodajSzkolenie();
                        break;
                    case 3:
                        Studenci.listaStudentów.RemoveAt(numer);
                        break;
                    default:
                        break;
                }
            } while (i != 0);
        }
    }
}

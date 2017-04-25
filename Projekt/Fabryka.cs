using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaStudenci;

namespace Projekt
{
    class Fabryka
    {
        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Dodaj Studenta Dziennego");
            Console.WriteLine("2. Dodaj Studenta Zaocznego");
            Console.WriteLine("0. Przejdź do menu głównego");
            int wybor;
            int.TryParse(Console.ReadLine(), out wybor);
            return wybor;
        }

        public static void Wybor()
        {
            int i;
            do
            {
                i = Menu();
                switch (i)
                {
                    case 1:
                        Studenci.DodajStudentaDziennego();
                        break;
                    case 2:
                        Studenci.DodajStudentaZaocznego();
                        break;
                    default:
                        break;
                }
            } while (i != 0);
        }
    }
}

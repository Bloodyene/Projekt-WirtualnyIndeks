using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaStudenci;

namespace Projekt
{
    class Klient
    {
        public static int Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Dodawanie studentów");
            Console.WriteLine("2. Wyświetlanie i modyfikacja danych");
            Console.WriteLine("0. Zakończenie programu");
            int wybor;
            int.TryParse(Console.ReadLine(), out wybor);
            return wybor;
        }

        public static void Uruchom()
        {
            Studenci.listaStudentów = Studenci.Deserializuj(Studenci.sciezkaBazyDanych);
            int i;
            do
            {
                i = Menu();
                switch (i)
                {
                    case 1:
                        Fabryka.Wybor();
                        break;
                    case 2:
                        WyświetlanieIModyfikacja.Wybor();
                        break;
                    case 0:
                        Studenci.Serializuj(Studenci.sciezkaBazyDanych, Studenci.listaStudentów);
                        break;
                    default:
                        break;
                }
            } while (i != 0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaStudenci;
using BibliotekaStudent;

namespace Projekt
{
    class WyświetlanieIModyfikacja
    {
        public delegate void Delegat(List<Student> lista);
        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Wyświetl bazę danych");
            Console.WriteLine("2. Wyświetl studentów dziennych");
            Console.WriteLine("3. Wyświetl studentów zaocznych");
            Console.WriteLine("4. Znajdź i wyświetl studenta");
            Console.WriteLine("5. Znajdź studenta i modyfikuj jego dane");
            Console.WriteLine("6. Wyświetl bazę danych pozortowaną po nazwisku");
            Console.WriteLine("7. Wyświetl bazę danych pozortowaną według wydziałów");
            Console.WriteLine("8. Wyświetl bazę danych pozortowaną według kierunków");
            Console.WriteLine("9. Wyświetl bazę danych pozortowaną według średniej");
            Console.WriteLine("10. Wczytaj z pliku wyniki wczesniejszych przeszukiwan");
            Console.WriteLine("0. Przejdź do menu głównego");
            int wybor;
            int.TryParse(Console.ReadLine(), out wybor);
            return wybor;
        }

        public static void Wybor()
        {
            Delegat d = new Delegat(Studenci.Wyświetl);
            d += Studenci.PytanieOZapisywanie;
            int i;
            do
            {
                i = Menu();
                switch (i)
                {
                    case 1:
                        Studenci.Wyświetl(Studenci.listaStudentów);
                        Console.ReadKey();
                        break;
                    case 2:
                        List<Student> lista = Studenci.WyszukajStudentówDziennych();
                        d(lista);
                        break;
                    case 3:
                        List<Student> lista2 = Studenci.WyszukajStudentówZaocznych();
                        d(lista2);
                        break;
                    case 4:
                        int ind = Studenci.ZnajdźStudenta();
                        if (ind >=0)
                        {
                            Studenci.listaStudentów[ind].WyświetlPełneInformacje();
                        }
                        
                        Console.ReadKey();
                        break;
                    case 5:
                        int numer = Studenci.ZnajdźStudenta();
                        if (numer >= 0)
                        {
                            Modyfikacja.Wybor(numer);
                        }
                        
                        break;
                    case 6:
                        Studenci.listaStudentów.Sort();
                        d(Studenci.listaStudentów);
                        break;
                    case 7:
                        Studenci.listaStudentów.Sort(new Student.PoWydziale());
                        d(Studenci.listaStudentów);
                        break;
                    case 8:
                        Studenci.listaStudentów.Sort(new Student.PoKierunku());
                        d(Studenci.listaStudentów);
                        break;
                    case 9:
                        Studenci.listaStudentów.Sort(new Student.PoŚredniej());
                        d(Studenci.listaStudentów);
                        break;
                    case 10:
                        Studenci.Wyświetl(Studenci.Wczytywanie());
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            } while (i != 0);
        }
    }
}

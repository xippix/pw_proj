using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pw_k_grafd
{
    class Program
    {
        static int ilosc_wierzch = graf.n;
        static void Main(string[] args)
        {
            graf gt = new graf();
            gt.gen_tab_polaczen(35);
            gt.najwyzszy();
            podtablica[] testowa = new podtablica[ilosc_wierzch];
            testowa = gt.stworz_tablice_podtablic();
            gt.wypisz();
            /*
            for (int i = 0; i < ilosc_wierzch; i++)
            {
                Console.WriteLine("tablica pusta dla wierzcholka: {0}", i);
                testowa[i].wypisz();
                Console.WriteLine();
            }*/
            gt.dobieraj_kolory(testowa);
            //Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*** \t POKOLOROWANE \t ***\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < ilosc_wierzch; i++)
            {
                Console.WriteLine("tablic pokolorowana dla wierzcholka: {0}", i);
                testowa[i].wypisz();
                Console.WriteLine();
            }
            Console.ReadLine();
        }



    }
}
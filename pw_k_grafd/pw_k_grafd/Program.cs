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
        static void Main(string[] args)
        {
            graf gt = new graf();
            gt.gen_tab_polaczen(35);
            gt.najwyzszy();
            podtablica[] testowa = new podtablica[8];
            testowa = gt.stworz_tablice_podtablic();
            gt.wypisz();
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine("tablica dla wierzcholka: {0}", i);
                testowa[i].wypisz();
                Console.WriteLine();
            }
            Console.ReadLine();
        }

    }
}
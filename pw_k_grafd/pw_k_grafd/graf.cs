using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pw_k_grafd
{
    class graf
    {
        static public int max_stopien;
        static public int n = 8;
        int[,] tab_polaczen = new int[n, n];

        public void gen_tab_polaczen(int p)    //pkt.1 DONE
        {
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int wyl;
                    wyl = rnd.Next(0, 100);
                    if (i == j)
                    {
                        tab_polaczen[i, j] = 0;
                    }
                    else if (wyl < p)
                    {
                        tab_polaczen[j, i] = tab_polaczen[i, j] = 1;
                    }
                    else
                    {
                        tab_polaczen[j, i] = tab_polaczen[i, j] = 0;
                    }
                }
            }
        }

        public void najwyzszy()             //pkt.2 DONE
        {
            int suma = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (tab_polaczen[i, j] == 1)
                        suma++;
                }
                if (suma > max_stopien)
                    max_stopien = suma;
                suma = 0;
            }
        }

        public void wypisz()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(tab_polaczen[i, j] + "\t");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        public podtablica[] stworz_tablice_podtablic()
        {
            podtablica[] temp_tablica_podtablic = new podtablica[n];
            for (int i = 0; i < n; i++)
            {
                int[] pomoc = new int[0]; //tablica pomocnicza aby pamietac do jakch wierzcholkow dany wierzcholek sie laczy
                for (int j = 0; j < n; j++)
                {
                    if (tab_polaczen[i, j] == 1)
                    {
                        Array.Resize<int>(ref pomoc, (pomoc.GetLength(0) + 1));   //powiekszamy tablice pomoc o 1.
                        pomoc[(pomoc.GetLength(0) - 1)] = j;                //wrzucamy nr wierzcholka do pomoc
                    }
                }
                temp_tablica_podtablic[i] = new podtablica(pomoc.GetLength(0), max_stopien, pomoc);
            }
            return temp_tablica_podtablic;
        }
    }
}
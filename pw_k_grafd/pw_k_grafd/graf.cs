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
        static public int n = Convert.ToInt32(Console.ReadLine());
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
            Console.WriteLine("najwyzszy stopien wierzcholka: {0}", max_stopien);
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

        public podtablica[] stworz_tablice_podtablic()  //pkt. 3 DONE
        {
            podtablica[] temp_tablica_podtablic = new podtablica[n];
            for (int i = 0; i < n; i++)
            {
                int[] pomoc = new int[1]; //tablica pomocnicza aby pamietac do jakch wierzcholkow dany wierzcholek sie laczy
                pomoc[0] = i;
                for (int j = 0; j < n; j++)
                {
                    if (tab_polaczen[i, j] == 1)
                    {
                        Array.Resize<int>(ref pomoc, (pomoc.GetLength(0) + 1));   //powiekszamy tablice pomoc o 1.
                        pomoc[(pomoc.GetLength(0) - 1)] = j;                //wrzucamy nr wierzcholka do pomoc
                    }
                }
                temp_tablica_podtablic[i] = new podtablica(pomoc.GetLength(0), max_stopien+1, pomoc);
            }
            return temp_tablica_podtablic;
        }

        public void dobieraj_kolory(podtablica[] tabl_podtablic)    //pkt. 4 DONE
        {
           bool czy_jest, nadany;
           for(int i=0; i<n; i++)   //przejscie po wszystkich tabl_podtablic
           {
               nadany = false;
               for (int k = 0; k < max_stopien + 1; k++)  //przejscie po tablicy "w dol" od sprawdzanego wierzch
               {
                   czy_jest = false;
                   for(int j=0; j<tabl_podtablic[i].tablica_numerów_wierzchołków.GetLength(0); j++)   //przejscie po wszystkich wierzcholkach polaczonych
                   {
                   //Console.WriteLine("J:{0}", j);
                       if (tabl_podtablic[i].tablic_wlasciwa[j, k] == 1)
                       {
                           czy_jest = true;
                           //Console.WriteLine("JEEEST");
                       }     
                   }
                   if (czy_jest == false && nadany == false)
                   {
                       //nadaj wierzch i, kolor k
                       tabl_podtablic[i].tablic_wlasciwa[0, k] = 1;
                       nadany = true;
                       // uaktualnij dla wszystkich pozostalych
                       // przejdz po wszystkich wierzcholkach i kiedy ich tablica nr wierzch zawiera ten wierzch
                       // przejdz do tego wierzcholka w tablicy wlasciwej i zmien jego kolor
                       for(int w=0; w<n; w++)
                       {
                           if (w == i)
                               continue;
                           if (tabl_podtablic[w].tablica_numerów_wierzchołków.Contains(i))
                                tabl_podtablic[w].tablic_wlasciwa[Array.IndexOf(tabl_podtablic[w].tablica_numerów_wierzchołków, i), k] = 1;
                       }
                   }
               }
           }

            // STARE KOMENTARZE, MOŻE KIEDYŚ SIĘ PRZYDA
            /*
                         if(tabl_podtablic[tabl_podtablic[i].tablica_numerów_wierzchołków[j]].tablica_numerów_wierzchołków.Contains(i) && k==0)
                         {
                             Console.WriteLine("tab podtablic {0} zawiera {1}", tabl_podtablic[i].tablica_numerów_wierzchołków[j], i);
                             tabl_podtablic[tabl_podtablic[i].tablica_numerów_wierzchołków[j]].tablic_wlasciwa[Array.IndexOf(tabl_podtablic[tabl_podtablic[i].tablica_numerów_wierzchołków[j]].tablica_numerów_wierzchołków, i), k] = 1;

                         }
                         */
            /*
                    if (tabl_podtablic[j].tablica_numerów_wierzchołków.Contains(i) && k == 0)
                    {
                        Console.WriteLine("tabl podtablic {0} zawiera {1}", j, i);
                        tabl_podtablic[j].tablic_wlasciwa[Array.IndexOf(tabl_podtablic[j].tablica_numerów_wierzchołków, i), k] = 1;
                        //tabl_podtablic[i].tablic_wlasciwa[j,k]=1;
                    }*/

            //if(tabl_podtablic[i].tablic_wlasciwa[j, k]==0)   //jak jest 0 to probuj po kolei nadac kolor
            //if (i==0)
            //tabl_podtablic[i].tablic_wlasciwa[j, k] = 1;
            //
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pw_k_grafd
{
    class podtablica
    {
        public int[,] tablic_wlasciwa;
        public int[] tablica_numerów_wierzchołków; //skoro nie mamy nazw to moze tak sobie oznaczac ktora tablica jest od czego?. Inaczej skąd wiemy które pole jest od czego?

        public podtablica(int ile_polaczen, int ile_kolorow, int[] numery_wierzchołków)
        {
            tablic_wlasciwa = new int[ile_polaczen, ile_kolorow];
            tablica_numerów_wierzchołków = new int[numery_wierzchołków.GetLength(0)];

            for (int i = 0; i < ile_polaczen; i++) //inicjalizacja, aby nie miec niespodzianki pt. nullreference
            {
                for (int j = 0; j < ile_kolorow; j++)
                {
                    tablic_wlasciwa[i, j] = 0;
                }
                tablica_numerów_wierzchołków[i] = numery_wierzchołków[i];
            }
        }

        public void wypisz()
        {
            for (int i = 0; i < tablica_numerów_wierzchołków.GetLength(0); i++)
            {
                Console.Write(tablica_numerów_wierzchołków[i] + " \t");
            }
            Console.Write("\n");
            for (int j = 0; j < tablic_wlasciwa.GetLength(1); j++)
            {
                for (int i = 0; i < tablic_wlasciwa.GetLength(0); i++)
                {
                    Console.Write(tablic_wlasciwa[i, j] + "\t");
                }
                Console.Write("\n");
            }
        }

    }
}
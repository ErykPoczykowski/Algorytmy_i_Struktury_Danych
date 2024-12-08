using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sortowania_kol
{
    public partial class Form1 : Form
    {
        private int[] tab = new int[10];
        public Form1()
        {
            InitializeComponent();
        }

        private void generuj_Click(object sender, EventArgs e)
        {
            wynik.Text = string.Empty;
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                tab[i] = rnd.Next(1, 100);
            }
            wynik.Text = string.Join(",", tab);

        }

        private void Bubble_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = 1; j < tab.Length; j++)
                {
                    if (tab[j - 1] > tab[j])
                    {
                        var temp = tab[j - 1];
                        tab[j - 1] = tab[j];
                        tab[j] = temp;
                    }

                }
            }
            wynik.Text = string.Join(",", tab);
        }

        private void Insertion_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < tab.Length; i++)
            {
                var klucz = tab[i];
                for (int j = i - 1; j >= 0;)
                {
                    if (klucz < tab[j])
                    {
                        tab[j + 1] = tab[j];
                        j--;
                        tab[j + 1] = klucz;
                    }
                    else break;
                }
            }
            wynik.Text = string.Join(",", tab);
        }

        private void Selection_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tab.Length - 1; i++)
            {
                var min = i;
                for (int j = i + 1; j < tab.Length; j++)
                {
                    if (tab[j] < tab[min])
                    {
                        min = j;
                    }
                }
                var temp = tab[min];
                tab[min] = tab[i];
                tab[i] = temp;
            }
            wynik.Text = string.Join(",", tab);
        }
        private static int Maks(int[] tab)
        {
            int max = tab[0];
            for(int i = 0;i<tab.Length;i++)
            {
                if (tab[i]> max)
                {
                    max = tab[i];
                }
            }
            return max;

        }
        private void Counting_Click_1(object sender, EventArgs e)
        {
            var max = Maks(tab);
            var wyst = new int[max + 1];
            for (int i = 0; i < max + 1; i++)
            {
                wyst[i] = 0;
            }
            for (int i = 0; i < tab.Length; i++)
            {
                wyst[tab[i]]++;
            }
            for (int i = 0, j = 0; i <= max; i++)
            {
                while (wyst[i] > 0)
                {
                    tab[j] = i;
                    j++;
                    wyst[i]--;
                }
            }
            wynik.Text = string.Join(",", tab);
        }

        private void Quick_Click(object sender, EventArgs e)
        {
            Quick_sort(tab,0,tab.Length-1);
            wynik.Text = string.Join(",", tab);
        }
        public int[] Quick_sort(int[] tab, int lewy, int prawy)
        {
            var i = lewy;
            var j = prawy;
            var pivot = tab[lewy];
            while (i <= j)
            {
                while (tab[i] < pivot)
                {
                    i++;
                }

                while (tab[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = tab[i];
                    tab[i] = tab[j];
                    tab[j] = temp;
                    i++;
                    j--;
                }
            }

            if (lewy < j)
                Quick_sort(tab, lewy, j);
            if (i < prawy)
                Quick_sort(tab, i, prawy);
            return tab;
        }
    }
}

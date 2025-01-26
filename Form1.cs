using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                tab[i] = rnd.Next(-100, 100);
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
                for (int j = i - 1; j >= 0; j--)
                {
                    if (klucz < tab[j])
                    {
                        tab[j + 1] = tab[j];
                        tab[j] = klucz;
                    }
                    else break;
                }
            }
            wynik.Text = string.Join(",", tab);
        }

        private void Counting_Click_1(object sender, EventArgs e)
        {
            int min = int.MaxValue, max = int.MinValue;

            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] < min)
                {
                    min = tab[i];
                }

                if (tab[i] > max)
                {
                    max = tab[i];
                }
            }

            int[] counts = new int[max - min + 1];

            for (int i = 0; i < tab.Length; i++)
            {
                counts[tab[i] - min]++;
            }

            int k = 0;

            for (int j = min; j <= max; j++)
            {
                for (int i = 0; i < counts[j - min]; i++)
                {
                    tab[k++] = j;
                }
            }
            wynik.Text = string.Join(",", tab);
        }


        private void Quick_Click(object sender, EventArgs e)
        {
            Quick_sort(tab, 0, tab.Length - 1);
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
                    var temp = tab[i];
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

        private void merge_Click(object sender, EventArgs e)
        {
            MergeSort(tab);
            wynik.Text = string.Join(",", tab);
        }
        public static void MergeSort(int[] tab)
        {
            if (tab.Length <= 1)
                return;

            int mid = tab.Length / 2;
            int[] lewy = new int[mid];
            int[] prawy = new int[tab.Length - mid];

            Array.Copy(tab, 0, lewy, 0, mid);
            Array.Copy(tab, mid, prawy, 0, tab.Length - mid);

            MergeSort(lewy);
            MergeSort(prawy);
            Merge(tab, lewy, prawy);
        }

        private static void Merge(int[] tab, int[] lewy, int[] prawy)
        {
            int i = 0, j = 0, k = 0;

            while (i < lewy.Length && j < prawy.Length)
            {
                if (lewy[i] <= prawy[j])
                {
                    tab[k++] = lewy[i++];
                }
                else
                {
                    tab[k++] = prawy[j++];
                }
            }

            while (i < lewy.Length)
            {
                tab[k++] = lewy[i++];
            }

            while (j < prawy.Length)
            {
                tab[k++] = prawy[j++];
            }
        }
    }
}

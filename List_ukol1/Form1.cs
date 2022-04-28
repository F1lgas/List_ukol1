using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace List_ukol1
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        List<int> cisla = new List<int>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private bool Prvocislo(int cislo)
        {
            double cislo2 = cislo / 2;
            bool prvocislo = true;
            for (int i = 2; i <= cislo2; i++)
            {
                if (cislo % i == 0)
                {
                    prvocislo = false;
                }
            }

            if (prvocislo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Vypis(List<int> list, ListBox listbox)
        {
            listbox.Items.Clear();
            listBox2.Items.Clear();

            foreach (int item in list)
            {
                listbox.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cisla.Clear();

            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                int cislo = rnd.Next(19, 31);
                cisla.Add(cislo);
            }

            Vypis(cisla, listBox1);

            foreach (int cislo in cisla)
            {
                if (listBox2.Items.Contains(cislo) == false)
                {
                    listBox2.Items.Add(cislo);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int max = cisla.Max();
            int prvnimax = 1;
            int n = Convert.ToInt32(textBox1.Text);

            for (int i = 0; i < n; i++)
            {
                if (cisla[i] == max)
                {
                    prvnimax = i;
                    break;
                }
            }

            bool je = false;
            int prvcislo = 0;

            foreach (int cislo in cisla)
            {
                if (Prvocislo(cislo) == true)
                {
                    je = true;
                    prvcislo = cislo;
                    break;
                }
            }

            int pozicemax = cisla.LastIndexOf(max);

            if (je == true)
            {
                MessageBox.Show("Pořadí prvního největšího čísla je " + (prvnimax + 1) + " a pořadí posledního je " + (pozicemax + 1) + Environment.NewLine + "Aritmetrický průměr prvků v listu je " + cisla.Average() + Environment.NewLine + "První prvočíslo je " + prvcislo);
            }
            else
            {
                MessageBox.Show("Pořadí prvního největšího čísla je " + (prvnimax + 1) + " a pořadí posledního je " + (pozicemax + 1) + Environment.NewLine + "Aritmetrický průměr prvků v listu je " + cisla.Average() + Environment.NewLine + "V listu nejsou žádná prvočísla");
            }
        }
    }
}

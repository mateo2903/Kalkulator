using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class KalkulatorForm : Form
    {
        private bool Rezultat;
        private static bool GreskaZarez;

        private readonly List<String> Nedozvoljeni = new List<String>()
        {
            "(*",
            "*)",
            "(/",
            "/)",
            "-)",
            "+)",

            "*/",
            "-*",
            "+*",
            "/*",
            "**",

            "-/",
            "+/",
            "//",

            "-+",
            "+-",
            "++",

            "--",

            ",)",
            ",(",
            ",*",
            ",/",
            ",+",
            ",-",
        };
        public KalkulatorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Rezultat)
            { 
                textBox1.Text = "1";
                Rezultat = false;
            }
            else
            {
                textBox1.Text += "1";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Rezultat)
            {
                textBox1.Text = "2";
                Rezultat = false;
            }
            else
            {
                textBox1.Text += "2";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Rezultat)
            {
                textBox1.Text = "3";
                Rezultat = false;
            }
            else
            {
                textBox1.Text += "3";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Rezultat)
            {
                textBox1.Text = "4";
                Rezultat = false;
            }
            else
            {
                textBox1.Text += "4";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Rezultat)
            {
                textBox1.Text = "5";
                Rezultat = false;
            }
            else
            {
                textBox1.Text += "5";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Rezultat)
            {
                textBox1.Text = "6";
                Rezultat = false;
            }
            else
            {
                textBox1.Text += "6";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Rezultat)
            {
                textBox1.Text = "7";
                Rezultat = false;
            }
            else
            {
                textBox1.Text += "7";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Rezultat)
            {
                textBox1.Text = "8";
                Rezultat = false;
            }
            else
            {
                textBox1.Text += "8";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Rezultat)
            {
                textBox1.Text = "9";
                Rezultat = false;
            }
            else
            {
                textBox1.Text += "9";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (Rezultat)
            {
                textBox1.Text = "0";
                Rezultat = false;
            }
            else
            {
                textBox1.Text += "0";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (Rezultat)
            {
                textBox1.Text = "(";
                Rezultat = false;
            }
            else
            {
                textBox1.Text += "(";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (Rezultat)
            {
                textBox1.Text = ")";
                Rezultat = false;
            }
            else
            {
                textBox1.Text += ")";
            }
        }

        private void buttonJednako_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Count(c => c == '(') != textBox1.Text.Count(c => c == ')'))
            {
                MessageBox.Show("Zagrade nisu ispravno postavljene");
            }
            else if (Nedozvoljeni.Any(s => textBox1.Text.Contains(s)))
            {
                MessageBox.Show("Operacije nisu ispravno zadane");
            }
            else
            {
                double rez = IzvrsiSaZagradama(textBox1.Text);
                if (!GreskaZarez)
                {
                    textBox1.Text = rez.ToString();
                    Rezultat = true;
                }
            }
        }

        private static double Izvrsi(String zadatak)
        {
            int i;
            if ((i = zadatak.IndexOf('+')) != -1 && ( i== 0 || (zadatak[i-1] != '-' && zadatak[i - 1] != '*' && zadatak[i - 1] != '/')))
                return Izvrsi(zadatak.Substring(0, i)) + Izvrsi(zadatak.Substring(i + 1));
            else if ((i = zadatak.IndexOf('-')) != -1 && ( i == 0 || (zadatak[i - 1] != '+' && zadatak[i - 1] != '*' && zadatak[i - 1] != '/')))
                return Izvrsi(zadatak.Substring(0, i)) - Izvrsi(zadatak.Substring(i + 1));
            else if ((i = zadatak.IndexOf('/')) != -1)
                return Izvrsi(zadatak.Substring(0, i)) / Izvrsi(zadatak.Substring(i + 1));
            else if ((i = zadatak.IndexOf('*')) != -1)
                return Izvrsi(zadatak.Substring(0, i)) * Izvrsi(zadatak.Substring(i + 1));
            else
                if(zadatak.Count(c => c == ',') > 1)
                {
                    MessageBox.Show("Jedan broj ne može imati dva zareza u sebi.");
                    GreskaZarez = true;
                    return 0;
                }
            if(zadatak.Trim() == string.Empty)
            {
                return 0;
            }
            return double.Parse(zadatak.Trim());
        }

        private static double IzvrsiSaZagradama(String zadatak)
        {
            int otvarajuca = zadatak.LastIndexOf('(');
            if (otvarajuca != -1)
            {
                String izaOtvoreneZagrade = zadatak.Substring(otvarajuca + 1);
                int zatvarajuca = izaOtvoreneZagrade.IndexOf(')');
                return IzvrsiSaZagradama(zadatak.Substring(0, otvarajuca) + Izvrsi(izaOtvoreneZagrade.Substring(0, zatvarajuca)) + izaOtvoreneZagrade.Substring(zatvarajuca + 1));
            }
            else
            {
                return Izvrsi(zadatak);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (Rezultat)
                Rezultat = false;
            textBox1.Text += "+";

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (Rezultat)
                Rezultat = false;
            textBox1.Text += "-";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (Rezultat)
                Rezultat = false;
            textBox1.Text += "*";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (Rezultat)
                Rezultat = false;
            textBox1.Text += "/";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (Rezultat)
            {
                textBox1.Text = ",";
                Rezultat = false;
            }
            else
            {
                textBox1.Text += ",";
            }
        }
    }
}

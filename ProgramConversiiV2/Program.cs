// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            p1();
        }
        static void p1()
        {
            Console.WriteLine("b1 b2 numar");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string[] t = Console.ReadLine().Split(' ');
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            int b1 = int.Parse(t[0]);
            int b2 = int.Parse(t[1]);
            char[] c = t[2].ToCharArray(); 
            if (verificarebaza(b1, c) == false)
            {
                Console.WriteLine("Numar scris incorect sau baza este mai mare decat 16 sau mai mica decat 2");
                Thread.Sleep(1500);
                Console.Clear();
                p1();
            }
            if (b1 == 10 && b2 != 10)
            {
                string x=Tranfs10inB(b2, c);
                Console.WriteLine(x);
            }
            else if (b1 != 10 && b2 == 10)
            {
                string x1=TranfsBin10(b1, c);
                Console.WriteLine(x1);
            }
            else if (b1 == b2)
            {
                Console.WriteLine(t[2]);
            }
            else if (b1 != 10 && b2 != 10)
            {
                string x2 = TranfsBin10(b1, c);
                for(int i=0;i<x2.Length;i++)
                {
                    if (x2[i] == '(') 
                    {
                        x2 = x2.Remove(i, 1);
                    }
                    if (x2[i]== ')')
                    {
                        x2 = x2.Remove(i, 1);
                    }
                }
                char[] c2 = x2.ToCharArray();
                x2 = Tranfs10inB(b2, c2);
                Console.WriteLine(x2);
            }
        }

        private static string Tranfs10inB(int b, char[] c)
        {
            //12.2 - > 1100.(0011)
            List<int> resturi1 = new List<int>();
            string[] t = new string(c).Split('.');
            decimal numar = decimal.Parse(c);
            int parteintreaga = int.Parse(t[0]);
            decimal partefrac = numar - Math.Truncate(numar);
            while(parteintreaga > 0)
            {
                int r = parteintreaga % b;
                parteintreaga /= b;
                resturi1.Add(r);
            }
            string nrintreg = String.Empty;
            foreach(int i in resturi1)
            {
                if (i == 10)
                {
                    nrintreg = nrintreg + "A";
                }
                else if (i == 11)
                {
                    nrintreg = nrintreg + "B";
                }
                else if (i == 12)
                {
                    nrintreg = nrintreg + "C";
                }
                else if (i == 13)
                {
                    nrintreg = nrintreg + "D";
                }
                else if (i == 14)
                {
                    nrintreg = nrintreg + "E";
                }
                else if (i == 15)
                {
                    nrintreg = nrintreg + "F";
                }
                else
                {
                    nrintreg = nrintreg + i.ToString();
                }
            }
            nrintreg = Reverse(nrintreg);

            //partea fractionara

            string nrfrac = "";
            List<decimal> numere = new List<decimal>();
            List<decimal> cifre2 = new List<decimal>();
            numere.Add(partefrac);
            bool dude = false;
            decimal test;
            decimal pion = 0;
            do
            {
                test = partefrac * b;
                cifre2.Add((int)Math.Truncate(test));
                if (!numere.Contains(test))
                {
                    numere.Add(test);
                }
                else
                {
                    pion = partefrac;
                    dude = true;
                    break;
                }
                partefrac = test - Math.Truncate(test);
            } while (test % 1 != 0);
            if (dude==false)
            {
                foreach (var item in cifre2) 
                {
                    if (item == 10)
                    {
                        nrfrac = nrfrac + "A";
                    }
                    else if (item == 11)
                    {
                        nrfrac = nrfrac + "B";
                    }
                    else if (item == 12)
                    {
                        nrfrac = nrfrac + "C";
                    }
                    else if (item == 13)
                    {
                        nrfrac = nrfrac + "D";
                    }
                    else if (item == 14)
                    {
                        nrfrac = nrfrac + "E";
                    }
                    else if (item == 15)
                    {
                        nrfrac = nrfrac + "F";
                    }
                    else
                    {
                        nrfrac = nrfrac + item.ToString();
                    }
                }
            }
            //1111011.0101000111101011100    mine B)
            //1111011.01010001111010111      Base Converter from internet
            else
            {
                for (int i = 0; i < numere.Count - 1; i++)
                {
                    if (numere[i] - Math.Truncate(numere[i]) == pion)
                    {
                        nrfrac = nrfrac + "(";
                    }
                    if (cifre2[i] == 10)
                    {
                        nrfrac = nrfrac + "A";
                    }
                    else if (cifre2[i] == 11)
                    {
                        nrfrac = nrfrac + "B";
                    }
                    else if (cifre2[i] == 12)
                    {
                        nrfrac = nrfrac + "C";
                    }
                    else if (cifre2[i] == 13)
                    {
                        nrfrac = nrfrac + "D";
                    }
                    else if (cifre2[i] == 14)
                    {
                        nrfrac = nrfrac + "E";
                    }
                    else if (cifre2[i] == 15)
                    {
                        nrfrac = nrfrac + "F";
                    }
                    if (cifre2[i] < 10)
                    {
                        nrfrac = nrfrac + cifre2[i].ToString();
                    }
                }
                if(nrfrac.Contains("("))
                {
                    nrfrac = nrfrac + ")";
                }
            }
            if(nrfrac.StartsWith("0"))
            {
                nrfrac.Remove(0, 1);
            }
            return nrintreg + "." + nrfrac;
        }

        private static string Reverse(string nrintreg)
        {
            char[] c = nrintreg.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        }

        private static string TranfsBin10(int b, char[] c)
        {
            if (c.Contains('.'))
            {
                List<double> lista = new List<double>();
                Dictionary<char, int> dictionar = new Dictionary<char, int>();
                //dictionar.Add('A', 10); dictionar.Add('B', 11); dictionar.Add('C', 12); dictionar.Add('D', 13); dictionar.Add('E', 14); dictionar.Add('F', 15);
                string[] t = new string(c).Split('.');
                char[] parteintreaga = t[0].ToCharArray();
                char[] partefrac = t[1].ToCharArray();
                double r = 0;
                for (int i = 0; i < parteintreaga.Length; i++)
                {
                    if (parteintreaga[i] == 'A')
                    {
                        r = r + Convert.ToInt32(10 * Math.Pow(b, parteintreaga.Length - 1 - i));
                    }
                    else if (parteintreaga[i] == 'B')
                    {
                        r = r + Convert.ToInt32(11 * Math.Pow(b, parteintreaga.Length - 1 - i));
                    }
                    else if (parteintreaga[i] == 'C')
                    {
                        r = r + Convert.ToInt32(12 * Math.Pow(b, parteintreaga.Length - 1 - i));
                    }
                    else if (parteintreaga[i] == 'D')
                    {
                        r = r + Convert.ToInt32(13 * Math.Pow(b, parteintreaga.Length - 1 - i));
                    }
                    else if (parteintreaga[i] == 'E')
                    {
                        r = r + Convert.ToInt32(14 * Math.Pow(b, parteintreaga.Length - 1 - i));
                    }
                    else if (parteintreaga[i] == 'F')
                    {
                        r = r + Convert.ToInt32(15 * Math.Pow(b, parteintreaga.Length - 1 - i));
                    }
                    else
                    {
                        r = r + Convert.ToInt32(int.Parse(parteintreaga[i].ToString()) * Math.Pow(b, parteintreaga.Length - 1 - i));
                    }
                }
                double numarator = Math.Pow(b, partefrac.Length);
                double numitor = 0;
                for (int i = 0; i < partefrac.Length; i++)
                {
                    numitor = numitor + Convert.ToInt32(int.Parse(partefrac[i].ToString()) * Math.Pow(b, partefrac.Length - 1 - i));
                }
                string numar = fractie((int)numitor, (int)numarator);
                if (numar == "(0)")
                {
                    numar = "0";
                }
                string r1 = r.ToString();
                string r2 = numar.ToString();
                r1 = r1 + "." + r2;
                return r1;
            }
            else
            {
                string t = new string(c) + ".0";
                char[] x1 = t.ToCharArray();
                return TranfsBin10(b, x1);
            }
        }

        private static string fractie(int numitor, int numarator)
        {
            int m = numitor, n = numarator;
            int parteInt, parteFract;
            parteInt = (int)(m / n); // 0
            parteFract = m % n; // 13
            int cifra, rest;
            List<int> resturi = new List<int>();
            List<int> cifre = new List<int>();
            resturi.Add(parteFract);
            bool periodic = false;
            do
            {
                cifra = parteFract * 10 / n;
                cifre.Add(cifra);
                rest = parteFract * 10 % n;
                if (!resturi.Contains(rest))
                {
                    resturi.Add(rest);
                }
                else
                {
                    periodic = true;
                    break;
                }
                parteFract = rest;
            } while (rest != 0);
            string x1 = String.Empty;
            string y1 = String.Empty;
            if (!periodic)
            {
                foreach (var item in cifre)
                {
                    x1 = x1 + item.ToString();
                }
                if(x1.StartsWith('0'))
                {
                    x1.Remove(0, 1);
                }
                return x1;
            }
            else
            {
                for (int i = 0; i < resturi.Count; i++)
                {
                    if (resturi[i] == rest)
                    {
                        y1 = y1 + "(";
                    }
                    y1 = y1 + cifre[i].ToString();
                }
                y1 = y1 + ")";
                if(y1.StartsWith('0'))
                {
                    y1.Remove(0, 1);
                }
                return y1;
            }
        }

        private static bool verificarebaza(int b, char[] c)
        {
            List<char> lista = new List<char>();
            char[] lol = "ABCDEF".ToCharArray();
            char[] lol1 = "GHIJKLMNOPQRSTUVWXYZ@|,;:'#[]{}-_`¬".ToCharArray();
            if(b<2)
            {
                return false;
            }
            if (b < 10)
            {
                for (int i = 0; i < c.Length; i++)
                {
                    if (lol.Contains(c[i]) || lol1.Contains(c[i]))
                    {
                        return false;
                    }
                }
            }
            else if (b > 9 && b < 17)
            {
                for (int i = 0; i < c.Length; i++)
                {
                    if (lol1.Contains(c[i]))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}


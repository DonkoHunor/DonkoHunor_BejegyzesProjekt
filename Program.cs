using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace DonkoHunor_BejegyzesProjekt
{
    internal class Program
    {
        static List<Bejegyzes> list = new List<Bejegyzes>();
        
        static Random rnd = new Random();

        static void Bekeres()
        {
            Console.Write("Adjon meg egy darabszámot! : ");
            string db = Console.ReadLine();
            Console.WriteLine();
            while (!int.TryParse(db, out int result))
            {
                Console.WriteLine("Nem jó számot adott meg!");
                Console.Write("Adjon meg egy darabszámot! : ");
                db = Console.ReadLine();
                Console.WriteLine();
            }

            for (int i = 0; i < int.Parse(db); i++) 
            {
                Console.Write("Adja meg a tartalmat: ");
                string tartalom = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Adja meg a szerző nevét: ");
                string szerzo = Console.ReadLine();
                Console.WriteLine();
                list.Add(new Bejegyzes(szerzo,tartalom));
            }
        }

        static void Beolvas()
        {
            StreamReader sr = new StreamReader("bejegyzesek.csv");
            while (!sr.EndOfStream)
            {
                string[] db = sr.ReadLine().Split(';');
                list.Add(new Bejegyzes(db[0], db[1]));
            }
            sr.Close();
        }

        static void RandomLike()
        {
            for (int i = 0; i < list.Count*20; i++)
            {
                list[rnd.Next(0,list.Count)].Like();
            }
        }

        static void SzovegModositas()
        {
            Console.Write("Adjon meg egy szöveget! : ");
            string szoveg = Console.ReadLine();
            list[1].Tartalom = szoveg;
        }

        static void Legnepszerubb()
        {
            int index = -1;
            int max = int.MinValue;

            for (int i = 0;i < list.Count;i++)
            {
                if (list[i].Likeok > max)
                {
                    max = list[i].Likeok;
                    index = i;
                }
            }

            Console.WriteLine($"A legnépszerűbb bekegyzés: {list[index].ToString()}\nLikeok száma: {max}");
        }

        static void TobbLike(int like)
        {
            bool van = false;

            foreach (var item in list)
            {
                if (item.Likeok > like)
                {
                    van = true;
                }
            }

            if (van) 
            {
                Console.WriteLine($"Van olyan bejegyzés ami {like}-nél/nál több likot kapott.");
            }
            else
            {
                Console.WriteLine($"Nincs olyan bejegyzés ami {like}-nél/nál több likot kapott.");
            }
        }

        static void Main(string[] args)
        {  
            list.Add(new Bejegyzes("Szun-ce","Dying is gay."));
            list.Add(new Bejegyzes("Balázs Dániel","Az én túróm is szaftos."));
                        
            Bekeres();

            Beolvas();

            RandomLike();

            SzovegModositas();

            Console.WriteLine();
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine();
            }
            Console.WriteLine();

            Legnepszerubb();

            Console.WriteLine();
            TobbLike(35);

            Console.ReadKey();
        }
    }
}

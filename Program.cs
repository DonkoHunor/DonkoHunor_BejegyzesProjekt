using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkoHunor_BejegyzesProjekt
{
    internal class Program
    {
        static List<Bejegyzes> list = new List<Bejegyzes>();
        
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

        static void Main(string[] args)
        {            
            list.Add(new Bejegyzes("Balázs Dániel","Az én túróm is szaftos."));
            list.Add(new Bejegyzes("Szun-ce","Dying is gay."));
            
            Bekeres();
            
            Console.ReadKey();
        }
    }
}

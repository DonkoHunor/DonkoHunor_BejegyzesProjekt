using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkoHunor_BejegyzesProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Bejegyzes> list = new List<Bejegyzes>();
            list.Add(new Bejegyzes("Balázs Dániel","Az én túróm is szaftos."));
            list.Add(new Bejegyzes("Szun-ce","Dying is gay."));
            Console.ReadKey();
        }
    }
}

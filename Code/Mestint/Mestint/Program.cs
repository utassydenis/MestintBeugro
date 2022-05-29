using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mestint
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Csucs startCsucs;
            GrafKereso kereso;
            Console.WriteLine("Teszt");
            startCsucs = new Csucs(new GyumolcsAllapot(13, 46, 59));

            kereso = new BackTrack(startCsucs,true);
            kereso.megoldasKiirasa(kereso.Kereses());
            Console.Read();
            Console.WriteLine("Teszt2");
            kereso = new MelysegiKereses(startCsucs,true);
            kereso.megoldasKiirasa(kereso.Kereses());

        }
    }
}

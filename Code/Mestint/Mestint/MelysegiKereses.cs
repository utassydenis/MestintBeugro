using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mestint
{
    internal class MelysegiKereses : GrafKereso
    {
        Stack<Csucs> Nyilt;
        List<Csucs> Zart;
        bool korFigyeles;

        public MelysegiKereses(Csucs startCsucs, bool korFigyeles): base(startCsucs)
        {
            Nyilt = new Stack<Csucs>();
            Nyilt.Push(startCsucs);
            Zart = new List<Csucs>();
            this.korFigyeles = korFigyeles;
        }

        public MelysegiKereses(Csucs startCsucs) : this(startCsucs, true)
        {

        }

        public override Csucs Kereses()
        {
            if (korFigyeles)
            {
                return TerminalisCsucsKereses();
            }
            return TerminalisCsucsKeresesGyorsan();
        }

        private Csucs TerminalisCsucsKereses()
        {
            while(Nyilt.Count != 0)
            {
                Csucs C = Nyilt.Pop();
                List<Csucs> ujCsucsok = C.Kiterjesztes();
                foreach(Csucs D in ujCsucsok)
                {
                    if (D.TerminelisCsucsE())
                    {
                        return D;
                    }
                    if(!Zart.Contains(D) && !Nyilt.Contains(D))
                    {
                        Nyilt.Push(D);
                    }
                }
                Zart.Add(C);
            }
            return null;
        }
        private Csucs TerminalisCsucsKeresesGyorsan()
        {
            while(Nyilt.Count != 0)
            {
                Csucs C = Nyilt.Pop();
                List<Csucs> ujCsucsok = C.Kiterjesztes();
                foreach(Csucs D in ujCsucsok)
                {
                    if (D.TerminelisCsucsE())
                    {
                        return D;
                    }
                    Nyilt.Push(D);
                }
            }
            return null;
        }
    }
}

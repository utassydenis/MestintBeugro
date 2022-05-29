using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mestint
{
    internal class BackTrack : GrafKereso
    {
        int korlat;
        bool emlekezikE;

        public BackTrack(Csucs startCsucs, int korlat, bool emlekezikE) : base(startCsucs)
        {
            this.korlat = korlat;
            this.emlekezikE = emlekezikE;
        }
        public BackTrack(Csucs startCsucs) : this(startCsucs, 0, false)
        {

        }
        public BackTrack(Csucs startCsucs, int korlat) : this(startCsucs, korlat, false)
        {

        }
        public BackTrack(Csucs startCsucs, bool emlekezikE) : this(startCsucs, 0, emlekezikE)
        {

        }
        public override Csucs Kereses()
        {
            return Kereses(GetStartCSucs());
        }

        private Csucs Kereses(Csucs aktCsucs)
        {
            int melyseg = aktCsucs.GetMelyseg();

            if(korlat > 0 && melyseg >= korlat)
            {
                return null;
            }
            Csucs aktSzulo = null;
            if (emlekezikE)
            {
                aktSzulo = aktCsucs.GetSzulo();
            }

            while(aktSzulo!= null)
            {
                if (aktCsucs.Equals(aktSzulo))
                {
                    return null;
                }
                aktSzulo = aktSzulo.GetSzulo();
            }
            if (aktCsucs.TerminelisCsucsE())
            {
                return aktCsucs;
            }
            for(int i = 0; i < aktCsucs.OperatorokSzama(); i++)
            {
                Csucs ujCsucs = new Csucs(aktCsucs);
                if (ujCsucs.SzuperOperator(i))
                {
                    Csucs terminalis = Kereses(ujCsucs);
                    if(terminalis != null)
                    {
                        return terminalis;
                    }
                }
            }
            return null;
        }
    }
}

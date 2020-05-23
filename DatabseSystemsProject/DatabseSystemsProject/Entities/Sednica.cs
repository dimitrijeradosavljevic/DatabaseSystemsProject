using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabseSystemsProject.Entities
{
    public abstract class Sednica
    {
        public virtual int Id { get; set; }
        public virtual int BrojSaziva { get; set; }
        public virtual int BrojZasedanja { get; set; }
        public virtual DateTime DatumPocetka { get; set; }
        public virtual DateTime DatumZavrsetka { get; set; }
        public virtual string TipSednice { get; set; }

        public virtual IList<RadniDan> RadniDani { get; set; }

        public Sednica()
        {
            RadniDani = new List<RadniDan>();
        }
    }

    public class RedovnaSednica : Sednica
    {

    }

    public class VanrednaSednica : Sednica
    {
        public virtual string TipVanredneSednice { get; set; }
        public virtual IList<NarodniPoslanik> Sazivaoci { get; set; }
       
        public VanrednaSednica() : base()
        {
            Sazivaoci = new List<NarodniPoslanik>();
        }
    }
}

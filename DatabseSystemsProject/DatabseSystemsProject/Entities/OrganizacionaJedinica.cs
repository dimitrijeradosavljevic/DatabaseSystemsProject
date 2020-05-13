using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabseSystemsProject.Entities
{
    public abstract class OrganizacionaJedinica
    {
        public virtual int Id { get; protected set; }
        public virtual string Tip { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string TipRadnogTela { get; set; }

        public virtual NarodniPoslanik Predsednik { get; set; }
        public virtual NarodniPoslanik Zamenik { get; set; }

        public virtual IList<NarodniPoslanik> Clanovi { get; set; }

        public virtual IList<SluzbenaProstorija> SluzbeneProstorije { get; set; }

        public OrganizacionaJedinica()
        {
            Clanovi = new List<NarodniPoslanik>();

            SluzbeneProstorije = new List<SluzbenaProstorija>();
        }
    }

    public class PoslanickaGrupa : OrganizacionaJedinica
    {
    }

    public class RadnoTelo : OrganizacionaJedinica
    {
    }
}

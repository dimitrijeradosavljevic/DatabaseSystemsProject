using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabseSystemsProject.Entities
{
    public class Akt
    {
        public virtual int Id { get; protected set; }
        public virtual string TipAkta { get; set; }
        public virtual string TipPredlozioca { get; set; }
    }

    public class AktNarodnihPoslanika : Akt
    {
        public IList<NarodniPoslanik> Predlagaci { get; set; }
    }

    public class AktViseOd1500Biraca : Akt
    {
        public int BrojBiraca { get; set; }
    }

    public class AktVlade : Akt
    {
    }
}

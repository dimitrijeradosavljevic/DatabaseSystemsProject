using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabseSystemsProject.Entities
{
    class Akt
    {
        public int Id { get; set; }
        public string TipAkta { get; set; }
        public string TipPredlozioca { get; set; }
    }

    public class AktNarodnihPoslanika
    {
    }

    public class AktViseOd1500Biraca
    {
        public int BrojBiraca { get; set; }
    }

    public class AktVlade
    {
    }
}

﻿using System;
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

        public Akt()
        {

        }
    }

    public class AktNarodnihPoslanika : Akt
    {
        public virtual IList<NarodniPoslanik> Predlagaci { get; set; }

        public AktNarodnihPoslanika() : base()
        {
            Predlagaci = new List<NarodniPoslanik>();
        }
    }

    public class AktViseOd1500Biraca : Akt
    {
        public virtual int BrojBiraca { get; set; }

        public AktViseOd1500Biraca() : base()
        {

        }
    }

    public class AktVlade : Akt
    {
        public AktVlade() : base()
        {

        }
    }
}

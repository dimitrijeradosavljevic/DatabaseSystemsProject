using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabseSystemsProject.Entities;
using FluentNHibernate.Mapping;

namespace DatabseSystemsProject.Mappings
{
    class JePredlozioMap : ClassMap<JePredlozio>
    {
        public JePredlozioMap()
        {
            Table("JE_PREDLOZIO");

            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            References(x => x.NarodniPoslanik).Column("NARODNI_POSLANIK_ID");
            References(x => x.Akt).Column("AKT_ID");
        }
    }
}

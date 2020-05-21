using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DatabseSystemsProject.Entities;

namespace DatabseSystemsProject.Mappings
{
    class AktMap : ClassMap<Akt>
    {
        public AktMap()
        {
            Table("AKT");

            DiscriminateSubClassesOnColumn("TIP_PREDLOZIOCA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.TipAkta, "TIP");
        }
    }

    class AktNarodnihPoslanikaMap : SubclassMap<AktNarodnihPoslanika>
    {
        public AktNarodnihPoslanikaMap()
        {
            DiscriminatorValue("narodni poslanici");

            HasManyToMany(x => x.Predlagaci)
              .Table("JE_PREDLOZIO")
              .ParentKeyColumn("AKT_ID")
              .ChildKeyColumn("NARODNI_POSLANIK_ID")
              .Cascade.All()
              .Inverse();
        }
    }

    class AktVladeMap : SubclassMap<AktVlade>
    {
        public AktVladeMap()
        {
            DiscriminatorValue("vlada");
        }
    }

    class AktViseOd1500BiracaMap : SubclassMap<AktViseOd1500Biraca>
    {
        public AktViseOd1500BiracaMap()
        {
            DiscriminatorValue("biraci");

            Map(x => x.BrojBiraca, "BROJ_BIRACA");
        }
    }
}

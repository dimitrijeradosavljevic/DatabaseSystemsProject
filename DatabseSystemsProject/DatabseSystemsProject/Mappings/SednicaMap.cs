using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DatabseSystemsProject.Entities;

namespace DatabseSystemsProject.Mappings
{
    public class SednicaMap : ClassMap<Sednica>
    {
        public SednicaMap()
        {
            Table("SEDNICA");

            DiscriminateSubClassesOnColumn("TIP_SEDNICE");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.BrojSaziva, "BROJ_SAZIVA");
            Map(x => x.BrojZasedanja, "BROJ_ZASEDANJA");
            Map(x => x.DatumPocetka, "DATUM_POCETKA");
            Map(x => x.DatumZavrsetka, "DATUM_ZAVRSETKA");
        }       
    }

    public class RedovnaSednicaMap : SubclassMap<RedovnaSednica>
    {
        public RedovnaSednicaMap()
        {
            DiscriminatorValue("redovna");
        }
    }

    public class VanrednaSednicaMap : SubclassMap<VanrednaSednica>
    {
        public VanrednaSednicaMap()
        {
            DiscriminatorValue("vanredna");
            Map(x => x.TipVanredneSednice, "TIP_VANREDNE_SEDNICE");

            HasManyToMany(x => x.Sazivaci)
                .Table("JE_SAZVALO")
                .ParentKeyColumn("SEDNICA_ID")
                .ChildKeyColumn("NARODNI_POSLANIK_ID")
                .Cascade.All()
                .Inverse();
        }  
    }
}

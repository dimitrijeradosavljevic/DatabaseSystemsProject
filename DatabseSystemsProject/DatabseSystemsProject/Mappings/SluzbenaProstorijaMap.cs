using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DatabseSystemsProject.Entities;

namespace DatabseSystemsProject.Mappings
{
    class SluzbenaProstorijaMap : ClassMap<SluzbenaProstorija>
    {
        public SluzbenaProstorijaMap()
        {
            Table("SLUZBENA_PROSTORIJA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            Map(x => x.Sprat, "SPRAT");
            Map(x => x.Broj, "BROJ");

            HasManyToMany(x => x.OrganizacioneJedinice)
                .Table("JE_DODELJENA")
                .ParentKeyColumn("SLUZBENA_PROSTORIJA_ID")
                .ChildKeyColumn("ORGANIZACIONA_JEDINICA_ID")
                .Cascade.All();
        }
    }
}

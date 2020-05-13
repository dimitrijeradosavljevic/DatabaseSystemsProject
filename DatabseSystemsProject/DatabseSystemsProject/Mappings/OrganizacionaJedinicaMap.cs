using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DatabseSystemsProject.Entities;

namespace DatabseSystemsProject.Mappings
{
    class OrganizacionaJedinicaMap : ClassMap<OrganizacionaJedinica>
    {
        public OrganizacionaJedinicaMap()
        {
            Table("ORGANIZACIONA_JEDINICA");

            DiscriminateSubClassesOnColumn("TIP");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.TipRadnogTela, "TIP_RADNOG_TELA");

            References(x => x.Predsednik).Column("PREDSEDNIK_ID").LazyLoad();
            References(x => x.Zamenik).Column("ZAMENIK_ID").LazyLoad();

            HasManyToMany(x => x.Clanovi)
                .Table("JE_CLAN")
                .ParentKeyColumn("ORGANIZACIONA_JEDINICA_ID")
                .ChildKeyColumn("NARODNI_POSLANIK_ID")
                .Cascade.All();

            HasManyToMany(x => x.SluzbeneProstorije)
                .Table("JE_DODELJENA")
                .ParentKeyColumn("ORGANIZACIONA_JEDINICA_ID")
                .ChildKeyColumn("SLUZBENA_PROSTORIJA_ID")
                .Cascade.All()
                .Inverse();
        }
    }

    class PoslanickaGrupaMap : SubclassMap<PoslanickaGrupa>
    {
        public PoslanickaGrupaMap()
        {
            DiscriminatorValue("poslanicka grupa");
        }
    }

    class RadnoTeloMap : SubclassMap<RadnoTelo>
    {
        public RadnoTeloMap()
        {
            DiscriminatorValue("radno telo");
        }
    }
}

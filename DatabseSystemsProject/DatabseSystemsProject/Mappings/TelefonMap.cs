using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DatabseSystemsProject.Entities;

namespace DatabseSystemsProject.Mappings
{
    class TelefonMap : ClassMap<Telefon>
    {
        public TelefonMap()
        {
            Table("TELEFON");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.BrojTelefona, "TELEFON");

            References(x => x.NarodniPoslanik).Column("NARODNI_POSLANIK_ID").LazyLoad();
        }
    }
}

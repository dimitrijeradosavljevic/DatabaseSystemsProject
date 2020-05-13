using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabseSystemsProject.Entities
{
    public class SluzbenaProstorija
    {
        public virtual int Id { get; protected set; }
        public virtual int Sprat { get; set; }
        public virtual int Broj { get; set; }

        public virtual IList<OrganizacionaJedinica> OrganizacioneJedinice { get; set; }

        public SluzbenaProstorija()
        {
            OrganizacioneJedinice = new List<OrganizacionaJedinica>();
        }
    }
}

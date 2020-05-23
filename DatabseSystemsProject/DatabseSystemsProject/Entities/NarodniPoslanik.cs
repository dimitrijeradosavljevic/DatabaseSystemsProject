using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabseSystemsProject.Entities
{
    public class NarodniPoslanik
    {
        public virtual int Id { get; protected set; }
        public virtual int Jib { get; set; }
        public virtual Int64 Jmbg { get; set; }
        public virtual string LicnoIme { get; set; }
        public virtual string ImeRoditelja { get; set; }
        public virtual string Prezime { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual string MestoRodjenja { get; set; }
        public virtual string IzbornaLista { get; set; }
        public virtual string MestoStanovanja { get; set; }
        public virtual string AdresaStanovanja { get; set; }

        public virtual IList<Telefon> Telefoni { get; set; }


        public virtual IList<OrganizacionaJedinica> JePredsednik { get; set; }
        public virtual IList<OrganizacionaJedinica> JeZamenik { get; set; }
        public virtual IList<OrganizacionaJedinica> OrganizacioneJedinice { get; set; }
        public virtual IList<Akt> PredlozeniAkti { get; set; }
        public virtual IList<VanrednaSednica> SazvaneSednice { get; set; }

        public NarodniPoslanik()
        {
            Telefoni = new List<Telefon>();
            JePredsednik = new List<OrganizacionaJedinica>();
            JeZamenik = new List<OrganizacionaJedinica>();
            OrganizacioneJedinice = new List<OrganizacionaJedinica>();
            PredlozeniAkti = new List<Akt>();
            SazvaneSednice = new List<VanrednaSednica>();
        }
    }
}


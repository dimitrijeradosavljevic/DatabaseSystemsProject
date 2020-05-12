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

        public NarodniPoslanik()
        {

        }
    }
}

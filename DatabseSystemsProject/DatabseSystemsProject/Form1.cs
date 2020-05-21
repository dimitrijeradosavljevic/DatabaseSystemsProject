using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using DatabseSystemsProject.Entities;

namespace DatabseSystemsProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ShowExceptionData(Exception exception)
        {
            MessageBox.Show(
                "Exception message: " + exception.Message +
                "\nInner exception: " + exception.InnerException
            );
        }

        private void btnCreateNarodniPoslanik_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = new NarodniPoslanik()
                {
                    Jib = 845715,
                    Jmbg = 7539628414972,
                    LicnoIme = "N",
                    ImeRoditelja = "NP",
                    Prezime = "P",
                    DatumRodjenja = new DateTime(1971, 6, 9),
                    MestoRodjenja = "MR",
                    IzbornaLista = "IL",
                    MestoStanovanja = "MS",
                    AdresaStanovanja = "AS"
                };

                session.Save(narodniPoslanik);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnReadNarodniPoslanik_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(42);

                MessageBox.Show(narodniPoslanik.LicnoIme + ", adresa stanovanja: " + narodniPoslanik.AdresaStanovanja);

                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnUpdateNarodniPoslanik_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(42);

                narodniPoslanik.AdresaStanovanja = "Stahinjica Bana 223";

                session.Update(narodniPoslanik);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnDeleteNarodniPoslanik_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(72);

                session.Delete(narodniPoslanik);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnCreateStalnoZaposlen_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                StalnoZaposlen stalnoZaposlen = new StalnoZaposlen()
                {
                    Jib = 957683,
                    Jmbg = 7485963214568,
                    LicnoIme = "Kreiran kroz app",
                    ImeRoditelja = "Mika",
                    Prezime = "Mikic",
                    DatumRodjenja = new DateTime(1980, 4, 23),
                    MestoRodjenja = "Nis",
                    IzbornaLista = "Lista A",
                    MestoStanovanja = "Nis",
                    AdresaStanovanja = "Kralja Milutina",
                    Brk = 226475,
                    RsGodine = 2,
                    RsMeseci = 4,
                    RsDani = 7,
                    ImeFirme = "Strahinic Ban"
                };

                session.Save(stalnoZaposlen);

                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnReadStalnoZaposlen_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                IList<NarodniPoslanik> narodniPoslanici = session.QueryOver<NarodniPoslanik>()
                                .Where(n => n.Id == 31)
                                .List<NarodniPoslanik>();

                StalnoZaposlen stalnoZaposlen = (StalnoZaposlen)narodniPoslanici[0];

                MessageBox.Show(stalnoZaposlen.LicnoIme + ", godine radnog staza: " + stalnoZaposlen.RsGodine);

                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void cmdUpdateStalnoZaposlen_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                StalnoZaposlen stalnoZaposlen = session.Load<StalnoZaposlen>(31);

                stalnoZaposlen.RsGodine= 6;

                session.Update(stalnoZaposlen);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void cmdDeleteStalnoZaposlen_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                StalnoZaposlen stalnoZaposlen = session.Load<StalnoZaposlen>(33);

                session.Delete(stalnoZaposlen);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnCreateTelefon_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(31);

                Telefon telefon = new Telefon()
                {
                    BrojTelefona = "+381 22222222"
                };

                telefon.NarodniPoslanik = narodniPoslanik;
                session.Save(telefon);

                session.Flush();
                session.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnReadTelefoni_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(31);

                foreach(Telefon telefon in narodniPoslanik.Telefoni)
                {
                    MessageBox.Show("Ime: " + narodniPoslanik.LicnoIme + ", broj telefona: " + telefon.BrojTelefona);
                }

                session.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnReadTelefon_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                Telefon telefon = session.Load<Telefon>(37);

                MessageBox.Show("Broj telefona: " + telefon.BrojTelefona + " narodnog poslanika: " + telefon.NarodniPoslanik.LicnoIme);

                session.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnUpdateTelefon_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                Telefon telefon = session.Load<Telefon>(37);

                telefon.BrojTelefona = "+381 22222222";

                session.Update(telefon);

                session.Flush();
                session.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        private void btnDeleteTelefon_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                Telefon telefon = session.Load<Telefon>(37);

                session.Delete(telefon);

                session.Flush();
                session.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnCreatePoslanickaGrupa_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik predsednik = session.Load<NarodniPoslanik>(56);
                NarodniPoslanik zamenik = session.Load<NarodniPoslanik>(57);

                PoslanickaGrupa poslanickaGrupa = new PoslanickaGrupa()
                {
                    Naziv = "Grupa Console"
                };

                poslanickaGrupa.Predsednik = predsednik;
                poslanickaGrupa.Zamenik = zamenik;

                session.Save(poslanickaGrupa);

                session.Flush();
                session.Close();
            }
            catch(Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnReadPoslanickaGrupa_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                
                IList<OrganizacionaJedinica> organizacioneJedinice = session.QueryOver<OrganizacionaJedinica>()
                              .Where(n => n.Id == 31)
                              .List<OrganizacionaJedinica>();

                PoslanickaGrupa poslanickaGrupa = (PoslanickaGrupa)organizacioneJedinice[0];

                MessageBox.Show(poslanickaGrupa.Naziv 
                                + ", predsednik: " + poslanickaGrupa.Predsednik.LicnoIme
                                + ", zamenik: " + poslanickaGrupa.Zamenik.LicnoIme);

                session.Close();
            }
            catch(Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnUpdatePoslanickaGrupa_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                PoslanickaGrupa poslanickaGrupa = session.Load<PoslanickaGrupa>(31);

                poslanickaGrupa.Naziv = "Promenjen iz app";

                session.Update(poslanickaGrupa);

                session.Flush();
                session.Close();
            }
            catch(Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnDeletePoslanickaGrupa_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                PoslanickaGrupa poslanickaGrupa = session.Load<PoslanickaGrupa>(31);

                session.Delete(poslanickaGrupa);

                session.Flush();
                session.Close();
            }
            catch(Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnCreateRadnoTelo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik predsednik = session.Load<NarodniPoslanik>(56);
                NarodniPoslanik zamenik = session.Load<NarodniPoslanik>(57);

                RadnoTelo radnoTelo = new RadnoTelo()
                {
                    TipRadnogTela = "komisija"
                };

                radnoTelo.Predsednik = predsednik;
                radnoTelo.Zamenik = zamenik;

                session.Save(radnoTelo);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnReadRadnoTelo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                
                RadnoTelo radnoTelo = session.Load<RadnoTelo>(35);
                
                MessageBox.Show("Tip radonog tela: " + radnoTelo.TipRadnogTela
                                + ", predsednik: " + radnoTelo.Predsednik.LicnoIme
                                + ", zamenik: " + radnoTelo.Zamenik.LicnoIme);

                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnUpdateRadnoTelo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                RadnoTelo radnoTelo = session.Load<RadnoTelo>(35);

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(67);

                radnoTelo.Predsednik = narodniPoslanik;
                radnoTelo.Zamenik = narodniPoslanik;

                session.Update(radnoTelo);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnDeleteRadnoTelo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                RadnoTelo radnoTelo = session.Load<RadnoTelo>(39);

                session.Delete(radnoTelo);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnReadJeClan_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(31);

                foreach(OrganizacionaJedinica organizacionaJedinica in narodniPoslanik.OrganizacioneJedinice)
                {
                    if (organizacionaJedinica.GetType() == typeof(PoslanickaGrupa))
                    {
                        PoslanickaGrupa poslanickaGrupa = (PoslanickaGrupa)organizacionaJedinica;
                        MessageBox.Show("Narodni poslanik " + narodniPoslanik.LicnoIme + ", je clan: " + poslanickaGrupa.Naziv);
                    }
                    else
                    {
                        RadnoTelo radnoTelo = (RadnoTelo)organizacionaJedinica;
                        MessageBox.Show("Narodni poslanik " + narodniPoslanik.LicnoIme + ", je clan: " + radnoTelo.TipRadnogTela);
                    }
                }
            }
            catch(Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnReadJePredsednik_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(55);

                foreach(OrganizacionaJedinica organizacionaJedinica in narodniPoslanik.JePredsednik)
                {
                    if(organizacionaJedinica.GetType() == typeof(PoslanickaGrupa))
                    {
                        PoslanickaGrupa poslanickaGrupa = (PoslanickaGrupa)organizacionaJedinica;
                        MessageBox.Show("Narodni poslanik " + narodniPoslanik.LicnoIme + ", je predsednik: " + poslanickaGrupa.Naziv);
                    }
                    else
                    {
                        RadnoTelo radnoTelo = (RadnoTelo)organizacionaJedinica;
                        MessageBox.Show("Narodni poslanik " + narodniPoslanik.LicnoIme + ", je predsednik: " + radnoTelo.TipRadnogTela);
                    }
                }

                session.Close();
            }
            catch(Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnReadJeZamenik_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(64);

                foreach (OrganizacionaJedinica organizacionaJedinica in narodniPoslanik.JeZamenik)
                {
                    if (organizacionaJedinica.GetType() == typeof(PoslanickaGrupa))
                    {
                        PoslanickaGrupa poslanickaGrupa = (PoslanickaGrupa)organizacionaJedinica;
                        MessageBox.Show("Narodni poslanik " + narodniPoslanik.LicnoIme + ", je zamenik: " + poslanickaGrupa.Naziv);
                    }
                    else
                    {
                        RadnoTelo radnoTelo = (RadnoTelo)organizacionaJedinica;
                        MessageBox.Show("Narodni poslanik " + narodniPoslanik.LicnoIme + ", je zamenik: " + radnoTelo.TipRadnogTela);
                    }
                }

                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnReadClanoviPG_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                PoslanickaGrupa poslanickaGrupa = session.Load<PoslanickaGrupa>(31);

                foreach(NarodniPoslanik clan in poslanickaGrupa.Clanovi)
                {
                    MessageBox.Show("Narodni poslanik " + clan.LicnoIme + ", je clan: " + poslanickaGrupa.Naziv);
                }

                session.Close();
            }
            catch(Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnReadClanoviRT_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                RadnoTelo radnoTelo = session.Load<RadnoTelo>(35);

                foreach (NarodniPoslanik clan in radnoTelo.Clanovi)
                {
                    MessageBox.Show("Narodni poslanik " + clan.LicnoIme + ", je clan: " + radnoTelo.TipRadnogTela);
                }

                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnCreateSluzbenaProstorija_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                SluzbenaProstorija p = new SluzbenaProstorija()
                { 
                    Broj = 4,
                    Sprat = 1
                };

                session.Save(p);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnReadSluzbenaProstorija_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                SluzbenaProstorija p = session.Load<SluzbenaProstorija>(33);

                MessageBox.Show("Sprat: " + p.Sprat + ", Soba: " + p.Broj);

                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnUpdateSluzbenaProstorija_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                SluzbenaProstorija p = session.Load<SluzbenaProstorija>(33);

                int brojSobe = 3;
                MessageBox.Show("Novi broj sobe ubacen putem app je: " + brojSobe);

                p.Broj = brojSobe;

                session.Update(p);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnDeleteSluzbenaProstorija_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                SluzbenaProstorija p = session.Load<SluzbenaProstorija>(33);

                session.Delete(p);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnCreateAkt_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                AktVlade avl = new AktVlade()
                { 
                   TipAkta = "odluka"
                };

                AktViseOd1500Biraca abir = new AktViseOd1500Biraca()
                {
                    TipAkta = "tumacenje",
                    BrojBiraca = 2000
                };

                AktNarodnihPoslanika anp = new AktNarodnihPoslanika()
                {
                    TipAkta = "zakon"
                };

                int id = 31;
                
                // dodajemo predlagace Akta

                while(id< 62)
                {
                    NarodniPoslanik p = session.Load<NarodniPoslanik>(id);

                    p.PredlozeniAkti.Add(anp);
                    anp.Predlagaci.Add(p);

                    id++;
                }


                session.Save(anp);
                session.Save(avl);
                session.Save(abir);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnReadSluzbeneProstorijePG_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                PoslanickaGrupa poslanickaGrupa = session.Load<PoslanickaGrupa>(34);

                foreach (SluzbenaProstorija sluzbenaProstorija in poslanickaGrupa.SluzbeneProstorije)
                {
                    MessageBox.Show("Naziv: " + poslanickaGrupa.Naziv
                        + ", sluzbena prostorija (sprat, broj): ( " + sluzbenaProstorija.Sprat + ", " + sluzbenaProstorija.Broj + ")");
                }

                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnReadSluzbenaProstorijaRT_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                RadnoTelo radnoTelo = session.Load<RadnoTelo>(37);

                if (radnoTelo.SluzbeneProstorije.Count() > 0)
                {
                    MessageBox.Show("Tip radnog tela: " + radnoTelo.TipRadnogTela
                        + ", sluzbena prostorija (sprat, broj): " +
                        "( " + radnoTelo.SluzbeneProstorije[0].Sprat + ", " + radnoTelo.SluzbeneProstorije[0].Broj + ")");
                }

                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnReadZauzeteProstorije_Click(object sender, EventArgs e)
        {

        }

        private void btnReadAkt_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                AktVlade akt = session.Load<AktVlade>(32);

                MessageBox.Show(akt.Id + ", " + akt.TipAkta + ", " + akt.TipPredlozioca);

                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnUpdateAkt_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                AktViseOd1500Biraca akt = session.Load<AktViseOd1500Biraca>(32);

                MessageBox.Show(" Novi broj biraca je 2020");

                akt.BrojBiraca = 2020;

                session.Update(akt);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnReadAllAkt_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                IList<Akt> akti = (from a in session.Query<Akt>() select a).ToList<Akt>();

                string tekst = "";

                foreach(var akt in akti)
                {
                    if (akt.GetType() == typeof(AktViseOd1500Biraca))
                    {
                        AktViseOd1500Biraca abir = (AktViseOd1500Biraca)akt;
                        tekst += abir.Id + ", " + abir.TipAkta + ", " + abir.TipPredlozioca + ", " + abir.BrojBiraca + "\n";
                    }
                    else
                    {
                        tekst += akt.Id + ", " + akt.TipAkta + ", " + akt.TipPredlozioca + "\n";
                    }
                }

                MessageBox.Show(tekst);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnDeleteAkt_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                AktVlade akt = session.Load<AktVlade>(31);

                session.Delete(akt);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnReadPredlagaci_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                AktNarodnihPoslanika akt = session.Load<AktNarodnihPoslanika>(39);

                string tekst = "";

                foreach (var poslanik in akt.Predlagaci)
                {
                    tekst += poslanik.Id + ", " + poslanik.LicnoIme + ", " + poslanik.Prezime + " \n";
                }

                MessageBox.Show(tekst);
                    
                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }


    }
}

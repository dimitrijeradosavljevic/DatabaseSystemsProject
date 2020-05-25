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

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(71);

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

                stalnoZaposlen.RsGodine = 6;

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

                StalnoZaposlen stalnoZaposlen = session.Load<StalnoZaposlen>(34);

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
            catch (Exception exception)
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

                foreach (Telefon telefon in narodniPoslanik.Telefoni)
                {
                    MessageBox.Show("Ime: " + narodniPoslanik.LicnoIme + ", broj telefona: " + telefon.BrojTelefona);
                }

                session.Close();
            }
            catch (Exception exception)
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
            catch (Exception exception)
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

                telefon.BrojTelefona = "+381 2222632222";

                session.Update(telefon);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
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
            catch (Exception exception)
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
                    Naziv = "Grupa Console1"
                };

                poslanickaGrupa.Predsednik = predsednik;
                poslanickaGrupa.Zamenik = zamenik;

                session.Save(poslanickaGrupa);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
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
            catch (Exception exception)
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
            catch (Exception exception)
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
            catch (Exception exception)
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

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(32);

                foreach (JeClan jeClan in narodniPoslanik.JeClanOrganizacionihJedinica)
                {
                    MessageBox.Show("Narodni poslanik " + narodniPoslanik.LicnoIme + ", je clan: " + jeClan.OrganizacionaJedinica.Id);
                }
            }
            catch (Exception exception)
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

                foreach (OrganizacionaJedinica organizacionaJedinica in narodniPoslanik.JePredsednik)
                {
                    if (organizacionaJedinica.GetType() == typeof(PoslanickaGrupa))
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
            catch (Exception exception)
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

                PoslanickaGrupa poslanickaGrupa = session.Load<PoslanickaGrupa>(34);

                foreach (JeClan jeClan in poslanickaGrupa.JeClanNarodniPoslanici)
                {
                    MessageBox.Show("Narodni poslanik " + jeClan.NarodniPoslanik.LicnoIme + ", je clan: " + poslanickaGrupa.Naziv);
                }

                session.Close();
            }
            catch (Exception exception)
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

                foreach (JeClan jeClan in radnoTelo.JeClanNarodniPoslanici)
                {
                    MessageBox.Show("Narodni poslanik " + jeClan.NarodniPoslanik.LicnoIme + ", je clan: " + radnoTelo.TipRadnogTela);
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
                    Broj = 6,
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

                p.Broj = brojSobe;

                session.Update(p);

                session.Flush();
                session.Close();

                MessageBox.Show("Novi broj sobe ubacen putem app je: " + brojSobe);
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
                    BrojBiraca = 20000
                };

                AktNarodnihPoslanika anp = new AktNarodnihPoslanika()
                {
                    TipAkta = "zakon"
                };

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

                foreach (JeDodeljena jeDodeljena in poslanickaGrupa.JeDodeljenaSluzbeneProstorije)
                {
                    MessageBox.Show("Naziv: " + poslanickaGrupa.Naziv
                        + ", sluzbena prostorija (sprat, broj): ( " + jeDodeljena.SluzbenaProstorija.Sprat + ", " + jeDodeljena.SluzbenaProstorija.Broj + ")");
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

                if (radnoTelo.JeDodeljenaSluzbeneProstorije.Count() > 0)
                {
                    MessageBox.Show("Tip radnog tela: " + radnoTelo.TipRadnogTela
                        + ", sluzbena prostorija (sprat, broj): " +
                        "( " + radnoTelo.JeDodeljenaSluzbeneProstorije[0].SluzbenaProstorija.Sprat + ", " + radnoTelo.JeDodeljenaSluzbeneProstorije[0].SluzbenaProstorija.Broj + ")");
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
            try
            {
                ISession session = DataLayer.GetSession();

                SluzbenaProstorija sluzbenaProstorija = session.Load<SluzbenaProstorija>(31);

                foreach (JeDodeljena jeDodeljena in sluzbenaProstorija.JeDodeljenaOrganizacionimJedinicama)
                {
                    // MessageBox.Show(orgJedinica.Id.ToString());

                    if (jeDodeljena.OrganizacionaJedinica.GetType() == typeof(PoslanickaGrupa))
                    {
                        MessageBox.Show(jeDodeljena.OrganizacionaJedinica.Id.ToString() + ", " + jeDodeljena.OrganizacionaJedinica.Naziv);
                    }
                    else if (jeDodeljena.OrganizacionaJedinica.GetType() == typeof(RadnoTelo))
                    {
                        MessageBox.Show(jeDodeljena.OrganizacionaJedinica.Id.ToString() + ", " + jeDodeljena.OrganizacionaJedinica.TipRadnogTela);
                    }
                }

                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnReadAkt_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                AktVlade akt = session.Load<AktVlade>(32);

                MessageBox.Show(akt.Id + ", " + akt.TipAkta);

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

                AktViseOd1500Biraca akt = session.Load<AktViseOd1500Biraca>(33);

                akt.BrojBiraca = 20299;

                session.Update(akt);

                session.Flush();
                session.Close();

                MessageBox.Show(" Novi broj biraca je 20203");
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

                foreach (var akt in akti)
                {
                    if (akt.GetType() == typeof(AktViseOd1500Biraca))
                    {
                        AktViseOd1500Biraca abir = (AktViseOd1500Biraca)akt;
                        tekst += abir.Id + ", " + abir.TipAkta + ", " + abir.BrojBiraca + "\n";
                    }
                    else
                    {
                        tekst += akt.Id + ", " + akt.TipAkta + ", " + "\n";
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

                AktNarodnihPoslanika akt = session.Load<AktNarodnihPoslanika>(114);

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

                AktNarodnihPoslanika akt = session.Load<AktNarodnihPoslanika>(103);

                string tekst = "";

                foreach (JePredlozio jePredlozio in akt.JePredlozioNarodniPoslanici)
                {
                    tekst += jePredlozio.NarodniPoslanik.Id + ", " + jePredlozio.NarodniPoslanik.LicnoIme + " " + jePredlozio.NarodniPoslanik.Prezime + " \n";
                }

                MessageBox.Show(tekst);

                session.Close();
            }
            catch (Exception exception)
            {
                this.ShowExceptionData(exception);
            }
        }

        private void btnReadSazvaneSednice_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(40);

                foreach (JeSazvalo jeSazvalo in narodniPoslanik.JeSazvaoSednice)
                {
                    MessageBox.Show("Ime: " + narodniPoslanik.LicnoIme + ", broj saziva sednice" + jeSazvalo.Sednica.BrojSaziva);
                }

                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnReadPredlozeniAkti_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(31);

                foreach (JePredlozio jePredlozio in narodniPoslanik.JePredlozioAkte)
                {
                    MessageBox.Show("Ime: " + narodniPoslanik.LicnoIme + ", akt: " + jePredlozio.Akt.TipAkta + ", " + jePredlozio.Akt.TipPredlozioca);
                }

                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnCreateSednica_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                RedovnaSednica rSed = new RedovnaSednica()
                {
                    BrojZasedanja = 5,
                    BrojSaziva = 3,
                    DatumPocetka = new DateTime(2012, 1, 1),
                    DatumZavrsetka = new DateTime(2012, 1, 1),
                };

                VanrednaSednica vSedVlade = new VanrednaSednica()
                {
                    BrojZasedanja = 6,
                    BrojSaziva = 1,
                    DatumPocetka = new DateTime(2012, 5, 1),
                    DatumZavrsetka = new DateTime(2012, 5, 1),
                    TipVanredneSednice = "na zahtev vlade"
                };

                VanrednaSednica vSedNP = new VanrednaSednica()
                {
                    BrojZasedanja = 6,
                    BrojSaziva = 2,
                    DatumPocetka = new DateTime(2012, 7, 1),
                    DatumZavrsetka = new DateTime(2012, 7, 2),
                    TipVanredneSednice = "na zahtev narodnih poslanika"
                };

                RadniDan rd1 = new RadniDan()
                {
                    DatumIVremePocetka = new DateTime(2012, 1, 1, 8, 10, 0),
                    DatumIVremeZavrsetka = new DateTime(2012, 1, 1, 12, 32, 0),
                    BrojPrisutnihPoslanika = 43
                };

                RadniDan rd2 = new RadniDan()
                {
                    DatumIVremePocetka = new DateTime(2012, 5, 1, 8, 10, 0),
                    DatumIVremeZavrsetka = new DateTime(2012, 5, 1, 12, 32, 0),
                    BrojPrisutnihPoslanika = 43
                };

                session.Save(rSed);
                session.Save(vSedVlade);
                session.Save(vSedNP);

                rd1.Sednica = rSed;

                rd2.Sednica = vSedVlade;

                // vanrednoj Sednici sazvanoj od strane narodnih poslanika dodelicemo radne dane u posebnom button-u
                // rezervisanom za kreiranje radnog dana sednice

                rSed.RadniDani.Add(rd1);
                rSed.RadniDani.Add(rd2);

                session.Save(rSed);
                session.Save(vSedVlade);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnUpdateSednica_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                Sednica s = session.Load<VanrednaSednica>(39);
                s.BrojZasedanja = 4;

                session.Update(s);

                session.Flush();
                session.Close();

                MessageBox.Show("Novi broj zasedanja je 4");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnReadSednica_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                VanrednaSednica vs = session.Load<VanrednaSednica>(32);

                string prikaz = "Broj saziva: " + vs.BrojSaziva + "\nBroj zasedanja: " + vs.BrojZasedanja + "\nDatum pocetka" + vs.DatumPocetka.ToShortDateString()
                    + "\nDatum zavrsetka" + vs.DatumZavrsetka.ToShortDateString() + " \nTip vanredne sednice: " + vs.TipVanredneSednice;

                MessageBox.Show(prikaz);


                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnReadRadniDaniSednice_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                VanrednaSednica vs = session.Load<VanrednaSednica>(32);

                string prikaz = "";

                foreach(var radniDan in vs.RadniDani)
                {
                    prikaz += "Pocetak: " + radniDan.DatumIVremePocetka.ToString() + ", Zavrsetak: " + radniDan.DatumIVremeZavrsetka.ToString()
                        + ", Broj prisutnih poslanika: " + radniDan.BrojPrisutnihPoslanika + "\n";
                }

                MessageBox.Show(prikaz);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnReadSazivaociVanrednaSednicaNarodnihPoslanika_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                VanrednaSednica vs = session.Load<VanrednaSednica>(39);

                string prikaz = "Sazivaoci: ";

                foreach (JeSazvalo jeSazvalo in vs.JeSazvaloNarodniPoslanici)
                {
                    prikaz += "\n" + jeSazvalo.NarodniPoslanik.LicnoIme + " " + jeSazvalo.NarodniPoslanik.ImeRoditelja + " " + jeSazvalo.NarodniPoslanik.Prezime;
                }

                MessageBox.Show(prikaz);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnCreateSazivaoci_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                RedovnaSednica s = session.Load<RedovnaSednica>(36);

                session.Delete(s);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnReadRadniDan_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                RadniDan rd = (from r in session.Query<RadniDan>() where (r.Sednica.Id == 32) select r).First<RadniDan>();

                MessageBox.Show("Datum: " + rd.DatumIVremePocetka.ToShortDateString() +
                    "\nPocetak: " + rd.DatumIVremePocetka.ToShortTimeString() + 
                    "\nZavrsetak: " + rd.DatumIVremeZavrsetka.ToShortTimeString() +
                    "\nBroj prisutnih poslanika: " + rd.BrojPrisutnihPoslanika);


                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnUpdateRadniDan_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                RadniDan rd = (from r in session.Query<RadniDan>() where (r.Sednica.Id == 32) select r).First<RadniDan>();

                rd.BrojPrisutnihPoslanika = 78;

                int id = rd.Id;

                session.Update(rd);

                session.Flush();
                session.Close();

                MessageBox.Show("Novi broj poslanika entiteta RadniDan sa id-jem " + id + " iznosi 78");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnReadSednicaForRadniDan_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                RadniDan rd = session.Load<RadniDan>(32);

                MessageBox.Show("Broj Zasedanja: " + rd.Sednica.BrojZasedanja +" Broj saziva: " + rd.Sednica.BrojSaziva.ToString());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnDeleteRadniDan_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                IList<RadniDan> radniDani = (from r in session.Query<RadniDan>() where (r.Sednica.Id == 93) select r).ToList<RadniDan>();

                foreach (var rd in radniDani)
                    session.Delete(rd);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void btnCreateJePredlozio_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                AktNarodnihPoslanika anp = session.Load<AktNarodnihPoslanika>(103);

                NarodniPoslanik np1 = session.Load<NarodniPoslanik>(31);
                NarodniPoslanik np2 = session.Load<NarodniPoslanik>(32);
                NarodniPoslanik np3 = session.Load<NarodniPoslanik>(40);

                JePredlozio jepredlozio1 = new JePredlozio();
                jepredlozio1.NarodniPoslanik = np1;
                jepredlozio1.Akt = anp;

                JePredlozio jepredlozio2 = new JePredlozio();
                jepredlozio2.NarodniPoslanik = np2;
                jepredlozio2.Akt = anp;

                JePredlozio jepredlozio3 = new JePredlozio();
                jepredlozio3.NarodniPoslanik = np3;
                jepredlozio3.Akt = anp;

                session.Save(jepredlozio1);
                session.Save(jepredlozio2);
                session.Save(jepredlozio3);

                //anp.JePredlozioNarodniPoslanici.Add(jepredlozio1);
                //anp.JePredlozioNarodniPoslanici.Add(jepredlozio2);
                //anp.JePredlozioNarodniPoslanici.Add(jepredlozio3);

               // session.Save(anp);

                session.Flush();
                session.Close();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnCreateJeClan_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                NarodniPoslanik np1 = session.Load<NarodniPoslanik>(37);
                PoslanickaGrupa pg = session.Load<PoslanickaGrupa>(36);

                JeClan jc = new JeClan();
                jc.NarodniPoslanik = np1;
                jc.OrganizacionaJedinica = pg;

                session.Save(jc);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();



                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnJeSazvalo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                VanrednaSednica vanrednaSednica = session.Load<VanrednaSednica>(39);
                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(65);

                JeSazvalo jeSazvalo = new JeSazvalo();
                jeSazvalo.NarodniPoslanik = narodniPoslanik;
                jeSazvalo.Sednica = vanrednaSednica;

                session.Save(jeSazvalo);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnJeDodeljena_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                RadnoTelo radnoTelo = session.Load<RadnoTelo>(32);
                SluzbenaProstorija sluzbenaProstorija = session.Load<SluzbenaProstorija>(44);

                JeDodeljena postoji = (from jd in session.Query<JeDodeljena>()
                                       where (jd.OrganizacionaJedinica == radnoTelo)
                                       select jd)
                                        .FirstOrDefault();

                //Posto Poslanickoj Grupi i Radnom Telu dodeljujemo prostprije kroz 
                //tabelu JE_DODELJENA, a radnom telu se oddeljue samo jedna prostorija po tekstu zadatka
                // to moramo proveriti putem aplikacije


                if(postoji != null)
                {
                    MessageBox.Show("Zeljenom radnom telu je vec dodeljena sluzbena prostorija na koriscenje!");
                    session.Flush();
                    session.Close();

                    return;
                }

                JeDodeljena jeDodeljena = new JeDodeljena();
                jeDodeljena.SluzbenaProstorija = sluzbenaProstorija;
                jeDodeljena.OrganizacionaJedinica = radnoTelo;

                session.Save(jeDodeljena);

                session.Flush();
                session.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }       
}

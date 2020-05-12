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
    }
}

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
    }
}

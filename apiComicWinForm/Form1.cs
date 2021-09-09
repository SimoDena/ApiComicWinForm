using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apiComicWinForm
{
    public partial class Form1 : Form
    {
        int numeroMassimo = 0;
        int numeroCorrente = 0;

        public Form1()
        {
            InitializeComponent();
            ApiHelper.InizializzaClient();
            btnNext.Enabled = false;
              
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (numeroCorrente > 1)
            {
                numeroCorrente--;
                btnNext.Enabled = true;
                await CaricaImmagine(numeroCorrente);

                if (numeroCorrente == 1)
                {
                    btnPrevious.Enabled = false;
                }
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (numeroCorrente < numeroMassimo)
            {
                numeroCorrente++;
                btnPrevious.Enabled = true;
                await CaricaImmagine(numeroCorrente);

                if (numeroCorrente == numeroMassimo)
                {
                    btnNext.Enabled = false;
                }
            }
        }

        private async Task CaricaImmagine(int numeroComic = 0)
        {
            var comic = await ComicProcessor.CaricaComic(numeroComic);

            if (numeroComic == 0)
            {
                numeroMassimo = comic.Num;
            }

            numeroCorrente = comic.Num;
            pictureBox1.ImageLocation = comic.Img;
            txtTitolo.Text = comic.Title;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await CaricaImmagine();
        }
    }
}

namespace Juego_de_Memoria
{
    public partial class Form1 : Form
    {
        List<Iconos> _icnoso = new List<Iconos>();   

        public Form1()
        {
            InitializeComponent();
            VerCartas(true);
        }

        private void VerCartas(bool MostrarCartas)
        {
            pnlCover1.Visible = !MostrarCartas;
            pnlCover2.Visible = !MostrarCartas;
            pnlCover3.Visible = !MostrarCartas;
            pnlCover4.Visible = !MostrarCartas;
            pnlCover5.Visible = !MostrarCartas;
            pnlCover6.Visible = !MostrarCartas;
            pnlCover7.Visible = !MostrarCartas;
            pnlCover8.Visible = !MostrarCartas;
            pnlCover9.Visible = !MostrarCartas;
            pnlCover10.Visible = !MostrarCartas;
            pnlCover11.Visible = !MostrarCartas;
            pnlCover12.Visible = !MostrarCartas;
            pnlCover13.Visible = !MostrarCartas;
            pnlCover14.Visible = !MostrarCartas;
            pnlCover15.Visible = !MostrarCartas;
            pnlCover16.Visible = !MostrarCartas;

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            VerCartas(false);
            timer1.Dispose();
        }
        
        private void Cargarimagenes()
        {

        }

        private void pnlCover1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
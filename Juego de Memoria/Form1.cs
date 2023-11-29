using System.Reflection;

namespace Juego_de_Memoria
{
    public partial class Form1 : Form
    {
        List<Iconos> _iconos = new List<Iconos>();
        Random random = new Random();
        Panel primeraSeleccion, SegundaSeleccion;
        Panel PrimerCoverSeleccion, SegundaCoverSeleccion;
        Dictionary<string, int> assignedPanels = new Dictionary<string, int>();
        public Form1()
        {
            InitializeComponent();
            CargarImagenes();
            CargarEnlaInterfaz();
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

        private void CargarImagenes()
        {
            var files = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            int id = 1;

            foreach (var imagenes in files)
            {
                if (!imagenes.EndsWith(".png"))
                {
                    continue;
                }


                var icono = new Iconos
                {
                    Id = id,
                    Nombre = imagenes.Replace("Juego_de_Memoria.Resources", "").Replace(".png", ""),
                    Image = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream(imagenes))
                };

                _iconos.Add(icono);
                _iconos.Add(icono);
                id++;
            }
        }

        private void CargarEnlaInterfaz()
        {
            Panel panel;
            int randomNumber;

            foreach (var item in this.Controls)
            {
                if (item is Panel && !((Panel)item).Name.Contains("pnlCover"))
                {
                    panel = (Panel)item;
                }
                else
                {
                    continue;
                }

                randomNumber = random.Next(0, _iconos.Count);


                panel.BackgroundImage = _iconos[randomNumber].Image;

                assignedPanels.Add(panel.Name, _iconos[randomNumber].Id);

                _iconos.RemoveAt(randomNumber);
            }
        }

        private void pnlCover_Click(object sender, EventArgs e)
        {
            if (primeraSeleccion != null && SegundaSeleccion != null)
            {
                return;
            }

            Panel clickPanel = (Panel)sender;
            if (clickPanel == null)
            {
                return;
            }
            if (!clickPanel.Visible)
            {
                return;
            }

            clickPanel.Visible = false;

            if (primeraSeleccion == null)
            {
                primeraSeleccion = GetIconPanel(clickPanel);
                PrimerCoverSeleccion = clickPanel;
                return;
            }
            if (SegundaSeleccion == null)
            {
                SegundaSeleccion = GetIconPanel(clickPanel);
                SegundaCoverSeleccion = clickPanel;
            }

            if (primeraSeleccion != null && SegundaSeleccion != null && CheckForMatch())
            {
                LimpiarSeleccion(true);
            }
            else
            {
                Reset();
            }
        }

        private Panel GetIconPanel(Panel coverPanel)
        {
            Panel iconPanel = null;
            foreach (var item in this.Controls)
            {
                if (item is Panel && !((Panel)item).Name.Contains("pnlCover") && ((Panel)item).Tag == coverPanel.Tag)
                {
                    iconPanel = (Panel)item;
                }
            }

            return iconPanel;
        }

        private bool CheckForMatch()
        {
            return assignedPanels[primeraSeleccion.Name] == assignedPanels[SegundaSeleccion.Name];
        }

        private void LimpiarSeleccion(bool match)
        {
            if (!match)
            {
                PrimerCoverSeleccion.Visible = true;
                SegundaCoverSeleccion.Visible = true;
            }

            primeraSeleccion = null;
            SegundaCoverSeleccion = null;
            PrimerCoverSeleccion = null;
            SegundaSeleccion = null;
        }

        private void Reset()
        {
            timer2.Start();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            LimpiarSeleccion(false);
            timer2.Stop();
        }
    }
}
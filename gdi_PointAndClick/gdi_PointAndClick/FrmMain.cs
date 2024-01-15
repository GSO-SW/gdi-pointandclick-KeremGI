using System.Collections.Generic; // benötigt für Listen

namespace gdi_PointAndClick
{
    public partial class FrmMain : Form
    {
        List<Rectangle> rectangles = new List<Rectangle>();

        public FrmMain()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            // Hilfsvarablen
            Graphics g = e.Graphics;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            // Zeichenmittel
            Random random = new Random();
            Color x = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), 0);

            Brush b = new SolidBrush(x);

            

            for (int i = 0; i < rectangles.Count; i++)
            { 
                g.FillRectangle(b, rectangles[i]);
            }

        }


        private void FrmMain_MouseClick(object sender, MouseEventArgs e)
        {
            Point mausposition = e.Location;
            Random rnd = new Random();

            int size = rnd.Next(1, 50);

            bool ContainsAbfrage = false;

            for (int i = 0; i < rectangles.Count; i++)
            {
                if (rectangles[i].Contains(mausposition))
                {
                    ContainsAbfrage = true;
                    break;
                }
                
            }
            if (ContainsAbfrage == false)
            {
                

                Rectangle r = new Rectangle(mausposition.X - (size / 2), mausposition.Y - (size / 2), size, size);

                rectangles.Add(r);


                Refresh();
            }
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                rectangles.Clear();
                Refresh();
            }
        }
    }
}
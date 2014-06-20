using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Carubbi.TSP.UI
{
    

    public partial class frmTSP : Form
    {
        public class Route
        {
            public City InitCity { get; set; }
            public City FinalCity { get; set; }
        }

        public frmTSP()
        {
            InitializeComponent();
            pnlMap.BackColor = Color.White;
          
        }
        private const int VERTICAL_OFFSET = 35;
        private const int HORIZONTAL_OFFSET = 20;

        private void pnlMap_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics, e.ClipRectangle, 50);
            DrawPoints(_bufferPoint, e.Graphics);
            DrawRoute(_bufferRoute, e.Graphics);
            Application.DoEvents();
           
        }

        private void DrawRoute(List<Route> _bufferRoute, Graphics graphics)
        {
            foreach (var route in _bufferRoute)
            {
                graphics.DrawLine(new Pen(Color.Blue, 1), new Point(route.InitCity.getx() * HORIZONTAL_OFFSET, route.InitCity.gety() * VERTICAL_OFFSET), new Point(route.FinalCity.getx() * HORIZONTAL_OFFSET, route.FinalCity.gety() * VERTICAL_OFFSET));
            }
        }

        private void DrawPoints(List<Point> points, Graphics gfx)
        {
            if (points != null)
            {
                foreach (var point in points)
                    gfx.DrawRectangle(new Pen(Color.Red, 5), point.X * HORIZONTAL_OFFSET, point.Y * VERTICAL_OFFSET, 1, 1);
            }
        }

        private void DrawGrid(Graphics gfx, Rectangle clip, int cellsDistance)
        {
            for (int i = 0; i < clip.Width; i = i + cellsDistance)
            {
                gfx.DrawLine(new Pen(Color.Black, 1), new Point(i, 0), new Point(i, clip.Height));
            }

            for (int i = 0; i < clip.Height; i = i + cellsDistance)
            {
                gfx.DrawLine(new Pen(Color.Black, 1), new Point(0, i), new Point(clip.Width, i));
            }
        }
        GA_TSP tsp = new GA_TSP();
        private void btnInitialize_Click(object sender, EventArgs e)
        {
            _bufferPoint.Clear();
            tsp.CityCreated += new EventHandler<NewCityEventArgs>(tsp_CityCreated);
            tsp.GenerationCreated += new EventHandler<GenerationCreatedEventArgs>(tsp_GenerationCreated);
            tsp.Initialization();
        }

        void tsp_GenerationCreated(object sender, GenerationCreatedEventArgs e)
        {
            lstCromossomes.DataSource = null;
            lstCromossomes.DataSource = e.Generation;
            lblGenerationValue.Text = e.GenerationNumber.ToString();
        }

        List<Point> _bufferPoint = new List<Point>();
        List<Route> _bufferRoute = new List<Route>();
        void tsp_CityCreated(object sender, NewCityEventArgs e)
        {
            _bufferPoint.Add(new Point(e.NewCity.getx(), e.NewCity.gety()));
            pnlMap.Refresh();
        }

        private void btnNextGen_Click(object sender, EventArgs e)
        {
            while (!tsp.NextGeneration())
            {
                
            }

        }

        private void lstCromossomes_SelectedIndexChanged(object sender, EventArgs e)
        {
            _bufferRoute.Clear();
            if (lstCromossomes.DataSource != null)
            {
                var chromossome = (Chromosome)lstCromossomes.Items[lstCromossomes.SelectedIndex];

                for (int i = 0; i < chromossome.CityList.Length-1; i++)
                {
                    lblCostValue.Text = chromossome.getCost().ToString();
                    
                    Route newRoute = new Route()
                    {
                        InitCity = tsp.Cities[chromossome.CityList[i]],
                        FinalCity = tsp.Cities[chromossome.CityList[i+1]],
                    };
                    _bufferRoute.Add(newRoute);
                    pnlMap.Refresh();
                }
            }
                
        }

        private void lstCromossomes_SelectedValueChanged(object sender, EventArgs e)
        {

        }

    }
}

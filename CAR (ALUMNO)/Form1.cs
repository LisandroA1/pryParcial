using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CAR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        clsVendedores objVendedores = new clsVendedores();
        clsVentas objVentas = new clsVentas();

        private void cmdGraficar_Click(object sender, EventArgs e)
        {
            DataTable tvendedores = objVendedores.Get_Tabla();
            DataTable tVentas = objVentas.Get_Tabla();
            chart1.Series.Clear();

            int desde = Convert.ToInt32(txtDesde.Text);
            int hasta = Convert.ToInt32(txtHasta.Text);

            for(int aa=desde;aa<=hasta;aa++)
            {
               Series serie = chart1.Series.Add(aa.ToString());
                foreach (ListViewItem a in lsvVendedores.CheckedItems)
                {
                    foreach (DataRow fv in tVentas.Rows)
                    {
                        serie.Points.AddXY(fv["vendedor"], fv["cantidad"]);

                    }


                    
                }

            }
            

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            DataTable tv = objVendedores.Get_Tabla();

            foreach(DataRow fv in tv.Rows)
            {
                ListViewItem a = lsvVendedores.Items.Add(fv["nombre"].ToString());
                a.Tag = fv["vendedor"];
            }
        }
    }
}

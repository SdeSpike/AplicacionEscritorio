using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFGEscrit
{
    public partial class GridMovimientosPrimas : Form
    {
        DataTable tabla;
        public GridMovimientosPrimas(DataTable t)
        {
            InitializeComponent();
            tabla = t;
        }

        private void GridMovimientosPrimas_Load(object sender, EventArgs e)
        {
            grdDatos.DataSource = tabla;
        }
    }
}

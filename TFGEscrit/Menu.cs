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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void hacerPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pedidos p = new Pedidos();
            p.Show();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AceptarPedido ap = new AceptarPedido();
            ap.Show();
        }
    }
}

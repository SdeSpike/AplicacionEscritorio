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
    public partial class MenuF : Form
    {
        public MenuF()
        {
            InitializeComponent();
            PersonalizarDiseno();
        }
        private void PersonalizarDiseno()
        {
            paPedidos.Visible = false;
            paCategorias.Visible = false;
            paMateriaPrima.Visible = false;
            paLog.Visible = false;
        }
        private void hideSubMenu()
        {
            if (paPedidos.Visible == true)
            {
                paPedidos.Visible = false;
            }
            if (paCategorias.Visible == true)
            {
                paCategorias.Visible = false;
            }
            if (paMateriaPrima.Visible == true)
            {
                paMateriaPrima.Visible = false;
            }
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            showSubMenu(paPedidos);
        }

        private void btnHacerPedido_Click(object sender, EventArgs e)
        {
            Pedidos p = new Pedidos();
            openChildForm(p);
            hideSubMenu();
        }

        private void btnConfirmarPedido_Click(object sender, EventArgs e)
        {
            AceptarPedido ap = new AceptarPedido();
            openChildForm(ap);
            hideSubMenu();
        }
        private Form activeForm = null;
        private void openChildForm(Form f)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = f;
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            pFormularios.Controls.Add(f);
            pFormularios.Tag = f;
            f.BringToFront();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(paCategorias);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MantenimientoCategoria p = new MantenimientoCategoria();
            openChildForm(p);
            hideSubMenu();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            showSubMenu(paMateriaPrima);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MantenimientoMateriaPrima p = new MantenimientoMateriaPrima();
            openChildForm(p);
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showSubMenu(paLog);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LogFabricando p = new LogFabricando();
            openChildForm(p);
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MovimientoMateriaPrima p = new MovimientoMateriaPrima();
            openChildForm(p);
            hideSubMenu();
        }

        private void pFormularios_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

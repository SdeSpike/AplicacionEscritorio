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
        }
        private void hideSubMenu()
        {
            if (paPedidos.Visible == true)
            {
                paPedidos.Visible = false;
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
    }
}

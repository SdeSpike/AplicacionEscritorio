using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFGEscrit
{
    public partial class MantenimientoCategoria : Form
    {
        static string strConexion = @"Data Source=DESKTOP-2915P7L;Initial Catalog=TFG;Integrated Security=True";
        SqlConnection conexion = new SqlConnection(strConexion);

        SqlCommand cmdCategorias = new SqlCommand("SELECT IdCategoria,Nombre FROM Produccion.Categorias");
        SqlDataReader lector;

        SqlCommand cmdMaxId = new SqlCommand("SELECT ISNULL(MAX(IdCategoria),0)+1 FROM Produccion.Categorias");

        SqlCommand cmdAlta = new SqlCommand("INSERT INTO Produccion.Categorias (IdCategoria,Nombre) VALUES (@p_altaIdCategoria,@p_altaNombre)");
        SqlParameter p_altaIdCategoria = new SqlParameter();
        SqlParameter p_altaNombre = new SqlParameter();

        SqlCommand cmdModificar = new SqlCommand("UPDATE Produccion.Categorias SET Nombre=@p_upNombre WHERE IdCategoria=@p_upIdCategoria");
        SqlParameter p_upNombre = new SqlParameter();
        SqlParameter p_upIdCategoria = new SqlParameter();

        SqlCommand cmdEliminar = new SqlCommand("DELETE Produccion.Categorias WHERE IdCategoria=@p_deCategoria");
        SqlParameter p_deCategoria = new SqlParameter();

        int maxId;
        public MantenimientoCategoria()
        {
            InitializeComponent();
        }

        private void MantenimientoCategoria_Load(object sender, EventArgs e)
        {
            cmdEliminar.Connection = conexion;

            p_deCategoria.ParameterName = "@p_deCategoria";
            p_deCategoria.SqlDbType = SqlDbType.TinyInt;
            cmdEliminar.Parameters.Add(p_deCategoria);

            cmdModificar.Connection = conexion;

            p_upNombre.ParameterName = "@p_upNombre";
            p_upNombre.SqlDbType = SqlDbType.VarChar;

            p_upIdCategoria.ParameterName = "@p_upIdCategoria";
            p_upIdCategoria.SqlDbType = SqlDbType.TinyInt;

            cmdModificar.Parameters.Add(p_upNombre);
            cmdModificar.Parameters.Add(p_upIdCategoria);

            ListViewItem l;

            cmdCategorias.Connection = conexion;
            conexion.Open();
            lector = cmdCategorias.ExecuteReader();
            while (lector.Read())
            {
                l = lstCategorias.Items.Add(lector[0].ToString());
                l.SubItems.Add(lector[1].ToString());
            }
            conexion.Close();

            cmdMaxId.Connection = conexion;
            maxId = 0;

            cmdAlta.Connection = conexion;

            p_altaIdCategoria.ParameterName = "@p_altaIdCategoria";
            p_altaIdCategoria.SqlDbType = SqlDbType.TinyInt;

            p_altaNombre.ParameterName = "@p_altaNombre";
            p_altaNombre.SqlDbType = SqlDbType.VarChar;

            cmdAlta.Parameters.Add(p_altaIdCategoria);
            cmdAlta.Parameters.Add(p_altaNombre);
        }

        private void lstCategorias_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtId.Text = lstCategorias.SelectedItems[0].SubItems[0].Text;
            txtNombre.Text = lstCategorias.SelectedItems[0].SubItems[1].Text;

            btnInsertar.Enabled = false;

            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (maxId == 0)
            {
                conexion.Open();
                maxId = Int32.Parse(cmdMaxId.ExecuteScalar().ToString());
                conexion.Close();
            }
            txtId.Text = maxId.ToString();
            txtNombre.Text = "";
            btnInsertar.Enabled = true;

            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            p_altaIdCategoria.Value = txtId.Text;
            p_altaNombre.Value = txtNombre.Text;

            conexion.Open();
            cmdAlta.ExecuteNonQuery();
            conexion.Close();

            ListViewItem l = lstCategorias.Items.Add(txtId.Text);
            l.SubItems.Add(txtNombre.Text);

            txtId.Text = "";
            txtNombre.Text = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            p_upIdCategoria.Value = txtId.Text;
            p_upNombre.Value = txtNombre.Text;

            conexion.Open();
            cmdModificar.ExecuteNonQuery();
            conexion.Close();

            for(int i = 0; i < lstCategorias.Items.Count; i++)
            {
                if (lstCategorias.Items[i].SubItems[0].Text.Equals(txtId.Text))
                {
                    lstCategorias.Items[i].SubItems[1].Text = txtNombre.Text;
                }
            }
            txtId.Text = "";
            txtNombre.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            p_deCategoria.Value = txtId.Text;

            conexion.Open();
            cmdEliminar.ExecuteNonQuery();
            conexion.Close();

            for(int i = 0; i < lstCategorias.Items.Count; i++)
            {
                if (lstCategorias.Items[i].SubItems[0].Text.Equals(txtId.Text))
                {
                    lstCategorias.Items[i].Remove();
                }
            }

            txtId.Text = "";
            txtNombre.Text = "";
        }
    }
}

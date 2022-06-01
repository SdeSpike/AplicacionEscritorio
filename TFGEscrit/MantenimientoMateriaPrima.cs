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
    public partial class MantenimientoMateriaPrima : Form
    {
        static string strConexion = @"Data Source=DESKTOP-2915P7L;Initial Catalog=TFG;Integrated Security=True";
        SqlConnection conexion = new SqlConnection(strConexion);

        SqlCommand cmdMateriaPrima = new SqlCommand("SELECT IdMateriaPrima,IdProvedor,Nombre,Precio,Stock,StockProximo FROM Produccion.MateriaPrima");
        SqlDataReader lector;

        SqlCommand cmdMaxId = new SqlCommand("SELECT ISNULL(MAX(IdMateriaPrima),0)+1 FROM Produccion.MateriaPrima");
        int maxId = 0;

        SqlCommand cmdInsertarMateria = new SqlCommand("INSERT INTO Produccion.MateriaPrima VALUES(@p_alIdMateriaPrima,@p_alIdProvedor,@p_alNombre,@p_alPrecio,@p_alStock,@p_alStockProximo)");
        SqlParameter p_alIdMateriaPrima = new SqlParameter();
        SqlParameter p_alIdProvedor = new SqlParameter();
        SqlParameter p_alNombre = new SqlParameter();
        SqlParameter p_alPrecio = new SqlParameter();
        SqlParameter p_alStock = new SqlParameter();
        SqlParameter p_alStockProximo = new SqlParameter();

        SqlCommand cmdModificarPrima = new SqlCommand(@"UPDATE Produccion.MateriaPrima 
                                                    SET IdProvedor=@p_modIdProvedor,Nombre=@p_modNombre,Precio=@p_modPrecio,Stock=@p_modStock,StockProximo=@p_modStockProximo
                                                     WHERE IdMateriaPrima=@p_modId");
     
        SqlParameter p_modIdProvedor = new SqlParameter();
        SqlParameter p_modNombre = new SqlParameter();
        SqlParameter p_modPrecio = new SqlParameter();
        SqlParameter p_modStock = new SqlParameter();
        SqlParameter p_modStockProximo = new SqlParameter();
        SqlParameter p_modIdMateriaPrima = new SqlParameter();

        SqlCommand cmdBorrar = new SqlCommand("DELETE Produccion.MateriaPrima WHERE IdMateriaPrima=@p_delIdMateriaPrima");
        SqlParameter p_delIdMateriaPrima = new SqlParameter();


        public MantenimientoMateriaPrima()
        {
            InitializeComponent();
        }

        private void MantenimientoMateriaPrima_Load(object sender, EventArgs e)
        {
            /*ELIMINAR*/
            cmdBorrar.Connection = conexion;
            p_delIdMateriaPrima.ParameterName = "@p_delIdMateriaPrima";
            p_delIdMateriaPrima.SqlDbType = SqlDbType.TinyInt;

            cmdBorrar.Parameters.Add(p_delIdMateriaPrima);
            /*ELIMINAR*/

            /*MODIFICACIONES*/
            cmdModificarPrima.Connection = conexion;
            p_modIdProvedor.ParameterName = "@p_modIdProvedor";
            p_modIdProvedor.SqlDbType = SqlDbType.TinyInt;

            p_modNombre.ParameterName = "@p_modNombre";
            p_modNombre.SqlDbType = SqlDbType.VarChar;

            p_modPrecio.ParameterName = "@p_modPrecio";
            p_modPrecio.SqlDbType = SqlDbType.Decimal;

            p_modStock.ParameterName = "@p_modStock";
            p_modStock.SqlDbType = SqlDbType.Int;

            p_modStockProximo.ParameterName = "@p_modStockProximo";
            p_modStockProximo.SqlDbType = SqlDbType.Int;

            p_modIdMateriaPrima.ParameterName = "@p_modId";
            p_modIdMateriaPrima.SqlDbType = SqlDbType.TinyInt;

            cmdModificarPrima.Parameters.Add(p_modIdProvedor);
            cmdModificarPrima.Parameters.Add(p_modNombre);
            cmdModificarPrima.Parameters.Add(p_modPrecio);
            cmdModificarPrima.Parameters.Add(p_modStock);
            cmdModificarPrima.Parameters.Add(p_modStockProximo);
            cmdModificarPrima.Parameters.Add(p_modIdMateriaPrima);
            /*MODIFICACIONES*/
            /*ALTA*/
            p_alIdMateriaPrima.ParameterName = "@p_alIdMateriaPrima";
            p_alIdMateriaPrima.SqlDbType = SqlDbType.TinyInt;

            p_alIdProvedor.ParameterName = "@p_alIdProvedor";
            p_alIdProvedor.SqlDbType = SqlDbType.TinyInt;

            p_alNombre.ParameterName = "@p_alNombre";
            p_alNombre.SqlDbType = SqlDbType.VarChar;

            p_alPrecio.ParameterName = "@p_alPrecio";
            p_alPrecio.SqlDbType = SqlDbType.Decimal;

            p_alStock.ParameterName = "@p_alStock";
            p_alStock.SqlDbType = SqlDbType.Int;

            p_alStockProximo.ParameterName = "@p_alStockProximo";
            p_alStockProximo.SqlDbType = SqlDbType.Int;

            cmdInsertarMateria.Parameters.Add(p_alIdMateriaPrima);
            cmdInsertarMateria.Parameters.Add(p_alIdProvedor);
            cmdInsertarMateria.Parameters.Add(p_alNombre);
            cmdInsertarMateria.Parameters.Add(p_alPrecio);
            cmdInsertarMateria.Parameters.Add(p_alStock);
            cmdInsertarMateria.Parameters.Add(p_alStockProximo);
            /*FIN ALTA*/


            ListViewItem l;
            cmdMateriaPrima.Connection = conexion;
            cmdMaxId.Connection = conexion;
            cmdInsertarMateria.Connection = conexion;

            conexion.Open();
            lector = cmdMateriaPrima.ExecuteReader();
            while (lector.Read())
            {
                l = lstMateriaPrima.Items.Add(lector[0].ToString());
                l.SubItems.Add(lector[1].ToString());
                l.SubItems.Add(lector[2].ToString());
                l.SubItems.Add(lector[3].ToString());
                l.SubItems.Add(lector[4].ToString());
                l.SubItems.Add(lector[5].ToString());
            }
            conexion.Close();
        }

        private void MantenimientoMateriaPrima_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void lstMateriaPrima_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtId.Text = lstMateriaPrima.SelectedItems[0].SubItems[0].Text;
            txtProvedor.Text = lstMateriaPrima.SelectedItems[0].SubItems[1].Text;
            txtNombre.Text = lstMateriaPrima.SelectedItems[0].SubItems[2].Text;
            txtPrecio.Text = lstMateriaPrima.SelectedItems[0].SubItems[3].Text;
            txtStock.Text = lstMateriaPrima.SelectedItems[0].SubItems[4].Text;
            txtStockProximo.Text = lstMateriaPrima.SelectedItems[0].SubItems[5].Text;

            btnInsertar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;

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
            txtPrecio.Text = "";
            txtProvedor.Text = "";
            txtStock.Text = "";
            txtStockProximo.Text = "";

            btnInsertar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            p_alIdMateriaPrima.Value = txtId.Text;
            p_alIdProvedor.Value = txtProvedor.Text;
            p_alNombre.Value = txtNombre.Text;
            p_alPrecio.Value = txtPrecio.Text;
            p_alStock.Value = txtStock.Text;
            p_alStockProximo.Value = txtStockProximo.Text;

            conexion.Open();
            cmdInsertarMateria.ExecuteNonQuery();
            conexion.Close();

            ListViewItem l = lstMateriaPrima.Items.Add(txtId.Text);
            l.SubItems.Add(txtNombre.Text);
            l.SubItems.Add(txtPrecio.Text);
            l.SubItems.Add(txtProvedor.Text);
            l.SubItems.Add(txtStock.Text);
            l.SubItems.Add(txtStockProximo.Text);
            
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtProvedor.Text = "";
            txtStock.Text = "";
            txtStockProximo.Text = "";

            maxId = 0;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            p_modIdMateriaPrima.Value = txtId.Text;
            p_modIdProvedor.Value = txtProvedor.Text;
            p_modNombre.Value = txtNombre.Text;
            p_modPrecio.Value = txtPrecio.Text;
            p_modStock.Value = txtStock.Text;
            p_modStockProximo.Value = txtStockProximo.Text;

            conexion.Open();
            cmdModificarPrima.ExecuteNonQuery();
            conexion.Close();

            for(int i = 0; i < lstMateriaPrima.Items.Count; i++)
            {
                if (lstMateriaPrima.Items[i].SubItems[0].Text.Equals(txtId.Text))
                {
                    lstMateriaPrima.Items[i].SubItems[1].Text = txtProvedor.Text;
                    lstMateriaPrima.Items[i].SubItems[2].Text = txtNombre.Text;
                    lstMateriaPrima.Items[i].SubItems[3].Text = txtPrecio.Text;
                    lstMateriaPrima.Items[i].SubItems[4].Text = txtStock.Text;
                    lstMateriaPrima.Items[i].SubItems[5].Text = txtStockProximo.Text;
                }
            }

            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtProvedor.Text = "";
            txtStock.Text = "";
            txtStockProximo.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            p_delIdMateriaPrima.Value = txtId.Text;
            conexion.Open();
            cmdBorrar.ExecuteNonQuery();
            conexion.Close();
            for(int i = 0; i < lstMateriaPrima.Items.Count; i++)
            {
                if (lstMateriaPrima.Items[i].SubItems[0].Text.Equals(txtId.Text))
                {
                    lstMateriaPrima.Items[i].Remove();
                }
            }

            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtProvedor.Text = "";
            txtStock.Text = "";
            txtStockProximo.Text = "";
        }
    }
}

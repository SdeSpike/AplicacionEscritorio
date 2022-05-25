using Microsoft.VisualBasic;
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
    public partial class Form1 : Form
    {
        static string strConexion = @"Data Source=segundo150\segundo150;Initial Catalog=DAM_LucianPotcoava;Integrated Security=True";
        static SqlConnection conexion = new SqlConnection(strConexion);

        //PRODUCTO
        SqlCommand cmdProductos = new SqlCommand("SELECT IdArticulo,IdCategoria,Nombre,Stock,Precio FROM Produccion.Productos WHERE IdCategoria=@p_IdCategoria", conexion);
        //SqlCommand cmdProductos = new SqlCommand("SELECT IdArticulo,IdCategoria,Nombre,Stock,Precio FROM Produccion.Productos WHERE IdCategoria=1", conexion);
        SqlParameter p_IdCategoria = new SqlParameter();

        SqlCommand cmdCategorias = new SqlCommand("SELECT IdCategoria,Nombre FROM Produccion.Categorias",conexion);

        DataTable tablaProductos = new DataTable();
        DataTable tablaCategorias = new DataTable();
        SqlDataAdapter adaptador = null;

        DataTable tablaCesta = new DataTable();

            
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            adaptador = new SqlDataAdapter(cmdCategorias);
            adaptador.Fill(tablaCategorias);
            cmbCategorias.DataSource = tablaCategorias;

            cmbCategorias.DisplayMember = "Nombre";
            cmbCategorias.ValueMember = "IdCategoria";

            p_IdCategoria.ParameterName = "@p_IdCategoria";
            p_IdCategoria.SqlDbType = SqlDbType.TinyInt;

            cmdProductos.Parameters.Add(p_IdCategoria);
            p_IdCategoria.Value = cmbCategorias.SelectedValue;

            adaptador = new SqlDataAdapter(cmdProductos);
            adaptador.Fill(tablaProductos);
            adaptador.FillSchema(tablaCesta,SchemaType.Source);
            tablaCesta.Columns.Add("Cantidad");
            tablaCesta.Columns.Add("Total");
            grdProductos.DataSource = tablaProductos;

        }

        private void cmbCategorias_SelectionChangeCommitted(object sender, EventArgs e)
        {
            p_IdCategoria.Value = cmbCategorias.SelectedValue;
            adaptador = new SqlDataAdapter(cmdProductos);
            tablaProductos.Rows.Clear();
            adaptador.Fill(tablaProductos);
            grdProductos.DataSource = tablaProductos;
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(grdProductos.Rows[grdProductos.SelectedRows[0].Index].Cells[2].Value.ToString());
            int cantidad = Int32.Parse(Interaction.InputBox("Inserte una cantidad"));


            DataRow fila = tablaCesta.NewRow();
            fila["IdArticulo"] = grdProductos.Rows[grdProductos.SelectedRows[0].Index].Cells[0].Value.ToString();
            fila["IdCategoria"] = grdProductos.Rows[grdProductos.SelectedRows[0].Index].Cells[1].Value.ToString();
            fila["Nombre"] = grdProductos.Rows[grdProductos.SelectedRows[0].Index].Cells[2].Value.ToString();
            fila["Stock"] =Int32.Parse(grdProductos.Rows[grdProductos.SelectedRows[0].Index].Cells[3].Value.ToString()) + cantidad;
            fila["Precio"] = grdProductos.Rows[grdProductos.SelectedRows[0].Index].Cells[4].Value.ToString();
            fila["Cantidad"] = cantidad;
            fila["Total"] = cantidad*float.Parse(grdProductos.Rows[grdProductos.SelectedRows[0].Index].Cells[4].Value.ToString());
            try
            {
                tablaCesta.Rows.Add(fila);
            }
            catch(Exception ex)
            {

            }
            grdCesta.DataSource = tablaCesta;
            
        }

        private void btnHacerPedido_Click(object sender, EventArgs e)
        {
            SqlCommand cmdHacerPedido = new SqlCommand("Produccion.HacerPedido", conexion);
            cmdHacerPedido.CommandType = CommandType.StoredProcedure;

            SqlParameter p_idMateriaPrima = new SqlParameter();
            SqlParameter p_cantidad = new SqlParameter();
            SqlParameter p_salida = new SqlParameter();

            p_idMateriaPrima.ParameterName = "@p_idMateriaPrima";
            p_idMateriaPrima.SqlDbType = SqlDbType.TinyInt;
            p_idMateriaPrima.Direction = ParameterDirection.Input;

            p_cantidad.ParameterName = "@p_cantidad";
            p_cantidad.SqlDbType = SqlDbType.Int;
            p_cantidad.Direction = ParameterDirection.Input;

            p_salida.ParameterName = "@p_salida";
            p_salida.SqlDbType = SqlDbType.Int;
            p_salida.Direction = ParameterDirection.Output;

            cmdCategorias.Parameters.Add(p_idMateriaPrima);
            cmdCategorias.Parameters.Add(p_cantidad);
            cmdCategorias.Parameters.Add(p_salida);

            for(int i = 0; i < tablaCesta.Rows.Count; i++)
            {
                p_idMateriaPrima.Value = tablaCesta.Rows[i][""];
            }
        }
    }
}

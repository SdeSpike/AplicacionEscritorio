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
    public partial class Pedidos : Form
    {
        static string strConexion = @"Data Source=segundo150\segundo150;Initial Catalog=DAM_LucianPotcoava;Integrated Security=True";
        static SqlConnection conexion = new SqlConnection(strConexion);
        SqlDataAdapter adaptador;

        SqlCommand cmdCategorias = new SqlCommand("SELECT IdCategoria,Nombre FROM Produccion.Categorias", conexion);
        DataTable taCategorias = new DataTable();

        SqlCommand cmdProductos = new SqlCommand("SELECT IdArticulo,IdCategoria,Nombre,Stock,Precio FROM Produccion.Productos WHERE IdCategoria=@p_IdCategoria",conexion);
        SqlParameter p_idCategoria = new SqlParameter();
        DataTable taProductos = new DataTable();

        SqlCommand cmdMateriaPrima = new SqlCommand("SELECT M.IdMateriaPrima,Nombre,Precio,Stock,StockProximo FROM Produccion.MateriaPrima M JOIN Produccion.LineaProduccion L ON M.IdMateriaPrima=l.IdMateriaPrima JOIN Produccion.Produccion P ON p.IdProduccion=l.IdProduccion WHERE p.IdProducto=@p_idProducto", conexion);
        SqlParameter p_idProducto = new SqlParameter();
        public Pedidos()
        {
            InitializeComponent();
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
            /*MATERIA PRIMA*/
            p_idProducto.ParameterName = "@p_idProducto";
            p_idProducto.SqlDbType = SqlDbType.Int;
            
            /*MATERIA PRIMA*/

            /*COMBO BOX DE CATEGORÍAS*/
            adaptador = new SqlDataAdapter(cmdCategorias);
            adaptador.Fill(taCategorias);
            cmbCategorias.DataSource = taCategorias;
            cmbCategorias.DisplayMember = "Nombre";
            cmbCategorias.ValueMember= "IdCategoria";
            /*COMBO BOX DE CATEGORÍAS*/


            /*LISTA DE PRODUCTOS*/
            p_idCategoria.ParameterName = "@p_IdCategoria";
            p_idCategoria.SqlDbType = SqlDbType.TinyInt;

            cmdProductos.Parameters.Add(p_idCategoria);
            p_idCategoria.Value = cmbCategorias.SelectedValue;

            adaptador = new SqlDataAdapter(cmdProductos);
            adaptador.Fill(taProductos);
            foreach(DataRow d in taProductos.Rows)
            {
                lstProductos.Items.Add(string.Format("{0}- {1}", d[0], d[2]));
            }

            /*LISTA DE PRODUCTOS*/
        }

        private void cmbCategorias_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (lstProductos.Items.Count > 0)
            {
                lstProductos.Items.Clear();
                taProductos.Clear();
            }
            p_idCategoria.Value = cmbCategorias.SelectedValue;
            adaptador = new SqlDataAdapter(cmdProductos);
            adaptador.Fill(taProductos);
            foreach (DataRow d in taProductos.Rows)
            {
                lstProductos.Items.Add(string.Format("{0}- {1}", d[0], d[2]));
            }
        }

        private void lstProductos_DoubleClick(object sender, EventArgs e)
        {
            p_idProducto.Value = "";
            
        }
    }
}

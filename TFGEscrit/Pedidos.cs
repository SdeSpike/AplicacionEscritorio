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
        DataTable taMateriaPrima = new DataTable();

        DataTable taMateriaPedido = new DataTable();

        SqlCommand cmdHacerPedido = new SqlCommand("Produccion.HacerPedido", conexion);
        SqlParameter p_idMateriaPrima = new SqlParameter();
        SqlParameter p_cantidad = new SqlParameter();
        SqlParameter p_salida = new SqlParameter();
        public Pedidos()
        {
            InitializeComponent();
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
            /*HACER PEDIDO*/
            cmdHacerPedido.CommandType = CommandType.StoredProcedure;

            p_idMateriaPrima.ParameterName = "@p_idMateriaPrima";
            p_idMateriaPrima.SqlDbType = SqlDbType.TinyInt;
            p_idMateriaPrima.Direction = ParameterDirection.Input;

            p_cantidad.ParameterName = "@p_cantidad";
            p_cantidad.SqlDbType = SqlDbType.Int;
            p_cantidad.Direction = ParameterDirection.Input;

            p_salida.ParameterName = "@p_salida";
            p_salida.SqlDbType = SqlDbType.Int;
            p_salida.Direction = ParameterDirection.Output;

            cmdHacerPedido.Parameters.Add(p_idMateriaPrima);
            cmdHacerPedido.Parameters.Add(p_cantidad);
            cmdHacerPedido.Parameters.Add(p_salida);
            /*HACER PEDIDO*/

            /*MATERIA PRIMA*/
            p_idProducto.ParameterName = "@p_idProducto";
            p_idProducto.SqlDbType = SqlDbType.Int;
            cmdMateriaPrima.Parameters.Add(p_idProducto);
            /*MATERIA PRIMA*/

            grdPedidos.DataSource = taMateriaPedido;
            p_idProducto.Value = 0;

            adaptador = new SqlDataAdapter(cmdMateriaPrima);
            adaptador.FillSchema(taMateriaPedido, SchemaType.Source);
            adaptador.FillSchema(taMateriaPrima, SchemaType.Source);
            taMateriaPedido.Columns.Add("Total");
            grdMateriaPrima.DataSource = taMateriaPrima;

            

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
            taMateriaPrima.Clear();
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
            try
            {
                taMateriaPrima.Clear();
                if (lstProductos.SelectedItem != null)
                {
                    string codigo = lstProductos.SelectedItem.ToString().Split('-')[0];
                    p_idProducto.Value = codigo;
                    adaptador = new SqlDataAdapter(cmdMateriaPrima);
                    adaptador.Fill(taMateriaPrima);
                }
                
            }
            catch(Exception ex)
            {

            }
            
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            //try
            //{
                int cantidad;
                for (int i = 0; i < grdPedidos.Rows.Count; i++)
                {
                    if (grdPedidos.Rows[i].Cells[0].Value.ToString().Equals(grdMateriaPrima.Rows[grdMateriaPrima.SelectedRows[0].Index].Cells[0].Value.ToString()))
                    {
                        cantidad = Int32.Parse(Interaction.InputBox("Inserte una cantidad"));
                        grdPedidos.Rows[i].Cells[4].Value = Int32.Parse(grdPedidos.Rows[i].Cells[4].Value.ToString()) +cantidad;
                        grdPedidos.Rows[i].Cells[5].Value = float.Parse(grdPedidos.Rows[i].Cells[5].Value.ToString()) + (cantidad * float.Parse(grdMateriaPrima.Rows[grdMateriaPrima.SelectedRows[0].Index].Cells[2].Value.ToString()));
                        return;
                    }
                }
                //MessageBox.Show(grdPedidos.Rows[0].Cells[0].Value.ToString());

                cantidad = Int32.Parse(Interaction.InputBox("Inserte una cantidad"));
                DataRow fila = taMateriaPedido.NewRow();
                fila["IdMateriaPrima"] = grdMateriaPrima.Rows[grdMateriaPrima.SelectedRows[0].Index].Cells[0].Value.ToString();
                fila["Nombre"] = grdMateriaPrima.Rows[grdMateriaPrima.SelectedRows[0].Index].Cells[1].Value.ToString();
                fila["Precio"] = grdMateriaPrima.Rows[grdMateriaPrima.SelectedRows[0].Index].Cells[2].Value.ToString();
                fila["Stock"] = grdMateriaPrima.Rows[grdMateriaPrima.SelectedRows[0].Index].Cells[3].Value.ToString();
                fila["StockProximo"] = cantidad;
                fila["Total"] = cantidad * float.Parse(grdMateriaPrima.Rows[grdMateriaPrima.SelectedRows[0].Index].Cells[2].Value.ToString());
                taMateriaPedido.Rows.Add(fila);
            //}
            //catch (Exception ex)
            //{

            //}
        }

        private void btnHacerPedido_Click(object sender, EventArgs e)
        {
            
            conexion.Open();
            for(int i = 0; i < grdPedidos.Rows.Count; i++)
            {
                p_idMateriaPrima.Value = grdPedidos.Rows[i].Cells[0].Value.ToString();
                p_cantidad.Value = grdPedidos.Rows[i].Cells[4].Value.ToString();
                cmdHacerPedido.ExecuteNonQuery();
            }
            conexion.Close();
        }
    }
}

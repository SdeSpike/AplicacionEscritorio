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
    public partial class LogFabricando : Form
    {
        static string strConexion = @"Data Source=DESKTOP-2915P7L;Initial Catalog=TFG;Integrated Security=True";
        SqlConnection conexion = new SqlConnection(strConexion);

        SqlCommand cmdFabricando = new SqlCommand("SELECT IdFabricando,IdProduccion,FechaInicio,FechaFinal FROM Produccion.Fabricando ORDER BY IdProduccion");
        SqlDataReader lector;

        SqlCommand cmdProducto = new SqlCommand(@"SELECT R.IdProduccion,IdArticulo,C.Nombre,Stock,Precio,P.Nombre FROM Produccion.Productos P 
                                                JOIN Produccion.Categorias C ON P.IdCategoria=C.IdCategoria
                                                JOIN Produccion.Produccion R ON R.IdProducto=P.IdArticulo
                                                ORDER BY IdArticulo");
        SqlDataAdapter adaptador = null;
        DataTable taProducto = new DataTable();


        SqlCommand cmdMateriaPrima = new SqlCommand(@"SELECT M.IdMateriaPrima,M.Nombre,L.Cantidad FROM Produccion.MateriaPrima M
                                                    JOIN Produccion.LineaProduccion L ON L.IdMateriaPrima=M.IdMateriaPrima
                                                    WHERE L.IdProduccion=@p_idProduccion");
        SqlParameter p_idProduccion = new SqlParameter();
        DataTable taLineaPrima = new DataTable();
        public LogFabricando()
        {
            InitializeComponent();
        }

        private void LogFabricando_Load(object sender, EventArgs e)
        {
            /*MATERIA PRIMA*/
            cmdMateriaPrima.Connection = conexion;

            p_idProduccion.ParameterName = "@p_idProduccion";
            p_idProduccion.SqlDbType = SqlDbType.Int;

            cmdMateriaPrima.Parameters.Add(p_idProduccion);
            /*MATERIA PRIMA*/

            /*PRODUCTOS*/
            cmdProducto.Connection = conexion;
            adaptador = new SqlDataAdapter(cmdProducto);
            adaptador.Fill(taProducto);
            /*PRODUCTOS*/

            ListViewItem l;
            cmdFabricando.Connection = conexion;

            conexion.Open();
            lector = cmdFabricando.ExecuteReader();
            while (lector.Read())
            {
                l = lstDatos.Items.Add(lector[0].ToString());
                l.SubItems.Add(lector[1].ToString());
                l.SubItems.Add(lector[2].ToString());
                l.SubItems.Add(lector[3].ToString());
            }
            conexion.Close();
        }

        private void lstDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void lstDatos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string idTabla;
            string idList= lstDatos.SelectedItems[0].SubItems[1].Text;

            int cantidad = 0;
            DateTime fechaInicio=DateTime.Parse(lstDatos.SelectedItems[0].SubItems[2].Text);
            DateTime fechaFinal=DateTime.Parse(lstDatos.SelectedItems[0].SubItems[3].Text);
            lblCantidad.Text = fechaFinal.Subtract(fechaInicio).TotalMinutes.ToString();

            p_idProduccion.Value = idList;

            if (taLineaPrima.Rows.Count > 0)
            {
                taLineaPrima.Clear();
            }
            adaptador = new SqlDataAdapter(cmdMateriaPrima);
            adaptador.Fill(taLineaPrima);
            grdPrimas.DataSource = taLineaPrima;

            for (int i = 0; i < taProducto.Rows.Count; i++)
            {
                idTabla = taProducto.Rows[i][0].ToString();
                if (idTabla.Equals(idList))
                {

                    lblId.Text = taProducto.Rows[i][1].ToString();
                    lblStock.Text = taProducto.Rows[i][3].ToString();
                    lblCategoria.Text = taProducto.Rows[i][2].ToString();
                    lblPrecio.Text = taProducto.Rows[i][4].ToString();
                    lblNombre.Text = taProducto.Rows[i][5].ToString();
                    break;
                }
            }
            
        }
    }
}

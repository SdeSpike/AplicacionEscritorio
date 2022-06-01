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
    public partial class MovimientoMateriaPrima : Form
    {
        static string strConexion = @"Data Source=DESKTOP-2915P7L;Initial Catalog=TFG;Integrated Security=True";
        SqlConnection conexion = new SqlConnection(strConexion);

        SqlCommand cmdMateriaPrima = new SqlCommand(@"SELECT IdMateriaPrima,Nombre,Precio,Stock,StockProximo FROM Produccion.MateriaPrima");
        SqlDataReader lector;

        SqlCommand cmdMovimientoPrima = new SqlCommand(@"SELECT IdMovimiento,IdMateriaPrima,Cantidad,Fecha 
                                                        FROM Produccion.MovimientoPrima
                                                        WHERE IdMateriaPrima=@p_IdMateriaPrima");
        SqlDataAdapter adaptador;
        DataTable taMovimientoTabla = new DataTable();
        SqlParameter p_IdMateriaPrima = new SqlParameter();

        int indice = 0;
        public MovimientoMateriaPrima()
        {
            InitializeComponent();
        }

        private void MovimientoMateriaPrima_Load(object sender, EventArgs e)
        {
            /*MOVIMIENTO PRIMA*/
            cmdMovimientoPrima.Connection = conexion;

            p_IdMateriaPrima.ParameterName = "@p_IdMateriaPrima";
            p_IdMateriaPrima.SqlDbType = SqlDbType.TinyInt;

            cmdMovimientoPrima.Parameters.Add(p_IdMateriaPrima);
            /*MOVIMIENTO PRIMA*/

            ListViewItem l;
            cmdMateriaPrima.Connection = conexion;

            /*MATERIA PRIMA*/
            conexion.Open();
            lector = cmdMateriaPrima.ExecuteReader();
            while (lector.Read())
            {
                l = lstPrima.Items.Add(lector[0].ToString());
                l.SubItems.Add(lector[1].ToString());
                l.SubItems.Add(lector[2].ToString());
                l.SubItems.Add(lector[3].ToString());
                l.SubItems.Add(lector[4].ToString());
            }
            conexion.Close();
            /*MATERIA PRIMA*/

        }

        private void lstPrima_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (taMovimientoTabla.Rows.Count > 0)
            {
                taMovimientoTabla.Rows.Clear();
            }
            p_IdMateriaPrima.Value = lstPrima.SelectedItems[0].SubItems[0].Text.ToString();
            adaptador = new SqlDataAdapter(cmdMovimientoPrima);
            adaptador.Fill(taMovimientoTabla);
            if (taMovimientoTabla.Rows.Count > 0)
            {
                indice = 0;
                lblId.Text = taMovimientoTabla.Rows[indice][0].ToString();
                lblNombre.Text = lstPrima.SelectedItems[0].SubItems[1].Text.ToString();
                lblCantidad.Text = taMovimientoTabla.Rows[indice][2].ToString();
                lblFecha.Text= taMovimientoTabla.Rows[indice][3].ToString();
            }
            
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if ((indice - 1) >= 0)
            {
                indice -= 1;
                lblId.Text = taMovimientoTabla.Rows[indice][0].ToString();
                lblNombre.Text = lstPrima.SelectedItems[0].SubItems[1].Text.ToString();
                lblCantidad.Text = taMovimientoTabla.Rows[indice][2].ToString();
                lblFecha.Text = taMovimientoTabla.Rows[indice][3].ToString();
            }
        }

        private void btnDelante_Click(object sender, EventArgs e)
        {
            if((indice + 1) < taMovimientoTabla.Rows.Count)
            {
                indice += 1;
                lblId.Text = taMovimientoTabla.Rows[indice][0].ToString();
                lblNombre.Text = lstPrima.SelectedItems[0].SubItems[1].Text.ToString();
                lblCantidad.Text = taMovimientoTabla.Rows[indice][2].ToString();
                lblFecha.Text = taMovimientoTabla.Rows[indice][3].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GridMovimientosPrimas grd = new GridMovimientosPrimas(taMovimientoTabla);
            grd.Show();
        }
    }
}

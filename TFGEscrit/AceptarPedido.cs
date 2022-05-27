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
    public partial class AceptarPedido : Form
    {
        static string strConexion = @"Data Source=DESKTOP-2915P7L;Initial Catalog=TFG;Integrated Security=True";
        static SqlConnection conexion = new SqlConnection(strConexion);

        SqlCommand cmdPedidos = new SqlCommand("SELECT IdPedido,m.Nombre,Cantidad,Finalizado FROM Produccion.Pedido P JOIN Produccion.MateriaPrima M ON p.IdMateriaPrima=m.IdMateriaPrima ORDER BY Finalizado", conexion);
        SqlDataReader lector;

        static SqlCommand cmdMateriaPrima = new SqlCommand("SELECT IdMateriaPrima,Nombre FROM Produccion.MateriaPrima", conexion);
        DataTable daMateriaPrima = new DataTable();
        SqlDataAdapter adaptador = new SqlDataAdapter(cmdMateriaPrima);

        SqlCommand cmdConfimarPedido = new SqlCommand("Produccion.FinalizarPedido");
        SqlParameter p_idPedido = new SqlParameter();
        SqlParameter p_idMateriaPrima = new SqlParameter();
        SqlParameter p_salida = new SqlParameter();

        
        

        public AceptarPedido()
        {
            InitializeComponent();
        }

        private void AceptarPedido_Load(object sender, EventArgs e)
        {
            adaptador.Fill(daMateriaPrima);

            /*CONFIRMAR PEDIDO*/
            cmdConfimarPedido.CommandType = CommandType.StoredProcedure;

            p_idPedido.ParameterName = "@p_IdPedido";
            p_idPedido.SqlDbType = SqlDbType.Int;

            p_idMateriaPrima.ParameterName = "@p_IdMateriaPrima";
            p_idMateriaPrima.SqlDbType = SqlDbType.TinyInt;

            p_salida.ParameterName = "@p_salida";
            p_salida.SqlDbType = SqlDbType.Int;
            p_salida.Direction = ParameterDirection.Output;

            cmdConfimarPedido.Parameters.Add(p_idPedido);
            cmdConfimarPedido.Parameters.Add(p_idMateriaPrima);
            cmdConfimarPedido.Parameters.Add(p_salida);
            /*CONFIRMAR PEDIDO*/


            conexion.Open();
            lector = cmdPedidos.ExecuteReader();
            while (lector.Read())
            {
                ListViewItem l = lstPedidos.Items.Add(lector[0].ToString());
                l.SubItems.Add(lector[1].ToString());
                l.SubItems.Add(lector[2].ToString());
                l.SubItems.Add(lector[3].ToString());
            }
            conexion.Close();
            
        }

        private void lstPedidos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            for(int i = 0; i < daMateriaPrima.Rows.Count; i++)
            {
                if (daMateriaPrima.Rows[i][1].ToString().Equals(lstPedidos.SelectedItems[0].SubItems[1].Text))
                {
                    txtIdMateriaPrima.Text = daMateriaPrima.Rows[i][0].ToString();
                    break;
                }
            }

            
            txtIdPedido.Text = lstPedidos.SelectedItems[0].SubItems[0].Text;
            txtCantidad.Text= lstPedidos.SelectedItems[0].SubItems[2].Text;
            txtFinalizado.Text= lstPedidos.SelectedItems[0].SubItems[3].Text;
            if (txtFinalizado.Text.Equals("N"))
            {
                btnFinalizar.Enabled = true;
                btnFinalizar.Visible = true;
            }
            else
            {
                btnFinalizar.Enabled = false;
                btnFinalizar.Visible = false;
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            DialogResult d=MessageBox.Show("Confirmar pedido?","CONFIRMAR", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                SqlConnection aux = new SqlConnection(strConexion);
                cmdConfimarPedido.Connection = aux;
                p_idPedido.Value = txtIdPedido.Text;
                p_idMateriaPrima.Value = txtIdMateriaPrima.Text;
                aux.Open();
                cmdConfimarPedido.ExecuteNonQuery();
                aux.Close();
                if (p_salida.Value.ToString().Equals("1"))
                {
                    MessageBox.Show("Confirmado con exito");

                    string x="";
                    for(int i = 0; i < daMateriaPrima.Rows.Count; i++)
                    {
                        if (daMateriaPrima.Rows[i][0].ToString().Equals(txtIdMateriaPrima.Text))
                        {
                            x = daMateriaPrima.Rows[i][1].ToString();
                            break;
                        }
                    }
                    for (int i = 0; i < lstPedidos.Items.Count; i++)
                    {
                        if (lstPedidos.Items[i].SubItems[1].Text.Equals(x)&& lstPedidos.Items[i].SubItems[0].Text.Equals(txtIdPedido.Text))
                        {
                            lstPedidos.Items[i].SubItems[3].Text ="S";
                            break;
                        }
                    }


                    txtCantidad.Text = "";
                    txtFinalizado.Text = "";
                    txtIdMateriaPrima.Text = "";
                    txtIdPedido.Text = "";

                    btnFinalizar.Enabled = false;
                    btnFinalizar.Visible = false;

                    
                }
                else
                {
                    MessageBox.Show("Se ha producido un error");
                }
            }
        }
    }
}

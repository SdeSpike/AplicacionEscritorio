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
        SqlCommand cmdProductos = new SqlCommand("SELECT IdArticulo,IdCategoria,Nombre,Stock,Precio FROM Produccion.Productos",conexion);

        SqlCommand cmdCategorias = new SqlCommand("SELECT IdCategoria,Nombre FROM Produccion.Categorias",conexion);

        BindingSource acopladorProductos=new BindingSource();
        BindingSource acopladorCategorias=new BindingSource();
            
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            
        }
    }
}

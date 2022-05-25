
namespace TFGEscrit
{
    partial class Pedidos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbCategorias = new System.Windows.Forms.ComboBox();
            this.lstProductos = new System.Windows.Forms.ListBox();
            this.grdMateriaPrima = new System.Windows.Forms.DataGridView();
            this.grdPedidos = new System.Windows.Forms.DataGridView();
            this.btnPedido = new System.Windows.Forms.Button();
            this.btnHacerPedido = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdMateriaPrima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCategorias
            // 
            this.cmbCategorias.FormattingEnabled = true;
            this.cmbCategorias.Location = new System.Drawing.Point(59, 28);
            this.cmbCategorias.Name = "cmbCategorias";
            this.cmbCategorias.Size = new System.Drawing.Size(401, 21);
            this.cmbCategorias.TabIndex = 2;
            this.cmbCategorias.SelectionChangeCommitted += new System.EventHandler(this.cmbCategorias_SelectionChangeCommitted);
            // 
            // lstProductos
            // 
            this.lstProductos.FormattingEnabled = true;
            this.lstProductos.Location = new System.Drawing.Point(59, 87);
            this.lstProductos.Name = "lstProductos";
            this.lstProductos.Size = new System.Drawing.Size(401, 290);
            this.lstProductos.TabIndex = 3;
            this.lstProductos.DoubleClick += new System.EventHandler(this.lstProductos_DoubleClick);
            // 
            // grdMateriaPrima
            // 
            this.grdMateriaPrima.AllowUserToAddRows = false;
            this.grdMateriaPrima.AllowUserToDeleteRows = false;
            this.grdMateriaPrima.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMateriaPrima.Location = new System.Drawing.Point(581, 87);
            this.grdMateriaPrima.Name = "grdMateriaPrima";
            this.grdMateriaPrima.ReadOnly = true;
            this.grdMateriaPrima.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdMateriaPrima.Size = new System.Drawing.Size(805, 290);
            this.grdMateriaPrima.TabIndex = 4;
            // 
            // grdPedidos
            // 
            this.grdPedidos.AllowUserToAddRows = false;
            this.grdPedidos.AllowUserToDeleteRows = false;
            this.grdPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPedidos.Location = new System.Drawing.Point(59, 413);
            this.grdPedidos.Name = "grdPedidos";
            this.grdPedidos.ReadOnly = true;
            this.grdPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPedidos.Size = new System.Drawing.Size(817, 215);
            this.grdPedidos.TabIndex = 5;
            // 
            // btnPedido
            // 
            this.btnPedido.Location = new System.Drawing.Point(1242, 397);
            this.btnPedido.Name = "btnPedido";
            this.btnPedido.Size = new System.Drawing.Size(130, 23);
            this.btnPedido.TabIndex = 6;
            this.btnPedido.Text = "Agregar al pedido";
            this.btnPedido.UseVisualStyleBackColor = true;
            this.btnPedido.Click += new System.EventHandler(this.btnPedido_Click);
            // 
            // btnHacerPedido
            // 
            this.btnHacerPedido.Location = new System.Drawing.Point(897, 605);
            this.btnHacerPedido.Name = "btnHacerPedido";
            this.btnHacerPedido.Size = new System.Drawing.Size(130, 23);
            this.btnHacerPedido.TabIndex = 7;
            this.btnHacerPedido.Text = "Hacer el pedido";
            this.btnHacerPedido.UseVisualStyleBackColor = true;
            this.btnHacerPedido.Click += new System.EventHandler(this.btnHacerPedido_Click);
            // 
            // Pedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1466, 690);
            this.Controls.Add(this.btnHacerPedido);
            this.Controls.Add(this.btnPedido);
            this.Controls.Add(this.grdPedidos);
            this.Controls.Add(this.grdMateriaPrima);
            this.Controls.Add(this.lstProductos);
            this.Controls.Add(this.cmbCategorias);
            this.Name = "Pedidos";
            this.Text = "Pedidos";
            this.Load += new System.EventHandler(this.Pedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMateriaPrima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPedidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCategorias;
        private System.Windows.Forms.ListBox lstProductos;
        private System.Windows.Forms.DataGridView grdMateriaPrima;
        private System.Windows.Forms.DataGridView grdPedidos;
        private System.Windows.Forms.Button btnPedido;
        private System.Windows.Forms.Button btnHacerPedido;
    }
}

namespace TFGEscrit
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdProductos = new System.Windows.Forms.DataGridView();
            this.cmbCategorias = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.grdCesta = new System.Windows.Forms.DataGridView();
            this.btnHacerPedido = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCesta)).BeginInit();
            this.SuspendLayout();
            // 
            // grdProductos
            // 
            this.grdProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProductos.Location = new System.Drawing.Point(51, 86);
            this.grdProductos.Name = "grdProductos";
            this.grdProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdProductos.Size = new System.Drawing.Size(543, 232);
            this.grdProductos.TabIndex = 0;
            // 
            // cmbCategorias
            // 
            this.cmbCategorias.FormattingEnabled = true;
            this.cmbCategorias.Location = new System.Drawing.Point(51, 27);
            this.cmbCategorias.Name = "cmbCategorias";
            this.cmbCategorias.Size = new System.Drawing.Size(121, 21);
            this.cmbCategorias.TabIndex = 1;
            this.cmbCategorias.SelectionChangeCommitted += new System.EventHandler(this.cmbCategorias_SelectionChangeCommitted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grdCesta
            // 
            this.grdCesta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCesta.Location = new System.Drawing.Point(682, 86);
            this.grdCesta.Name = "grdCesta";
            this.grdCesta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCesta.Size = new System.Drawing.Size(743, 232);
            this.grdCesta.TabIndex = 3;
            // 
            // btnHacerPedido
            // 
            this.btnHacerPedido.Location = new System.Drawing.Point(1300, 333);
            this.btnHacerPedido.Name = "btnHacerPedido";
            this.btnHacerPedido.Size = new System.Drawing.Size(125, 23);
            this.btnHacerPedido.TabIndex = 4;
            this.btnHacerPedido.Text = "Hacer pedido";
            this.btnHacerPedido.UseVisualStyleBackColor = true;
            this.btnHacerPedido.Click += new System.EventHandler(this.btnHacerPedido_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 692);
            this.Controls.Add(this.btnHacerPedido);
            this.Controls.Add(this.grdCesta);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbCategorias);
            this.Controls.Add(this.grdProductos);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCesta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdProductos;
        private System.Windows.Forms.ComboBox cmbCategorias;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView grdCesta;
        private System.Windows.Forms.Button btnHacerPedido;
    }
}


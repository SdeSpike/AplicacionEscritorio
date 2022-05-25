
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
            ((System.ComponentModel.ISupportInitialize)(this.grdMateriaPrima)).BeginInit();
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
            this.grdMateriaPrima.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMateriaPrima.Location = new System.Drawing.Point(581, 87);
            this.grdMateriaPrima.Name = "grdMateriaPrima";
            this.grdMateriaPrima.Size = new System.Drawing.Size(805, 290);
            this.grdMateriaPrima.TabIndex = 4;
            // 
            // Pedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1466, 690);
            this.Controls.Add(this.grdMateriaPrima);
            this.Controls.Add(this.lstProductos);
            this.Controls.Add(this.cmbCategorias);
            this.Name = "Pedidos";
            this.Text = "Pedidos";
            this.Load += new System.EventHandler(this.Pedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMateriaPrima)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCategorias;
        private System.Windows.Forms.ListBox lstProductos;
        private System.Windows.Forms.DataGridView grdMateriaPrima;
    }
}
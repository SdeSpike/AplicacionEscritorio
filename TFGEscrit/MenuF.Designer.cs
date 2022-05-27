
namespace TFGEscrit
{
    partial class MenuF
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPedidos = new System.Windows.Forms.Button();
            this.paPedidos = new System.Windows.Forms.Panel();
            this.btnHacerPedido = new System.Windows.Forms.Button();
            this.btnConfirmarPedido = new System.Windows.Forms.Button();
            this.pFormularios = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.paPedidos.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panel1.Controls.Add(this.paPedidos);
            this.panel1.Controls.Add(this.btnPedidos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 731);
            this.panel1.TabIndex = 0;
            // 
            // btnPedidos
            // 
            this.btnPedidos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPedidos.FlatAppearance.BorderSize = 0;
            this.btnPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPedidos.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnPedidos.Location = new System.Drawing.Point(0, 0);
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnPedidos.Size = new System.Drawing.Size(250, 45);
            this.btnPedidos.TabIndex = 1;
            this.btnPedidos.Text = "Pedidos";
            this.btnPedidos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPedidos.UseVisualStyleBackColor = true;
            this.btnPedidos.Click += new System.EventHandler(this.btnPedidos_Click);
            // 
            // paPedidos
            // 
            this.paPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.paPedidos.Controls.Add(this.btnConfirmarPedido);
            this.paPedidos.Controls.Add(this.btnHacerPedido);
            this.paPedidos.Dock = System.Windows.Forms.DockStyle.Top;
            this.paPedidos.Location = new System.Drawing.Point(0, 45);
            this.paPedidos.Name = "paPedidos";
            this.paPedidos.Size = new System.Drawing.Size(250, 90);
            this.paPedidos.TabIndex = 2;
            // 
            // btnHacerPedido
            // 
            this.btnHacerPedido.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHacerPedido.FlatAppearance.BorderSize = 0;
            this.btnHacerPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHacerPedido.ForeColor = System.Drawing.Color.LightGray;
            this.btnHacerPedido.Location = new System.Drawing.Point(0, 0);
            this.btnHacerPedido.Name = "btnHacerPedido";
            this.btnHacerPedido.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnHacerPedido.Size = new System.Drawing.Size(250, 40);
            this.btnHacerPedido.TabIndex = 0;
            this.btnHacerPedido.Text = "Hacer pedido";
            this.btnHacerPedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHacerPedido.UseVisualStyleBackColor = true;
            this.btnHacerPedido.Click += new System.EventHandler(this.btnHacerPedido_Click);
            // 
            // btnConfirmarPedido
            // 
            this.btnConfirmarPedido.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConfirmarPedido.FlatAppearance.BorderSize = 0;
            this.btnConfirmarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarPedido.ForeColor = System.Drawing.Color.LightGray;
            this.btnConfirmarPedido.Location = new System.Drawing.Point(0, 40);
            this.btnConfirmarPedido.Name = "btnConfirmarPedido";
            this.btnConfirmarPedido.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnConfirmarPedido.Size = new System.Drawing.Size(250, 40);
            this.btnConfirmarPedido.TabIndex = 1;
            this.btnConfirmarPedido.Text = "Confirmar pedido";
            this.btnConfirmarPedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmarPedido.UseVisualStyleBackColor = true;
            this.btnConfirmarPedido.Click += new System.EventHandler(this.btnConfirmarPedido_Click);
            // 
            // pFormularios
            // 
            this.pFormularios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(45)))));
            this.pFormularios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFormularios.Location = new System.Drawing.Point(250, 0);
            this.pFormularios.Name = "pFormularios";
            this.pFormularios.Size = new System.Drawing.Size(1337, 731);
            this.pFormularios.TabIndex = 2;
            // 
            // MenuF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1587, 731);
            this.Controls.Add(this.pFormularios);
            this.Controls.Add(this.panel1);
            this.Name = "MenuF";
            this.Text = "MenuF";
            this.panel1.ResumeLayout(false);
            this.paPedidos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel paPedidos;
        private System.Windows.Forms.Button btnConfirmarPedido;
        private System.Windows.Forms.Button btnHacerPedido;
        private System.Windows.Forms.Button btnPedidos;
        private System.Windows.Forms.Panel pFormularios;
    }
}
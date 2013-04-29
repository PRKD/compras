namespace Costes_Logisticos_Quality
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.qC600DataSet1 = new Costes_Logisticos_Quality.QC600DataSet();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informePorFechasAgenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informeArticuloComprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informeRutasAgenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informePedidosFechasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarEnExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.qC600DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // qC600DataSet1
            // 
            this.qC600DataSet1.DataSetName = "QC600DataSet";
            this.qC600DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1063, 316);
            this.dataGridView1.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.informesToolStripMenuItem,
            this.guardarEnExcelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1063, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(60, 20);
            this.toolStripMenuItem1.Text = "Archivo";
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // informesToolStripMenuItem
            // 
            this.informesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informePorFechasAgenciasToolStripMenuItem,
            this.informeArticuloComprasToolStripMenuItem,
            this.informeRutasAgenciaToolStripMenuItem,
            this.informePedidosFechasToolStripMenuItem});
            this.informesToolStripMenuItem.Name = "informesToolStripMenuItem";
            this.informesToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.informesToolStripMenuItem.Text = "Informes";
            // 
            // informePorFechasAgenciasToolStripMenuItem
            // 
            this.informePorFechasAgenciasToolStripMenuItem.Name = "informePorFechasAgenciasToolStripMenuItem";
            this.informePorFechasAgenciasToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.informePorFechasAgenciasToolStripMenuItem.Text = "Informe Proveedores Compras";
            this.informePorFechasAgenciasToolStripMenuItem.Click += new System.EventHandler(this.informePorFechasAgenciasToolStripMenuItem_Click);
            // 
            // informeArticuloComprasToolStripMenuItem
            // 
            this.informeArticuloComprasToolStripMenuItem.Name = "informeArticuloComprasToolStripMenuItem";
            this.informeArticuloComprasToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.informeArticuloComprasToolStripMenuItem.Text = "Informe Articulo Compras";
            this.informeArticuloComprasToolStripMenuItem.Click += new System.EventHandler(this.informeArticuloComprasToolStripMenuItem_Click);
            // 
            // informeRutasAgenciaToolStripMenuItem
            // 
            this.informeRutasAgenciaToolStripMenuItem.Name = "informeRutasAgenciaToolStripMenuItem";
            this.informeRutasAgenciaToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.informeRutasAgenciaToolStripMenuItem.Text = "Informe Rutas Agencia";
            this.informeRutasAgenciaToolStripMenuItem.Click += new System.EventHandler(this.informeRutasAgenciaToolStripMenuItem_Click);
            // 
            // informePedidosFechasToolStripMenuItem
            // 
            this.informePedidosFechasToolStripMenuItem.Name = "informePedidosFechasToolStripMenuItem";
            this.informePedidosFechasToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.informePedidosFechasToolStripMenuItem.Text = "Informe Pedidos Fechas";
            this.informePedidosFechasToolStripMenuItem.Click += new System.EventHandler(this.informePedidosFechasToolStripMenuItem_Click);
            // 
            // guardarEnExcelToolStripMenuItem
            // 
            this.guardarEnExcelToolStripMenuItem.Name = "guardarEnExcelToolStripMenuItem";
            this.guardarEnExcelToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.guardarEnExcelToolStripMenuItem.Text = "Guardar en Excel";
            this.guardarEnExcelToolStripMenuItem.Click += new System.EventHandler(this.guardarEnExcelToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 340);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "Albaran compras";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.qC600DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QC600DataSet qC600DataSet1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informePorFechasAgenciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarEnExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informeArticuloComprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informeRutasAgenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informePedidosFechasToolStripMenuItem;
    }
}


namespace importarFIPE
{
    partial class frmPrincipal
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
            this.btnImportaMarcas = new System.Windows.Forms.Button();
            this.btnImportaVeiculos = new System.Windows.Forms.Button();
            this.btnImpModVeiMarca = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssMarcas = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssVeiculos = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssModVei = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssDetalhes = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSqlMarcas = new System.Windows.Forms.Button();
            this.btnSqlVeiculos = new System.Windows.Forms.Button();
            this.btnSqlModVei = new System.Windows.Forms.Button();
            this.btnSqlBaseTabelas = new System.Windows.Forms.Button();
            this.btnImpDetalhesMod = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSqlDetalhes = new System.Windows.Forms.Button();
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImportaMarcas
            // 
            this.btnImportaMarcas.Location = new System.Drawing.Point(107, 61);
            this.btnImportaMarcas.Name = "btnImportaMarcas";
            this.btnImportaMarcas.Size = new System.Drawing.Size(166, 23);
            this.btnImportaMarcas.TabIndex = 0;
            this.btnImportaMarcas.Text = "Importar Marcas";
            this.btnImportaMarcas.UseVisualStyleBackColor = true;
            this.btnImportaMarcas.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnImportaVeiculos
            // 
            this.btnImportaVeiculos.Location = new System.Drawing.Point(107, 90);
            this.btnImportaVeiculos.Name = "btnImportaVeiculos";
            this.btnImportaVeiculos.Size = new System.Drawing.Size(166, 23);
            this.btnImportaVeiculos.TabIndex = 1;
            this.btnImportaVeiculos.Text = "Importar Veiculos > Marca";
            this.btnImportaVeiculos.UseVisualStyleBackColor = true;
            this.btnImportaVeiculos.Click += new System.EventHandler(this.btnImportaVeiculos_Click);
            // 
            // btnImpModVeiMarca
            // 
            this.btnImpModVeiMarca.Location = new System.Drawing.Point(107, 119);
            this.btnImpModVeiMarca.Name = "btnImpModVeiMarca";
            this.btnImpModVeiMarca.Size = new System.Drawing.Size(166, 23);
            this.btnImpModVeiMarca.TabIndex = 2;
            this.btnImpModVeiMarca.Text = "Imp. Modelo > Veiculo > Marca";
            this.btnImpModVeiMarca.UseVisualStyleBackColor = true;
            this.btnImpModVeiMarca.Click += new System.EventHandler(this.btnImpModVeiMarca_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssMarcas,
            this.tssVeiculos,
            this.tssModVei,
            this.tssDetalhes});
            this.statusStrip1.Location = new System.Drawing.Point(0, 255);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(419, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssMarcas
            // 
            this.tssMarcas.Name = "tssMarcas";
            this.tssMarcas.Size = new System.Drawing.Size(57, 17);
            this.tssMarcas.Text = "Marcas: 0";
            // 
            // tssVeiculos
            // 
            this.tssVeiculos.Name = "tssVeiculos";
            this.tssVeiculos.Size = new System.Drawing.Size(62, 17);
            this.tssVeiculos.Text = "Veiculos: 0";
            // 
            // tssModVei
            // 
            this.tssModVei.Name = "tssModVei";
            this.tssModVei.Size = new System.Drawing.Size(116, 17);
            this.tssModVei.Text = "Modelos->Veiculo: 0";
            // 
            // tssDetalhes
            // 
            this.tssDetalhes.Name = "tssDetalhes";
            this.tssDetalhes.Size = new System.Drawing.Size(0, 17);
            // 
            // btnSqlMarcas
            // 
            this.btnSqlMarcas.Location = new System.Drawing.Point(279, 61);
            this.btnSqlMarcas.Name = "btnSqlMarcas";
            this.btnSqlMarcas.Size = new System.Drawing.Size(42, 23);
            this.btnSqlMarcas.TabIndex = 4;
            this.btnSqlMarcas.Text = "SQL";
            this.btnSqlMarcas.UseVisualStyleBackColor = true;
            this.btnSqlMarcas.Click += new System.EventHandler(this.btnSqlMarcas_Click);
            // 
            // btnSqlVeiculos
            // 
            this.btnSqlVeiculos.Location = new System.Drawing.Point(279, 90);
            this.btnSqlVeiculos.Name = "btnSqlVeiculos";
            this.btnSqlVeiculos.Size = new System.Drawing.Size(42, 23);
            this.btnSqlVeiculos.TabIndex = 5;
            this.btnSqlVeiculos.Text = "SQL";
            this.btnSqlVeiculos.UseVisualStyleBackColor = true;
            this.btnSqlVeiculos.Click += new System.EventHandler(this.btnSqlVeiculos_Click);
            // 
            // btnSqlModVei
            // 
            this.btnSqlModVei.Location = new System.Drawing.Point(279, 119);
            this.btnSqlModVei.Name = "btnSqlModVei";
            this.btnSqlModVei.Size = new System.Drawing.Size(42, 23);
            this.btnSqlModVei.TabIndex = 6;
            this.btnSqlModVei.Text = "SQL";
            this.btnSqlModVei.UseVisualStyleBackColor = true;
            this.btnSqlModVei.Click += new System.EventHandler(this.btnSqlModVei_Click);
            // 
            // btnSqlBaseTabelas
            // 
            this.btnSqlBaseTabelas.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnSqlBaseTabelas.Location = new System.Drawing.Point(107, 12);
            this.btnSqlBaseTabelas.Name = "btnSqlBaseTabelas";
            this.btnSqlBaseTabelas.Size = new System.Drawing.Size(214, 33);
            this.btnSqlBaseTabelas.TabIndex = 7;
            this.btnSqlBaseTabelas.Text = "BASE DE TABELAS SQL";
            this.btnSqlBaseTabelas.UseVisualStyleBackColor = false;
            this.btnSqlBaseTabelas.Click += new System.EventHandler(this.btnSqlBaseTabelas_Click);
            // 
            // btnImpDetalhesMod
            // 
            this.btnImpDetalhesMod.Location = new System.Drawing.Point(107, 148);
            this.btnImpDetalhesMod.Name = "btnImpDetalhesMod";
            this.btnImpDetalhesMod.Size = new System.Drawing.Size(166, 23);
            this.btnImpDetalhesMod.TabIndex = 8;
            this.btnImpDetalhesMod.Text = "Imp. Detalhes do Modelo";
            this.btnImpDetalhesMod.UseVisualStyleBackColor = true;
            this.btnImpDetalhesMod.Click += new System.EventHandler(this.btnImpDetalhesMod_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "IMPORTAR TODOS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnSqlDetalhes
            // 
            this.btnSqlDetalhes.Location = new System.Drawing.Point(279, 148);
            this.btnSqlDetalhes.Name = "btnSqlDetalhes";
            this.btnSqlDetalhes.Size = new System.Drawing.Size(42, 23);
            this.btnSqlDetalhes.TabIndex = 11;
            this.btnSqlDetalhes.Text = "SQL";
            this.btnSqlDetalhes.UseVisualStyleBackColor = true;
            this.btnSqlDetalhes.Click += new System.EventHandler(this.btnSqlDetalhes_Click);
            // 
            // progBar
            // 
            this.progBar.Location = new System.Drawing.Point(12, 229);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(395, 23);
            this.progBar.TabIndex = 12;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(419, 277);
            this.Controls.Add(this.progBar);
            this.Controls.Add(this.btnSqlDetalhes);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnImpDetalhesMod);
            this.Controls.Add(this.btnSqlBaseTabelas);
            this.Controls.Add(this.btnSqlModVei);
            this.Controls.Add(this.btnSqlVeiculos);
            this.Controls.Add(this.btnSqlMarcas);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnImpModVeiMarca);
            this.Controls.Add(this.btnImportaVeiculos);
            this.Controls.Add(this.btnImportaMarcas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Tabela FIPE";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportaMarcas;
        private System.Windows.Forms.Button btnImportaVeiculos;
        private System.Windows.Forms.Button btnImpModVeiMarca;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssMarcas;
        private System.Windows.Forms.ToolStripStatusLabel tssVeiculos;
        private System.Windows.Forms.ToolStripStatusLabel tssModVei;
        private System.Windows.Forms.Button btnSqlMarcas;
        private System.Windows.Forms.Button btnSqlVeiculos;
        private System.Windows.Forms.Button btnSqlModVei;
        private System.Windows.Forms.Button btnSqlBaseTabelas;
        private System.Windows.Forms.Button btnImpDetalhesMod;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripStatusLabel tssDetalhes;
        private System.Windows.Forms.Button btnSqlDetalhes;
        private System.Windows.Forms.ProgressBar progBar;
    }
}


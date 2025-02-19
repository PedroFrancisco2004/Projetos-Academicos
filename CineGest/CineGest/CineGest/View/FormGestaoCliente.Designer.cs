namespace CineGest.View
{
    partial class FormGestaoCliente
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAlterarCliente = new System.Windows.Forms.Button();
            this.buttonAdicionarCliente = new System.Windows.Forms.Button();
            this.buttonRemoverCliente = new System.Windows.Forms.Button();
            this.textBoxNIFCliente = new System.Windows.Forms.TextBox();
            this.textBoxMoradaCliente = new System.Windows.Forms.TextBox();
            this.textBoxNomeCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.dataViewClientes = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.N_Bilhetes = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Preco_Total = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAlterarCliente);
            this.groupBox1.Controls.Add(this.buttonAdicionarCliente);
            this.groupBox1.Controls.Add(this.buttonRemoverCliente);
            this.groupBox1.Controls.Add(this.textBoxNIFCliente);
            this.groupBox1.Controls.Add(this.textBoxMoradaCliente);
            this.groupBox1.Controls.Add(this.textBoxNomeCliente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 32);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(224, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clientes";
            // 
            // buttonAlterarCliente
            // 
            this.buttonAlterarCliente.Location = new System.Drawing.Point(16, 115);
            this.buttonAlterarCliente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAlterarCliente.Name = "buttonAlterarCliente";
            this.buttonAlterarCliente.Size = new System.Drawing.Size(56, 19);
            this.buttonAlterarCliente.TabIndex = 7;
            this.buttonAlterarCliente.Text = "Alterar";
            this.buttonAlterarCliente.UseVisualStyleBackColor = true;
            this.buttonAlterarCliente.Click += new System.EventHandler(this.buttonAlterarCliente_Click);
            // 
            // buttonAdicionarCliente
            // 
            this.buttonAdicionarCliente.Location = new System.Drawing.Point(150, 115);
            this.buttonAdicionarCliente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAdicionarCliente.Name = "buttonAdicionarCliente";
            this.buttonAdicionarCliente.Size = new System.Drawing.Size(70, 19);
            this.buttonAdicionarCliente.TabIndex = 6;
            this.buttonAdicionarCliente.Text = "Adicionar Cliente";
            this.buttonAdicionarCliente.UseVisualStyleBackColor = true;
            this.buttonAdicionarCliente.Click += new System.EventHandler(this.buttonAdicionarCliente_Click);
            // 
            // buttonRemoverCliente
            // 
            this.buttonRemoverCliente.Location = new System.Drawing.Point(76, 115);
            this.buttonRemoverCliente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRemoverCliente.Name = "buttonRemoverCliente";
            this.buttonRemoverCliente.Size = new System.Drawing.Size(70, 19);
            this.buttonRemoverCliente.TabIndex = 2;
            this.buttonRemoverCliente.Text = "Remover";
            this.buttonRemoverCliente.UseVisualStyleBackColor = true;
            this.buttonRemoverCliente.Click += new System.EventHandler(this.buttonRemoverCliente_Click);
            // 
            // textBoxNIFCliente
            // 
            this.textBoxNIFCliente.Location = new System.Drawing.Point(42, 78);
            this.textBoxNIFCliente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxNIFCliente.MaxLength = 9;
            this.textBoxNIFCliente.Name = "textBoxNIFCliente";
            this.textBoxNIFCliente.Size = new System.Drawing.Size(110, 20);
            this.textBoxNIFCliente.TabIndex = 5;
            this.textBoxNIFCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNIFCliente_KeyPress);
            // 
            // textBoxMoradaCliente
            // 
            this.textBoxMoradaCliente.Location = new System.Drawing.Point(62, 51);
            this.textBoxMoradaCliente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMoradaCliente.Name = "textBoxMoradaCliente";
            this.textBoxMoradaCliente.Size = new System.Drawing.Size(110, 20);
            this.textBoxMoradaCliente.TabIndex = 4;
            // 
            // textBoxNomeCliente
            // 
            this.textBoxNomeCliente.Location = new System.Drawing.Point(54, 24);
            this.textBoxNomeCliente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxNomeCliente.Name = "textBoxNomeCliente";
            this.textBoxNomeCliente.Size = new System.Drawing.Size(110, 20);
            this.textBoxNomeCliente.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "NIF:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Morada:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Location = new System.Drawing.Point(598, 448);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(75, 23);
            this.buttonVoltar.TabIndex = 3;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            // 
            // dataViewClientes
            // 
            this.dataViewClientes.AllowUserToAddRows = false;
            this.dataViewClientes.AllowUserToDeleteRows = false;
            this.dataViewClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewClientes.Location = new System.Drawing.Point(281, 32);
            this.dataViewClientes.MultiSelect = false;
            this.dataViewClientes.Name = "dataViewClientes";
            this.dataViewClientes.ReadOnly = true;
            this.dataViewClientes.RowHeadersWidth = 51;
            this.dataViewClientes.Size = new System.Drawing.Size(395, 350);
            this.dataViewClientes.TabIndex = 4;
            this.dataViewClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewClientes_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Número de bilhetes vendidos:";
            // 
            // N_Bilhetes
            // 
            this.N_Bilhetes.AutoSize = true;
            this.N_Bilhetes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.N_Bilhetes.Location = new System.Drawing.Point(12, 253);
            this.N_Bilhetes.Name = "N_Bilhetes";
            this.N_Bilhetes.Size = new System.Drawing.Size(115, 15);
            this.N_Bilhetes.TabIndex = 6;
            this.N_Bilhetes.Text = "Número de bilhetes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Preço total dos bilhetes:";
            // 
            // Preco_Total
            // 
            this.Preco_Total.AutoSize = true;
            this.Preco_Total.Location = new System.Drawing.Point(15, 325);
            this.Preco_Total.Name = "Preco_Total";
            this.Preco_Total.Size = new System.Drawing.Size(117, 13);
            this.Preco_Total.TabIndex = 8;
            this.Preco_Total.Text = "Preço total dos bilhetes";
            // 
            // FormGestaoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 483);
            this.Controls.Add(this.Preco_Total);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.N_Bilhetes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataViewClientes);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormGestaoCliente";
            this.Text = "FormGestaoClientes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGestaoCliente_FormClosed);
            this.Load += new System.EventHandler(this.FormGestaoCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAlterarCliente;
        private System.Windows.Forms.Button buttonAdicionarCliente;
        private System.Windows.Forms.TextBox textBoxNIFCliente;
        private System.Windows.Forms.TextBox textBoxMoradaCliente;
        private System.Windows.Forms.TextBox textBoxNomeCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRemoverCliente;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.DataGridView dataViewClientes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label N_Bilhetes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Preco_Total;
	}
}
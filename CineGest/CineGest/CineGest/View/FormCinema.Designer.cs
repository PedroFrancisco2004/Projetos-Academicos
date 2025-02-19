namespace CineGest.View
{
    partial class FormCinema
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
            this.btnAdInforCinema = new System.Windows.Forms.Button();
            this.btnAlterDadosCinema = new System.Windows.Forms.Button();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxMorada = new System.Windows.Forms.TextBox();
            this.textBoxNomeCinema = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonAlterarSala = new System.Windows.Forms.Button();
            this.buttonAdicionarSala = new System.Windows.Forms.Button();
            this.textBoxFilas = new System.Windows.Forms.TextBox();
            this.textBoxColunas = new System.Windows.Forms.TextBox();
            this.textBoxSala = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.dataViewSalas = new System.Windows.Forms.DataGridView();
            this.dataViewCinema = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewSalas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewCinema)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdInforCinema);
            this.groupBox1.Controls.Add(this.btnAlterDadosCinema);
            this.groupBox1.Controls.Add(this.textBoxEmail);
            this.groupBox1.Controls.Add(this.textBoxMorada);
            this.groupBox1.Controls.Add(this.textBoxNomeCinema);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 222);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(277, 141);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alterar informação cinema";
            // 
            // btnAdInforCinema
            // 
            this.btnAdInforCinema.Location = new System.Drawing.Point(171, 104);
            this.btnAdInforCinema.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdInforCinema.Name = "btnAdInforCinema";
            this.btnAdInforCinema.Size = new System.Drawing.Size(88, 24);
            this.btnAdInforCinema.TabIndex = 10;
            this.btnAdInforCinema.Text = "Adicionar";
            this.btnAdInforCinema.UseVisualStyleBackColor = true;
            this.btnAdInforCinema.Click += new System.EventHandler(this.btnAdInforCinema_Click);
            // 
            // btnAlterDadosCinema
            // 
            this.btnAlterDadosCinema.Location = new System.Drawing.Point(17, 104);
            this.btnAlterDadosCinema.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAlterDadosCinema.Name = "btnAlterDadosCinema";
            this.btnAlterDadosCinema.Size = new System.Drawing.Size(88, 24);
            this.btnAlterDadosCinema.TabIndex = 9;
            this.btnAlterDadosCinema.Text = "Alterar";
            this.btnAlterDadosCinema.UseVisualStyleBackColor = true;
            this.btnAlterDadosCinema.Click += new System.EventHandler(this.btnAlterDadosCinema_Click);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(52, 69);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(167, 20);
            this.textBoxEmail.TabIndex = 6;
            // 
            // textBoxMorada
            // 
            this.textBoxMorada.Location = new System.Drawing.Point(52, 45);
            this.textBoxMorada.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMorada.Name = "textBoxMorada";
            this.textBoxMorada.Size = new System.Drawing.Size(167, 20);
            this.textBoxMorada.TabIndex = 5;
            // 
            // textBoxNomeCinema
            // 
            this.textBoxNomeCinema.Location = new System.Drawing.Point(95, 20);
            this.textBoxNomeCinema.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxNomeCinema.Name = "textBoxNomeCinema";
            this.textBoxNomeCinema.Size = new System.Drawing.Size(167, 20);
            this.textBoxNomeCinema.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "E-Mail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Morada:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome do Cinema:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonAlterarSala);
            this.groupBox2.Controls.Add(this.buttonAdicionarSala);
            this.groupBox2.Controls.Add(this.textBoxFilas);
            this.groupBox2.Controls.Add(this.textBoxColunas);
            this.groupBox2.Controls.Add(this.textBoxSala);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(16, 20);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(270, 153);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sala";
            // 
            // buttonAlterarSala
            // 
            this.buttonAlterarSala.Location = new System.Drawing.Point(9, 117);
            this.buttonAlterarSala.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAlterarSala.Name = "buttonAlterarSala";
            this.buttonAlterarSala.Size = new System.Drawing.Size(90, 25);
            this.buttonAlterarSala.TabIndex = 9;
            this.buttonAlterarSala.Text = "Alterar Sala";
            this.buttonAlterarSala.UseVisualStyleBackColor = true;
            this.buttonAlterarSala.Click += new System.EventHandler(this.buttonAlterarSala_Click);
            // 
            // buttonAdicionarSala
            // 
            this.buttonAdicionarSala.Location = new System.Drawing.Point(164, 117);
            this.buttonAdicionarSala.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAdicionarSala.Name = "buttonAdicionarSala";
            this.buttonAdicionarSala.Size = new System.Drawing.Size(90, 25);
            this.buttonAdicionarSala.TabIndex = 8;
            this.buttonAdicionarSala.Text = "Adicionar Sala";
            this.buttonAdicionarSala.UseVisualStyleBackColor = true;
            this.buttonAdicionarSala.Click += new System.EventHandler(this.buttonAdicionarSala_Click);
            // 
            // textBoxFilas
            // 
            this.textBoxFilas.Location = new System.Drawing.Point(87, 76);
            this.textBoxFilas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxFilas.MaxLength = 2;
            this.textBoxFilas.Name = "textBoxFilas";
            this.textBoxFilas.Size = new System.Drawing.Size(167, 20);
            this.textBoxFilas.TabIndex = 7;
            this.textBoxFilas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFilas_KeyPress);
            // 
            // textBoxColunas
            // 
            this.textBoxColunas.Location = new System.Drawing.Point(100, 52);
            this.textBoxColunas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxColunas.MaxLength = 2;
            this.textBoxColunas.Name = "textBoxColunas";
            this.textBoxColunas.Size = new System.Drawing.Size(167, 20);
            this.textBoxColunas.TabIndex = 6;
            this.textBoxColunas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxColunas_KeyPress);
            // 
            // textBoxSala
            // 
            this.textBoxSala.Location = new System.Drawing.Point(88, 26);
            this.textBoxSala.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxSala.Name = "textBoxSala";
            this.textBoxSala.Size = new System.Drawing.Size(167, 20);
            this.textBoxSala.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 78);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Numero de filas:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Numero de colunas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Numero da sala:";
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Location = new System.Drawing.Point(517, 382);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(75, 23);
            this.buttonVoltar.TabIndex = 3;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            // 
            // dataViewSalas
            // 
            this.dataViewSalas.AllowUserToAddRows = false;
            this.dataViewSalas.AllowUserToDeleteRows = false;
            this.dataViewSalas.AllowUserToResizeColumns = false;
            this.dataViewSalas.AllowUserToResizeRows = false;
            this.dataViewSalas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewSalas.Location = new System.Drawing.Point(319, 21);
            this.dataViewSalas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataViewSalas.MultiSelect = false;
            this.dataViewSalas.Name = "dataViewSalas";
            this.dataViewSalas.ReadOnly = true;
            this.dataViewSalas.RowHeadersWidth = 51;
            this.dataViewSalas.RowTemplate.Height = 24;
            this.dataViewSalas.Size = new System.Drawing.Size(273, 152);
            this.dataViewSalas.TabIndex = 4;
            this.dataViewSalas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewSalas_CellClick);
            // 
            // dataViewCinema
            // 
            this.dataViewCinema.AllowUserToAddRows = false;
            this.dataViewCinema.AllowUserToDeleteRows = false;
            this.dataViewCinema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewCinema.Location = new System.Drawing.Point(318, 222);
            this.dataViewCinema.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataViewCinema.MultiSelect = false;
            this.dataViewCinema.Name = "dataViewCinema";
            this.dataViewCinema.ReadOnly = true;
            this.dataViewCinema.RowHeadersWidth = 51;
            this.dataViewCinema.RowTemplate.Height = 24;
            this.dataViewCinema.Size = new System.Drawing.Size(273, 141);
            this.dataViewCinema.TabIndex = 5;
            this.dataViewCinema.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewCinema_CellClick);
            // 
            // FormCinema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 415);
            this.Controls.Add(this.dataViewCinema);
            this.Controls.Add(this.dataViewSalas);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormCinema";
            this.Text = "FormCinema";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCinema_FormClosed);
            this.Load += new System.EventHandler(this.FormCinema_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewSalas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewCinema)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxMorada;
        private System.Windows.Forms.TextBox textBoxNomeCinema;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonAlterarSala;
        private System.Windows.Forms.Button buttonAdicionarSala;
        private System.Windows.Forms.TextBox textBoxFilas;
        private System.Windows.Forms.TextBox textBoxColunas;
        private System.Windows.Forms.TextBox textBoxSala;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.Button btnAlterDadosCinema;
        private System.Windows.Forms.Button btnAdInforCinema;
        private System.Windows.Forms.DataGridView dataViewSalas;
        private System.Windows.Forms.DataGridView dataViewCinema;
    }
}
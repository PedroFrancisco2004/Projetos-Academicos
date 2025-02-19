namespace CineGest.View
{
    partial class FormFilme
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxAtivo = new System.Windows.Forms.CheckBox();
            this.textBoxTempoFilme = new System.Windows.Forms.TextBox();
            this.textBoxNomeFilme = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxCategoria = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.dataViewFilmes = new System.Windows.Forms.DataGridView();
            this.btnCriarFilme = new System.Windows.Forms.Button();
            this.buttonCategorias = new System.Windows.Forms.Button();
            this.buttonEditarFilme = new System.Windows.Forms.Button();
            this.buttonApagarFilme = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filmeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.filmeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sessaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewFilmes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filmeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filmeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessaoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxAtivo);
            this.groupBox1.Controls.Add(this.textBoxTempoFilme);
            this.groupBox1.Controls.Add(this.textBoxNomeFilme);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 176);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(372, 263);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filme";
            // 
            // checkBoxAtivo
            // 
            this.checkBoxAtivo.AutoSize = true;
            this.checkBoxAtivo.Location = new System.Drawing.Point(119, 97);
            this.checkBoxAtivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxAtivo.Name = "checkBoxAtivo";
            this.checkBoxAtivo.Size = new System.Drawing.Size(59, 20);
            this.checkBoxAtivo.TabIndex = 8;
            this.checkBoxAtivo.Text = "Ativo";
            this.checkBoxAtivo.UseVisualStyleBackColor = true;
            // 
            // textBoxTempoFilme
            // 
            this.textBoxTempoFilme.Location = new System.Drawing.Point(137, 60);
            this.textBoxTempoFilme.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTempoFilme.Name = "textBoxTempoFilme";
            this.textBoxTempoFilme.Size = new System.Drawing.Size(188, 22);
            this.textBoxTempoFilme.TabIndex = 7;
            this.textBoxTempoFilme.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTempoFilme_KeyPress);
            // 
            // textBoxNomeFilme
            // 
            this.textBoxNomeFilme.Location = new System.Drawing.Point(61, 30);
            this.textBoxNomeFilme.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNomeFilme.Name = "textBoxNomeFilme";
            this.textBoxNomeFilme.Size = new System.Drawing.Size(209, 22);
            this.textBoxNomeFilme.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Estado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Duração(Minutos):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = " Nome:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxCategoria);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(5, 146);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(360, 111);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Categoria";
            // 
            // comboBoxCategoria
            // 
            this.comboBoxCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategoria.FormattingEnabled = true;
            this.comboBoxCategoria.Location = new System.Drawing.Point(63, 41);
            this.comboBoxCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxCategoria.Name = "comboBoxCategoria";
            this.comboBoxCategoria.Size = new System.Drawing.Size(203, 24);
            this.comboBoxCategoria.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nome:";
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Location = new System.Drawing.Point(820, 603);
            this.buttonVoltar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(100, 28);
            this.buttonVoltar.TabIndex = 2;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            // 
            // dataViewFilmes
            // 
            this.dataViewFilmes.AllowUserToAddRows = false;
            this.dataViewFilmes.AllowUserToDeleteRows = false;
            this.dataViewFilmes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewFilmes.Location = new System.Drawing.Point(405, 41);
            this.dataViewFilmes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataViewFilmes.MultiSelect = false;
            this.dataViewFilmes.Name = "dataViewFilmes";
            this.dataViewFilmes.ReadOnly = true;
            this.dataViewFilmes.RowHeadersWidth = 51;
            this.dataViewFilmes.RowTemplate.Height = 24;
            this.dataViewFilmes.Size = new System.Drawing.Size(503, 481);
            this.dataViewFilmes.TabIndex = 3;
            this.dataViewFilmes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewFilmes_CellClick);
            // 
            // btnCriarFilme
            // 
            this.btnCriarFilme.Location = new System.Drawing.Point(17, 458);
            this.btnCriarFilme.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCriarFilme.Name = "btnCriarFilme";
            this.btnCriarFilme.Size = new System.Drawing.Size(107, 38);
            this.btnCriarFilme.TabIndex = 4;
            this.btnCriarFilme.Text = "Criar Filme";
            this.btnCriarFilme.UseVisualStyleBackColor = true;
            this.btnCriarFilme.Click += new System.EventHandler(this.btnCriarFilme_Click);
            // 
            // buttonCategorias
            // 
            this.buttonCategorias.Location = new System.Drawing.Point(124, 569);
            this.buttonCategorias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCategorias.Name = "buttonCategorias";
            this.buttonCategorias.Size = new System.Drawing.Size(107, 38);
            this.buttonCategorias.TabIndex = 5;
            this.buttonCategorias.Text = "Categorias";
            this.buttonCategorias.UseVisualStyleBackColor = true;
            this.buttonCategorias.Click += new System.EventHandler(this.buttonCategorias_Click);
            // 
            // buttonEditarFilme
            // 
            this.buttonEditarFilme.Location = new System.Drawing.Point(131, 458);
            this.buttonEditarFilme.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEditarFilme.Name = "buttonEditarFilme";
            this.buttonEditarFilme.Size = new System.Drawing.Size(100, 38);
            this.buttonEditarFilme.TabIndex = 6;
            this.buttonEditarFilme.Text = "Editar filme";
            this.buttonEditarFilme.UseVisualStyleBackColor = true;
            this.buttonEditarFilme.Click += new System.EventHandler(this.buttonEditarFilme_Click);
            // 
            // buttonApagarFilme
            // 
            this.buttonApagarFilme.Location = new System.Drawing.Point(239, 458);
            this.buttonApagarFilme.Margin = new System.Windows.Forms.Padding(4);
            this.buttonApagarFilme.Name = "buttonApagarFilme";
            this.buttonApagarFilme.Size = new System.Drawing.Size(120, 38);
            this.buttonApagarFilme.TabIndex = 7;
            this.buttonApagarFilme.Text = "Apagar Filme";
            this.buttonApagarFilme.UseVisualStyleBackColor = true;
            this.buttonApagarFilme.Click += new System.EventHandler(this.buttonApagarFilme_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Categoria";
            this.dataGridViewTextBoxColumn1.HeaderText = "Categoria";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // filmeBindingSource1
            // 
            this.filmeBindingSource1.DataSource = typeof(CineGest.Model.Filme);
            // 
            // filmeBindingSource
            // 
            this.filmeBindingSource.DataSource = typeof(CineGest.Model.Filme);
            // 
            // sessaoBindingSource
            // 
            this.sessaoBindingSource.DataSource = typeof(CineGest.Model.Sessao);
            // 
            // FormFilme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 646);
            this.Controls.Add(this.buttonApagarFilme);
            this.Controls.Add(this.buttonEditarFilme);
            this.Controls.Add(this.buttonCategorias);
            this.Controls.Add(this.btnCriarFilme);
            this.Controls.Add(this.dataViewFilmes);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormFilme";
            this.Text = "FormFilme";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormFilme_FormClosed);
            this.Load += new System.EventHandler(this.FormFilme_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewFilmes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filmeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filmeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessaoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxNomeFilme;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.DataGridView dataViewFilmes;
        private System.Windows.Forms.Button btnCriarFilme;
        private System.Windows.Forms.ComboBox comboBoxCategoria;
        private System.Windows.Forms.Button buttonCategorias;
        private System.Windows.Forms.TextBox textBoxTempoFilme;
        private System.Windows.Forms.Button buttonEditarFilme;
        private System.Windows.Forms.Button buttonApagarFilme;
        private System.Windows.Forms.BindingSource filmeBindingSource;
        private System.Windows.Forms.BindingSource sessaoBindingSource;
        private System.Windows.Forms.BindingSource filmeBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.CheckBox checkBoxAtivo;
    }
}
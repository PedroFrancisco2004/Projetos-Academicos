namespace CineGest.View
{
    partial class FormAtendimento
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
			this.groupBoxInserirCliente = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxNumFiscal = new System.Windows.Forms.TextBox();
			this.textBoxMorada = new System.Windows.Forms.TextBox();
			this.textBoxNome = new System.Windows.Forms.TextBox();
			this.buttonAdicionarClientes = new System.Windows.Forms.Button();
			this.buttonVoltar = new System.Windows.Forms.Button();
			this.dataViewAtendeClientes = new System.Windows.Forms.DataGridView();
			this.PanelSala = new System.Windows.Forms.FlowLayoutPanel();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBoxSessaoCinema = new System.Windows.Forms.ComboBox();
			this.btnCriarBilhete = new System.Windows.Forms.Button();
			this.checkBoxEstado = new System.Windows.Forms.CheckBox();
			this.dataViewBilhetes = new System.Windows.Forms.DataGridView();
			this.btnEditarBilhete = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.groupBoxInserirCliente.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataViewAtendeClientes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataViewBilhetes)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBoxInserirCliente
			// 
			this.groupBoxInserirCliente.Controls.Add(this.label3);
			this.groupBoxInserirCliente.Controls.Add(this.label2);
			this.groupBoxInserirCliente.Controls.Add(this.label1);
			this.groupBoxInserirCliente.Controls.Add(this.textBoxNumFiscal);
			this.groupBoxInserirCliente.Controls.Add(this.textBoxMorada);
			this.groupBoxInserirCliente.Controls.Add(this.textBoxNome);
			this.groupBoxInserirCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxInserirCliente.Location = new System.Drawing.Point(31, 37);
			this.groupBoxInserirCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBoxInserirCliente.Name = "groupBoxInserirCliente";
			this.groupBoxInserirCliente.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBoxInserirCliente.Size = new System.Drawing.Size(344, 142);
			this.groupBoxInserirCliente.TabIndex = 0;
			this.groupBoxInserirCliente.TabStop = false;
			this.groupBoxInserirCliente.Text = "Inserir cliente";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(7, 100);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 18);
			this.label3.TabIndex = 5;
			this.label3.Text = "NIF:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(7, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 18);
			this.label2.TabIndex = 4;
			this.label2.Text = "Morada:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(7, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 18);
			this.label1.TabIndex = 3;
			this.label1.Text = "Nome:";
			// 
			// textBoxNumFiscal
			// 
			this.textBoxNumFiscal.Location = new System.Drawing.Point(51, 96);
			this.textBoxNumFiscal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxNumFiscal.MaxLength = 9;
			this.textBoxNumFiscal.Name = "textBoxNumFiscal";
			this.textBoxNumFiscal.Size = new System.Drawing.Size(253, 24);
			this.textBoxNumFiscal.TabIndex = 2;
			this.textBoxNumFiscal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumFiscal_KeyPress);
			// 
			// textBoxMorada
			// 
			this.textBoxMorada.Location = new System.Drawing.Point(83, 65);
			this.textBoxMorada.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxMorada.Name = "textBoxMorada";
			this.textBoxMorada.Size = new System.Drawing.Size(253, 24);
			this.textBoxMorada.TabIndex = 1;
			// 
			// textBoxNome
			// 
			this.textBoxNome.Location = new System.Drawing.Point(67, 34);
			this.textBoxNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxNome.Name = "textBoxNome";
			this.textBoxNome.Size = new System.Drawing.Size(253, 24);
			this.textBoxNome.TabIndex = 0;
			// 
			// buttonAdicionarClientes
			// 
			this.buttonAdicionarClientes.Location = new System.Drawing.Point(31, 183);
			this.buttonAdicionarClientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonAdicionarClientes.Name = "buttonAdicionarClientes";
			this.buttonAdicionarClientes.Size = new System.Drawing.Size(96, 32);
			this.buttonAdicionarClientes.TabIndex = 2;
			this.buttonAdicionarClientes.Text = "Adicionar";
			this.buttonAdicionarClientes.UseVisualStyleBackColor = true;
			this.buttonAdicionarClientes.Click += new System.EventHandler(this.buttonAdicionarClientes_Click);
			// 
			// buttonVoltar
			// 
			this.buttonVoltar.Location = new System.Drawing.Point(1337, 537);
			this.buttonVoltar.Margin = new System.Windows.Forms.Padding(4);
			this.buttonVoltar.Name = "buttonVoltar";
			this.buttonVoltar.Size = new System.Drawing.Size(100, 28);
			this.buttonVoltar.TabIndex = 4;
			this.buttonVoltar.Text = "Voltar";
			this.buttonVoltar.UseVisualStyleBackColor = true;
			this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
			// 
			// dataViewAtendeClientes
			// 
			this.dataViewAtendeClientes.AllowUserToAddRows = false;
			this.dataViewAtendeClientes.AllowUserToDeleteRows = false;
			this.dataViewAtendeClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataViewAtendeClientes.Location = new System.Drawing.Point(31, 239);
			this.dataViewAtendeClientes.Margin = new System.Windows.Forms.Padding(4);
			this.dataViewAtendeClientes.MultiSelect = false;
			this.dataViewAtendeClientes.Name = "dataViewAtendeClientes";
			this.dataViewAtendeClientes.ReadOnly = true;
			this.dataViewAtendeClientes.RowHeadersWidth = 51;
			this.dataViewAtendeClientes.Size = new System.Drawing.Size(391, 226);
			this.dataViewAtendeClientes.TabIndex = 7;
			this.dataViewAtendeClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewClientes_CellClick);
			// 
			// PanelSala
			// 
			this.PanelSala.Location = new System.Drawing.Point(556, 12);
			this.PanelSala.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.PanelSala.Name = "PanelSala";
			this.PanelSala.Size = new System.Drawing.Size(801, 414);
			this.PanelSala.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(824, 436);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 11;
			this.label4.Text = "Sessões:";
			// 
			// comboBoxSessaoCinema
			// 
			this.comboBoxSessaoCinema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSessaoCinema.FormattingEnabled = true;
			this.comboBoxSessaoCinema.Location = new System.Drawing.Point(827, 458);
			this.comboBoxSessaoCinema.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxSessaoCinema.Name = "comboBoxSessaoCinema";
			this.comboBoxSessaoCinema.Size = new System.Drawing.Size(280, 24);
			this.comboBoxSessaoCinema.TabIndex = 10;
			this.comboBoxSessaoCinema.SelectedIndexChanged += new System.EventHandler(this.comboBoxSessaoCinema_SelectedIndexChanged);
			// 
			// btnCriarBilhete
			// 
			this.btnCriarBilhete.Location = new System.Drawing.Point(827, 537);
			this.btnCriarBilhete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCriarBilhete.Name = "btnCriarBilhete";
			this.btnCriarBilhete.Size = new System.Drawing.Size(119, 34);
			this.btnCriarBilhete.TabIndex = 12;
			this.btnCriarBilhete.Text = "Criar Bilhete";
			this.btnCriarBilhete.UseVisualStyleBackColor = true;
			this.btnCriarBilhete.Click += new System.EventHandler(this.btnCriarBilhete_Click);
			// 
			// checkBoxEstado
			// 
			this.checkBoxEstado.AutoSize = true;
			this.checkBoxEstado.Location = new System.Drawing.Point(1373, 460);
			this.checkBoxEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxEstado.Name = "checkBoxEstado";
			this.checkBoxEstado.Size = new System.Drawing.Size(70, 20);
			this.checkBoxEstado.TabIndex = 15;
			this.checkBoxEstado.Text = "Usado";
			this.checkBoxEstado.UseVisualStyleBackColor = true;
			// 
			// dataViewBilhetes
			// 
			this.dataViewBilhetes.AllowUserToAddRows = false;
			this.dataViewBilhetes.AllowUserToDeleteRows = false;
			this.dataViewBilhetes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataViewBilhetes.Location = new System.Drawing.Point(1373, 15);
			this.dataViewBilhetes.Margin = new System.Windows.Forms.Padding(4);
			this.dataViewBilhetes.Name = "dataViewBilhetes";
			this.dataViewBilhetes.ReadOnly = true;
			this.dataViewBilhetes.RowHeadersWidth = 51;
			this.dataViewBilhetes.Size = new System.Drawing.Size(547, 414);
			this.dataViewBilhetes.TabIndex = 16;
			this.dataViewBilhetes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewBilhetes_CellClick);
			// 
			// btnEditarBilhete
			// 
			this.btnEditarBilhete.Location = new System.Drawing.Point(984, 537);
			this.btnEditarBilhete.Margin = new System.Windows.Forms.Padding(4);
			this.btnEditarBilhete.Name = "btnEditarBilhete";
			this.btnEditarBilhete.Size = new System.Drawing.Size(100, 34);
			this.btnEditarBilhete.TabIndex = 17;
			this.btnEditarBilhete.Text = "Editar";
			this.btnEditarBilhete.UseVisualStyleBackColor = true;
			this.btnEditarBilhete.Click += new System.EventHandler(this.btnEditarBilhete_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(1117, 537);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(100, 34);
			this.btnCancelar.TabIndex = 18;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// FormAtendimento
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1924, 583);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnEditarBilhete);
			this.Controls.Add(this.dataViewBilhetes);
			this.Controls.Add(this.checkBoxEstado);
			this.Controls.Add(this.btnCriarBilhete);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.comboBoxSessaoCinema);
			this.Controls.Add(this.PanelSala);
			this.Controls.Add(this.dataViewAtendeClientes);
			this.Controls.Add(this.buttonVoltar);
			this.Controls.Add(this.buttonAdicionarClientes);
			this.Controls.Add(this.groupBoxInserirCliente);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "FormAtendimento";
			this.Text = "FormAtendimento";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAtendimento_FormClosed);
			this.Load += new System.EventHandler(this.FormAtendimento_Load);
			this.groupBoxInserirCliente.ResumeLayout(false);
			this.groupBoxInserirCliente.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataViewAtendeClientes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataViewBilhetes)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInserirCliente;
        private System.Windows.Forms.TextBox textBoxNumFiscal;
        private System.Windows.Forms.TextBox textBoxMorada;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAdicionarClientes;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.DataGridView dataViewAtendeClientes;
		private System.Windows.Forms.FlowLayoutPanel PanelSala;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBoxSessaoCinema;
		private System.Windows.Forms.Button btnCriarBilhete;
		private System.Windows.Forms.CheckBox checkBoxEstado;
        private System.Windows.Forms.DataGridView dataViewBilhetes;
        private System.Windows.Forms.Button btnEditarBilhete;
		private System.Windows.Forms.Button btnCancelar;
	}
}
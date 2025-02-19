namespace CineGest.View
{
    partial class FormSessao
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
			this.monthCalendarSessao = new System.Windows.Forms.MonthCalendar();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxHora = new System.Windows.Forms.TextBox();
			this.textBoxMinuto = new System.Windows.Forms.TextBox();
			this.buttonVoltar = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonCriarSessao = new System.Windows.Forms.Button();
			this.dataViewSessao = new System.Windows.Forms.DataGridView();
			this.label6 = new System.Windows.Forms.Label();
			this.buttonEditarSessao = new System.Windows.Forms.Button();
			this.buttonRemoverSessao = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxPreco = new System.Windows.Forms.TextBox();
			this.comboBoxFilmes = new System.Windows.Forms.ComboBox();
			this.comboBoxSalas = new System.Windows.Forms.ComboBox();
			this.salaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.filmeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dataViewSessao)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.salaBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.filmeBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// monthCalendarSessao
			// 
			this.monthCalendarSessao.Location = new System.Drawing.Point(9, 39);
			this.monthCalendarSessao.Name = "monthCalendarSessao";
			this.monthCalendarSessao.TabIndex = 0;
			this.monthCalendarSessao.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarSessao_DateSelected);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 270);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Hora:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(132, 270);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Minuto:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(542, 59);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(0, 16);
			this.label3.TabIndex = 3;
			// 
			// textBoxHora
			// 
			this.textBoxHora.Location = new System.Drawing.Point(53, 267);
			this.textBoxHora.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxHora.MaxLength = 2;
			this.textBoxHora.Name = "textBoxHora";
			this.textBoxHora.Size = new System.Drawing.Size(71, 22);
			this.textBoxHora.TabIndex = 4;
			this.textBoxHora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHora_KeyPress);
			// 
			// textBoxMinuto
			// 
			this.textBoxMinuto.Location = new System.Drawing.Point(179, 270);
			this.textBoxMinuto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxMinuto.MaxLength = 2;
			this.textBoxMinuto.Name = "textBoxMinuto";
			this.textBoxMinuto.Size = new System.Drawing.Size(71, 22);
			this.textBoxMinuto.TabIndex = 5;
			this.textBoxMinuto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMinuto_KeyPress);
			// 
			// buttonVoltar
			// 
			this.buttonVoltar.Location = new System.Drawing.Point(896, 558);
			this.buttonVoltar.Margin = new System.Windows.Forms.Padding(4);
			this.buttonVoltar.Name = "buttonVoltar";
			this.buttonVoltar.Size = new System.Drawing.Size(100, 28);
			this.buttonVoltar.TabIndex = 9;
			this.buttonVoltar.Text = "Voltar";
			this.buttonVoltar.UseVisualStyleBackColor = true;
			this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(307, 267);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 16);
			this.label4.TabIndex = 12;
			this.label4.Text = "Filme:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(307, 398);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(38, 16);
			this.label5.TabIndex = 13;
			this.label5.Text = "Sala:";
			// 
			// buttonCriarSessao
			// 
			this.buttonCriarSessao.Location = new System.Drawing.Point(52, 378);
			this.buttonCriarSessao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonCriarSessao.Name = "buttonCriarSessao";
			this.buttonCriarSessao.Size = new System.Drawing.Size(199, 37);
			this.buttonCriarSessao.TabIndex = 14;
			this.buttonCriarSessao.Text = "Criar Sessao";
			this.buttonCriarSessao.UseVisualStyleBackColor = true;
			this.buttonCriarSessao.Click += new System.EventHandler(this.buttonCriarSessao_Click);
			// 
			// dataViewSessao
			// 
			this.dataViewSessao.AllowUserToAddRows = false;
			this.dataViewSessao.AllowUserToDeleteRows = false;
			this.dataViewSessao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataViewSessao.Location = new System.Drawing.Point(581, 39);
			this.dataViewSessao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dataViewSessao.MultiSelect = false;
			this.dataViewSessao.Name = "dataViewSessao";
			this.dataViewSessao.ReadOnly = true;
			this.dataViewSessao.RowHeadersWidth = 51;
			this.dataViewSessao.RowTemplate.Height = 24;
			this.dataViewSessao.Size = new System.Drawing.Size(415, 465);
			this.dataViewSessao.TabIndex = 15;
			this.dataViewSessao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewSessao_CellClick);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(575, 9);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 16;
			this.label6.Text = "Sessões:";
			// 
			// buttonEditarSessao
			// 
			this.buttonEditarSessao.Location = new System.Drawing.Point(52, 432);
			this.buttonEditarSessao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonEditarSessao.Name = "buttonEditarSessao";
			this.buttonEditarSessao.Size = new System.Drawing.Size(199, 37);
			this.buttonEditarSessao.TabIndex = 17;
			this.buttonEditarSessao.Text = "Editar";
			this.buttonEditarSessao.UseVisualStyleBackColor = true;
			this.buttonEditarSessao.Click += new System.EventHandler(this.buttonEditarSessao_Click);
			// 
			// buttonRemoverSessao
			// 
			this.buttonRemoverSessao.Location = new System.Drawing.Point(52, 487);
			this.buttonRemoverSessao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonRemoverSessao.Name = "buttonRemoverSessao";
			this.buttonRemoverSessao.Size = new System.Drawing.Size(199, 37);
			this.buttonRemoverSessao.TabIndex = 18;
			this.buttonRemoverSessao.Text = "Remover";
			this.buttonRemoverSessao.UseVisualStyleBackColor = true;
			this.buttonRemoverSessao.Click += new System.EventHandler(this.buttonRemoverSessao_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(19, 336);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(46, 16);
			this.label7.TabIndex = 20;
			this.label7.Text = "Preço:";
			// 
			// textBoxPreco
			// 
			this.textBoxPreco.Location = new System.Drawing.Point(71, 332);
			this.textBoxPreco.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxPreco.Name = "textBoxPreco";
			this.textBoxPreco.Size = new System.Drawing.Size(179, 22);
			this.textBoxPreco.TabIndex = 21;
			this.textBoxPreco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPreco_KeyPress_1);
			// 
			// comboBoxFilmes
			// 
			this.comboBoxFilmes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxFilmes.FormattingEnabled = true;
			this.comboBoxFilmes.Location = new System.Drawing.Point(310, 306);
			this.comboBoxFilmes.Name = "comboBoxFilmes";
			this.comboBoxFilmes.Size = new System.Drawing.Size(212, 24);
			this.comboBoxFilmes.TabIndex = 22;
			// 
			// comboBoxSalas
			// 
			this.comboBoxSalas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSalas.FormattingEnabled = true;
			this.comboBoxSalas.Location = new System.Drawing.Point(310, 434);
			this.comboBoxSalas.Name = "comboBoxSalas";
			this.comboBoxSalas.Size = new System.Drawing.Size(212, 24);
			this.comboBoxSalas.TabIndex = 23;
			// 
			// salaBindingSource
			// 
			this.salaBindingSource.DataSource = typeof(CineGest.Model.Sala);
			// 
			// filmeBindingSource
			// 
			this.filmeBindingSource.DataSource = typeof(CineGest.Model.Filme);
			// 
			// FormSessao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1009, 599);
			this.Controls.Add(this.comboBoxSalas);
			this.Controls.Add(this.comboBoxFilmes);
			this.Controls.Add(this.textBoxPreco);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.buttonRemoverSessao);
			this.Controls.Add(this.buttonEditarSessao);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.dataViewSessao);
			this.Controls.Add(this.buttonCriarSessao);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.buttonVoltar);
			this.Controls.Add(this.textBoxMinuto);
			this.Controls.Add(this.textBoxHora);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.monthCalendarSessao);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "FormSessao";
			this.Text = " ";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSessao_FormClosed);
			this.Load += new System.EventHandler(this.FormSessao_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataViewSessao)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.salaBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.filmeBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendarSessao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxHora;
        private System.Windows.Forms.TextBox textBoxMinuto;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCriarSessao;
        private System.Windows.Forms.DataGridView dataViewSessao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonEditarSessao;
        private System.Windows.Forms.Button buttonRemoverSessao;
        private System.Windows.Forms.BindingSource salaBindingSource;
        private System.Windows.Forms.BindingSource filmeBindingSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPreco;
        private System.Windows.Forms.ComboBox comboBoxFilmes;
        private System.Windows.Forms.ComboBox comboBoxSalas;
    }
}
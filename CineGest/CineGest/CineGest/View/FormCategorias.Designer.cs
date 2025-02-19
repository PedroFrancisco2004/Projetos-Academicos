namespace CineGest.View
{
    partial class FormCategorias
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
            this.textBoxNomeCategoria = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxAtivo = new System.Windows.Forms.CheckBox();
            this.dataViewCategorias = new System.Windows.Forms.DataGridView();
            this.buttonCriarCategoria = new System.Windows.Forms.Button();
            this.buttonApagar = new System.Windows.Forms.Button();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxNomeCategoria
            // 
            this.textBoxNomeCategoria.Location = new System.Drawing.Point(180, 61);
            this.textBoxNomeCategoria.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxNomeCategoria.Name = "textBoxNomeCategoria";
            this.textBoxNomeCategoria.Size = new System.Drawing.Size(182, 20);
            this.textBoxNomeCategoria.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome categoria:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Activa:";
            // 
            // checkBoxAtivo
            // 
            this.checkBoxAtivo.AutoSize = true;
            this.checkBoxAtivo.Location = new System.Drawing.Point(189, 110);
            this.checkBoxAtivo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxAtivo.Name = "checkBoxAtivo";
            this.checkBoxAtivo.Size = new System.Drawing.Size(50, 17);
            this.checkBoxAtivo.TabIndex = 3;
            this.checkBoxAtivo.Text = "Ativo";
            this.checkBoxAtivo.UseVisualStyleBackColor = true;
            // 
            // dataViewCategorias
            // 
            this.dataViewCategorias.AllowUserToAddRows = false;
            this.dataViewCategorias.AllowUserToDeleteRows = false;
            this.dataViewCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewCategorias.Location = new System.Drawing.Point(70, 190);
            this.dataViewCategorias.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataViewCategorias.MultiSelect = false;
            this.dataViewCategorias.Name = "dataViewCategorias";
            this.dataViewCategorias.ReadOnly = true;
            this.dataViewCategorias.RowHeadersWidth = 51;
            this.dataViewCategorias.RowTemplate.Height = 24;
            this.dataViewCategorias.Size = new System.Drawing.Size(335, 210);
            this.dataViewCategorias.TabIndex = 4;
            this.dataViewCategorias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewCategorias_CellClick);
            // 
            // buttonCriarCategoria
            // 
            this.buttonCriarCategoria.Location = new System.Drawing.Point(142, 145);
            this.buttonCriarCategoria.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCriarCategoria.Name = "buttonCriarCategoria";
            this.buttonCriarCategoria.Size = new System.Drawing.Size(65, 27);
            this.buttonCriarCategoria.TabIndex = 5;
            this.buttonCriarCategoria.Text = "Adicionar";
            this.buttonCriarCategoria.UseVisualStyleBackColor = true;
            this.buttonCriarCategoria.Click += new System.EventHandler(this.buttonCriarCategoria_Click);
            // 
            // buttonApagar
            // 
            this.buttonApagar.Location = new System.Drawing.Point(296, 145);
            this.buttonApagar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonApagar.Name = "buttonApagar";
            this.buttonApagar.Size = new System.Drawing.Size(65, 27);
            this.buttonApagar.TabIndex = 7;
            this.buttonApagar.Text = "Apagar";
            this.buttonApagar.UseVisualStyleBackColor = true;
            this.buttonApagar.Click += new System.EventHandler(this.buttonApagar_Click);
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Location = new System.Drawing.Point(331, 437);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(75, 23);
            this.buttonVoltar.TabIndex = 8;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Location = new System.Drawing.Point(219, 145);
            this.buttonEditar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(65, 27);
            this.buttonEditar.TabIndex = 9;
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(496, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Comédia, Sci-fi, Terror, Romance, Acção, Thriller, Drama, Mistério, Crime, Aventu" +
    "ra, Fantasia, Animação";
            // 
            // FormCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 472);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.buttonApagar);
            this.Controls.Add(this.buttonCriarCategoria);
            this.Controls.Add(this.dataViewCategorias);
            this.Controls.Add(this.checkBoxAtivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNomeCategoria);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormCategorias";
            this.Text = "Categorias";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCategorias_FormClosed);
            this.Load += new System.EventHandler(this.FormCategorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataViewCategorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNomeCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxAtivo;
        private System.Windows.Forms.DataGridView dataViewCategorias;
        private System.Windows.Forms.Button buttonCriarCategoria;
        private System.Windows.Forms.Button buttonApagar;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.Button buttonEditar;
		private System.Windows.Forms.Label label3;
	}
}
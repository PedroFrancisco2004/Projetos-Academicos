namespace Projeto
{
    partial class FormChat
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMensagem = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.listBoxMensagens = new System.Windows.Forms.ListBox();
            this.tbUtilizador = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.btnRegistar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(663, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enviar Texto:";
            // 
            // textBoxMensagem
            // 
            this.textBoxMensagem.Location = new System.Drawing.Point(667, 111);
            this.textBoxMensagem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMensagem.Multiline = true;
            this.textBoxMensagem.Name = "textBoxMensagem";
            this.textBoxMensagem.Size = new System.Drawing.Size(651, 79);
            this.textBoxMensagem.TabIndex = 1;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(1429, 153);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(100, 28);
            this.btnEnviar.TabIndex = 2;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(1564, 513);
            this.btnSair.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(100, 28);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // listBoxMensagens
            // 
            this.listBoxMensagens.FormattingEnabled = true;
            this.listBoxMensagens.ItemHeight = 16;
            this.listBoxMensagens.Location = new System.Drawing.Point(680, 213);
            this.listBoxMensagens.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxMensagens.Name = "listBoxMensagens";
            this.listBoxMensagens.Size = new System.Drawing.Size(637, 244);
            this.listBoxMensagens.TabIndex = 4;
            // 
            // tbUtilizador
            // 
            this.tbUtilizador.Location = new System.Drawing.Point(112, 124);
            this.tbUtilizador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbUtilizador.Name = "tbUtilizador";
            this.tbUtilizador.Size = new System.Drawing.Size(236, 22);
            this.tbUtilizador.TabIndex = 5;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(112, 181);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(236, 22);
            this.tbPassword.TabIndex = 6;
            // 
            // btnEntrar
            // 
            this.btnEntrar.Location = new System.Drawing.Point(169, 249);
            this.btnEntrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(99, 38);
            this.btnEntrar.TabIndex = 7;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // btnRegistar
            // 
            this.btnRegistar.Location = new System.Drawing.Point(169, 327);
            this.btnRegistar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegistar.Name = "btnRegistar";
            this.btnRegistar.Size = new System.Drawing.Size(99, 42);
            this.btnRegistar.TabIndex = 8;
            this.btnRegistar.Text = "Registar";
            this.btnRegistar.UseVisualStyleBackColor = true;
            this.btnRegistar.Click += new System.EventHandler(this.btnRegistar_Click);
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1688, 554);
            this.Controls.Add(this.btnRegistar);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUtilizador);
            this.Controls.Add(this.listBoxMensagens);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.textBoxMensagem);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormChat";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormChat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMensagem;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.ListBox listBoxMensagens;
        private System.Windows.Forms.TextBox tbUtilizador;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Button btnRegistar;
    }
}


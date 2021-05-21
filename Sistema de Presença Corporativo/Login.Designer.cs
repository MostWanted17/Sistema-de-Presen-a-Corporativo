
namespace Sistema_de_Presença_Corporativo
{
    partial class Login
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.btnminimizar = new System.Windows.Forms.PictureBox();
            this.btnfechar = new System.Windows.Forms.PictureBox();
            this.esqueceu = new System.Windows.Forms.Label();
            this.btnlimpar = new System.Windows.Forms.Button();
            this.checkMostrarsenha = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.senha = new System.Windows.Forms.TextBox();
            this.senhatext = new System.Windows.Forms.Label();
            this.usuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnminimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnfechar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnminimizar
            // 
            this.btnminimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnminimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnminimizar.Image")));
            this.btnminimizar.Location = new System.Drawing.Point(209, 37);
            this.btnminimizar.Name = "btnminimizar";
            this.btnminimizar.Size = new System.Drawing.Size(26, 19);
            this.btnminimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnminimizar.TabIndex = 21;
            this.btnminimizar.TabStop = false;
            this.btnminimizar.Click += new System.EventHandler(this.btnminimizar_Click);
            // 
            // btnfechar
            // 
            this.btnfechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnfechar.Image = ((System.Drawing.Image)(resources.GetObject("btnfechar.Image")));
            this.btnfechar.Location = new System.Drawing.Point(239, 37);
            this.btnfechar.Name = "btnfechar";
            this.btnfechar.Size = new System.Drawing.Size(26, 19);
            this.btnfechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnfechar.TabIndex = 20;
            this.btnfechar.TabStop = false;
            this.btnfechar.Click += new System.EventHandler(this.btnfechar_Click);
            // 
            // esqueceu
            // 
            this.esqueceu.AutoSize = true;
            this.esqueceu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.esqueceu.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.esqueceu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(42)))), ((int)(((byte)(104)))));
            this.esqueceu.Location = new System.Drawing.Point(118, 490);
            this.esqueceu.Name = "esqueceu";
            this.esqueceu.Size = new System.Drawing.Size(119, 17);
            this.esqueceu.TabIndex = 19;
            this.esqueceu.Text = "Esqueceu a Senha?";
            this.esqueceu.Click += new System.EventHandler(this.esqueceu_Click);
            // 
            // btnlimpar
            // 
            this.btnlimpar.BackColor = System.Drawing.Color.Transparent;
            this.btnlimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpar.FlatAppearance.BorderSize = 2;
            this.btnlimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(42)))), ((int)(((byte)(104)))));
            this.btnlimpar.Location = new System.Drawing.Point(25, 389);
            this.btnlimpar.Name = "btnlimpar";
            this.btnlimpar.Size = new System.Drawing.Size(216, 35);
            this.btnlimpar.TabIndex = 18;
            this.btnlimpar.Text = "Limpar";
            this.btnlimpar.UseVisualStyleBackColor = false;
            this.btnlimpar.Click += new System.EventHandler(this.btnlimpar_Click);
            // 
            // checkMostrarsenha
            // 
            this.checkMostrarsenha.AutoSize = true;
            this.checkMostrarsenha.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkMostrarsenha.Location = new System.Drawing.Point(126, 313);
            this.checkMostrarsenha.Name = "checkMostrarsenha";
            this.checkMostrarsenha.Size = new System.Drawing.Size(112, 21);
            this.checkMostrarsenha.TabIndex = 17;
            this.checkMostrarsenha.Text = "Mostrar senha";
            this.checkMostrarsenha.UseVisualStyleBackColor = true;
            this.checkMostrarsenha.CheckedChanged += new System.EventHandler(this.checkMostrarsenha_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(42)))), ((int)(((byte)(104)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(25, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 35);
            this.button1.TabIndex = 16;
            this.button1.Text = "Entrar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // senha
            // 
            this.senha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.senha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.senha.Font = new System.Drawing.Font("Nirmala UI", 12F);
            this.senha.Location = new System.Drawing.Point(25, 267);
            this.senha.Multiline = true;
            this.senha.Name = "senha";
            this.senha.PasswordChar = '*';
            this.senha.Size = new System.Drawing.Size(216, 28);
            this.senha.TabIndex = 15;
            // 
            // senhatext
            // 
            this.senhatext.AutoSize = true;
            this.senhatext.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.senhatext.Location = new System.Drawing.Point(25, 242);
            this.senhatext.Name = "senhatext";
            this.senhatext.Size = new System.Drawing.Size(43, 17);
            this.senhatext.TabIndex = 14;
            this.senhatext.Text = "Senha";
            // 
            // usuario
            // 
            this.usuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.usuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usuario.Font = new System.Drawing.Font("Nirmala UI", 12F);
            this.usuario.Location = new System.Drawing.Point(25, 197);
            this.usuario.Multiline = true;
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(216, 28);
            this.usuario.TabIndex = 13;
            this.usuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.usuario_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nome do usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(42)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(20, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 37);
            this.label1.TabIndex = 11;
            this.label1.Text = "LOGIN";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(285, 544);
            this.Controls.Add(this.btnminimizar);
            this.Controls.Add(this.btnfechar);
            this.Controls.Add(this.esqueceu);
            this.Controls.Add(this.btnlimpar);
            this.Controls.Add(this.checkMostrarsenha);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.senha);
            this.Controls.Add(this.senhatext);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.btnminimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnfechar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnminimizar;
        private System.Windows.Forms.PictureBox btnfechar;
        private System.Windows.Forms.Label esqueceu;
        private System.Windows.Forms.Button btnlimpar;
        private System.Windows.Forms.CheckBox checkMostrarsenha;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox senha;
        private System.Windows.Forms.Label senhatext;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}


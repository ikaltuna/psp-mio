namespace Eventos
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.activarConsulta = new System.Windows.Forms.Button();
            this.activarEnvioFTP = new System.Windows.Forms.Button();
            this.guardar = new System.Windows.Forms.Button();
            this.provinciaCombo = new System.Windows.Forms.ComboBox();
            this.municipioCombo = new System.Windows.Forms.ComboBox();
            this.eventoCombo = new System.Windows.Forms.ComboBox();
            this.provinciaText = new System.Windows.Forms.Label();
            this.municipioText = new System.Windows.Forms.Label();
            this.eventoText = new System.Windows.Forms.Label();
            this.datosText = new System.Windows.Forms.Label();
            this.servidorT = new System.Windows.Forms.Label();
            this.usuarioT = new System.Windows.Forms.Label();
            this.passwordT = new System.Windows.Forms.Label();
            this.servidorText = new System.Windows.Forms.TextBox();
            this.usuarioText = new System.Windows.Forms.TextBox();
            this.paswordText = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // activarConsulta
            // 
            this.activarConsulta.Location = new System.Drawing.Point(13, 43);
            this.activarConsulta.Name = "activarConsulta";
            this.activarConsulta.Size = new System.Drawing.Size(150, 49);
            this.activarConsulta.TabIndex = 0;
            this.activarConsulta.Text = "Activar Consulta";
            this.activarConsulta.UseVisualStyleBackColor = true;
            this.activarConsulta.Click += new System.EventHandler(this.activarConsulta_Click);
            // 
            // activarEnvioFTP
            // 
            this.activarEnvioFTP.Enabled = false;
            this.activarEnvioFTP.Location = new System.Drawing.Point(13, 277);
            this.activarEnvioFTP.Name = "activarEnvioFTP";
            this.activarEnvioFTP.Size = new System.Drawing.Size(150, 49);
            this.activarEnvioFTP.TabIndex = 1;
            this.activarEnvioFTP.Text = "Activar Envío FTP";
            this.activarEnvioFTP.UseVisualStyleBackColor = true;
            this.activarEnvioFTP.Click += new System.EventHandler(this.activarEnvioFTP_Click);
            // 
            // guardar
            // 
            this.guardar.Enabled = false;
            this.guardar.Location = new System.Drawing.Point(337, 363);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(119, 46);
            this.guardar.TabIndex = 2;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // provinciaCombo
            // 
            this.provinciaCombo.Enabled = false;
            this.provinciaCombo.FormattingEnabled = true;
            this.provinciaCombo.Location = new System.Drawing.Point(438, 43);
            this.provinciaCombo.Name = "provinciaCombo";
            this.provinciaCombo.Size = new System.Drawing.Size(121, 23);
            this.provinciaCombo.TabIndex = 3;
            this.provinciaCombo.SelectedIndexChanged += new System.EventHandler(this.provinciaCombo_SelectedIndexChanged);
            // 
            // municipioCombo
            // 
            this.municipioCombo.Enabled = false;
            this.municipioCombo.FormattingEnabled = true;
            this.municipioCombo.Location = new System.Drawing.Point(438, 74);
            this.municipioCombo.Name = "municipioCombo";
            this.municipioCombo.Size = new System.Drawing.Size(121, 23);
            this.municipioCombo.TabIndex = 4;
            this.municipioCombo.SelectedIndexChanged += new System.EventHandler(this.municipioCombo_SelectedIndexChanged);
            // 
            // eventoCombo
            // 
            this.eventoCombo.Enabled = false;
            this.eventoCombo.FormattingEnabled = true;
            this.eventoCombo.Location = new System.Drawing.Point(438, 110);
            this.eventoCombo.Name = "eventoCombo";
            this.eventoCombo.Size = new System.Drawing.Size(121, 23);
            this.eventoCombo.TabIndex = 5;
            this.eventoCombo.SelectedIndexChanged += new System.EventHandler(this.eventoCombo_SelectedIndexChanged);
            // 
            // provinciaText
            // 
            this.provinciaText.AutoSize = true;
            this.provinciaText.Enabled = false;
            this.provinciaText.Location = new System.Drawing.Point(191, 43);
            this.provinciaText.Name = "provinciaText";
            this.provinciaText.Size = new System.Drawing.Size(113, 15);
            this.provinciaText.TabIndex = 9;
            this.provinciaText.Text = "Provincia/ Lurraldea";
            // 
            // municipioText
            // 
            this.municipioText.AutoSize = true;
            this.municipioText.Enabled = false;
            this.municipioText.Location = new System.Drawing.Point(190, 74);
            this.municipioText.Name = "municipioText";
            this.municipioText.Size = new System.Drawing.Size(101, 15);
            this.municipioText.TabIndex = 10;
            this.municipioText.Text = "Municipio/ Herria";
            // 
            // eventoText
            // 
            this.eventoText.AutoSize = true;
            this.eventoText.Enabled = false;
            this.eventoText.Location = new System.Drawing.Point(190, 110);
            this.eventoText.Name = "eventoText";
            this.eventoText.Size = new System.Drawing.Size(43, 15);
            this.eventoText.TabIndex = 11;
            this.eventoText.Text = "Evento";
            // 
            // datosText
            // 
            this.datosText.AutoSize = true;
            this.datosText.Enabled = false;
            this.datosText.Location = new System.Drawing.Point(191, 170);
            this.datosText.Name = "datosText";
            this.datosText.Size = new System.Drawing.Size(95, 15);
            this.datosText.TabIndex = 12;
            this.datosText.Text = "Datos del evento";
            // 
            // servidorT
            // 
            this.servidorT.AutoSize = true;
            this.servidorT.Enabled = false;
            this.servidorT.Location = new System.Drawing.Point(301, 277);
            this.servidorT.Name = "servidorT";
            this.servidorT.Size = new System.Drawing.Size(50, 15);
            this.servidorT.TabIndex = 13;
            this.servidorT.Text = "Servidor";
            // 
            // usuarioT
            // 
            this.usuarioT.AutoSize = true;
            this.usuarioT.Enabled = false;
            this.usuarioT.Location = new System.Drawing.Point(301, 323);
            this.usuarioT.Name = "usuarioT";
            this.usuarioT.Size = new System.Drawing.Size(47, 15);
            this.usuarioT.TabIndex = 14;
            this.usuarioT.Text = "Usuario";
            // 
            // passwordT
            // 
            this.passwordT.AutoSize = true;
            this.passwordT.Enabled = false;
            this.passwordT.Location = new System.Drawing.Point(545, 323);
            this.passwordT.Name = "passwordT";
            this.passwordT.Size = new System.Drawing.Size(57, 15);
            this.passwordT.TabIndex = 15;
            this.passwordT.Text = "Password";
            // 
            // servidorText
            // 
            this.servidorText.Enabled = false;
            this.servidorText.Location = new System.Drawing.Point(405, 277);
            this.servidorText.Name = "servidorText";
            this.servidorText.Size = new System.Drawing.Size(100, 23);
            this.servidorText.TabIndex = 16;
            // 
            // usuarioText
            // 
            this.usuarioText.Enabled = false;
            this.usuarioText.Location = new System.Drawing.Point(405, 315);
            this.usuarioText.Name = "usuarioText";
            this.usuarioText.Size = new System.Drawing.Size(100, 23);
            this.usuarioText.TabIndex = 17;
            // 
            // paswordText
            // 
            this.paswordText.Enabled = false;
            this.paswordText.Location = new System.Drawing.Point(639, 323);
            this.paswordText.Name = "paswordText";
            this.paswordText.Size = new System.Drawing.Size(100, 23);
            this.paswordText.TabIndex = 18;
            this.paswordText.UseSystemPasswordChar = true;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(301, 139);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(258, 123);
            this.textBox1.TabIndex = 19;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(586, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 219);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.paswordText);
            this.Controls.Add(this.usuarioText);
            this.Controls.Add(this.servidorText);
            this.Controls.Add(this.passwordT);
            this.Controls.Add(this.usuarioT);
            this.Controls.Add(this.servidorT);
            this.Controls.Add(this.datosText);
            this.Controls.Add(this.eventoText);
            this.Controls.Add(this.municipioText);
            this.Controls.Add(this.provinciaText);
            this.Controls.Add(this.eventoCombo);
            this.Controls.Add(this.municipioCombo);
            this.Controls.Add(this.provinciaCombo);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.activarEnvioFTP);
            this.Controls.Add(this.activarConsulta);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button activarConsulta;
        private Button activarEnvioFTP;
        private Button guardar;
        private ComboBox provinciaCombo;
        private ComboBox municipioCombo;
        private ComboBox eventoCombo;
        private Label provinciaText;
        private Label municipioText;
        private Label eventoText;
        private Label datosText;
        private Label servidorT;
        private Label usuarioT;
        private Label passwordT;
        private TextBox servidorText;
        private TextBox usuarioText;
        private TextBox paswordText;
        private TextBox textBox1;
        private PictureBox pictureBox1;
    }
}
namespace PSP05
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
            UsuarioLabel = new Label();
            VisualizarCheck = new CheckBox();
            RegistrarCheck = new CheckBox();
            BorrarCheck = new CheckBox();
            UsuarioBox = new TextBox();
            RegistrarButton = new Button();
            PanelRegistroUsuario = new GroupBox();
            AceptarRegistro = new Button();
            EmailBox = new TextBox();
            EmailLabel = new Label();
            label1 = new Label();
            radioNo = new RadioButton();
            radioSi = new RadioButton();
            PanelRegistroContraseña = new GroupBox();
            BotonGuardarRegistro = new Button();
            RegistrarContraseñaBox = new TextBox();
            label7 = new Label();
            RegistarDescripcionBox = new TextBox();
            label6 = new Label();
            PanelBorrarContrasena = new GroupBox();
            BorrarDescripcionCombo = new ComboBox();
            BotonBorrar = new Button();
            label8 = new Label();
            PanelVisualizarUsuario = new GroupBox();
            VisualizarContraseñaBox = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            BotonFIchero = new Button();
            DescripcionCombo = new ComboBox();
            label2 = new Label();
            BotonGuardarCerrar = new Button();
            PanelRegistroUsuario.SuspendLayout();
            PanelRegistroContraseña.SuspendLayout();
            PanelBorrarContrasena.SuspendLayout();
            PanelVisualizarUsuario.SuspendLayout();
            SuspendLayout();
            // 
            // UsuarioLabel
            // 
            UsuarioLabel.AutoSize = true;
            UsuarioLabel.Location = new Point(13, 24);
            UsuarioLabel.Name = "UsuarioLabel";
            UsuarioLabel.Size = new Size(47, 15);
            UsuarioLabel.TabIndex = 0;
            UsuarioLabel.Text = "Usuario";
            // 
            // VisualizarCheck
            // 
            VisualizarCheck.AutoSize = true;
            VisualizarCheck.Enabled = false;
            VisualizarCheck.Location = new Point(13, 56);
            VisualizarCheck.Name = "VisualizarCheck";
            VisualizarCheck.Size = new Size(138, 19);
            VisualizarCheck.TabIndex = 1;
            VisualizarCheck.Text = "Visualizar Contraseña";
            VisualizarCheck.UseVisualStyleBackColor = true;
            VisualizarCheck.CheckedChanged += VisualizarCheck_CheckedChanged;
            // 
            // RegistrarCheck
            // 
            RegistrarCheck.AutoSize = true;
            RegistrarCheck.Enabled = false;
            RegistrarCheck.Location = new Point(13, 81);
            RegistrarCheck.Name = "RegistrarCheck";
            RegistrarCheck.Size = new Size(135, 19);
            RegistrarCheck.TabIndex = 2;
            RegistrarCheck.Text = "Registrar Contraseña";
            RegistrarCheck.UseVisualStyleBackColor = true;
            RegistrarCheck.CheckedChanged += RegistrarCheck_CheckedChanged;
            // 
            // BorrarCheck
            // 
            BorrarCheck.AutoSize = true;
            BorrarCheck.Enabled = false;
            BorrarCheck.Location = new Point(13, 106);
            BorrarCheck.Name = "BorrarCheck";
            BorrarCheck.Size = new Size(121, 19);
            BorrarCheck.TabIndex = 3;
            BorrarCheck.Text = "Borrar Contraseña";
            BorrarCheck.UseVisualStyleBackColor = true;
            BorrarCheck.CheckedChanged += BorrarCheck_CheckedChanged;
            // 
            // UsuarioBox
            // 
            UsuarioBox.Location = new Point(80, 21);
            UsuarioBox.Name = "UsuarioBox";
            UsuarioBox.Size = new Size(100, 23);
            UsuarioBox.TabIndex = 4;
            // 
            // RegistrarButton
            // 
            RegistrarButton.Location = new Point(208, 20);
            RegistrarButton.Name = "RegistrarButton";
            RegistrarButton.Size = new Size(75, 23);
            RegistrarButton.TabIndex = 5;
            RegistrarButton.Text = "Registrar";
            RegistrarButton.UseVisualStyleBackColor = true;
            RegistrarButton.Click += RegistrarButton_Click;
            // 
            // PanelRegistroUsuario
            // 
            PanelRegistroUsuario.Controls.Add(AceptarRegistro);
            PanelRegistroUsuario.Controls.Add(EmailBox);
            PanelRegistroUsuario.Controls.Add(EmailLabel);
            PanelRegistroUsuario.Controls.Add(label1);
            PanelRegistroUsuario.Controls.Add(radioNo);
            PanelRegistroUsuario.Controls.Add(radioSi);
            PanelRegistroUsuario.Enabled = false;
            PanelRegistroUsuario.Location = new Point(338, 12);
            PanelRegistroUsuario.Name = "PanelRegistroUsuario";
            PanelRegistroUsuario.Size = new Size(394, 163);
            PanelRegistroUsuario.TabIndex = 6;
            PanelRegistroUsuario.TabStop = false;
            PanelRegistroUsuario.Text = "Registro Usuario";
            // 
            // AceptarRegistro
            // 
            AceptarRegistro.Location = new Point(85, 120);
            AceptarRegistro.Name = "AceptarRegistro";
            AceptarRegistro.Size = new Size(75, 23);
            AceptarRegistro.TabIndex = 7;
            AceptarRegistro.Text = "Aceptar";
            AceptarRegistro.UseVisualStyleBackColor = true;
            AceptarRegistro.Click += AceptarRegistro_Click;
            // 
            // EmailBox
            // 
            EmailBox.Enabled = false;
            EmailBox.Location = new Point(85, 80);
            EmailBox.Name = "EmailBox";
            EmailBox.Size = new Size(100, 23);
            EmailBox.TabIndex = 6;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Enabled = false;
            EmailLabel.Location = new Point(18, 84);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(39, 15);
            EmailLabel.TabIndex = 5;
            EmailLabel.Text = "Email:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 19);
            label1.Name = "label1";
            label1.Size = new Size(259, 15);
            label1.TabIndex = 2;
            label1.Text = "El usuario indicado no existe: ¿desea registrarlo?";
            // 
            // radioNo
            // 
            radioNo.AutoSize = true;
            radioNo.Location = new Point(148, 44);
            radioNo.Name = "radioNo";
            radioNo.Size = new Size(41, 19);
            radioNo.TabIndex = 1;
            radioNo.TabStop = true;
            radioNo.Text = "No";
            radioNo.UseVisualStyleBackColor = true;
            radioNo.CheckedChanged += radioNo_CheckedChanged;
            // 
            // radioSi
            // 
            radioSi.AutoSize = true;
            radioSi.Location = new Point(68, 44);
            radioSi.Name = "radioSi";
            radioSi.Size = new Size(34, 19);
            radioSi.TabIndex = 0;
            radioSi.TabStop = true;
            radioSi.Text = "Si";
            radioSi.UseVisualStyleBackColor = true;
            radioSi.CheckedChanged += radioSi_CheckedChanged;
            // 
            // PanelRegistroContraseña
            // 
            PanelRegistroContraseña.Controls.Add(BotonGuardarRegistro);
            PanelRegistroContraseña.Controls.Add(RegistrarContraseñaBox);
            PanelRegistroContraseña.Controls.Add(label7);
            PanelRegistroContraseña.Controls.Add(RegistarDescripcionBox);
            PanelRegistroContraseña.Controls.Add(label6);
            PanelRegistroContraseña.Enabled = false;
            PanelRegistroContraseña.Location = new Point(12, 343);
            PanelRegistroContraseña.Name = "PanelRegistroContraseña";
            PanelRegistroContraseña.Size = new Size(720, 125);
            PanelRegistroContraseña.TabIndex = 7;
            PanelRegistroContraseña.TabStop = false;
            PanelRegistroContraseña.Text = "Registrar";
            // 
            // BotonGuardarRegistro
            // 
            BotonGuardarRegistro.Location = new Point(265, 80);
            BotonGuardarRegistro.Name = "BotonGuardarRegistro";
            BotonGuardarRegistro.Size = new Size(75, 23);
            BotonGuardarRegistro.TabIndex = 17;
            BotonGuardarRegistro.Text = "Guardar";
            BotonGuardarRegistro.UseVisualStyleBackColor = true;
            BotonGuardarRegistro.Click += BotonGuardarRegistro_Click;
            // 
            // RegistrarContraseñaBox
            // 
            RegistrarContraseñaBox.Location = new Point(265, 51);
            RegistrarContraseñaBox.Name = "RegistrarContraseñaBox";
            RegistrarContraseñaBox.Size = new Size(439, 23);
            RegistrarContraseñaBox.TabIndex = 16;
            RegistrarContraseñaBox.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(135, 54);
            label7.Name = "label7";
            label7.Size = new Size(67, 15);
            label7.TabIndex = 15;
            label7.Text = "Contraseña";
            // 
            // RegistarDescripcionBox
            // 
            RegistarDescripcionBox.Location = new Point(265, 22);
            RegistarDescripcionBox.Name = "RegistarDescripcionBox";
            RegistarDescripcionBox.Size = new Size(439, 23);
            RegistarDescripcionBox.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(135, 25);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 13;
            label6.Text = "Descripción";
            // 
            // PanelBorrarContrasena
            // 
            PanelBorrarContrasena.Controls.Add(BorrarDescripcionCombo);
            PanelBorrarContrasena.Controls.Add(BotonBorrar);
            PanelBorrarContrasena.Controls.Add(label8);
            PanelBorrarContrasena.Enabled = false;
            PanelBorrarContrasena.Location = new Point(12, 491);
            PanelBorrarContrasena.Name = "PanelBorrarContrasena";
            PanelBorrarContrasena.Size = new Size(720, 78);
            PanelBorrarContrasena.TabIndex = 8;
            PanelBorrarContrasena.TabStop = false;
            PanelBorrarContrasena.Text = "Borrar";
            // 
            // BorrarDescripcionCombo
            // 
            BorrarDescripcionCombo.FormattingEnabled = true;
            BorrarDescripcionCombo.Location = new Point(265, 16);
            BorrarDescripcionCombo.Name = "BorrarDescripcionCombo";
            BorrarDescripcionCombo.Size = new Size(439, 23);
            BorrarDescripcionCombo.TabIndex = 19;
            // 
            // BotonBorrar
            // 
            BotonBorrar.Location = new Point(265, 45);
            BotonBorrar.Name = "BotonBorrar";
            BotonBorrar.Size = new Size(75, 23);
            BotonBorrar.TabIndex = 18;
            BotonBorrar.Text = "Borrar";
            BotonBorrar.UseVisualStyleBackColor = true;
            BotonBorrar.Click += BotonBorrar_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(137, 19);
            label8.Name = "label8";
            label8.Size = new Size(104, 15);
            label8.TabIndex = 16;
            label8.Text = "Elija la descripción";
            // 
            // PanelVisualizarUsuario
            // 
            PanelVisualizarUsuario.Controls.Add(VisualizarContraseñaBox);
            PanelVisualizarUsuario.Controls.Add(label5);
            PanelVisualizarUsuario.Controls.Add(label4);
            PanelVisualizarUsuario.Controls.Add(label3);
            PanelVisualizarUsuario.Controls.Add(BotonFIchero);
            PanelVisualizarUsuario.Controls.Add(DescripcionCombo);
            PanelVisualizarUsuario.Controls.Add(label2);
            PanelVisualizarUsuario.Enabled = false;
            PanelVisualizarUsuario.Location = new Point(13, 192);
            PanelVisualizarUsuario.Name = "PanelVisualizarUsuario";
            PanelVisualizarUsuario.Size = new Size(720, 125);
            PanelVisualizarUsuario.TabIndex = 9;
            PanelVisualizarUsuario.TabStop = false;
            PanelVisualizarUsuario.Text = "Visualizar";
            // 
            // VisualizarContraseñaBox
            // 
            VisualizarContraseñaBox.Location = new Point(264, 78);
            VisualizarContraseñaBox.Name = "VisualizarContraseñaBox";
            VisualizarContraseñaBox.Size = new Size(439, 23);
            VisualizarContraseñaBox.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(134, 81);
            label5.Name = "label5";
            label5.Size = new Size(118, 15);
            label5.TabIndex = 11;
            label5.Text = "Esta es su contraseña";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(356, 53);
            label4.Name = "label4";
            label4.Size = new Size(119, 15);
            label4.TabIndex = 10;
            label4.Text = "Ubicacion del fichero";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(102, 53);
            label3.Name = "label3";
            label3.Size = new Size(150, 15);
            label3.TabIndex = 9;
            label3.Text = "Registre el fichero de clave:";
            // 
            // BotonFIchero
            // 
            BotonFIchero.Location = new Point(264, 49);
            BotonFIchero.Name = "BotonFIchero";
            BotonFIchero.Size = new Size(75, 23);
            BotonFIchero.TabIndex = 8;
            BotonFIchero.Text = "Fichero";
            BotonFIchero.UseVisualStyleBackColor = true;
            BotonFIchero.Click += BotonFIchero_Click;
            // 
            // DescripcionCombo
            // 
            DescripcionCombo.FormattingEnabled = true;
            DescripcionCombo.Location = new Point(264, 25);
            DescripcionCombo.Name = "DescripcionCombo";
            DescripcionCombo.Size = new Size(439, 23);
            DescripcionCombo.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(145, 28);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 1;
            label2.Text = "Elija la descripcion:";
            // 
            // BotonGuardarCerrar
            // 
            BotonGuardarCerrar.Location = new Point(648, 653);
            BotonGuardarCerrar.Name = "BotonGuardarCerrar";
            BotonGuardarCerrar.Size = new Size(140, 23);
            BotonGuardarCerrar.TabIndex = 19;
            BotonGuardarCerrar.Text = "Guardar y Cerrar";
            BotonGuardarCerrar.UseVisualStyleBackColor = true;
            BotonGuardarCerrar.Click += BotonGuardarCerrar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 688);
            Controls.Add(BotonGuardarCerrar);
            Controls.Add(PanelVisualizarUsuario);
            Controls.Add(PanelBorrarContrasena);
            Controls.Add(PanelRegistroContraseña);
            Controls.Add(PanelRegistroUsuario);
            Controls.Add(RegistrarButton);
            Controls.Add(UsuarioBox);
            Controls.Add(BorrarCheck);
            Controls.Add(RegistrarCheck);
            Controls.Add(VisualizarCheck);
            Controls.Add(UsuarioLabel);
            Name = "Form1";
            Text = "Form1";
            PanelRegistroUsuario.ResumeLayout(false);
            PanelRegistroUsuario.PerformLayout();
            PanelRegistroContraseña.ResumeLayout(false);
            PanelRegistroContraseña.PerformLayout();
            PanelBorrarContrasena.ResumeLayout(false);
            PanelBorrarContrasena.PerformLayout();
            PanelVisualizarUsuario.ResumeLayout(false);
            PanelVisualizarUsuario.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UsuarioLabel;
        private CheckBox VisualizarCheck;
        private CheckBox RegistrarCheck;
        private CheckBox BorrarCheck;
        private TextBox UsuarioBox;
        private Button RegistrarButton;
        private GroupBox PanelRegistroUsuario;
        private Button AceptarRegistro;
        private TextBox EmailBox;
        private Label EmailLabel;
        private Label label1;
        private RadioButton radioNo;
        private RadioButton radioSi;
        private GroupBox PanelRegistroContraseña;
        private Button BotonGuardarRegistro;
        private TextBox RegistrarContraseñaBox;
        private Label label7;
        private TextBox RegistarDescripcionBox;
        private Label label6;
        private GroupBox PanelBorrarContrasena;
        private ComboBox BorrarDescripcionCombo;
        private Button BotonBorrar;
        private Label label8;
        private GroupBox PanelVisualizarUsuario;
        private TextBox VisualizarContraseñaBox;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button BotonFIchero;
        private ComboBox DescripcionCombo;
        private Label label2;
        private Button BotonGuardarCerrar;
        private ComboBox comboBox1;
    }
}
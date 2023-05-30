using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.IO;
using System.Collections;
using System.Xml.Linq;
using System.ComponentModel;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PSP05
{
    public partial class Form1 : Form
    {
        private string[] descripcion;
        private string[] pass;
        public Form1()
        {
            InitializeComponent();
        }

        private void RegistrarButton_Click(object sender, EventArgs e)
        {
            string path = @"../../../bbdd/" + UsuarioBox.Text + ".txt";

            bool fileExist = File.Exists(path);
            if (fileExist)
            {
                VisualizarCheck.Enabled = true;
                RegistrarCheck.Enabled = true;
                BorrarCheck.Enabled = true;
            }
            else
            {
                PanelRegistroUsuario.Enabled = true;
            }
        }

        private void AceptarRegistro_Click(object sender, EventArgs e)
        {
            generarClaves(UsuarioBox.Text + "_public.xml", UsuarioBox.Text + "_private.xml");
            enviarClave(UsuarioBox.Text + "_private.xml", EmailBox.Text, UsuarioBox.Text);
            File.Create(@"../../../bbdd/" + UsuarioBox.Text + ".txt").Close();
        }
        private static void generarClaves(string publicKF, string privateKF)
        {
            //Creamos un objeto de tipo RSACryptoServiceProvider para hacer uso de la clave pública y clave privada para su poserior uso.
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                //Obtiene o establece un valor que indica si la clave debe conservarse en el proveedor de servicios criptográficos (CSP).
                //Le indicamos el valor a false porque no queremos que esté en ningún proveedor de servicios.
                rsa.PersistKeyInCsp = false;

                //Borramos cualquier fichero que contenga los mismos nombres
                if (File.Exists(@"../../../publickeys/" + publicKF))
                    File.Delete(@"../../../publickeys/" + publicKF);
                if (File.Exists(@"../../../privatekeys/" + privateKF))
                    File.Delete(@"../../../privatekeys/" + privateKF);


                //ToXmlString(false): Crea un string con la clave pública. Para que sea pública hay que pasarle como parámetro (false).
                string publicKey = rsa.ToXmlString(false);

                //Crea un fichero y guarda el texto de la clave en el fichero.
                File.WriteAllText(@"../../../publickeys/" + publicKF, publicKey);


                //Mismo proceso anterior para la clave privada
                string privateKey = rsa.ToXmlString(true);
                File.WriteAllText(@"../../../privatekeys/" + privateKF, privateKey);

            }
        }
        private static void enviarClave(string privateKF, string correo, string usuario)
        {

            //Dirección de cuenta desde la cual se quiere enviar un correo electrónico
            MailAddress origen = new MailAddress("ikaltuna@birt.eus", "From BirtPSP");

            //Dirección de cuenta a la cual se quiere enviar un correo electrónico
            MailAddress destino = new MailAddress(correo, usuario);

            //Se especifica información del servidor, protocolo, credenciales, ...de la conexión que se va a realizar
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(origen.Address, "DrZKWqcP"),
                EnableSsl = true

            };

            //Se especifica el fichero
            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(@"../../../privatekeys/" + privateKF);
            //Se escribe el mensage que vamos a enviar indicando cual será el receptor y el emisor
            MailMessage mezua = new MailMessage();
            mezua.IsBodyHtml = true;
            mezua.From = new MailAddress("ikaltuna@birt.eus", "Birt");
            mezua.To.Add(new MailAddress(correo, usuario));
            mezua.Subject = "clave privada";
            mezua.Body = "Clave de acceso a contraseñas en el gestor de password";


            {
                if (attachment != null)
                {

                    mezua.Attachments.Add(attachment);
                }
            }

            //Se ejecuta el envío del mensaje.
            try
            {
                smtp.Send(mezua);

            }
            catch (Exception ex)
            {
                //En caso de error se muestra por la consola.
                Console.WriteLine(ex.ToString());
            }
        }
        private void radioSi_CheckedChanged(object sender, EventArgs e)
        {
            EmailLabel.Enabled = true;
            EmailBox.Enabled = true;
        }

        private void radioNo_CheckedChanged(object sender, EventArgs e)
        {
            EmailLabel.Enabled = false;
            EmailBox.Enabled = false;
        }
        public void obtenerdatos()
        {
            DescripcionCombo.Items.Clear();
            string guardar = "";
            using (StreamReader leer = new StreamReader(@"../../../bbdd/" + UsuarioBox.Text + ".txt"))
            {
                guardar += leer.ReadToEnd();
            }
            string[] datosFichero = guardar.Split(" cifrado ");
            for (int i = 1; i < datosFichero.Length; i++)
            {

                DescripcionCombo.Items.Add(datosFichero[i]);
                i++;
            }
        }
        public void borrardatos()
        {

            BorrarDescripcionCombo.Items.Clear();
            string guardar = "";
            using (StreamReader leer = new StreamReader(@"../../../bbdd/" + UsuarioBox.Text + ".txt"))
            {
                guardar += leer.ReadToEnd();
            }
            string[] datosFichero = guardar.Split(" cifrado ");
            for (int i = 1; i < datosFichero.Length; i++)
            {

                BorrarDescripcionCombo.Items.Add(datosFichero[i]);
                i++;
            }
        }
        private void VisualizarCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (PanelVisualizarUsuario.Enabled)
            {
                PanelVisualizarUsuario.Enabled = false;
                DescripcionCombo.Items.Clear();
            }
            else
            {
                PanelVisualizarUsuario.Enabled = true;
                obtenerdatos();

            }

        }

        private void RegistrarCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (PanelRegistroContraseña.Enabled)
            {
                PanelRegistroContraseña.Enabled = false;
            }
            else
            {
                PanelRegistroContraseña.Enabled = true;
            }
        }

        private void BorrarCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (PanelBorrarContrasena.Enabled)
            {
                PanelBorrarContrasena.Enabled = false;
                BorrarDescripcionCombo.Items.Clear();
            }
            else
            {
                PanelBorrarContrasena.Enabled = true;
                borrardatos();
            }
        }

        private void BotonGuardarRegistro_Click(object sender, EventArgs e)
        {
            byte[] bytextoCifrado;
            //RegistrarContraseñaBox.Text;
            string caracteres = @"[!@#&()–[{}:',?/*~$^+=<>]";
            string numeros = @"[0-9]+";
            Regex rgx = new Regex(caracteres);
            Regex rgxn = new Regex(numeros);
            if ((RegistrarContraseñaBox.Text.Length <= 8 || RegistrarContraseñaBox.Text.Length >= 10)
                || !RegistrarContraseñaBox.Text.Any(char.IsUpper) || !RegistrarContraseñaBox.Text.Any(char.IsLower)
                || !rgx.IsMatch(RegistrarContraseñaBox.Text) || !rgxn.IsMatch(RegistrarContraseñaBox.Text))
            {
                MessageBox.Show("La contraseña al menos tiene que contener \n" +
                    "1 mayúscula \n" +
                    "1 minúscula \n" +
                    "1 número \n" +
                    "8 - 10 caracteres de longitud \n" +
                    "1 caracter: !@#&()–[{}:',?/*~$^+=<>");
            }
            else
            {




                //StreamWriter sw = new StreamWriter(@"../../../bbdd/" + UsuarioBox.Text + ".txt");
                //sw.WriteLine(RegistarDescripcionBox.Text);
                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                string guardar;
                bytextoCifrado = encriptar(@"../../../publickeys/" + UsuarioBox.Text + "_public.xml", ByteConverter.GetBytes(RegistrarContraseñaBox.Text));

                string cifrado = "";
                for (int i = 0; i < bytextoCifrado.Length; i++)
                {
                    cifrado += Convert.ToString(bytextoCifrado[i]) + "-";

                }


                using (StreamReader leer = new StreamReader(@"../../../bbdd/" + UsuarioBox.Text + ".txt"))
                {
                    guardar = leer.ReadToEnd();
                }
                guardar += " cifrado " + (RegistarDescripcionBox.Text);
                guardar += " cifrado " + cifrado;
                using (StreamWriter escribir = new StreamWriter(@"../../../bbdd/" + UsuarioBox.Text + ".txt"))
                {
                    escribir.WriteLine(guardar);
                }
            }
        }
        public static byte[] encriptar(string publicKF, byte[] textoPlano)
        {
            byte[] encriptado;

            //Se crea un objeto de tipo RSACryptoServiceProvider para poder hacer uso de sus métodos de encriptación
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                //Le indicamos el valor a false porque no queremos que esté en ningún proveedor de servicios.
                rsa.PersistKeyInCsp = false;

                //Lee el contenido del fichero y lo guarda en un string
                string publicKey = File.ReadAllText(publicKF);

                //FromXmlString(publicKey): Inicializa un objeto RSA de la información de clave de una cadena XML.
                rsa.FromXmlString(publicKey);

                //Cifra los datos con el algoritmo RSA.
                //@textoPlano: datos que se van a cifrar
                //@Booleano: true para realizar el cifrado RSA directo mediante el relleno de OAEP (solo disponible en equipos con Windows XP o versiones posteriores como en nuestro caso); de lo contrario, false para usar el relleno PKCS#1 v1.5.
                encriptado = rsa.Encrypt(textoPlano, true);

            }

            //Valor que se devuelve
            return encriptado;

        }
        public static byte[] Desencriptar(string privateKF, byte[] textoEncriptado)
        {

            byte[] desencriptado;
            //Se crea un objeto de tipo RSACryptoServiceProvider para poder hacer uso de sus métodos.
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                //Le indicamos el valor a false porque no queremos que esté en ningún proveedor de servicios.
                rsa.PersistKeyInCsp = false;


                //Lee el contenido del fichero y lo guarda en un string
                string privateKey = File.ReadAllText(privateKF);

                //FromXmlString(false): Inicializa un objeto RSA de la información de clave de una cadena XML.
                //En este caso clave privada ya que la utilizaremos para descifrar
                rsa.FromXmlString(privateKey);

                //Descifra los datos que se cifraron anteriormente.
                //@textoEncriptado: Datos que se van a descifrar.
                //@Booleano: true para realizar el cifrado RSA directo mediante el relleno de OAEP (solo disponible en equipos con Windows XP o versiones posteriores como en nuestro caso); de lo contrario, false 
                desencriptado = rsa.Decrypt(textoEncriptado, true);

            }
            return (desencriptado);

        }
        private void BotonFIchero_Click(object sender, EventArgs e)
        {
            int size = -1;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string contrasenas = "";
                    using (StreamReader leer = new StreamReader(@"../../../bbdd/" + UsuarioBox.Text + ".txt"))
                    {
                        contrasenas += leer.ReadToEnd();
                    }
                    string[] datosFichero = contrasenas.Split(" cifrado ");
                    int x = 0;
                    string[] pass = new string[datosFichero.Length];
                    for (int i = 1; i < datosFichero.Length; i++)
                    {
                        pass[x] = (datosFichero[i + 1]);
                        x++;
                        i++;
                    }
                    string[] passstring = pass[DescripcionCombo.SelectedIndex].Split("-");
                    passstring = passstring.Take(passstring.Length - 1).ToArray();
                    int[] passint = passstring.Select(int.Parse).ToArray();
                    byte[] passencriptado = passint.Select(i => (byte)i).ToArray();
                    UnicodeEncoding ByteConverter = new UnicodeEncoding();
                    string text = File.ReadAllText(file);
                    label4.Text = file;
                    byte[] desencriptado = Desencriptar(file, passencriptado);
                    this.VisualizarContraseñaBox.Text = ByteConverter.GetString(desencriptado);
                }
                catch (IOException)
                {
                }
            }
        }

        private void BotonBorrar_Click(object sender, EventArgs e)
        {
            string[] lineas = File.ReadAllLines(@"../../../bbdd/" + UsuarioBox.Text + ".txt");
            int x = 0;
            string texto = "";
            for (int i = 0; i < lineas.Length; i++)
            {

                if (i.Equals(BorrarDescripcionCombo.SelectedIndex))
                {

                }
                else
                {
                    texto += lineas[i] + "\n";

                }

            }
            using (StreamWriter escribir = new StreamWriter(@"../../../bbdd/" + UsuarioBox.Text + ".txt"))
            {
                escribir.WriteLine(texto);
            }

        }

        private void BotonGuardarCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
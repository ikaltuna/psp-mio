using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Eventos
{
    public partial class Form1 : Form
    {
        String[] provincia;
        String[] provinciaid;
        String[] municipio;
        String[] municipioid;
        String[] evento;
        String[] eventoid;
        public Form1()
        {
            InitializeComponent();
        }

        private async void provinciaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.municipioCombo.Items.Clear();

            using (HttpClient client = new HttpClient())

            using (HttpResponseMessage response = await client.GetAsync($"https://api.euskadi.eus/culture/events/v1.0/municipalities/byProvince/1/?_elements=300&provinceId=" + provinciaid[provinciaCombo.SelectedIndex]))
            {
                string datomunicipio = await response.Content.ReadAsStringAsync();
                dynamic objDatosMunicipios = JValue.Parse(datomunicipio);
                municipio = new String[(int)objDatosMunicipios.totalItems];
                municipioid = new String[(int)objDatosMunicipios.totalItems];
                for (int i = 0; i < (int)objDatosMunicipios.totalItems; i++)
                {
                    municipio[i] = objDatosMunicipios.items[i].nameEs;
                    municipioid[i] = objDatosMunicipios.items[i].municipalityId;
                    this.municipioCombo.Items.Add(municipio[i]);
                }
                this.municipioCombo.Text = municipio[0].ToString();
            }

        }

        private async void municipioCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.eventoCombo.Items.Clear();

            using (HttpClient client = new HttpClient())

            using (HttpResponseMessage response = await client.GetAsync($"https://api.euskadi.eus/culture/events/v1.0/events?_elements=3000&municipalityNoraCode=" + municipioid[municipioCombo.SelectedIndex] + "&year=2023"))
            {
                string datoevento = await response.Content.ReadAsStringAsync();
                dynamic objDatosEventos = JValue.Parse(datoevento);
                evento = new String[(int)objDatosEventos.totalItems];
                eventoid = new String[(int)objDatosEventos.totalItems];
                for (int i = 0; i < (int)objDatosEventos.totalItems; i++)
                {
                    evento[i] = objDatosEventos.items[i].nameEs;
                    eventoid[i] = objDatosEventos.items[i].id;
                    this.eventoCombo.Items.Add(evento[i]);
                }
                this.eventoCombo.Text = evento[0].ToString();
            }
        }

        private async void activarConsulta_Click(object sender, EventArgs e)
        {
            habilitarConsulta();

            this.provinciaCombo.Items.Clear();

            using (HttpClient client = new HttpClient())

            using (HttpResponseMessage response = await client.GetAsync($"https://api.euskadi.eus/culture/events/v1.0/provinces"))
            {
                
                string datoprovincia = await response.Content.ReadAsStringAsync();
                
                dynamic objDatosProvincias = JValue.Parse(datoprovincia);
                provincia = new String[(int)objDatosProvincias.totalItems];
                provinciaid = new String[(int)objDatosProvincias.totalItems];
                for (int i = 1; i < (int)objDatosProvincias.totalItems; i++)
                {
                    
                    provincia[i-1] = objDatosProvincias.items[i].nameEs;
                    provinciaid[i-1] = objDatosProvincias.items[i].provinceId;
                    this.provinciaCombo.Items.Add(provincia[i - 1]);

                }
                this.provinciaCombo.Text = provincia[0].ToString();
            }

        }

        private async void eventoCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = "";

            using (HttpClient client = new HttpClient())

            using (HttpResponseMessage response = await client.GetAsync($"https://api.euskadi.eus/culture/events/v1.0/events?_elements=3000&municipalityNoraCode=" + municipioid[municipioCombo.SelectedIndex] + "&year=2023"))
            {
                string datoevento = await response.Content.ReadAsStringAsync();
                dynamic objDatosEventos = JValue.Parse(datoevento);
                evento = new String[(int)objDatosEventos.totalItems];
                eventoid = new String[(int)objDatosEventos.totalItems];
                for (int i = 0; i < (int)objDatosEventos.totalItems; i++)
                {
                    string info = "Tipo de evento: " + objDatosEventos.items[eventoCombo.SelectedIndex].typeEs + ".";
                    info += Environment.NewLine + "Nombre de evento: " + objDatosEventos.items[eventoCombo.SelectedIndex].nameEs + ".";
                    info += Environment.NewLine + "Hora de evento: " + objDatosEventos.items[eventoCombo.SelectedIndex].startDate + ".";
                    info += Environment.NewLine + "Edificio: " + objDatosEventos.items[eventoCombo.SelectedIndex].establishmentEs + ".";
                    info += Environment.NewLine + "Precio: " + objDatosEventos.items[eventoCombo.SelectedIndex].priceEs + ".";
                    this.textBox1.Text = info;
                    pictureBox1.ImageLocation = objDatosEventos.items[eventoCombo.SelectedIndex].images[0].imageUrl;

                }
            }
        }
        private void activarEnvioFTP_Click(object sender, EventArgs e)
        {
            habilitarFtp();
            string nombre = eventoCombo.Text;
            using (StreamWriter crearFichero = new StreamWriter("fichero.txt")){
                crearFichero.WriteLine(this.textBox1.Text);
            }

        }
        private void guardar_Click(object sender, EventArgs e)
        {
            string resultado = "";
            // creamos una conexión FTP
            //Indicamos servidor al que nos vamos a conectar. Nuestro servidor no dispone de ninguna dirección URL o ULI y por lo tanto lo adaptamos a la dirección IP
            //En este caso vamos a subir un fichero local y necesitamos indicarle el nombre del fichero que va a recibir en el servidor.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + servidorText.Text + "/" + "/" + eventoCombo.Text + ".txt");

            // Si no se especifican las credenciales se asignan unas credenciales de tipo anónimas. El servidor lo deberá permitir.
            request.Credentials = new NetworkCredential(usuarioText.Text, paswordText.Text);

            //Recogemos en el atributo Method el tipo de acción que vamos a realizar: en este caso subir un fichero.
            request.Method = WebRequestMethods.Ftp.UploadFile;


            byte[] fileContents;

            //Recogemos el contenido del fichero en un buffer
            using (StreamReader sourceStream = new StreamReader("fichero.txt"))
            {
                fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            }

            //Recogemos en el atributo ContentLength del objeto request
            request.ContentLength = fileContents.Length;

            //Creamos un objeto de tipo Stream para enviar la información
            //Hacemos uso del método write, pasamos el contenido del fichero, offset(0) indicando el comienzo del fichero  y longitud del fichero.
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileContents, 0, fileContents.Length);
            }

            //Se espera la respuesta y enviara por correo.
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                resultado = "Fichero subido con código: " + response.StatusDescription;
            }


            //Dirección de cuenta desde la cual se quiere enviar un correo electrónico
            MailAddress origen = new MailAddress("ikaltuna@birt.eus", "From Iker");

            //Dirección de cuenta a la cual se quiere enviar un correo electrónico
            MailAddress destino = new MailAddress("birtpsp@gmail.com", "To BirtPSP");

            //Se especifica información del servidor, protocolo, credenciales, ...de la conexión que se va a realizar
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(origen.Address, "DrZKWqcP"),
                EnableSsl = true

            };

            //Se escribe el mensage que vamos a enviar indicando cual será el receptor y el emisor
            using (MailMessage mezua = new MailMessage(origen, destino)
            {
                Subject = eventoCombo.Text,
                Body = resultado
            })

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

            this.textBox1.Text = "Email enviado";
            servidorText.Text = "";
            usuarioText.Text = "";
            paswordText.Text = "";
            deshabilitarTodo();


        }
        private void habilitarConsulta()
        {
            provinciaText.Enabled = true;
            municipioText.Enabled = true;
            eventoText.Enabled = true;
            datosText.Enabled = true;
            provinciaCombo.Enabled = true;
            municipioCombo.Enabled = true;
            eventoCombo.Enabled = true;
            textBox1.Enabled = true;
            activarEnvioFTP.Enabled = true;
        }
        private void habilitarFtp()
        {
            servidorT.Enabled = true;
            usuarioT.Enabled = true;
            servidorText.Enabled = true;
            usuarioText.Enabled = true;
            passwordT.Enabled = true;
            paswordText.Enabled = true;
            guardar.Enabled = true;
        }
        private void deshabilitarTodo()
        {
            provinciaText.Enabled = false;
            municipioText.Enabled = false;
            eventoText.Enabled = false;
            datosText.Enabled = false;
            provinciaCombo.Enabled = false;
            municipioCombo.Enabled = false;
            eventoCombo.Enabled = false;
            textBox1.Enabled = false;
            activarEnvioFTP.Enabled = false;
            servidorT.Enabled = false;
            usuarioT.Enabled = false;
            servidorText.Enabled = false;
            usuarioText.Enabled = false;
            passwordT.Enabled = false;
            paswordText.Enabled = false;
            guardar.Enabled = false;
        }
    }
}
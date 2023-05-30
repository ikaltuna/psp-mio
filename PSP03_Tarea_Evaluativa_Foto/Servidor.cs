using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;

namespace ClienteMultiple
{

    public class TCPServidor
    {
        
        public int jugadas = 0;
        private Object o = new object();

        private string datotratar = string.Empty;
        public static int Main(String[] args)
        {
            TCPServidor appserver = new TCPServidor();

            //Inicialización de variables

            TcpClient socketcliente = null;
            NetworkStream network = null;
            StreamWriter writer = null;
            StreamReader reader = null;
            

            //Preparación de datos para el listener
            
            string servidor = "127.0.0.1";
            IPAddress ipserver = IPAddress.Parse(servidor);
            Int32 port = 13000;
            TcpListener listener = new TcpListener(ipserver, port);
            Console.WriteLine("Socket lister creado");
            listener.Start(10);
            

            while (true)
            {
                socketcliente = listener.AcceptTcpClient(); //linea bloqueante
                Console.WriteLine("Conexión con clientecliente establecida.");
               
                Thread t = new Thread(() => appserver.ControlDatos(socketcliente));
                t.Start();
            }

            socketcliente.Close();

            Console.WriteLine("\n Fin del juego");
            Console.Read();
            return 0;
        }
        public TCPServidor()
        {
            
        }
        
        private void ControlDatos(TcpClient socket)
        {
  
            NetworkStream network = socket.GetStream();
            StreamWriter writer = new StreamWriter(network);
            StreamReader reader = new StreamReader(network);
            Console.WriteLine("Buffer de entrada y salida creados.");
            writer.Flush();
            datotratar = "a";


            try
            {
                writer.Flush();
                writer.WriteLine("MENU");
                while (true)
                {
                    try
                    {
                        
                        writer.Flush();
                        datotratar = reader.ReadLine();


                        if (datotratar.Equals("1"))
                        {
                            writer.WriteLine("FotoMonte");
                            byte[] bytes = File.ReadAllBytes("FotoMonte.jpg");
                            writer.WriteLine(bytes.Length.ToString());
                            writer.Flush();


                            writer.WriteLine("FotoMonte_enviado.jpg");
                            writer.Flush();
                            Console.WriteLine("Enviando archivo");
                            socket.Client.SendFile("FotoMonte.jpg");
                            datotratar = "";

                        }
                        if (datotratar.Equals("2"))
                        {
                            writer.WriteLine("FotoPlaya");
                            byte[] bytes = File.ReadAllBytes("FotoPlaya.jpg");
                            writer.WriteLine(bytes.Length.ToString());
                            writer.Flush();


                            writer.WriteLine("FotoPlaya_enviado.jpg");
                            writer.Flush();
                            Console.WriteLine("Enviando archivo");
                            socket.Client.SendFile("FotoPlaya.jpg");
                            datotratar = "";

                        }
                        if (datotratar.Equals("3"))
                        {
                            writer.WriteLine("FotoCiudad");

                            byte[] bytes = File.ReadAllBytes("FotoCiudad.jpg");
                            writer.WriteLine(bytes.Length.ToString());
                            writer.Flush();


                            writer.WriteLine("FotoCiudad_enviado.jpg");
                            writer.Flush();
                            Console.WriteLine("Enviando archivo");
                            socket.Client.SendFile("FotoCiudad.jpg");
                            writer.Flush();
                            datotratar = "";

                        }
                        if (datotratar.Equals("4"))
                        {
                            writer.WriteLine("Salir");


                            writer.Flush();
                            datotratar = "";

                        }
                        else
                        {
                            writer.WriteLine("MENU");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.Out.Flush();
                    }
                }
            }

            finally
            {

            }

        }


    }
}
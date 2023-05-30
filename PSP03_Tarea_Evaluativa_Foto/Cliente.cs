using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;

namespace ClienteMultiple
{

    public class TCPCliente
    {

        TcpClient socket = null;
        NetworkStream network = null;
        StreamWriter writer = null;
        StreamReader reader = null;    
        public static int Main(String[] args)
        {
            TCPCliente appcliente = new TCPCliente();
            string servidor = "127.0.0.1";
            Int32 port = 13000;

            appcliente.Connect(servidor, port);
            appcliente.ControlDatos();
            appcliente.Cerrar();

            Console.WriteLine("\n Fin del juego");
            Console.Read();
            return 0;
        }
        public TCPCliente()
        {

        }
        private void Connect(String server, Int32 port)
        {
            try
            {
               
                this.socket = new TcpClient(server, port);
                Console.WriteLine("Socket Cliente creado.");
                network = socket.GetStream();
                this.writer = new StreamWriter(network);
                this.reader = new StreamReader(network);
                Console.WriteLine("Buffer de escritura y lectura creados.");


                string datouser = string.Empty;


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        private void ControlDatos()
        {
            string datouser = string.Empty;
            int num = int.MaxValue;
            try
            {
                
                do
                {
                    datouser = reader.ReadLine();
                    int partidas = 0;
                    if (datouser.Equals("MENU"))
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("1: FotoMonte");
                        Console.WriteLine("2: FotoPlaya");
                        Console.WriteLine("3: FotoCiudad");
                        Console.WriteLine("4: Salir");
                        Console.WriteLine("--------------------------------");
                        datouser = Console.ReadLine();
                        writer.WriteLine(datouser);
                        writer.Flush();

                    }
                    else if (datouser.Equals("FotoMonte"))
                    {
                        writer.Flush();
                        Console.WriteLine("FotoMonte");
                        string cmdFileSize = reader.ReadLine();
                        string cmdFileName = reader.ReadLine();
                        int length = Convert.ToInt32(cmdFileSize);
                        byte[] buffer = new byte[length];
                        int received = 0;
                        int read = 0;
                        int size = 1024;
                        int remaining = 0;
                        while (received < length)
                        {
                            remaining = length - received;
                            if (remaining < size)
                            {
                                size = remaining;
                            }

                            read = socket.GetStream().Read(buffer, received, size);
                            received += read;
                        }
                        using (FileStream fStream = new FileStream(Path.GetFileName(cmdFileName), FileMode.Create))
                        {
                            fStream.Write(buffer, 0, buffer.Length);
                            fStream.Flush();
                            fStream.Close();
                        }

                        Console.WriteLine("Foto guardada en " + Environment.CurrentDirectory);
                        writer.Flush();
                        
                    }
                    else if (datouser.Equals("FotoPlaya"))
                    {
                        writer.Flush();
                        Console.WriteLine("FotoPlaya");
                        string cmdFileSize = reader.ReadLine();
                        string cmdFileName = reader.ReadLine();
                        int length = Convert.ToInt32(cmdFileSize);
                        byte[] buffer = new byte[length];
                        int received = 0;
                        int read = 0;
                        int size = 1024;
                        int remaining = 0;
                        while (received < length)
                        {
                            remaining = length - received;
                            if (remaining < size)
                            {
                                size = remaining;
                            }

                            read = socket.GetStream().Read(buffer, received, size);
                            received += read;
                        }
                        using (FileStream fStream = new FileStream(Path.GetFileName(cmdFileName), FileMode.Create))
                        {
                            fStream.Write(buffer, 0, buffer.Length);
                            fStream.Flush();
                            fStream.Close();
                        }

                        Console.WriteLine("Foto guardada en " + Environment.CurrentDirectory);
                        writer.Flush(); ;

                    }
                    else if (datouser.Equals("FotoCiudad"))
                    {
                        writer.Flush();
                        Console.WriteLine("FotoCiudad");
                        string cmdFileSize = reader.ReadLine();
                        string cmdFileName = reader.ReadLine();
                        int length = Convert.ToInt32(cmdFileSize);
                        byte[] buffer = new byte[length];
                        int received = 0;
                        int read = 0;
                        int size = 1024;
                        int remaining = 0;
                        while (received < length)
                        {
                            remaining = length - received;
                            if (remaining < size)
                            {
                                size = remaining;
                            }

                            read = socket.GetStream().Read(buffer, received, size);
                            received += read;
                        }
                        using (FileStream fStream = new FileStream(Path.GetFileName(cmdFileName), FileMode.Create))
                        {
                            fStream.Write(buffer, 0, buffer.Length);
                            fStream.Flush();
                            fStream.Close();
                        }

                        Console.WriteLine("Foto guardada en " + Environment.CurrentDirectory);
                        writer.Flush();

                    }


                } while (true); 
                Console.WriteLine("*****************");
                Console.WriteLine("Fin de la partida.");
                Console.WriteLine("*****************");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Out.Flush();
            }

        }
        private void Cerrar()
        {
            this.socket.Close();
            this.writer.Close();    
            this.network.Close();
            this.socket.Close();
        }

       
  
    }
}
using System;
using System.IO;
using System.Net;
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
            PartidaCliente partidaCliente = new PartidaCliente();
            TCPCliente appcliente = new TCPCliente();
            string servidor = "127.0.0.1";
            Int32 port = 13000;

            appcliente.Connect(servidor, port, partidaCliente);
            appcliente.ControlDatos(partidaCliente);
            appcliente.Cerrar();

            Console.WriteLine("\n Fin del juego");
            Console.Read();
            return 0;
        }
        public TCPCliente()
        {

        }
        private void Connect(String server, Int32 port, PartidaCliente partidaC)
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
        private void ControlDatos(PartidaCliente partidaC)
        {
            string datouser = string.Empty;
            int num = int.MaxValue;
            try
            {
                //Muestra el inicio del juego
                
                Console.WriteLine(reader.ReadLine());
                datouser = Console.ReadLine();
                writer.WriteLine(datouser);
                partidaC.setNombre(datouser);
                writer.Flush();
                Console.WriteLine(reader.ReadLine());
                
                

                //Recoge la primera cifra
                writer.WriteLine(datouser);
                writer.Flush();
                
                do
                {
                    datouser = reader.ReadLine();
                    int partidas = 0;
                    if (datouser.Equals("MENU"))
                    {
                 
                        Console.WriteLine("Juega piedra papel o tijera:elige");
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("1: Jugar");
                        Console.WriteLine("2: Puntuación");
                        Console.WriteLine("3: Mostrar Resultado");
                        Console.WriteLine("-1: Salir");
                        Console.WriteLine("--------------------------------");
                        datouser = Console.ReadLine();
                        writer.WriteLine(datouser);
                        writer.Flush();

                    }
                    else if (datouser.Equals("JUGAR"))
                    {
                        writer.Flush();
                        Console.WriteLine("Escoge priedra papel o tijera");
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("1: Piedra");
                        Console.WriteLine("2: Papel");
                        Console.WriteLine("3: Tijera");
                        Console.WriteLine("--------------------------------");
                        datouser = Console.ReadLine();
                        Console.WriteLine("El numero de la jugada es " + partidaC.getJugadas());
                        partidas = partidaC.getJugadas();
                        datouser = datouser + 10 + partidaC.getNombre();
                        writer.WriteLine(datouser);
                        writer.Flush();
                        
                    }
                    else if (datouser.Equals("PUNTUACION"))
                    {
                        
                        Console.WriteLine("Has escogido puntuación");
                        string jugador1 = reader.ReadLine();
                        string jugador2 = reader.ReadLine();
                        string ganadas1 = reader.ReadLine();
                        string ganadas2 = reader.ReadLine();
                        Console.WriteLine("Jugador: " + jugador1 + ", número puntos: " + ganadas1);
                        Console.WriteLine("Jugador: " + jugador2 + ", número puntos: " + ganadas2);
                        writer.WriteLine(datouser);
                        writer.Flush();

                    }
                    else if (datouser.Contains("RESULTADO"))
                    {
                        writer.Flush();
                        string ultimoGanador = datouser.Substring(9);
                        Console.WriteLine("El ganador de la últiuma jugada ha sido: " + ultimoGanador);
                        writer.WriteLine(datouser);
                        writer.Flush();

                    }

                    else if (datouser.Equals("ACERTADO"))
                    {
                        Console.WriteLine("Has ganado!!Zorionak!");
                        writer.WriteLine(datouser);
                        writer.Flush();
                        partidaC.aumentarJugadas();

                    }
                    else if (datouser.Equals("PERDEDOR"))
                    {


                        Console.WriteLine("Has perdido");
                        writer.WriteLine(datouser);
                        writer.Flush();

                    }
                    else if (datouser.Equals("EMPATE"))
                    {

                        ++partidas;
                        Console.WriteLine("Empate");
                        writer.WriteLine(datouser);
                        writer.Flush();
                        if (partidas == partidaC.getJugadas())
                        {
                            partidaC.aumentarJugadas();
                        }

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
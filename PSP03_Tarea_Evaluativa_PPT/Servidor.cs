using System;
using System.IO;
using System.Net;
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
            Partida p = new Partida();

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
               
                Thread t = new Thread(() => appserver.ControlDatos(socketcliente, p));
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
        
        private void ControlDatos(TcpClient socket, Partida partida)
        {
  
            NetworkStream network = socket.GetStream();
            StreamWriter writer = new StreamWriter(network);
            StreamReader reader = new StreamReader(network);
            Console.WriteLine("Buffer de entrada y salida creados.");
            writer.Flush();
            int judadas = partida.getJugadasTotales();


            try
            {
                //datotratar = reader.ReadLine();


                int jugadores = partida.getJugadores();
                partida.anadirJugadores();
                if (partida.getJugadores() > 2)
                {
                    writer.WriteLine("No se permiten mas de 2 jugadores.");
                }
                else
                {


                    writer.WriteLine("Indica el nombre con el que quiere inscribirse al juego.");
                    writer.Flush();
                    datotratar = reader.ReadLine();

                    Console.WriteLine(datotratar);
                    partida.anadirNomJugador(datotratar, jugadores);
                    writer.WriteLine("La inscripción fue correcta");

                    //partida.setSituacionJugada(false);

                    while (true)
                    {
                        try
                        {

                            writer.Flush();

                            datotratar = reader.ReadLine(); //linea bloqueante
                            Console.WriteLine(datotratar);
                            if (!partida.getSituacionJugada() && !partida.getJugada().Equals("empate"))
                            {
                                Console.WriteLine("dddd");
                                //partida.setJugada("inicio");
                            }

                            if (datotratar.Equals("1"))
                            {
                                writer.WriteLine("JUGAR");


                                writer.Flush();
                                judadas = partida.getJugadasTotales();
                                partida.setJugadas(judadas++);
                                //partida.setGanador(socket.Client.Handle);
                                //break;

                            }
                            else if (datotratar.Equals("2"))
                            {
                                writer.WriteLine("PUNTUACION");

                                writer.WriteLine(partida.getnomJugadores()[0]);
                                writer.WriteLine(partida.getnomJugadores()[1]);
                                writer.WriteLine(partida.getVictorias()[0]);
                                writer.WriteLine(partida.getVictorias()[1]);
                                writer.Flush();
                                datotratar = "";
                            }

                            else if (datotratar.Equals("3"))
                            {

                                writer.WriteLine("RESULTADO" + partida.getUltimoGanador());
                                writer.Flush();
                                datotratar = "";

                            }
                            else if (datotratar.Equals("-1"))
                            {

                                writer.Close();
                                network.Close();
                                reader.Close();
                                break;

                            }
                            else if (datotratar.Contains("11"))
                            {

                                string nombre = datotratar.Substring(3);
                                string jugadaAnterior = "rr";
                                if (!partida.getJugada().Equals(""))
                                {
                                    jugadaAnterior = partida.getJugada();
                                }
                                writer.WriteLine(nombre);
                                partida.setNombre(nombre);
                                Console.WriteLine(partida.getNombre());

                                writer.Flush();

                                partida.setJugada("piedra");
                                partida.setSituacionJugada(true);


                                if (!jugadaAnterior.Equals(partida.getJugada()))
                                {
                                    while (partida.getSituacionJugada())
                                    {
                                        if (partida.getJugada().Equals("tijera"))
                                        {
                                            jugadaAnterior = "";
                                            partida.setUltimoGanador(nombre);
                                            partida.setSituacionJugada(false);
                                            partida.setJugada("");
                                            partida.anadirVictoria(jugadores);
                                            writer.WriteLine("ACERTADO");
                                        }
                                        else if (partida.getJugada().Equals("papel"))
                                        {
                                            writer.WriteLine("PERDEDOR");
                                            //partida.setJugada("piedra");
                                            nombre = partida.getNombre();
                                            partida.setJugada("");
                                            partida.setSituacionJugada(false);
                                        }


                                    }
                                    if (jugadaAnterior.Equals("papel"))
                                    {
                                        writer.WriteLine("PERDEDOR");
                                        partida.setJugada("");
                                        nombre = partida.getNombre();
                                    }
                                    else if (partida.getJugada().Equals("tijera"))
                                    {
                                        jugadaAnterior = "";
                                        partida.setUltimoGanador(nombre);
                                        partida.setJugada("");
                                        partida.setSituacionJugada(false);
                                        partida.anadirVictoria(jugadores);
                                        writer.WriteLine("ACERTADO");
                                    }
                                    else if (partida.getJugada().Equals("empate"))
                                    {
                                        partida.setJugada("");
                                        writer.WriteLine("EMPATE");
                                    }

                                }
                                else
                                {
                                    partida.setJugada("empate");
                                    writer.WriteLine("EMPATE");
                                    partida.setSituacionJugada(false);


                                }

                                datotratar = "";
                                writer.Flush();


                            }
                            else if (datotratar.Contains("21"))
                            {

                                string nombre = datotratar.Substring(3);
                                string jugadaAnterior = "rr";
                                if (!partida.getJugada().Equals(""))
                                {
                                    jugadaAnterior = partida.getJugada();
                                }
                                Console.WriteLine(partida.getNombre());
                                writer.Flush();
                                partida.setJugada("papel");
                                partida.setSituacionJugada(true);
                                Console.WriteLine(partida.getJugada());
                                if (!jugadaAnterior.Equals(partida.getJugada()))
                                {
                                    while (partida.getSituacionJugada())
                                    {
                                        if (partida.getJugada().Equals("piedra"))
                                        {
                                            jugadaAnterior = "";
                                            partida.setUltimoGanador(nombre);
                                            partida.setJugada("");
                                            partida.setSituacionJugada(false);
                                            partida.anadirVictoria(jugadores);
                                            writer.WriteLine("ACERTADO");
                                        }
                                        else if (partida.getJugada().Equals("tijera"))
                                        {
                                            writer.WriteLine("PERDEDOR");
                                            partida.setJugada("papel");
                                            nombre = partida.getNombre();
                                        }

                                    }
                                    if (jugadaAnterior.Equals("tijera"))
                                    {
                                        writer.WriteLine("PERDEDOR");
                                        partida.setJugada("");
                                        nombre = partida.getNombre();
                                    }
                                    else if (jugadaAnterior.Equals("piedra"))
                                    {
                                        jugadaAnterior = "";
                                        partida.setUltimoGanador(nombre);
                                        partida.setJugada("");
                                        partida.setSituacionJugada(false);
                                        partida.anadirVictoria(jugadores);
                                        writer.WriteLine("ACERTADO");
                                    }
                                    else if (partida.getJugada().Equals("empate"))
                                    {
                                        partida.setJugada("");
                                        writer.WriteLine("EMPATE");

                                    }

                                }
                                else
                                {
                                    partida.setJugada("empate");
                                    writer.WriteLine("EMPATE");
                                    partida.setSituacionJugada(false);


                                }



                                writer.Flush();
                                datotratar = "";

                            }
                            else if (datotratar.Contains("31"))
                            {
                                string nombre = datotratar.Substring(3);
                                string jugadaAnterior = "rr";
                                if (!partida.getJugada().Equals(""))
                                {
                                    jugadaAnterior = partida.getJugada();
                                }
                                partida.setNombre(nombre);
                                Console.WriteLine(partida.getNombre());
                                writer.Flush();
                                partida.setJugada("tijera");
                                partida.setSituacionJugada(true);

                                if (!jugadaAnterior.Equals(partida.getJugada()))
                                {

                                    while (partida.getSituacionJugada())
                                    {
                                        if (partida.getJugada().Equals("papel"))
                                        {
                                            jugadaAnterior = "";
                                            partida.setUltimoGanador(nombre);
                                            partida.setJugada("");
                                            partida.setSituacionJugada(false);
                                            partida.anadirVictoria(jugadores);
                                            writer.WriteLine("ACERTADO");

                                        }
                                        else if (partida.getJugada().Equals("piedra"))
                                        {
                                            writer.WriteLine("PERDEDOR");
                                            partida.setJugada("tijera");
                                            nombre = partida.getNombre();
                                        }
                                    }
                                    if (jugadaAnterior.Equals("piedra"))
                                    {
                                        writer.WriteLine("PERDEDOR");
                                        partida.setJugada("");
                                        nombre = partida.getNombre();
                                    }
                                    else if (partida.getJugada().Equals("papel"))
                                    {
                                        jugadaAnterior = "";
                                        partida.setUltimoGanador(nombre);
                                        partida.setJugada("");
                                        partida.setSituacionJugada(false);
                                        partida.anadirVictoria(jugadores);
                                        writer.WriteLine("ACERTADO");

                                    }
                                    else if (partida.getJugada().Equals("empate"))
                                    {
                                        writer.WriteLine("EMPATE");
                                        partida.setJugada("");

                                    }
                                }
                                else
                                {
                                    partida.setJugada("empate");
                                    writer.WriteLine("EMPATE");
                                    partida.setSituacionJugada(false);
                                }
                                writer.Flush();
                                datotratar = "";
                            }
                            else
                            {
                                writer.Flush();
                                datotratar = "";
                                writer.WriteLine("MENU");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.Out.Flush();
                        }


                    }
                    datotratar = reader.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                writer.Close();
                network.Close();
                reader.Close();
            }
           

        }


    }
}
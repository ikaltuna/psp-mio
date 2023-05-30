using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClienteMultiple
{

    public class Partida
    {
        private const int MAX_PARTICIPANTES = 2;
        public int jugadas = 0;
        public string nombre = null;
        public string jugada = "";
        public string ultimoGanador;
        public bool situacionJugada;
        private IntPtr[] participantes = null;
        public int[] victorias = new int[]{0,0};
        public int jugadores = 0;
        public string[] nomJugadores = new string[2];

        public Partida()
        {
            this.participantes = new IntPtr[MAX_PARTICIPANTES];
            for (int i = 0; i < this.participantes.Length; i++)
            {
                this.participantes[i] = IntPtr.Zero;
            }
        } 
        public int numCliente(IntPtr identificador)
        {
            for (int i = 0; i < this.participantes.Length; i++)
            {
                if (identificador.Equals(this.participantes[i]))
                {
                    return i;
                }
                else 
                {
                    return -1;
                }
            }
            return -1;
        }
        public int getJugadasTotales()
        {
            return this.jugadas;

        }
        public string[] getnomJugadores()
        {
            return this.nomJugadores;

        }
        public string getNombre()
        {
            return this.nombre;

        }
        public int getJugadores()
        {
            return this.jugadores;

        }
        public string getUltimoGanador()
        {
            return this.ultimoGanador;

        }
        public string getJugada()
        {
            return this.jugada;

        }
        public bool getSituacionJugada()
        {
            return this.situacionJugada;

        }
        public int[] getVictorias()
        {
            return this.victorias;

        }
        private int setNumAleatorio()
        {
            return new Random().Next(1, 101);
        }
        public void setJugadas(int jugadas)
        {
            this.jugadas = jugadas;
        }
        public void setSituacionJugada(bool situacionJugada)
        {
            this.situacionJugada = situacionJugada;

        }
        public void setJugada(string jugada)
        {
            this.jugada = jugada;
        }
        public void setUltimoGanador(string ultimoGanador)
        {
            this.ultimoGanador = ultimoGanador;
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public void anadirJugadores()
        {
            this.jugadores++;
        }
        public void anadirNomJugador(string nomJugadores, int jug)
        {
            this.nomJugadores[jug] = nomJugadores;
        }
        public void anadirVictoria(int jug)
        {
            this.victorias[jug]++;
        }
    }
}
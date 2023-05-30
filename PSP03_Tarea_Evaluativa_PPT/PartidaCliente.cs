using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClienteMultiple
{
    
    public class PartidaCliente
    {
        
        private int jugadas = 1;
        public string nombre = "";

        public PartidaCliente()
        {
            
        }
        public void aumentarJugadas()
        {
            this.jugadas++;
        }
        public void setNombre(string nomb)
        {
            this.nombre = nomb;
        }
        public int getJugadas()
        {
            return this.jugadas;

        }
        public string getNombre()
        {
            return this.nombre;

        }
        public void setJugadas(int jugada)
        {
            this.jugadas = jugada;

        }
       
    }
}
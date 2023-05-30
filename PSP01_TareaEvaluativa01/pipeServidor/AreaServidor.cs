//importar las librerias
using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;



//le damos nombre al paquete de soluciones
namespace pipeServidor
{
    //le damos nombre a la clase
    class AreaServidor
    {
        //comenzamos a trabajar con el método main()
        static void Main(string[] args)
        {
            //definimos un try-catch para recoger las excepciones que surgan a lo largo del método
            try
            {
                //Crear un objeto de clase NamedPipeServerStream y pasar como prámetro el nombre del Pipe "Calcula_areas", para conseguir establecer comunicación con el servidor
                var server = new NamedPipeServerStream("Calcula_areas");

                //esperar que el programa o proceso cliente contacto con el servidor con el método WaitForConnection
                server.WaitForConnection();
                Console.WriteLine("Conexión a servidor establecida.");
                Console.WriteLine("Pipe Servidor esperando datos.");

                //Crear objetos para la escritura y lectura en el buffer
                StreamReader reader = new StreamReader(server);
                StreamWriter writer = new StreamWriter(server);

                //Creamos un bucle para que el progarma esté escuchando y leyendo continuamente
                while (true)
                {
                    // Nos quedamos a la espere de lectura del buffer para que el cliente pase algún dato
                    var line = reader.ReadLine();
                    Console.WriteLine("Pipe Servidor procesando datos: '{0}'",line);

                    // Cuando recibe algo, procesamos el dato
                    float resultado = ProcesaOperdador(line);
                    writer.WriteLine(resultado.ToString());

                    // Se envía la respuesta del dato al programa cliente
                    Console.WriteLine("Pipe Servidor datos enviados: '{0}'", resultado);

                    // Borramos el buffer
                    writer.Flush();

                    // Finaliza el bucle
                }
                //Recogemos la excepción y la tratamos.
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}  Apangado servidor por error", e.Message);
            }
        }

        // Creamos un método donde se procesa el dato y nos devuelve una resouesta con el dato procesado
        // @ String operador: Se le pasa una línea del texto que está leyendo con los datos del cliente

        private static float ProcesaOperdador(string operador)
        {
            // Declaramos las variables requeridas en el método
            float resultado = 0;
            float op1;
            float op2;


            // Guardamos en un arra de String toda la línea que se recoge con un separador
            string[] datOperador = operador.Split(' ');


            // Parseamos el primer dato a un float, recogiendo así el primer operando. Si no se puede parear damos un mensaje de error
            if (!Single.TryParse(datOperador[1], out op1))
            {
                Console.WriteLine("No se puede parsear a numero el operando 1 '{0}'.", op1);
            }
            // Parseamos el segundo dato a un float, recogiendo así el segundo operando. Si no se puede parear damos un mensaje de error a no ser que sea un circulo
            if (!Single.TryParse(datOperador[2], out op2) && !"circulo".Equals(datOperador[0]))
            {
                Console.WriteLine("No se puede parsear a numero el operando 2 '{0}'.", op2);
            }

            // Dependiendo de la figura geométrica ejecutaremos la operación correspondiente mediante un if
            // Mostramos por consola la operación que se va a realizar
            if ("circulo".Equals(datOperador[0]))
            {
                Console.WriteLine("Pipe Servidor operación: '{0} del circulo con radio {1}'", op1, datOperador[0], op2);
                resultado = (float)Math.PI  * op1 * op1;

            }
            else if ("triangulo".Equals(datOperador[0]))
            {
                Console.WriteLine("Pipe Servidor operación: '{0} con base {1} y altura {2}'", op1, datOperador[0], op2);
                resultado = (op1 * op2) / 2;

            }
            else if ("rectangulo".Equals(datOperador[0]))
            {
                Console.WriteLine("Pipe Servidor operación: '{0} con base {1} y altura {2}'", op1, datOperador[0], op2);
                resultado = op1 * op2;
            }
            else if ("pentagono".Equals(datOperador[0]))
            {
                Console.WriteLine("Pipe Servidor operación: '{0} lado {1} y apotema {2}'", op1, datOperador[0], op2);
                resultado = ((op1*5)*op2)/2;
            }


            // El método devuelve el resultado de la operacion al main
            return resultado;
        }
    }
}

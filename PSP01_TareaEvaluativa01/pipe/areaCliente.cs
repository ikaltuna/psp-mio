// Importar las librerias
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

// Nombrar la libreria
namespace pipe
{
    // Nombrar la clase
    class areaCliente
    {
      
        //Método principal
        static void Main(string[] args)
        {
            // Declarar un objeto de tipo process
            Process p;

            // Llamada a método donde lanza el proceso servidor para su comunicación y posterior proceso de datos
            StartServer(out p);

            // Se deja un tiempo de espera, tiempo prudencial de espera antes de hacer cualquier cálculo
            Task.Delay(1000).Wait();
            string operacion;

            // Preparar conexion del cliente
            // Creación de objeto NamedPipeClientStream para la creación del pipe de tipo nombte
            var client = new NamedPipeClientStream("Calcula_areas");
            client.Connect();
            StreamReader reader = new StreamReader(client);
            StreamWriter writer = new StreamWriter(client);

            while (true)
            {
                // Inialización de variable para el envio de información al servidor
                operacion = "";
                PintarMenu(ref operacion);

                // Operación donde se solicira la información  de operandos y tipo de operación a realizar
                if (operacion != null)
                {
                    if ("E".Equals(operacion))
                    {
                        // Salir del while (true)
                        break;
                    }
                    // Envío de información del string mediante el buffer
                    writer.WriteLine(operacion);
                    writer.Flush();
                    // Recepción de información desde el servidor y puvlicacion en consola
                    Console.WriteLine("Resultado: {0} cm^2", reader.ReadLine());
                }
            }
            //Parar pipes
            if (p != null && !p.HasExited)
            {
                p.Kill();
                p = null;
            }
        }
        
        // Método donde se lanza el proceso 
        // @p1: devuelve un parámetro de tipo Process para su futura gestion
        static Process StartServer(out Process p1)
        {
            // lanza el proceso del programa AreaServidor
            // Se crea un objeto de tipo ProcessStartInfo donde se guarda la información  de la ubicacioón del fichero .exe desde el cual se va a ejecutar el procesp
            ProcessStartInfo info = new ProcessStartInfo(@"C:\Users\Iker\source\repos\PSP2022_2023\PSP01\PSP01_TA02\PSP01_Calculadora_Entrega\PSP01_TareaEvaluativa01\pipeServidor\bin\Release\netcoreapp3.1\publish\win-x64\areasServidor.exe");
            
            // Se guarda informacion sobre la ventana consola que se lanza cuando se lanza el proceso
            // su valor por defecto el false, si se establece a true no se "crea" ventana
            info.CreateNoWindow = false;
            info.WindowStyle = ProcessWindowStyle.Normal;
            // indica si se utiliza el cmd para lanzar el proceso
            info.UseShellExecute = true;
            p1 = Process.Start(info);
            return p1;
        }

        // Muestra en consola la información del menú
        // @operación: devuelvee al main() la informacion de "operacion´operando1 operando2"
        private static void PintarMenu(ref string operacion)
        {
            Console.WriteLine("Area que desea calcular:");
            Console.WriteLine(" 1 - Circulo");
            Console.WriteLine(" 2 - Triangulo");
            Console.WriteLine(" 3 - Rectangulo");
            Console.WriteLine(" 4 - Pentagono");
            Console.WriteLine(" (-1) Salir");
            Console.Write("Introduzca la operación: ");
            //lectura de teclado
            string input = Console.ReadLine();
            //Llamada a método ValidaOperacion
            bool ret = ValidaOperacion(input, ref operacion);//, out op);
        }
        // Añade al signo de la operación los operando requeridos para la operación
        private static bool ValidaOperacion(string cadenaIn, ref string operacion)
        {
            int opcion;
            //Recoge el string de la operación a realizar
            //Controla si el dato es un dato valido
            if (!Int32.TryParse(cadenaIn, out int op))
            {
                Console.WriteLine("Opción {0} no válida.", op);
                //opcion = op;
                operacion = null;
                return false;
            } else
            {
                // Dependiendo de lo seleccionado por el usuario se guarda al comienzo de un Strinf el signo de la operación
                opcion = op;
            }
            // Se realiza una llamada al método IntroducirOperandos
            switch (opcion)
            {
                case 1: // Circulo
                    operacion = operacion + "circulo ";
                    IntroducirOperandos(ref operacion);
                    break;
                
                case 2: // Triangulo
                    operacion = operacion + "triangulo ";
                    IntroducirOperandos(ref operacion);
                    break;

                case 3: // Rectangulo
                    operacion = operacion + "rectangulo ";
                    IntroducirOperandos(ref operacion);
                    break;
                case 4: // Pentagono
                    operacion = operacion + "pentagono ";
                    IntroducirOperandos(ref operacion);
                    break;
                case -1: // Salir
                    operacion = operacion + "E";
                    Console.WriteLine("Exit");
                break;

                default: // Error de opcion
                    Console.WriteLine("Opción {0} no válida.", op);
                    operacion = null;
                break;

            }
            return false;
        }

        private static bool IntroducirOperandos(ref string operacion)
        {
            // Declaramos las variables requeridas en el método
            string input = null;
            string input2 = null;

            // Se separan por el metodo if para dar distinto mensaje
            // Se solicita los operandos al usuario y se guardan los operandos separados de un espacio en la variable de tipo string denominada operación
            // Si todo ha ido según lo previsto devolverá un booleano = true


            if ("circulo ".Equals(operacion))
            {
                Console.Write("Introduce en cm el area del circulo :");
                input = Console.ReadLine();
            }
            else if ("triangulo ".Equals(operacion))
            {
                Console.Write("Introduce en cm la base del triangulo :");
                input = Console.ReadLine();
                Console.Write("Introduce en cm la altura del triangulo :");
                input2 = Console.ReadLine();

            }
            else if ("rectangulo ".Equals(operacion))
            {
                Console.Write("Introduce en cm la base del rectangulo :");
                input = Console.ReadLine();
                Console.Write("Introduce en cm la altura del rectangulo :");
                input2 = Console.ReadLine();

            }
            else if ("pentagono ".Equals(operacion))
            {
                Console.Write("Introduce en cm la perimetro del pentagono :");
                input = Console.ReadLine();
                Console.Write("Introduce en cm la apotema del pentagono :");
                input2 = Console.ReadLine();

            }

            // Comprueba el priner operando
            else if (!Single.TryParse(input, out float op))
            {
                Console.WriteLine("El primer operando NO es un número");
                operacion = null;
                return false;
            }
            // Comprueba el segundo operando, si no es circulo
            else if (!Single.TryParse(input2, out float op2) && !"circulo ".Equals(operacion))
            {
               Console.WriteLine("El segundo operando NO es un número");
                // Realiza operacion
                operacion = null;
                // Devuelve operacion
                return false;
            }

            operacion = operacion + input + " " + input2;
            return true;
        }
    }
}

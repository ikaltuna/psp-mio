using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;


namespace consumerProducer
{
    class Program
    {
        static void Main(string[] args)
        {

            BlockingCollection<int> almacenPrincipal = new BlockingCollection<int>(100);
            BlockingCollection<int> almacenSecundario = new BlockingCollection<int>(100);
            bool AnadirElemento = true;
            int cantAlmacen = 0;


            Task consumidorAmara = Task.Run(() =>
            {
                while (AnadirElemento) 
                {

                    int data = -1;

                    try
                    {

                        data = almacenPrincipal.Take();

                        
                    }

                    catch (InvalidOperationException) { }

                    
                    if (data != -1)
                    {
                        Console.WriteLine("Un usuario en la zona Amara ha alquilado la bicicleta{0}", data);
                    }

                }


                    Console.WriteLine("En zona Amara no hay más bicis en el almacén");
            });
            Task consumidorGros = Task.Run(() =>
            {
                while (AnadirElemento) 
                {
                    
                    int data = -1;


                    try
                    {

                        data = almacenPrincipal.Take();


                    }

                    catch (InvalidOperationException) { }

                    if (data != -1)
                    {
                        Console.WriteLine("Un usuario en la zona Gros ha alquilado la bicicleta{0}", data);
                    }

                    if ((data % 3) == 0 && data != -1)
                    {
                        Console.WriteLine("Un usuario en la zona Gros ha devuelto la bicicleta{0}", data);
                        try
                        {
                            almacenPrincipal.Add(data);
                        }
                        catch (InvalidOperationException) { }
                    }
                    

                }
                while (!almacenPrincipal.IsCompleted && !AnadirElemento)
                {
                    int data = -1;
                    Console.WriteLine("El almacén principal está completo, se depositarán las bicis en el secundario");

                    try
                    {

                        data = almacenPrincipal.Take();


                    }

                    catch (InvalidOperationException) { }
                    if (data != -1)
                    {
                        Console.WriteLine("Un usuario en la zona Gros ha alquilado la bicicleta{0}", data);
                    }
                    if ((data % 3) == 0 && data != -1)
                    {
                        Console.WriteLine("Un usuario en la zona Gros ha devuelto la bicicleta{0} al segundo almacén", data);
                        cantAlmacen++;
                        try
                        {
                            almacenSecundario.Add(data);
                           
                        }
                        catch (InvalidOperationException) { }
                    }

                }

                Console.WriteLine("En zona Gros no hay más bicis en el almacén");
            });

            Task productor = Task.Run(() =>
            {
                int data = 0;
                

                while (AnadirElemento)
                {

                    almacenPrincipal.Add(data);
                    Console.WriteLine("La empresa de bicis ha comprado la bicicleta {0} y la tiene en el almacén principal.", data);

                    data++;

                    if (data == 200)
                    {

                        Console.WriteLine("Cierre de almacén, nadie podrá depositar bicicletas en dicho almacen");
                        AnadirElemento = false;
                    }

                }
                // La colección no va a aceptar más elementos
                almacenPrincipal.CompleteAdding();
                

            });


            consumidorAmara.Wait();
            consumidorGros.Wait();
            productor.Wait();
            Console.WriteLine("El stock sobrante es " +  cantAlmacen + " bicis.");
        }
        
    }
}
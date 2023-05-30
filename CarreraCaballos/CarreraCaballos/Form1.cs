using System;
using System.Runtime.CompilerServices;

namespace CarreraCaballos
{
    public partial class Form1 : Form
    {

        static int[] ArrayCaballos = { 0, 0, 0, 0 };
        static Boolean acaba = false;

        public Form1()
        {
            InitializeComponent();

        }

        private void empezar_Click(object sender, EventArgs e)
        {
            Thread empezarCarrera = new Thread(carrera); // Encargado de escribir números en la cola

            
            empezarCarrera.Start();
            while (!acaba)
            {
                progressBar1.Value = ArrayCaballos[0];
                progressBar2.Value = ArrayCaballos[1];
                progressBar3.Value = ArrayCaballos[2];
                progressBar4.Value = ArrayCaballos[3];
            }

            if (acaba)
            {
                
                if (ArrayCaballos[0] == 100)
                {
                    resultado.Text = "Ganador: Caballo1";
                    progressBar1.Value = ArrayCaballos[0];
                }
                if (ArrayCaballos[1] == 100)
                {
                    resultado.Text = "Ganador: Caballo2";
                    progressBar2.Value = ArrayCaballos[1];
                }
                if (ArrayCaballos[2] == 100)
                {
                    resultado.Text = "Ganador: Caballo3";
                    progressBar3.Value = ArrayCaballos[2];
                }
                if (ArrayCaballos[3] == 100)
                {
                    resultado.Text = "Ganador: Caballo4";
                    progressBar4.Value = ArrayCaballos[3];
                }
                resultadoCaballo1.Text = "Caballo1:" + ArrayCaballos[0];
                resultadoCaballo2.Text = "Caballo2:" + ArrayCaballos[1];
                resultadoCaballo3.Text = "Caballo3:" + ArrayCaballos[2];
                resultadoCaballo4.Text = "Caballo4:" + ArrayCaballos[3];

            }



        }
        public static void carrera()
        {
            Thread caballo1 = new Thread(AvanceCaballos);
            Thread caballo2 = new Thread(AvanceCaballos);
            Thread caballo3 = new Thread(AvanceCaballos);
            Thread caballo4 = new Thread(AvanceCaballos);
            caballo1.Name = "1";
            caballo2.Name = "2";
            caballo3.Name = "3";
            caballo4.Name = "4";
            caballo1.Priority = ThreadPriority.AboveNormal;
            caballo2.Priority = ThreadPriority.Highest;
            caballo3.Priority = ThreadPriority.Normal;
            caballo4.Priority = ThreadPriority.BelowNormal;
            caballo1.Start();
            caballo2.Start();
            caballo3.Start();
            caballo4.Start();


        }
        public static void AvanceCaballos()
        {



            while (!acaba)
            {
                int NArray = Int32.Parse(Thread.CurrentThread.Name) - 1;
                {
                    Random Mavanzados = new Random();

                    int avanzar = Mavanzados.Next(0, 11);

                    if (ArrayCaballos[NArray] + avanzar < 100)
                    {
                        ArrayCaballos[NArray] = ArrayCaballos[NArray] + avanzar;
                    }
                    if (ArrayCaballos[NArray] + avanzar >= 100)
                    {
                        ArrayCaballos[NArray] = 100;
                        acaba= true;
                    }
                    Thread.Sleep(300);

                }
              
            }





        }

        private void reiniciar_Click(object sender, EventArgs e)
        {
            acaba = false;
            resultado.Text = "Resultado";
            resultadoCaballo1.Text = " ";
            resultadoCaballo2.Text = " ";
            resultadoCaballo3.Text = " ";
            resultadoCaballo4.Text = " ";
            ArrayCaballos[0] = 0;
            ArrayCaballos[1] = 0;
            ArrayCaballos[2] = 0;
            ArrayCaballos[3] = 0;
            progressBar1.Value = ArrayCaballos[0];
            progressBar2.Value = ArrayCaballos[1];
            progressBar3.Value = ArrayCaballos[2];
            progressBar4.Value = ArrayCaballos[3];

        }
    }
}
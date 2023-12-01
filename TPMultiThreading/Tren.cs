using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace TPMultiThreading
{
    public class Tren
    {
        public int Numero { get; set; }
        public int CapacidadActual { get; set; }
        public int Velocidad { get; set; }
        public string Estado { get; set; }
        public Direccion Direccion = Direccion.IDA;
        public bool Espera;
        public IEstacion EstacionActual { get; set; }

        public Label lTrenNombre;
        public Label lNumeroTren;
        public Label lNumeroEstacionActual;
        public Label lDestino;
        public Label lEstado;
        public Label lCapacidadActual;

        private static readonly object Locker = new object();

        public void Inicio()
        {
            Central.ActualizoMapa(this);
            Proceso();
        }

        public void Proceso()
        {
            while (true)
            {
                CargaPersonas();
                VoyProximaEstacion();
            }
        }

        private void CargaPersonas()
        {
            Thread.Sleep(Velocidad);

        }

        public void Reporte(string status)
        {
            Estado = status;
            Central.ActualizarEstado(this);
        }

        private void VoyProximaEstacion()
        {
            
            lock (Locker)
            {
                var ProximaEstacion = EstacionActual.ObtenerEstacionProxima().ObtenerNombre();
                Reporte("Comprobando disponibilidad de " + ProximaEstacion);
                while (!EstacionActual.ProximaEstacionDisponible(Direccion))
                {
                    Espera = true;
                    lEstado.ForeColor = Color.Red;
                    Reporte(ProximaEstacion + " se encuentra ocupada. Aguarde a que se encuentre disponile");
                    Monitor.Wait(Locker, ObtenerTiempoEspera());
                    lEstado.ForeColor = Color.DarkGreen;
                }

                Reporte("Luz verde para " + ProximaEstacion);
                lEstado.ForeColor = Color.Black;
                Espera = false;

                if (EstacionActual.ProximaEstacionDisponible(Direccion))
                {
                    Reporte("Tren esperando luz verde");
                    Monitor.PulseAll(Locker);
                }

                Reporte("Partiendo de la estacion " + EstacionActual.ObtenerNombre());
                EstacionActual.Partir(this);
                Central.ActualizoMapa(this);
            }
        }

       
      
        private int ObtenerTiempoEspera()
        {
            var normalizedTime = (decimal)CapacidadActual / 100;
            return (int)normalizedTime * 5000;
        }
    }
}

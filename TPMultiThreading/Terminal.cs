using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace TPMultiThreading
{
    public class Terminal : IEstacion
    {
        public string Nombre { get; set; }

        public List<Tren> andenes = new List<Tren>();
        public IEstacion EstacionAnterior { get; set; }
        public IEstacion EstacionProxima { get; set; }
        public Point Ubicacion { get; set; }

        private int trenesMaximos = 5;

        public Terminal(int nroAndenes)
        {
            trenesMaximos = nroAndenes;
        }
        public void Arribar(Tren tren)
        {
            andenes.Add(tren);
            tren.CurrentStation = this;
        }

        public bool EstaDisponible(Direccion direccion)
        {
            return andenes.Count < trenesMaximos;
        }

        public void Partir(Tren tren)
        {
            andenes.Remove(tren);

            // Le cambiamos la direccion al tren.
            if (EstacionProxima == null)
            {
                tren.Direccion = Direccion.VUELTA;
                EstacionAnterior.Arribar(tren);
                tren.TrainName.ForeColor = Color.Green;
            }
            else
            {
                tren.Direccion = Direccion.IDA;
                EstacionProxima.Arribar(tren);
                tren.TrainName.ForeColor = Color.Yellow;
            }
        }

        public void SetearEstacionAnterior(IEstacion estacion)
        {
            EstacionAnterior = estacion;
        }

        public void SetearEstacionProxima(IEstacion estacion)
        {
            EstacionProxima = estacion;
        }

        public bool ProximaEstacionDisponible(Direccion direccion)
        {
            // Estamos en la ultima estacion y necesistamos verificar
            // la estacion anterior en el sentido opuesto
            if (EstacionProxima == null) return EstacionAnterior.EstaDisponible(Direccion.VUELTA);
            // Estamos en la primera estación y necesitamos verificar la proxima estación
            else return EstacionProxima.EstaDisponible(Direccion.IDA);
        }

        public Point ObtenerCoordenadas(Tren tren)
        {
            if (Nombre == "Retiro")
            {
                var nroAnden = andenes.IndexOf(tren) + 1;
                var nuevaUbicacion = new Point(Ubicacion.X - 50, (16 + (nroAnden * 47)));
                //(Ubicacion.Y + (nroAnden * 50)));
                return nuevaUbicacion;
            }

            if (tren.Direccion == Direccion.VUELTA)
            {
                return new Point(Ubicacion.X, Ubicacion.Y + 55);
            }
            return Ubicacion;

        }
        public IEstacion ObtenerEstacionProxima()
        {
            if (Nombre == "Retiro")
            {
                return EstacionProxima;
            }
            return EstacionAnterior;
        }
        public IEstacion ObtenerEstacionAnterior()
        {
            if (Nombre == "Retiro")
            {
                return EstacionProxima;
            }
            return EstacionAnterior;

        }

        public string ObtenerNombre()
        {
            return Nombre;
        }
    }
}

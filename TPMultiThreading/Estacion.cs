using System.Drawing;

namespace TPMultiThreading
{
    public class Estacion : IEstacion
    {
        public string Nombre { get; set; }
        public Tren AndenIda { get; set; }
        public Tren AndenVuelta { get; set; }
        public IEstacion EstacionAnterior { get; set; }
        public IEstacion EstacionProxima { get; set; }
        public Point Ubicacion { get; set; }

        public bool EstaDisponible(Direccion direccion)
        {
            var trenEnAnden = direccion == Direccion.IDA ? AndenIda : AndenVuelta;
            return trenEnAnden == null;
        }

        public void Arribar(Tren tren)
        {
            if (tren.Direccion == Direccion.IDA) AndenIda = tren;
            else AndenVuelta = tren;
            tren.EstacionActual = this;
        }

        public void Partir(Tren tren)
        {         
            if (tren.Direccion == Direccion.IDA)
            {
                AndenIda = null;
                EstacionProxima.Arribar(tren);
            }
            else
            {
                AndenVuelta = null;
                EstacionAnterior.Arribar(tren);
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
            if (direccion == Direccion.IDA) return EstacionProxima.EstaDisponible(direccion);
            else return EstacionAnterior.EstaDisponible(direccion);
        }

        public Point ObtenerCoordenadas(Tren tren)
        {
            if (tren.Direccion == Direccion.VUELTA)
            {
                return new Point(Ubicacion.X, Ubicacion.Y + 55);
            }
            return Ubicacion;
        }

        public IEstacion ObtenerEstacionProxima()
        {
           if (EstacionProxima != null)
            {
                return EstacionProxima;
            }
            return EstacionAnterior;
        }

        public IEstacion ObtenerEstacionAnterior()
        {
            if (EstacionProxima == null)
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

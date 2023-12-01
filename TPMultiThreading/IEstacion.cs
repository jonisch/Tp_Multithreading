using System.Drawing;

namespace TPMultiThreading
{
    public interface IEstacion
    {
        bool EstaDisponible(Direccion direccion);
        void Arribar(Tren tren);
        void Partir(Tren tren);

        void SetearEstacionAnterior(IEstacion estacion);
        void SetearEstacionProxima(IEstacion estacion);
        bool ProximaEstacionDisponible(Direccion direccion);
        Point ObtenerCoordenadas(Tren tren);
        IEstacion ObtenerEstacionProxima();
        IEstacion ObtenerEstacionAnterior();
        string ObtenerNombre();
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace TPMultiThreading
{
    public class Central
    {
        public List<IEstacion> Estaciones = new List<IEstacion>();
        private static readonly Queue<Tren> _trainDeposit = new Queue<Tren>();
        private static readonly List<Tren> _activeTrains = new List<Tren>();
        public static readonly object Locker = new object();

        public Central()
        {
            var listaEstaciones = new List<string>
            {
                "Retiro",
                "3 de Febrero",
                "Carranza",
                "Colegiales",
                "Belgrano R.",
                "Drago",
                "Urquiza",
                "Pueyrredón",
                "Miguelete",
                "San Martin",
                "San Andrés",
                "Malaver",
                "Villa Ballester",
                "Chilavert",
                "José León Suarez"
            };

            for (var i = 0; i < listaEstaciones.Count; i++)
            {
                var ubicacionEstacion = new Point(180, 130);
                ubicacionEstacion.X += (62 * i);

                IEstacion tempEstacion;
                if (listaEstaciones[i] == "Retiro" || listaEstaciones[i] == "José León Suarez")
                {
                    var nroAndenes = listaEstaciones[i] == "Retiro" ? 5 : 2;
                    tempEstacion = new Terminal(nroAndenes)
                    {
                        Nombre = listaEstaciones[i],
                        Ubicacion = ubicacionEstacion
                    };
                }
                else
                {
                    tempEstacion = new Estacion
                    {
                        Nombre = listaEstaciones[i],
                        AndenVuelta = null,
                        Ubicacion = ubicacionEstacion
                    };
                }

                if (Estaciones.ElementAtOrDefault(i - 1) != null)
                {
                    tempEstacion.SetearEstacionAnterior(Estaciones[i-1]);
                    Estaciones[i - 1].SetearEstacionProxima(tempEstacion);
                }

                Estaciones.Add(tempEstacion);
            }

            var depositMonitor = new Thread(DepositMonitor);
            depositMonitor.Start();

            var dispatcher = new Thread(Dispatcher);
            dispatcher.Start();
        }

        public void AddTrain(Tren train)
        {
            lock (Locker)
            {
                _trainDeposit.Enqueue(train);
                Monitor.Pulse(Locker);
            }
        }

        private void Dispatcher()
        {
            lock (Locker)
            {
                Monitor.Wait(Locker);
                var tren = _trainDeposit.Dequeue();
                _activeTrains.Add(tren);
                tren.EstacionActual = Estaciones[0];
                tren.Numero = _activeTrains.Count;
                tren.lTrenNombre.Invoke(new Action(() => tren.lTrenNombre.Text = "Tren #" + tren.Numero.ToString()));



                Estaciones[0].Arribar(tren);

                var thr = new Thread(tren.Inicio);
                thr.Start();

                Monitor.Pulse(Locker);
                Dispatcher();
            }
        }

        private void DepositMonitor()
        {
            while (true)
            {
                lock (Locker)
                {
                    if (!_trainDeposit.Any() || Estaciones[0].EstaDisponible(Direccion.IDA))
                    {
                        continue;
                    }
                    Monitor.Pulse(Locker);
                    Monitor.Wait(Locker);
                }
            }
        }

        public static void ActualizarEstado(Tren tren)
        {
            tren.lNumeroTren.Invoke(new Action(() => tren.lNumeroTren.Text = tren.Numero.ToString()));
            tren.lNumeroEstacionActual.Invoke(new Action(() => tren.lNumeroEstacionActual.Text = tren.EstacionActual.ObtenerNombre()));
            tren.lEstado.Invoke(new Action(() => tren.lEstado.Text = tren.Estado));


            var destino = tren.Direccion == Direccion.IDA
                ? tren.EstacionActual.ObtenerEstacionProxima().ObtenerNombre()
                : tren.EstacionActual.ObtenerEstacionAnterior().ObtenerNombre();

            switch (destino)
            {
                case null when tren.Direccion == Direccion.IDA:
                    destino = tren.EstacionActual.ObtenerEstacionAnterior().ObtenerNombre();
                    break;
                case null when tren.Direccion == Direccion.VUELTA:
                    destino = tren.EstacionActual.ObtenerEstacionProxima().ObtenerNombre();
                    break;
            }
            tren.lDestino.Invoke(new Action(() => tren.lDestino.Text = destino));
        }


        public static void ActualizoMapa(Tren train)
        {
            var lblPos = train.EstacionActual.ObtenerCoordenadas(train);
            train.lTrenNombre.Invoke(new Action(() => train.lTrenNombre.Visible = true));
            train.lTrenNombre.Invoke(new Action(() => train.lTrenNombre.Location = lblPos));
        }
    }
}

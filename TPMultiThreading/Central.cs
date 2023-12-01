using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace TPMultiThreading
{
    public class Central
    {
        public List<IEstacion> Stations = new List<IEstacion>();
        private static readonly Queue<Tren> _trainDeposit = new Queue<Tren>();
        private static readonly List<Tren> _activeTrains = new List<Tren>();
        public static readonly object Locker = new object();

        public Central()
        {
            var stationList = new List<string>
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

            for (var i = 0; i < stationList.Count; i++)
            {
                //var stationLocation = new Point(105, 130);
                var stationLocation = new Point(160, 130);
                stationLocation.X += (62*i);

                IEstacion tempStation;                  
                if (stationList[i] == "Retiro" || stationList[i] == "José León Suarez")
                {
                    var nroAndenes = stationList[i] == "Retiro" ? 5 : 2;
                    tempStation = new Terminal(nroAndenes)
                    {
                        Nombre = stationList[i],
                        Ubicacion = stationLocation
                    };
                }
                else
                {
                    tempStation = new Estacion
                    {
                        Nombre = stationList[i],
                        AndenVuelta = null,
                        Ubicacion = stationLocation
                    };
                }

                if (Stations.ElementAtOrDefault(i - 1) != null)
                {
                    tempStation.SetearEstacionAnterior(Stations[i - 1]);
                    Stations[i - 1].SetearEstacionProxima(tempStation);
                }

                Stations.Add(tempStation);
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
                var train = _trainDeposit.Dequeue();
                _activeTrains.Add(train);
                train.EstacionActual = Stations[0];
                train.Numero = _activeTrains.Count;
                train.lTrenNombre.Invoke(new Action(() => train.lTrenNombre.Text = "Train #" + train.Numero.ToString()));
               
                
                
                Stations[0].Arribar(train);

                var thr = new Thread(train.Inicio);
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
                    if (!_trainDeposit.Any() || Stations[0].EstaDisponible(Direccion.IDA))
                    {
                        continue;
                    }
                    Monitor.Pulse(Locker);
                    Monitor.Wait(Locker);
                }
            }
        }

        public static void ActualizarEstado(Tren train)
        {
            train.lNumeroTren.Invoke(new Action(() => train.lNumeroTren.Text = train.Numero.ToString()));
            train.lNumeroEstacionActual.Invoke(new Action(() => train.lNumeroEstacionActual.Text = train.EstacionActual.ObtenerNombre()));
            train.lEstado.Invoke(new Action(() => train.lEstado.Text = train.Estado));


            var destination = train.Direccion == Direccion.IDA
                ? train.EstacionActual.ObtenerEstacionProxima().ObtenerNombre()
                : train.EstacionActual.ObtenerEstacionAnterior().ObtenerNombre();

            switch (destination)
            {
                case null when train.Direccion == Direccion.IDA:
                    destination = train.EstacionActual.ObtenerEstacionAnterior().ObtenerNombre();
                    break;
                case null when train.Direccion == Direccion.VUELTA:
                    destination = train.EstacionActual.ObtenerEstacionProxima().ObtenerNombre();
                    break;
            }
            train.lDestino.Invoke(new Action(() => train.lDestino.Text = destination));
        }


        public static void ActualizoMapa(Tren train)
        {
            var lblPos = train.EstacionActual.ObtenerCoordenadas(train);
            train.lTrenNombre.Invoke(new Action(() => train.lTrenNombre.Visible = true));
            train.lTrenNombre.Invoke(new Action(() => train.lTrenNombre.Location = lblPos));
        }
    }
}

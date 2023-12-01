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
                train.CurrentStation = Stations[0];
                train.Number = _activeTrains.Count;
                train.TrainName.Invoke(new Action(() => train.TrainName.Text = "Train #" + train.Number.ToString()));
               
                
                
                Stations[0].Arribar(train);

                var thr = new Thread(train.Start);
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

        public static void UpdateStatus(Tren train)
        {
            train.LabelNumber.Invoke(new Action(() => train.LabelNumber.Text = train.Number.ToString()));
            train.LabelCurrentStation.Invoke(new Action(() => train.LabelCurrentStation.Text = train.CurrentStation.ObtenerNombre()));
            train.LabelStatus.Invoke(new Action(() => train.LabelStatus.Text = train.Status));


            var destination = train.Direccion == Direccion.IDA
                ? train.CurrentStation.ObtenerEstacionProxima().ObtenerNombre()
                : train.CurrentStation.ObtenerEstacionAnterior().ObtenerNombre();

            switch (destination)
            {
                case null when train.Direccion == Direccion.IDA:
                    destination = train.CurrentStation.ObtenerEstacionAnterior().ObtenerNombre();
                    break;
                case null when train.Direccion == Direccion.VUELTA:
                    destination = train.CurrentStation.ObtenerEstacionProxima().ObtenerNombre();
                    break;
            }
            train.LabelDestination.Invoke(new Action(() => train.LabelDestination.Text = destination));
        }


        public static void UpdateMap(Tren train)
        {
            var lblPos = train.CurrentStation.ObtenerCoordenadas(train);
            train.TrainName.Invoke(new Action(() => train.TrainName.Visible = true));
            train.TrainName.Invoke(new Action(() => train.TrainName.Location = lblPos));
        }
    }
}

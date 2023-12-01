using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace TPMultiThreading
{
    public class Tren
    {
        public int Number { get; set; }
        public int CurrentCapacity { get; set; }
        public int Speed { get; set; }
        public string Status { get; set; }
        public Direccion Direccion = Direccion.IDA;
        public bool Waiting;
        public IEstacion CurrentStation { get; set; }

        public Label TrainName;
        public Label LabelNumber;
        public Label LabelCurrentStation;
        public Label LabelDestination;
        public Label LabelStatus;
        public Label LabelCurrentCapacity;

        private static readonly object Locker = new object();

        public void Start()
        {
            Central.UpdateMap(this);
            Process();
        }

        public void Process()
        {
            while (true)
            {
                LoadPeople();
                GoNextStation();
            }
        }

        private void LoadPeople()
        {
            Thread.Sleep(Speed);

        }

        public void Report(string status)
        {
            Status = status;
            Central.UpdateStatus(this);
        }

        private void GoNextStation()
        {
            
            lock (Locker)
            {
                var ProximaEstacion = CurrentStation.ObtenerEstacionProxima().ObtenerNombre();
                Report("Checking availability for " + ProximaEstacion);
                while (!CurrentStation.ProximaEstacionDisponible(Direccion))
                {
                    Waiting = true;
                    LabelStatus.ForeColor = Color.Red;
                    Report(ProximaEstacion + " is busy. Waiting for it to be available");
                    Monitor.Wait(Locker, ObtenerTiempoEspera());
                    LabelStatus.ForeColor = Color.DarkGreen;
                }

                Report("Greenlighted for " + ProximaEstacion);
                LabelStatus.ForeColor = Color.Black;
                Waiting = false;

                if (CurrentStation.ProximaEstacionDisponible(Direccion))
                {
                    Report("Greenlighting waiting train");
                    Monitor.PulseAll(Locker);
                }

                Report("Leaving station " + CurrentStation.ObtenerNombre());
                CurrentStation.Partir(this);
                Central.UpdateMap(this);
            }
        }

       
      
        private int ObtenerTiempoEspera()
        {
            var normalizedTime = (decimal)CurrentCapacity / 100;
            return (int)normalizedTime * 5000;
        }
    }
}

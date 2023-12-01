using System;
using System.Drawing;
using System.Windows.Forms;

namespace TPMultiThreading
{
    public partial class Main : Form
    {
        private Central _central;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _central = new Central();
        }

        private void BtnAddTrain_Click(object sender, EventArgs e)
        {
            var newTrain = new Tren
            {
                Velocidad = (int)numSpeed.Value,
                lTrenNombre = GetMapLabel(),
                lNumeroTren = new Label { AutoSize = true },
                lNumeroEstacionActual = new Label { AutoSize = true },
                lDestino = new Label { AutoSize = true },
                lEstado = new Label { AutoSize = true },
                lCapacidadActual = new Label { AutoSize = true }
            };

            tableActiveTrains.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableActiveTrains.Controls.Add(newTrain.lNumeroTren);
            tableActiveTrains.Controls.Add(newTrain.lNumeroEstacionActual);
            tableActiveTrains.Controls.Add(newTrain.lDestino);
            tableActiveTrains.Controls.Add(newTrain.lEstado);
            tableActiveTrains.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            _central.AddTrain(newTrain);
        }

        private Label GetMapLabel()
        {
            return new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Parent = picMap,
                Visible = false
            };
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

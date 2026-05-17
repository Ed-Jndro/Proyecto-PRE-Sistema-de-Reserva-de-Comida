using System.IO;
namespace Sistema_de_Reserva_de_comida
{
    public partial class Form1 : Form
    {
        // VARIABLES Y ARREGLOS

        string[] nombres = new string[10];
        string[] asientos = new string[10];
        string[] reservas = new string[10];
        double[] preciosReserva = new double[10];

        string[] comidas =
        {
            "Pollo",
            "Carne",
            "Vegetariano",
            "Pasta",
            "Ensalada"
        };

        double[] precios =
        {
            8.50,
            10.00,
            7.25,
            9.50,
            6.75
        };

        int contador = 0;
        double totalGeneral = 0;

        string archivo = "reservas.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < comidas.Length; i++)
            {
                cmbcomidas.Items.Add(
                    comidas[i] + " - $" + precios[i]
                );
            }

            CargarReservasArchivo();
        }
        void CargarReservasArchivo()
        {
            if (!File.Exists(archivo))
            {
                return;
            }

            StreamReader reader = new StreamReader(archivo);

            string linea;

            while ((linea = reader.ReadLine()) != null)
            {
                string[] datos = linea.Split('|');

                nombres[contador] = datos[0];
                asientos[contador] = datos[1];
                reservas[contador] = datos[2];
                preciosReserva[contador] = double.Parse(datos[3]);

                totalGeneral += preciosReserva[contador];

                contador++;
            }

            reader.Close();
        }
        void CrearReserva()
        {
            if (contador >= 10)
            {
                MessageBox.Show("No hay espacio para más reservas.");
                return;
            }

            string nombre = txtnombre.Text;
            string asiento = txtasiento.Text;

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingrese un nombre.");
                return;
            }

            if (string.IsNullOrWhiteSpace(asiento))
            {
                MessageBox.Show("Ingrese un asiento.");
                return;
            }

            if (cmbcomidas.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una comida.");
                return;
            }

            int cantidadReservas = ContarReservasAsiento(asiento);

            if (cantidadReservas >= 2)
            {
                MessageBox.Show("Este asiento ya alcanzó el límite.");
                return;
            }

            nombres[contador] = nombre;
            asientos[contador] = asiento;
            reservas[contador] = comidas[cmbcomidas.SelectedIndex];
            preciosReserva[contador] = precios[cmbcomidas.SelectedIndex];

            totalGeneral += precios[cmbcomidas.SelectedIndex];

            contador++;

            GuardarReservasArchivo();

            MessageBox.Show("Reserva realizada correctamente.");

            MostrarReservas();

            txtnombre.Clear();
            txtasiento.Clear();
            cmbcomidas.SelectedIndex = -1;
        }
        void GuardarReservasArchivo()
        {
            StreamWriter writer = new StreamWriter(archivo);

            for (int i = 0; i < contador; i++)
            {
                writer.WriteLine(
                    nombres[i] + "|" +
                    asientos[i] + "|" +
                    reservas[i] + "|" +
                    preciosReserva[i]
                );
            }

            writer.Close();
        }
        int ContarReservasAsiento(string asiento)
        {
            int cantidad = 0;

            for (int i = 0; i < contador; i++)
            {
                if (asientos[i].ToLower() == asiento.ToLower())
                {
                    cantidad++;
                }
            }

            return cantidad;
        }
        void MostrarReservas()
        {
            Reservas.Items.Clear();

            if (contador == 0)
            {
                MessageBox.Show("No existen reservas.");
                return;
            }

            for (int i = 0; i < contador; i++)
            {
                Reservas.Items.Add(
                    nombres[i] +
                    " | Asiento: " +
                    asientos[i] +
                    " | " +
                    reservas[i] +
                    " | $" +
                    preciosReserva[i]
                );
            }

            Reservas.Items.Add("");
            Reservas.Items.Add("TOTAL GENERAL: $" + totalGeneral);
        }
        void CancelarReserva()
        {
            int indice = Reservas.SelectedIndex;

            // Verificar selección
            if (indice == -1)
            {
                MessageBox.Show("Seleccione una reserva.");
                return;
            }

            // Evitar seleccionar TOTAL GENERAL
            if (indice >= contador)
            {
                MessageBox.Show("Seleccione una reserva válida.");
                return;
            }

            // Restar precio eliminado
            totalGeneral -= preciosReserva[indice];

            // Reorganizar arreglos
            for (int i = indice; i < contador - 1; i++)
            {
                nombres[i] = nombres[i + 1];
                asientos[i] = asientos[i + 1];
                reservas[i] = reservas[i + 1];
                preciosReserva[i] = preciosReserva[i + 1];
            }

            contador--;

            // Guardar cambios en txt
            GuardarReservasArchivo();

            // Actualizar ListBox
            MostrarReservas();

            MessageBox.Show("Reserva cancelada.");
        }


        private void btnreservar_Click(object sender, EventArgs e)
        {
            CrearReserva();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            CancelarReserva();
        }

        private void btnmostrar_Click(object sender, EventArgs e)
        {
            MostrarReservas();
        }
    }
}

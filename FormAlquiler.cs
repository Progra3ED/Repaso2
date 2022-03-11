using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repaso2
{
    public partial class FormAlquiler : Form
    {
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        List<Cliente> clientes = new List<Cliente>();
        List<Alquiler> alquileres = new List<Alquiler>();
        List<Mostrar> datos = new List<Mostrar>();
        public FormAlquiler()
        {
            InitializeComponent();
        }

        private void CargarVehiculos()
        {
            FileStream stream = new FileStream("Vehiculos.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            
            while (reader.Peek() > -1)
            {
                Vehiculo vehiculo = new Vehiculo();
                vehiculo.placa = reader.ReadLine();
                vehiculo.marca = reader.ReadLine();
                vehiculo.modelo = Convert.ToInt16(reader.ReadLine());
                vehiculo.color = reader.ReadLine();
                vehiculo.precioKilometo = Convert.ToDecimal(reader.ReadLine()); 

                vehiculos.Add(vehiculo);
            }
        }
        private void FormAlquiler_Load(object sender, EventArgs e)
        {
            CargarVehiculos();
            dataGridView1.DataSource = vehiculos;
            dataGridView1.Refresh();
        }

        private void buttonAlquileres_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < alquileres.Count; i++)
            {
                Mostrar dato = new Mostrar();

                for (int j = 0; j < clientes.Count; j++)
                {
                    if (alquileres[i].nit == clientes[j].nit)
                    {
                        dato.nombre = clientes[j].nombre;
                    }

                }
                for (int k = 0; k < vehiculos.Count; k++)
                {
                    if (alquileres[i].placa == vehiculos[k].placa)
                    {
                        dato.placa = vehiculos[k].placa;
                        dato.marca = vehiculos[k].marca;
                        dato.total = vehiculos[k].precioKilometo * alquileres[i].kilometros;
                    }

                }
                datos.Add(dato);
            }
            dataGridView2.DataSource = datos;
            dataGridView2.Refresh();
        }
    }
}

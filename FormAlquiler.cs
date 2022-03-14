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
        List<Mostrar> resumen = new List<Mostrar>();
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

            reader.Close();
        }

        private void CargarClientes()
        {
            FileStream stream = new FileStream("Clientes.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Cliente cliente = new Cliente();
                cliente.nit = reader.ReadLine();
                cliente.nombre = reader.ReadLine();
                cliente.direccion = reader.ReadLine();

                clientes.Add(cliente);
            }

            reader.Close();
        }

        private void CargarAlquileres()
        {
            FileStream stream = new FileStream("Alquileres.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Alquiler alquiler = new Alquiler();
                alquiler.nit = reader.ReadLine();
                alquiler.placa = reader.ReadLine(); 
                alquiler.fechaAlquiler = Convert.ToDateTime(reader.ReadLine());
                alquiler.fechaDevolucion = Convert.ToDateTime(reader.ReadLine());
                alquiler.kilometros = Convert.ToInt16(reader.ReadLine());

                alquileres.Add(alquiler);

            }

            reader.Close();
        }

        private void FormAlquiler_Load(object sender, EventArgs e)
        {            
            CargarClientes();
            CargarVehiculos();
            dataGridViewVehiculos.DataSource = vehiculos;
            dataGridViewVehiculos.Refresh();
            CargarAlquileres();
            dataGridViewAlquileres.DataSource = alquileres;
            dataGridViewAlquileres.Refresh();
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
                        dato.fechaDevolucion = alquileres[i].fechaDevolucion;
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
                
                resumen.Add(dato);
            }
            dataGridViewResumen.DataSource = resumen;
            dataGridViewResumen.Refresh();
        }
    }
}

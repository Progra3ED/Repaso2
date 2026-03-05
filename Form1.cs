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
    public partial class Form1 : Form
    {

        List<Cliente> clientes = new List<Cliente>();
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        List<Alquiler> alquileres = new List<Alquiler>();
        List<Reporte> reportes = new List<Reporte>();   

        const string fileVehiculos = @"Vehiculos.txt";
        const string fileClientes = @"Clientes.txt";
        const string fileAlquileres = @"Alquieleres.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void MostrarClientes()
        {
            dataGridViewVehiculos.DataSource = null;
            dataGridViewClientes.DataSource = clientes;
        
        }

        private void LeerCliente()
        {
            
            FileStream stream = new FileStream(fileClientes, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);


            while (reader.Peek() > -1)
            {
                Cliente cliente = new Cliente();
                cliente.Nit = reader.ReadLine();
                cliente.Nombre = reader.ReadLine();
                cliente.Direccion = reader.ReadLine();

                clientes.Add(cliente);

            }

            reader.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            LeerCliente();
            MostrarClientes();
        }

        private void GuardarVehiculo()
        {
            FileStream stream = new FileStream(fileVehiculos, FileMode.OpenOrCreate, FileAccess.Write);            
            StreamWriter writer = new StreamWriter(stream);

            foreach (var vehiculo in vehiculos)
            {
                writer.WriteLine(vehiculo.Placa);
                writer.WriteLine(vehiculo.Marca);
                writer.WriteLine(vehiculo.Modelo);
                writer.WriteLine(vehiculo.Color);
                writer.WriteLine(vehiculo.PrecioKm);

            }
                                    
            writer.Close();

        }

        private void MostrarVehiculo()
        {
            dataGridViewVehiculos.DataSource = null;
            dataGridViewVehiculos.DataSource = vehiculos;
        
        }

        private void LeerVehiculo()
        {            

            if (File.Exists(fileVehiculos))
            {
                FileStream stream = new FileStream(fileVehiculos, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);


                while (reader.Peek() > -1)
                {
                    Vehiculo vehiculo = new Vehiculo();
                    vehiculo.Placa = reader.ReadLine();
                    vehiculo.Marca = reader.ReadLine();
                    vehiculo.Modelo = Convert.ToInt16(reader.ReadLine());
                    vehiculo.Color = reader.ReadLine();
                    vehiculo.PrecioKm = Convert.ToDecimal(reader.ReadLine());

                    vehiculos.Add(vehiculo);
                }

                reader.Close();
            }

        }
        private void buttonGuardarVehiculo_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = new Vehiculo();

            vehiculo.Placa = textBoxPlaca.Text;
            vehiculo.Marca = textBoxMarca.Text;
            vehiculo.Modelo = Convert.ToInt16(numericUpDownModelo.Value);
            vehiculo.Color = textBoxColor.Text;
            vehiculo.PrecioKm = numericUpDownPrecio.Value;

            vehiculos.Add(vehiculo);

            GuardarVehiculo();

            MostrarVehiculo();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeerCliente();
            LeerVehiculo();
            LeerAlquiler();

            MostrarClientes();
            MostrarVehiculo();
            MostrarAlquiler();
        }

        private void GuardarAlquiler()
        {
            FileStream stream = new FileStream(fileAlquileres, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var alquiler in alquileres)
            {
                writer.WriteLine(alquiler.Nit);
                writer.WriteLine(alquiler.Placa);
                writer.WriteLine(alquiler.FechaAlquiler);
                writer.WriteLine(alquiler.FechaDevolucion);
                writer.WriteLine(alquiler.Kilometros);
            }
            writer.Close();
        
        }

        private void MostrarAlquiler()
        {
            dataGridViewAlquileres.DataSource = null;
            dataGridViewAlquileres.DataSource = alquileres;
        }

        private void LeerAlquiler()
        {
            if (File.Exists(fileAlquileres))
            {
                FileStream stream = new FileStream(fileAlquileres, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                while (reader.Peek() > -1)
                {
                    Alquiler alquiler = new Alquiler();
                    alquiler.Nit = reader.ReadLine();
                    alquiler.Placa = reader.ReadLine();
                    alquiler.FechaAlquiler = Convert.ToDateTime(reader.ReadLine());
                    alquiler.FechaDevolucion = Convert.ToDateTime(reader.ReadLine());
                    alquiler.Kilometros = Convert.ToInt16(reader.ReadLine());

                    alquileres.Add(alquiler);

                }
                reader.Close();
            }
        }

        private void buttonGuardarAlquiler_Click(object sender, EventArgs e)
        {
            Alquiler alquiler = new Alquiler(); 
            alquiler.Nit = textBoxNit.Text;
            alquiler.Placa = comboBoxPlaca.SelectedValue.ToString();
            alquiler.FechaAlquiler = dateTimePickerInicio.Value;
            alquiler.FechaDevolucion = dateTimePickerFinal.Value;
            alquiler.Kilometros = (int)numericUpDownKilometros.Value;

            alquileres.Add(alquiler);

            GuardarAlquiler();
            MostrarAlquiler();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                comboBoxPlaca.ValueMember = "Placa";
                comboBoxPlaca.DataSource = vehiculos;
            }

        }

        private void MostrarReporte()
        {
            dataGridViewReporte.DataSource = null;
            dataGridViewReporte.DataSource = reportes;
        }

        private void buttonReporte_Click(object sender, EventArgs e)
        {
            //Un cilo que recorra todos los alquileres
            foreach (var alquiler in alquileres)
            {
                Reporte reporte = new Reporte();

                //Por cada alquiler que se lee, hay que buscar entre los clientes
                //quien tiene el NIT que alquilo, para encontrar su Nombre
                foreach(var cliente in clientes)
                {
                    if (alquiler.Nit == cliente.Nit)
                    {
                        reporte.Nombre = cliente.Nombre;
                    }
                }
                //Por cada alquiler que se lee, hay que buscar entre los vehículos
                //quien tiene la Placa del vehículo que se alquilo, para encontra
                //los datos de ese vehículo
                foreach (var vehiculo in vehiculos)
                {
                    if (alquiler.Placa == vehiculo.Placa)
                    {
                        reporte.Placa = vehiculo.Placa;
                        reporte.Color = vehiculo.Color;

                        reporte.FechaDevolucion = alquiler.FechaDevolucion;

                        //Aquí se calcula el Total a pagar
                        //El precio por vehículo esta en el Vehículo
                        //y los kilometros recorridos estan en el Alquiler
                        decimal Total = vehiculo.PrecioKm *alquiler.Kilometros;

                        reporte.TotalPagar = Total;
                    }
                }
                //Cada dato que se encontró se guardo en reporte
                //Entonces guardamos ese reporte en la lista de reportes
                reportes.Add(reporte);
            }
            MostrarReporte();
        }

        private void buttonMasKilometros_Click(object sender, EventArgs e)
        {
            Alquiler alquiler = new Alquiler();

            //Para encontrar el alquiler con más kilometros recorridos
            //Primero se ordena la lista de alquileres descendentemente con base a los kilometros
            //luego se obtiene el primer dato de la lista ordenada First()
            
            alquiler = alquileres.OrderByDescending(a => a.Kilometros).First();

            MessageBox.Show("El vehículo:" + alquiler.Placa 
                             + " recorrió " 
                             + alquiler.Kilometros);
        }
    }
}

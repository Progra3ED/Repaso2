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

        VehiculoPersistencia vehiculoPersistencia = new VehiculoPersistencia();
        ClientePersistencia clientePersistencia = new ClientePersistencia();
        AlquilerPersistencia alquilerPersistencia = new AlquilerPersistencia();

        public Form1()
        {
            InitializeComponent();
        }

        private void MostrarClientes()
        {
            dataGridViewVehiculos.DataSource = null;
            dataGridViewClientes.DataSource = clientes;
        
        }

        

        private void tabPage1_Click(object sender, EventArgs e)
        {            
            clientes = clientePersistencia.LeerTxt();
            //LeerCliente();
            MostrarClientes();
        }

        

        private void MostrarVehiculo()
        {
            dataGridViewVehiculos.DataSource = null;
            dataGridViewVehiculos.DataSource = vehiculos;
        
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

            
            vehiculoPersistencia.GuardarTxt(vehiculos);
            //GuardarVehiculo();

            MostrarVehiculo();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            clientes = clientePersistencia.LeerTxt();         
            vehiculos = vehiculoPersistencia.LeerTxt();
            alquileres = alquilerPersistencia.LeerTxt();

            MostrarClientes();
            MostrarVehiculo();
            MostrarAlquiler();
        }

        

        private void MostrarAlquiler()
        {
            dataGridViewAlquileres.DataSource = null;
            dataGridViewAlquileres.DataSource = alquileres;
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

            alquilerPersistencia.GuardarTxt(alquileres);
            //GuardarAlquiler();
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

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void buttonJson_Click(object sender, EventArgs e)
        {
                        
            Alquiler alquiler = new Alquiler();
            alquiler.Nit = textBoxNit.Text;
            alquiler.Placa = comboBoxPlaca.Text;
            alquiler.FechaAlquiler = dateTimePickerInicio.Value;
            alquiler.FechaDevolucion = dateTimePickerFinal.Value;
            alquiler.Kilometros = (int)numericUpDownKilometros.Value;

            alquileres.Add(alquiler);


            AlquilerPersistencia persistencia = new AlquilerPersistencia();
            persistencia.GuardarJson(alquileres);

        }

        private void buttonLeerJson_Click(object sender, EventArgs e)
        {
            AlquilerPersistencia persistencia = new AlquilerPersistencia();
            alquileres = persistencia.LeerJson();
            MostrarAlquiler();
        }

        private void buttonGuardarCliente_Click(object sender, EventArgs e)
        {
            Cliente nuevoCliente = new Cliente();
            nuevoCliente.Nit = textBoxNitCliente.Text;
            nuevoCliente.Nombre = textBoxNombreCliente.Text;
            nuevoCliente.Direccion = textBoxDireccionCliente.Text;
            nuevoCliente.Email = textBoxEmailCliente.Text;
            nuevoCliente.Usuario = textBoxUsuarioCliente.Text;
            nuevoCliente.Password = textBoxPasswordCliente.Text;

            clientes.Add(nuevoCliente);
            clientePersistencia.GuardarTxt(clientes);
            MostrarClientes();

            // Limpiar campos
            textBoxNitCliente.Clear();
            textBoxNombreCliente.Clear();
            textBoxDireccionCliente.Clear();
            textBoxEmailCliente.Clear();
            textBoxUsuarioCliente.Clear();
            textBoxPasswordCliente.Clear();
        }
    }
}

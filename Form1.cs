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
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        public Form1()
        {
            InitializeComponent();
        }

        private void GuardarVehiculo()
        {
            FileStream stream = new FileStream("Vehiculos.txt", FileMode.OpenOrCreate, FileAccess.Write);            
            StreamWriter writer = new StreamWriter(stream);

            foreach (var vehiculo in vehiculos)
            {
                writer.WriteLine(vehiculo.placa);
                writer.WriteLine(vehiculo.marca);
                writer.WriteLine(vehiculo.modelo);
                writer.WriteLine(vehiculo.color);
                writer.WriteLine(vehiculo.precioKilometo);
            }            
            writer.Close();

        }
        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = new Vehiculo();
            vehiculo.placa = textBox1.Text;
            vehiculo.marca = textBox2.Text;
            vehiculo.modelo = Convert.ToInt16(textBox3.Text);
            vehiculo.color = textBox4.Text;
            vehiculo.precioKilometo = Convert.ToDecimal(textBox5.Text);

            int posicion = vehiculos.FindIndex(x => x.placa == textBox1.Text);
            if (posicion == -1)
            {
                vehiculos.Add(vehiculo);
                GuardarVehiculo();
            }
            else
            {
                MessageBox.Show("El vehículo ya estaba ingresado.");
            }
            
        }

        private void buttonVehiculo_Click(object sender, EventArgs e)
        {
            FormAlquiler formularioAlquiler = new FormAlquiler();
            formularioAlquiler.Show();
        }
    }
}

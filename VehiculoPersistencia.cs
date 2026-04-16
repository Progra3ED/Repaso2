using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso2
{
    internal class VehiculoPersistencia
    {
        string fileVehiculos = "Vehiculos.txt";
        

        public void GuardarTxt(List<Vehiculo> vehiculos)
        {
            FileStream stream = new FileStream(fileVehiculos, FileMode.Create, FileAccess.Write);
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

        public List<Vehiculo> LeerTxt()
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();

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

            return vehiculos;

        }
    }
}

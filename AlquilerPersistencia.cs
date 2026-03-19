using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso2
{
    internal class AlquilerPersistencia
    {
        string fileAlquileres = "Alquileres.txt";

        public void GuardarTxt(List<Alquiler> alquileres)
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

        public List<Alquiler> LeerTxt()
        {
            List<Alquiler> alquileres = new List<Alquiler>();
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
            return alquileres;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso2
{
    internal class ClientePersistencia
    {
        string fileClientes = "Clientes.txt";
        

        //Este método devuelve una lista de clientes
        //al programa principal
        public List<Cliente> LeerTxt()
        {
            List<Cliente> clientes = new List<Cliente>();
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
            return clientes;
        }
    }
}

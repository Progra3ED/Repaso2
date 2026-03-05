using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso2
{
    internal class Reporte
    {
        string nombre;
        string placa;        
        string color;
        DateTime fechaDevolucion;
        decimal totalPagar;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Color { get => color; set => color = value; }
        public DateTime FechaDevolucion { get => fechaDevolucion; set => fechaDevolucion = value; }
        public decimal TotalPagar { get => totalPagar; set => totalPagar = value; }
    }
}

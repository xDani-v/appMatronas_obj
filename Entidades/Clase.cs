using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMatronas_obj.Entidades
{
    public class Clase
    {
        public string codigo { get; set; }
        public Matrona matrona { get; set; }
        public Centro centro { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFin { get; set; }
        public string dia { get; set; }

        //constructor vacio
        public Clase()
        {
        }

        // Constructor
        public Clase(string codigo,Matrona matrona, Centro centro, TimeSpan horaInicio, TimeSpan horaFin, string dia)
        {
            this.codigo = codigo;
            this.matrona = matrona;
            this.centro = centro;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.dia = dia;
           
        }

        //metodo to string
        public override string ToString()
        {
            return "Clase{" + "matrona=" + matrona + ", centro=" + centro + ", horaInicio=" + horaInicio + ", horaFin=" + horaFin + ", dia=" + dia + '}';
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMatronas_obj.Entidades
{
    public class Embarazada
    {
        public Clase asiste;
        public string nombreEmbarazada { get; set; }
        public int edadEmbarazada { get; set; }
        public int semanaGestacion { get; set; }
        public int numeroHijos { get; set; }
        public int numeroClases { get; set; }
        public Matrona asignada { get; set; }
        public string seguridadSocial { get; set; }
        public string direccion { get; set; }
        public DateTime fechaAlta { get; set; }

        public Embarazada()
        {

        }

        public Embarazada(Clase asistencia,string nombreEmbarazada, int edadEmbarazada, int semanaGestacion, int numeroHijos, int numeroClases, Matrona asignada, string seguridadSocial, string direccion, DateTime fechaAlta)
        {
            this.asiste = asistencia;
            this.nombreEmbarazada = nombreEmbarazada;
            this.edadEmbarazada = edadEmbarazada;
            this.semanaGestacion = semanaGestacion;
            this.numeroHijos = numeroHijos;
            this.numeroClases = numeroClases;
            this.asignada = asignada;
            this.seguridadSocial = seguridadSocial;
            this.direccion = direccion;
            this.fechaAlta = fechaAlta;
        }
      
    }
}

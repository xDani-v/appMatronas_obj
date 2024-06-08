using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMatronas_obj.Entidades
{
    public class Matrona
    {
       
        public string nombreMatrona { get; set; }
        public Centro centroAtencion { get; set; }

        public Matrona()
        {

        }

        public Matrona(string nombreMatrona, Centro centroAtencion)
        {
            this.nombreMatrona = nombreMatrona;
            this.centroAtencion = centroAtencion;
        }

        public override string ToString()
        {
            return "Matrona{" + "nombreMatrona=" + nombreMatrona + ", centroAtencion=" + centroAtencion + '}';
        }

    }
}

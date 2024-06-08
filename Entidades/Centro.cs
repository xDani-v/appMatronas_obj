using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMatronas_obj.Entidades
{
    public class Centro
    {
        public string nombreCentro { get; set; }
        public string direccionCentro { get; set; }
        public bool tieneAuditorio { get; set; }

        public Centro()
        {
        }
        public Centro(string nombreCentro, string direccionCentro, bool tieneAuditorio)
        {
            this.nombreCentro = nombreCentro;
            this.direccionCentro = direccionCentro;
            this.tieneAuditorio = tieneAuditorio;
        }

        //tostring
        public override string ToString()
        {
            return "Centro{" + "nombreCentro=" + nombreCentro + ", direccionCentro=" + direccionCentro + ", tieneAuditorio=" + tieneAuditorio + '}';
        }
    }
}

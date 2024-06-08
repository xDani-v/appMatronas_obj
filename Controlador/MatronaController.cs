using appMatronas_obj.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMatronas_obj.Controlador
{
    public class MatronaController
    {
        //listas
        List<Matrona> matronas = new List<Matrona>();
        List<Centro> centros = new List<Centro>();
        List<Clase> clases = new List<Clase>();
        List<Embarazada> embarazadas = new List<Embarazada>();


        //procesos matronas
        public void agregarMatrona(Matrona obj)
        {
            matronas.Add(obj);
        }

        public List<Matrona> listarMatronas()
        { 
            return matronas;
        }

        public bool buscarCentroMatrona(Matrona obj)
        {
            bool result = false;

            foreach (Matrona matrona in matronas)
            {
                  if(matrona.centroAtencion.Equals(obj.centroAtencion))
                  {
                      result = true;
                  }
            }
            return result;
        }

        //procesos centros
        public void agregarCentro(Centro obj)
        {
           centros.Add(obj);
        }

        public List<Centro> listarCentros()
        {
            return centros;
        }

        public List<Centro> listarCentrosSin()
        {
            List<Centro> centrosSinAuditorio = new List<Centro>();
            foreach (Centro centro in centros)
            {
                if (!centro.tieneAuditorio)
                {
                    centrosSinAuditorio.Add(centro);
                }
            }
            return centrosSinAuditorio;
        }

        public List<Centro> listarCentrosConAuditorio()
        {
            List<Centro> centrosConAuditorio = new List<Centro>();
            foreach (Centro centro in centros)
            {
                if (centro.tieneAuditorio)
                {
                    centrosConAuditorio.Add(centro);
                }
            }
            return centrosConAuditorio;
        }

        //procesos clases
        public void agregarClase(Clase obj)
        {
            clases.Add(obj);
        }

        public List<Clase> listarClases()
        {
            return clases;
        }

        //modificar
        public void modificarClase(string codigo, Clase obj)
        {
            foreach (Clase clase in clases)
            {
                if (clase.codigo.Equals(codigo))
                {
                    clase.matrona = obj.matrona;
                    clase.centro = obj.centro;
                    clase.dia = obj.dia;
                    clase.horaInicio = obj.horaInicio;
                    clase.horaFin = obj.horaFin;
                }
            }
        }

        //eliminar
        public void eliminarClase(string codigo)
        {
            foreach (Clase clase in clases)
            {
                if (clase.codigo.Equals(codigo))
                {
                    clases.Remove(clase);
                    break;
                }
            }
        }

        //buscar clase x codigo
        public Clase buscarClaseCod(string codigo)
        {
            Clase claseEncontrada = null;
            foreach (Clase clase in clases)
            {
                if (clase.codigo.Equals(codigo))
                {
                    claseEncontrada = clase;
                    break;
                }
            }
            return claseEncontrada;
        }

        //lo mismo pero booleano
        public bool buscarClaseCodBool(string codigo)
        {
            bool result = false;
            foreach (Clase clase in clases)
            {
                if (clase.codigo.Equals(codigo))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        //verificar cque no exista registro de matrona, centro, dia y hora en la lista de clases
        public bool buscarClase(Clase obj)
        {
            bool result = false;

            foreach (Clase clase in clases)
            {
                if (clase.matrona.Equals(obj.matrona) && clase.centro.Equals(obj.centro) && clase.dia.Equals(obj.dia) && clase.horaInicio.Equals(obj.horaInicio) && clase.horaFin.Equals(obj.horaFin))
                {
                    result = true;
                }
            }
            return result;
        }

        //procesos embarazadas
        public void agregarEmbarazada(Embarazada obj)
        {
            embarazadas.Add(obj);
        }

        public List<Embarazada> listarEmbarazadas()
        {
            return embarazadas;
        }

        public void modificarEmbarazada(string nombre, Embarazada obj)
        {
            foreach (Embarazada embarazada in embarazadas)
            {
                if (embarazada.nombreEmbarazada.Equals(nombre))
                {
                    embarazada.edadEmbarazada = obj.edadEmbarazada;
                    embarazada.numeroHijos = obj.numeroHijos;
                    embarazada.numeroClases = obj.numeroClases;
                    embarazada.asignada = obj.asignada;
                    embarazada.seguridadSocial = obj.seguridadSocial;
                    embarazada.direccion = obj.direccion;
                }
            }
        }

        //buscar embarazada x nombre bool
        public bool buscarEmbarazadaBool(string nombre)
        {
            bool result = false;
            foreach (Embarazada embarazada in embarazadas)
            {
                if (embarazada.nombreEmbarazada.Equals(nombre))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        //buscar objeto embarazada x nombre
        public Embarazada buscarEmbarazada(string nombre)
        {
            Embarazada embarazadaEncontrada = null;
            foreach (Embarazada embarazada in embarazadas)
            {
                if (embarazada.nombreEmbarazada.Equals(nombre))
                {
                    embarazadaEncontrada = embarazada;
                    break;
                }
            }
            return embarazadaEncontrada;
        }

        //consultas
        //El total de clases impartidas por cada matrona agrupada según su centro de salud. 0.25 Ptos. 
        public string totalClasesPorMatrona()
        {
            int numClases = 0;
            string cadena = "";

            foreach(Matrona matrona in matronas)
            {
                foreach (Clase clase in clases)
                {
                    if (matrona.Equals(clase.matrona))
                    {
                        numClases++;
                    }
                }

                cadena += "Matrona: " + matrona.nombreMatrona + " - Total de clases: " + numClases + "\n";
                numClases = 0;
            }
            return cadena;
        }

        //Porcentaje de clases impartidas según el centro de salud. 0.5 Ptos.
        public string porcentajeClasesPorCentro()
        {
            int numClases = 0;
            string cadena = "";
            int totalClases = clases.Count;

            foreach (Centro centro in centros)
            {
                foreach (Clase clase in clases)
                {
                    if (centro.Equals(clase.centro))
                    {
                        numClases++;
                    }
                }

                cadena += "Centro: " + centro.nombreCentro + " - Porcentaje de clases: " + (numClases * 100 / totalClases) + "%\n";
                numClases = 0;
            }
            return cadena;
        }

        //Cual fue la matrona que mayores horas de clase impartió. 0.25 Ptos.
        //cada clase dura 1h
        public string matronaConMasHoras()
        {
            int numClases = 0;
            int mayor = 0;
            string cadena = "";
            Matrona matronaMayor = null;

            foreach (Matrona matrona in matronas)
            {
                foreach (Clase clase in clases)
                {
                    if (matrona.Equals(clase.matrona))
                    {
                        numClases++;
                    }
                }

                if (numClases > mayor)
                {
                    mayor = numClases;
                    matronaMayor = matrona;
                }
                numClases = 0;
            }

            if(matronaMayor != null) {
              cadena = "Matrona con mas horas: " + matronaMayor.nombreMatrona + " - Total de horas: " + mayor + "\n";
            return cadena;
            } else {
              return "No hay matronas registradas";
            }
        }
         
    }
}

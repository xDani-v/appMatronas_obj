using appMatronas_obj.Controlador;
using appMatronas_obj.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appMatronas_obj.Vistas
{
    public partial class EmbarazadaForm : Form
    {
        string codigo = "";
        MatronaController logica;
        public EmbarazadaForm(string codigosesion, MatronaController logica)
        {
            InitializeComponent();
            codigo = codigosesion;
            this.logica = logica;
            cargarMatronas();
        }

        public void cargarMatronas()
        {
            comboBox1.DataSource = logica.listarMatronas();
            comboBox1.DisplayMember = "nombreMatrona";
            comboBox1.ValueMember = "nombreMatrona";
        }

        public Embarazada crearObjeto() {      
            string nombre = textBox1.Text;
            int  edad = int.Parse(textBox2.Text);
            int semana = int.Parse(textBox3.Text); 
            int numhijos = int.Parse(textBox4.Text); 
            int numclases = int.Parse(textBox5.Text);
            Matrona matrona = (Matrona)comboBox1.SelectedItem;
            string seguridad = textBox6.Text;
            string direccion = textBox7.Text;
            DateTime fecha = DateTime.Now;
            Clase cls = logica.buscarClaseCod(codigo);
            return new Embarazada(cls,nombre,edad,semana,numhijos,numclases,matrona,seguridad,direccion,fecha);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Embarazada obj = crearObjeto();
            if (logica.buscarEmbarazadaBool(obj.nombreEmbarazada))
            {
                logica.modificarEmbarazada(obj.nombreEmbarazada,obj);
            }
            else { 
            logica.agregarEmbarazada(crearObjeto());
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Embarazada bus_obj = logica.buscarEmbarazada(textBox1.Text);
                if (bus_obj != null)
                {
                    textBox1.Text = bus_obj.nombreEmbarazada;
                    textBox2.Text = bus_obj.edadEmbarazada.ToString();
                    textBox3.Text = bus_obj.CalcularSemanaGestacionActual().ToString();
                    textBox4.Text = bus_obj.numeroHijos.ToString();
                    textBox5.Text = bus_obj.numeroClases.ToString();
                    comboBox1.SelectedItem = bus_obj.asignada;
                    textBox6.Text = bus_obj.seguridadSocial;
                    textBox7.Text = bus_obj.direccion;
                }
                else
                {
                    MessageBox.Show("No se encontro la embarazada");
                }
            }
        }
    }
}

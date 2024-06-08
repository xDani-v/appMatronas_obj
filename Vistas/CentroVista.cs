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
    public partial class CentroVista : Form
    {
        MatronaController logica;
        public CentroVista(MatronaController logica)
        {
            InitializeComponent();
            this.logica = logica;
            cargarDatos();
        }

        public Centro crearObjeto()
        {
            string nombre = textBox1.Text;
            string direccion = textBox2.Text;
            bool auditorio = checkBox1.Checked;
            Centro obj=new Centro(nombre, direccion, auditorio);
            return obj;
        }

        public void limpiar() {
            textBox1.Text = "";
            textBox2.Text = "";
            checkBox1.Checked = false;
        }

        public void cargarDatos()
        {
           dataGridView1.DataSource = logica.listarCentros().ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logica.agregarCentro(crearObjeto());
            cargarDatos();
            limpiar();
        }
    }
}

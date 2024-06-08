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
    public partial class MatronaVista : Form
    {
        MatronaController logica;
        public MatronaVista(MatronaController logica)
        {
            InitializeComponent();
            this.logica = logica;
            comboCentros();
            cargarMatronas();
        }

        public void comboCentros ()
        {
            comboBox1.DataSource = logica.listarCentrosConAuditorio();
            comboBox1.DisplayMember = "nombreCentro";
            comboBox1.ValueMember = "nombreCentro";
        }

        public void cargarMatronas()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = logica.listarMatronas();
        }

        public Matrona crearObjeto()
        {
            Matrona matrona = new Matrona();
            matrona.nombreMatrona = textBox1.Text;
            matrona.centroAtencion = (Centro)comboBox1.SelectedItem;
            return matrona;
        }

        public void limpiar() {             
            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Matrona nueva = crearObjeto();
            if (!logica.buscarCentroMatrona(nueva))
            {
                logica.agregarMatrona(nueva);
                cargarMatronas();
                limpiar();
            }
            else
            {
                MessageBox.Show("Este centro ya esta asignado a una matrona");
            }
          
        }
    }
}

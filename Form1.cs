using appMatronas_obj.Controlador;
using appMatronas_obj.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appMatronas_obj
{
    public partial class Form1 : Form
    {
        MatronaController logica = new MatronaController();
        public Form1()
        {
            InitializeComponent();
        }

        public void cargarFormularioPanel(Form form)
        {
            // Configurar el formulario para que no tenga bordes y deshabilitar minimizar y maximizar
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Añadir el formulario al panel y mostrarlo
            panel1.Controls.Clear();
            panel1.Controls.Add(form);
            form.Show();
        }

        private void matronasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarFormularioPanel(new MatronaVista(logica));
        }

        private void centroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarFormularioPanel(new CentroVista(logica));
        }

        private void clasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarFormularioPanel(new ClasesVista(logica));
        }
    }
}

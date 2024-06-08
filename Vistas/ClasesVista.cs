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
    public partial class ClasesVista : Form
    {
        MatronaController logica;
        public ClasesVista(MatronaController logica)
        {
            InitializeComponent();
            this.logica = logica;
            Tiempo(dateTimePicker1);
            Tiempo(dateTimePicker2);
            cargarDias();
            cargarClases();
        }

        public void Tiempo(DateTimePicker dt)
        {
            dt.Format = DateTimePickerFormat.Custom;
            dt.CustomFormat = "HH:mm";
            dt.ShowUpDown = true; // Esto mostrará una flecha para aumentar/disminuir el tiempo
            dateTimePicker2.Value = dateTimePicker1.Value.AddHours(1);
        }

        public void cargarDias()
        {

            comboBox3.Items.Add("Domingo");
            comboBox3.Items.Add("Lunes");
            comboBox3.Items.Add("Martes");
            comboBox3.Items.Add("Miercoles");
            comboBox3.Items.Add("Jueves");
            comboBox3.Items.Add("Viernes");
            comboBox3.Items.Add("Sabado");

            // Opcional: Seleccionar un día por defecto
            comboBox3.SelectedIndex = 0;

            comboBox1.DataSource = logica.listarMatronas();
            comboBox1.DisplayMember = "nombreMatrona";
            comboBox1.ValueMember = "nombreMatrona";

            comboBox2.DataSource = logica.listarCentrosSin();
            comboBox2.DisplayMember = "nombreCentro";
            comboBox2.ValueMember = "nombreCentro";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker1.Value.AddHours(1);
        }

        public Clase crearObjeto()
        {
            string codigo = textBox1.Text;
            Matrona matrona = (Matrona) comboBox1.SelectedItem;
            Centro centro = (Centro) comboBox2.SelectedItem;
            DateTime dt1 = dateTimePicker1.Value;
            TimeSpan horaInicio = new TimeSpan(dt1.Hour, dt1.Minute, 0);
            DateTime dt2 = dateTimePicker2.Value;
            TimeSpan horaFin = new TimeSpan(dt2.Hour, dt2.Minute, 0);
            string dia = comboBox3.SelectedItem.ToString();
            return new Clase(codigo, matrona, centro, horaInicio, horaFin, dia);
        }

        public void cargarClases()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = logica.listarClases();
        }

        public void limpiar()
        {
            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clase nueva= crearObjeto();
            if (!logica.buscarClase(nueva))
            {
                if(!logica.buscarClaseCodBool(nueva.codigo))
                {
                    logica.agregarClase(nueva);
                  
                }
                else
                {
                   logica.modificarClase(nueva.codigo, nueva);
                }
                cargarClases();
                limpiar();
            }
            else
            {
                MessageBox.Show("Este horario, ya se encuentra ocupado");
            }
            textBox1.ReadOnly = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                string codigo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                logica.eliminarClase(codigo);
                cargarClases();
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string codigo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Clase clasemodificar = logica.buscarClaseCod(codigo);
                textBox1.Text = clasemodificar.codigo;
                comboBox1.SelectedItem = clasemodificar.matrona;
                comboBox2.SelectedItem = clasemodificar.centro;
                dateTimePicker1.Value = DateTime.Today.Add(clasemodificar.horaInicio);
                dateTimePicker2.Value = DateTime.Today.Add(clasemodificar.horaFin);
                comboBox3.SelectedItem = clasemodificar.dia;
                textBox1.ReadOnly = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string con1 =  logica.totalClasesPorMatrona();
            string con2 = logica.porcentajeClasesPorCentro();
            string con3 = logica.matronaConMasHoras();

            MessageBox.Show(con1 + "\n" + con2 + "\n" + con3);
        }
    }
    
}

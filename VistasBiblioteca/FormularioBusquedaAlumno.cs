using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistasBiblioteca
{
    public partial class FormularioBusquedaAlumno : Form
    {

        public delegate void accionBotonBuscar(int valor);

        public event accionBotonBuscar clickBotonBuscar;

        public FormularioBusquedaAlumno()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            clickBotonBuscar(0);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            clickBotonBuscar(1);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            clickBotonBuscar(2);
        }
    }
}

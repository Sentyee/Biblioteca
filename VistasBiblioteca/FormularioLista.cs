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
    public partial class FormularioLista : Form
    {

        public delegate void accionBotonLista(int valor);

        public event accionBotonLista clickBotonLista;

        public FormularioLista()
        {
            InitializeComponent();
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            clickBotonLista(0);
        }
    }
}

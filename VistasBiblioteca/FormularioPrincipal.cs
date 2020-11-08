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
    public partial class FormularioPrincipal : Form
    {

        public delegate void accionBotonPrincipal(int valor);

        public event accionBotonPrincipal clickBotonPrincipal;

        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            clickBotonPrincipal(0);
        }


        private void searchButton_Click(object sender, EventArgs e)
        {
            clickBotonPrincipal(1);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            clickBotonPrincipal(2);
        }



    }
}

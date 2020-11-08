using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VistasBiblioteca;

namespace ControladoresBiblioteca
{
    public class Controlador
    {
        FormularioPrincipal mf;
        
        
        public Controlador()
        {
            try
            {

                mf = new FormularioPrincipal();

                mf.clickBotonPrincipal += clickBotonPrincipal;

                mf.ShowDialog();
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("Error fatal, por favor, contacte con el desarrollador", "NullException", MessageBoxButtons.OK);
                Console.WriteLine(nre.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: No se ha podido abrir la ventana principal, contacte con el desarrollador", "Error Ventana Principal.", 
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
                Console.WriteLine(e.Message);
            }

        }

        private void clickBotonPrincipal(int valor)
        {
            if (valor == 0)
            {
                mf.Close();
                mf.Dispose();
                new ControladorLista();
                
            }
            else if (valor == 1)
            {
                mf.Close();
                mf.Dispose();
                new ControladorBusqueda();
            }
            else if (valor == 2)
            {
                MessageBox.Show("Hasta la próxima", " ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                Application.Exit();
            }
        }
    }
}
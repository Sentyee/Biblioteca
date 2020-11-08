using System;
using System.Collections.Generic;
using System.Text;
using VistasBiblioteca;
using ModelosBiblioteca;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ControladoresBiblioteca
{
    public class ControladorBusqueda
    {
        FormularioBusquedaAlumno ssf;
        Model modelo;
        
        public ControladorBusqueda()
        {
            try
            {

                ssf = new FormularioBusquedaAlumno();
                modelo = new Model();
                ssf.clickBotonBuscar += clickBotonBuscar;
                
                ssf.ShowDialog();
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("Error fatal, por favor, contacte con el desarrollador", "NullException", MessageBoxButtons.OK);
                Console.WriteLine(nre.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: No se ha podido abrir la ventana de búsqueda, por favor, contacte con el desarrollador", "Error Ventana Búsqueda.",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
            }


        }

        private void clickBotonBuscar(int valor)
        {
            if (valor == 0)
            {
                buscarAlumno();

            }
            else if (valor == 1)
            {
                borrarAlumno();
            }
            else if (valor == 2)
            {
                MessageBox.Show("Volverá al menú principal", " ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                ssf.Close();
                ssf.Dispose();
                new Controlador();
            }
        }

        public void buscarAlumno()
        { 
            String dni = "";
            dni = ssf.GetTextBoxDni.Text;
            String[] alumnos = modelo.getCamposAlumnos(dni);

            if (alumnos[0] == "Null")
            {
                MessageBox.Show("El alumno que busca no existe", " ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            

            ssf.SetTextBoxNombre(alumnos[0]);
            ssf.SetTextBoxApellido1(alumnos[1]);
            ssf.SetTextBoxApellido2(alumnos[2]);

        }

        public void borrarAlumno()
        {
            String dni = "";
            Boolean bo;
            dni = ssf.GetTextBoxDni.Text;
            bo = modelo.prestamosExiste(dni);

            if (bo)
            {
                modelo.borrarAlumno(dni);
            } else
            {
                MessageBox.Show("El alumno que intenta borrar tiene un préstamo asociado", " ",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}

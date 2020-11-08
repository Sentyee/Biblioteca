using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using VistasBiblioteca;
using ModelosBiblioteca;
using System.Data;
using MySql.Data.MySqlClient;


namespace ControladoresBiblioteca
{

    public class ControladorLista
    {
        FormularioLista lf;
        Model modelo;

        public ControladorLista()
        {
            try
            {

                lf = new FormularioLista();
                modelo = new Model();
                lf.clickBotonLista += clickBotonLista;
                ListaAlumnos();
                lf.ShowDialog();
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("Error fatal, por favor, contacte con el desarrollador", "NullException", MessageBoxButtons.OK);
                Console.WriteLine(nre.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: No se ha podido abrir la ventana pde listado, por favor, contacte con el desarrollador", "Error Ventana Listado.",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
            }

        }

        private void clickBotonLista(int valor)
        {
            if (valor == 0)
            {
            DialogResult dr = MessageBox.Show("¿Está seguro?", "Volver atrás", System.Windows.Forms.MessageBoxButtons.OKCancel);
                if(dr == DialogResult.OK)
                 {
                     lf.Close();
                     lf.Dispose();
                     new Controlador();
                 } 
            }
        }

        public void ListaAlumnos()
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adapter = modelo.getAlumnos();
            adapter.Fill(ds);

            lf.GetDataGridAlumnos.DataSource = ds.Tables[0];

        }

    }

    }
     
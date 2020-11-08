using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms; 

namespace ModelosBiblioteca
{
    public class Model
    {
        Conexion ConexionDB = new Conexion();
        MySqlConnection connector;

        public Model()
        {
            connector = ConexionDB.ConexionBD();
            connector.Open();
        }

        public MySqlDataAdapter getAlumnos()
        {
            string query = "SELECT * FROM ALUMNOS";
            MySqlDataAdapter ListaAlumnos = new MySqlDataAdapter(query, connector);
            return ListaAlumnos; 
        }

        public string[] getCamposAlumnos (string dni)
        {
            string query = "SELECT * FROM ALUMNOS WHERE DNI = '" + dni + "'";
            MySqlCommand command = new MySqlCommand(query, connector);
            MySqlDataReader msdr = command.ExecuteReader();
            string[] alumnos = new string[3];
            if (msdr.Read())
            {
                alumnos[0] = msdr.GetString(2);
                alumnos[1] = msdr.GetString(3);
                alumnos[2] = msdr.GetString(4);
            } else
            {
                alumnos[0] = "Null";
            }

            msdr.Close();

            return alumnos;
        }

        public Boolean prestamosExiste (string dni) 
            {

            string query = "SELECT * FROM ALUMNOS WHERE DNI = '" + dni + "'";
            MySqlCommand command = new MySqlCommand(query, connector);
            MySqlDataReader msdr = command.ExecuteReader();
            String id = "";
            if (msdr.Read())
            {
                id = msdr.GetString(0);
            }
            msdr.Close();

            Boolean bo = true;
            string query2 = "SELECT * FROM PRESTAMOS WHERE codAlumno = '" + id + "'";
            MySqlCommand command2 = new MySqlCommand(query2, connector);
            MySqlDataReader msdr2 = command2.ExecuteReader();

            if (msdr2.Read())
            {
                bo = false;
            }

            msdr2.Close();

            return bo;
        } 

        public void borrarAlumno (string dni)
        {
            try
            {
                string query = "DELETE FROM ALUMNOS WHERE dni='" + dni + "'";
                MySqlCommand comando = new MySqlCommand(query, connector);
                MySqlDataReader msdr3 = comando.ExecuteReader();
            }
            catch (MySqlException me)
            {
                MessageBox.Show("Error: Error con la base de daots, contacte con el desarrollador", "Error MySQL Borrar.",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
                Console.WriteLine(me.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: Error desconocido, contacte con el desarrollador", "Error Borrar Alumno.",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
                Console.WriteLine(e.Message);
            }
        }
    }
}

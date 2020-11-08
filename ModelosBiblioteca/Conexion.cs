using System;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace ModelosBiblioteca
{
    public class Conexion
    {
        public MySqlConnection ConexionBD()
        {
            string servidor = "localhost"; //Nombre o ip del servidor de MySQL

            string bd = "libros"; //Nombre de la base de datos

            string usuario = "root"; //Usuario de acceso a MySQL

            string password = ""; //Contraseña de usuario de acceso a MySQL

            string datos = null; //Variable para almacenar el resultado

            //Crearemos la cadena de conexión concatenando las variables

            string cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";





            //Instancia para conexión a MySQL, recibe la cadena de conexión

            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            MySqlDataReader reader = null; //Variable para leer el resultado de la consulta

            //Agregamos try-catch para capturar posibles errores de conexión o sintaxis.


            return conexionBD;


        }
    }
}
        

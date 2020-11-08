using System;


namespace Biblioteca
{
    static class ClasePrincipal
    {
        [STAThread]
        static void Main()
        {
            ControladoresBiblioteca.Controlador menu = new ControladoresBiblioteca.Controlador();
        }
    }
}

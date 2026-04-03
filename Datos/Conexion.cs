using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CRUD_Usuarios.Datos
{
    public class Conexion
    {
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection("Server=LUIS\\SQLEXPRESS;Database=TAREA;Trusted_Connection=True;");
        }
    }
}
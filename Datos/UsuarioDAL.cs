using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CRUD_Usuarios.Modelo;

namespace CRUD_Usuarios.Datos
{
    public class UsuarioDAL
    {
        public void Crear(Usuario u)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Usuarios (Nombre, Email) VALUES (@Nombre, @Email)", conn);

                cmd.Parameters.AddWithValue("@Nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@Email", u.Email);

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable Listar()
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Usuarios", conn);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Actualizar(Usuario u)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "UPDATE Usuarios SET Nombre=@Nombre, Email=@Email WHERE Id=@Id", conn);

                cmd.Parameters.AddWithValue("@Id", u.Id);
                cmd.Parameters.AddWithValue("@Nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@Email", u.Email);

                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Usuarios WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
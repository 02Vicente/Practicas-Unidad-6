using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_VI_II_Model.Models
{
    public class UsuarioDB
    {
        string cs = ConfigurationManager.ConnectionStrings["ConnectionStrDB"].ConnectionString;

        public List<Usuario> ListAll()
        {
            SqlConnection con = new SqlConnection(cs);
            List<Usuario> lst = new List<Usuario>();

            try
            {
                SqlCommand com = new SqlCommand("SelectUsuarios", con);
                com.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = com.ExecuteReader();


                while (rdr.Read())
                {
                    lst.Add(new Usuario
                    {
                        UsuarioId = Convert.ToInt32(rdr["UsuarioId"]),
                        Nombre = rdr["Nombre"].ToString(),
                        Apellido = rdr["Apellido"].ToString(),
                        Username = rdr["Username"].ToString(),
                        Password = rdr["Password"].ToString(),
                        Correo = rdr["Correo"].ToString(),

                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }


            return lst;

        }

        public Usuario Login(string Username, string Password)
        {
            Usuario lst = new Usuario();
            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand com = new SqlCommand("Login_Usuario", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Username", Username);
                com.Parameters.AddWithValue("@Password", Password);
                con.Open();
                SqlDataReader rdr = com.ExecuteReader();
                
                if (rdr.Read())
                {
                    lst.UsuarioId = Convert.ToInt32(rdr["UsuarioId"]);
                    lst.Nombre    = rdr["Nombre"].ToString();
                    lst.Apellido  = rdr["Apellido"].ToString();
                    lst.Username  = rdr["Username"].ToString();
                    lst.Password  = rdr["Password"].ToString();
                    lst.Correo    = rdr["Correo"].ToString();
                }
                else
                {
                    return null;
                }

                con.Close();

                return lst;
            }
        }

        public Usuario Buscar(int Id)
        {
            Usuario lst = new Usuario();
            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand com = new SqlCommand("Buscar_Usuario", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Id);
                con.Open();
                SqlDataReader rdr = com.ExecuteReader();

                if (rdr.Read())
                {
                    lst.UsuarioId = Convert.ToInt32(rdr["UsuarioId"]);
                    lst.Nombre    = rdr["Nombre"].ToString();
                    lst.Apellido  = rdr["Apellido"].ToString();
                    lst.Username  = rdr["Username"].ToString();
                    lst.Password  = rdr["Password"].ToString();
                    lst.Correo    = rdr["Correo"].ToString();
                }
                else
                {
                    return null;
                }

                con.Close();

                return lst;
            }
        }

        public int Add(Usuario u)
        {
            int r;
            using (SqlConnection con = new SqlConnection(cs))
            {
                
                SqlCommand com = new SqlCommand("InsertupdateUsuario", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Nombre", u.Nombre);
                com.Parameters.AddWithValue("@Apellido", u.Apellido);
                com.Parameters.AddWithValue("@Username", u.Username);
                com.Parameters.AddWithValue("@Password", u.Password);
                com.Parameters.AddWithValue("@Correo", u.Correo);
                com.Parameters.AddWithValue("@Action", 0);
                con.Open();
                r = com.ExecuteNonQuery();
                con.Close();
            }

            return r;
        }

        public int Update(Usuario u)
        {
            int r;
            using (SqlConnection con = new SqlConnection(cs))
            {
                
                SqlCommand com = new SqlCommand("InsertupdateUsuario", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@UsuarioId", u.UsuarioId);
                com.Parameters.AddWithValue("@Nombre", u.Nombre);
                com.Parameters.AddWithValue("@Apellido", u.Apellido);
                com.Parameters.AddWithValue("@Username", u.Username);
                com.Parameters.AddWithValue("@Password", u.Password);
                com.Parameters.AddWithValue("@Correo", u.Correo);
                com.Parameters.AddWithValue("@Action", 1);
                con.Open();
                r = com.ExecuteNonQuery();
                con.Close();
            }

            return r;
        }

        public int Delete(int Id)
        {
            int r;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("DeleteUsuario", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@UsuarioId", Id);
                con.Open();
                r = com.ExecuteNonQuery();
                con.Close();
            }

            return r;
        }
    }
}

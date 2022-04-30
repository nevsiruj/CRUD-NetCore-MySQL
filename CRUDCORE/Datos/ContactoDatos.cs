using CRUDCORE.Models;
using MySql.Data;
using MySqlConnector;

namespace CRUDCORE.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Listar()
        {

            var oLista = new List<ContactoModel>();

            var cn = new Conexion(); // Creamos un objecto de tipo Conexion();
            using (var conexion = new MySqlConnection(cn.getCadena()))
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand("sp_Listar", conexion); // Creamos un objeto tipo comando enlazado por nombre al procedimiento, creando la conexion
                cmd.CommandType = System.Data.CommandType.StoredProcedure; // El tipo de comando es para un Procedimiento Almacenado 

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ContactoModel()
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }

            }
            return oLista;

        }

        public ContactoModel Obtener(int IdContacto)
        {

            var oContacto = new ContactoModel();

            var cn = new Conexion(); // Creamos un objecto de tipo Conexion();

            using (var conexion = new MySqlConnection(cn.getCadena()))
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand("sp_Obtener", conexion); // Creamos un objeto tipo comando enlazado por nombre al procedimiento, creando la conexion
                cmd.Parameters.AddWithValue("_IdContacto", IdContacto);
                cmd.CommandType = System.Data.CommandType.StoredProcedure; // El tipo de comando es para un Procedimiento Almacenado 

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.Correo = dr["Correo"].ToString();
                    }
                }

            }
            return oContacto;

        }


        public bool Guardar(ContactoModel oContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion(); // Creamos un objecto de tipo Conexion();

                using (var conexion = new MySqlConnection(cn.getCadena()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_Guardar", conexion); // Creamos un objeto tipo comando enlazado por nombre al procedimiento, creando la conexion
                    cmd.Parameters.AddWithValue("_Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("_Correo", oContacto.Correo);
                    cmd.Parameters.AddWithValue("_Telefono", oContacto.Telefono);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure; // El tipo de comando es para un Procedimiento Almacenado 
                    cmd.ExecuteNonQuery();

                }
                rpta = true;

            }

            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }


            return rpta;
        }


        public bool Editar(ContactoModel oContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion(); // Creamos un objecto de tipo Conexion();

                using (var conexion = new MySqlConnection(cn.getCadena()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_Editar", conexion); // Creamos un objeto tipo comando enlazado por nombre al procedimiento, creando la conexion
                    cmd.Parameters.AddWithValue("_IdContacto", oContacto.IdContacto);
                    cmd.Parameters.AddWithValue("_Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("_Correo", oContacto.Correo);
                    cmd.Parameters.AddWithValue("_Telefono", oContacto.Telefono);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure; // El tipo de comando es para un Procedimiento Almacenado 
                    cmd.ExecuteNonQuery();

                }
                rpta = true;

            }

            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }


            return rpta;
        }

        public bool Eliminar(int IdContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion(); // Creamos un objecto de tipo Conexion();

                using (var conexion = new MySqlConnection(cn.getCadena()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_Eliminar", conexion); // Creamos un objeto tipo comando enlazado por nombre al procedimiento, creando la conexion
                    cmd.Parameters.AddWithValue("_IdContacto", IdContacto);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure; // El tipo de comando es para un Procedimiento Almacenado 
                    cmd.ExecuteNonQuery();

                }
                rpta = true;

            }

            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }


            return rpta;
        }
    }
}


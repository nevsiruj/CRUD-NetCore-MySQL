using MySql.Data;
using MySql.Data.MySqlClient;

namespace CRUDCORE.Datos

{
    public class Conexion
    {
        private string mySql = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build(); 

            mySql = builder.GetSection("ConnectionStrings:CadenaMySql").Value;


        }

        public string getCadena()
        {
            return mySql;   
        }
    }
}

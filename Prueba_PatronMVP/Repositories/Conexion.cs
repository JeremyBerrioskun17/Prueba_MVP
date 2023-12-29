using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_PatronMVP.Repositories
{
    public abstract class Conexion
    {
        private readonly string Cadena_Conexion;

        public Conexion()
        {
            Cadena_Conexion = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=VeterinaryDb;User ID=LAPTOP-BI755VM9\\HP;Trusted_Connection=True;";
        }

        protected SqlConnection GetSqlConnection()
        {
            return new SqlConnection(Cadena_Conexion);
        }
    }
}

